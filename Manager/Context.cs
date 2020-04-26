﻿//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pumpet.net@gmail.com
//  Git: https://github.com/Pumpet/Robin
//  Copyright (C) Alex Rozanov, 2020 
//

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Common;
using System.Text;

namespace Manager {

    /// <summary>Режимы запуска формы: 
    /// Default = 0 - по умолчанию (ни один из других вариантов); 
    /// GetResult = 1 - форма вернет результат (форма-список для выбора); 
    /// NewRecEdit = 2 - форма-редактор для новой записи; 
    /// Modal = 4 - модальная форма; 
    /// Single = 8 - форма может быть запущена 1 раз (для всех форм из меню, заполненного по настройкам); 
    /// ViewOnlyEdit = 16 - форма-редактор только для просмотра данных; 
    /// </summary>
    [Flags]
    public enum FormModes { Default = 0, GetResult = 1, NewRecEdit = 2, Modal = 4, Single = 8, ViewOnlyEdit = 16 }

    /// <summary>Контекст приложения.
    /// Объект контекста (свойство Self) создается при старте приложения.
    /// При создании инициализирует главную форму, создает и проверяет подключение, начитывает данные настроек для меню, форм и команд.
    /// Содержит методы для вызова форм, методов сборок и выполнения запросов.
    /// </summary>
    public class Context {

        // объекты и коллекции настроек:
        string username; // текущий пользователь
        string appcode; // код приложения (из конфига - по нему определяются настройки из таблиц)
        string userFormOptions; // текущие настройки форм пользователя/хоста
        List<DataRow> menus; // настройки меню (tMenu)
        List<DataRow> cmds;  // настройки команд (tCommand)

        bool trassa = false;
        public Dictionary<string, Form> LivingForms = new Dictionary<string, Form>();
        
        /// <summary>Объект контекста приложения</summary>
        public static Context Self { get; private set; }
        /// <summary>Объект подключения приложения</summary>
        public SqlConnection Conn { get; set; }
        /// <summary>Последняя активная форма приложения</summary>
        public Form LastActiveForm { get; set; } = null;
        /// <summary>Главная форма приложения</summary>
        public Form MainForm { get; private set; }
        /// <summary>Объект для передачи данных, например возврат результата из формы</summary>
        public object TransferObject { get; set; }
        /// <summary>Сборка с иконками в ресурсах</summary>
        public string ImgAsmName { get; private set; }
        /// <summary>Набор общих данных</summary>
        public Dictionary<string, object> CommonObjects { get; private set; } = new Dictionary<string, object>();

        ///<summary>Создать объект контекста и запустить приложение</summary>
        /// <param name="mainForm">Главная форма приложения</param>
        /// <param name="configPath">[Путь]Файл конфигурации. По умолчанию - имя_приложения.xml</param>
        public static void Run(Form mainForm, string configPath = "") {
            try {
                AppConfig.Load(configPath);
                Self = new Context(mainForm);
            }
            catch (Exception e) {
                Loger.SendMess(e, "Ошибка формирования контекста приложения");
                return;
            }

            try {
                Application.Run(Self.MainForm);
            }
            catch (Exception e) {
                Loger.SendMess(e, "Необработанная ошибка приложения! Приложение будет закрыто.");
            }
        }

        Context(Form mainForm) {
            var connStr = AppConfig.Prop("ConnectionString");
            Conn = new SqlConnection(connStr);
            if (!CheckConnection(Conn))
                throw new Exception($"Ошибка подключения!\n{connStr}");
            username = Conn?.GetValue("select suser_name()").ToString();
            appcode = AppConfig.Prop("AppCode") ?? Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName.Replace("vshost.", ""));
            GetKernelData();

            MainForm = mainForm;
            MainForm.KeyPreview = true;
            MainForm.KeyDown += MainForm_KeyDown;
            MainForm.KeyDown += AnyForm_KeyDown;

            ImgAsmName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppConfig.Prop("ImgAsm") ?? AppDomain.CurrentDomain.FriendlyName.Replace("vshost.", ""));

        }

        #region Работа с формами

        /// <summary>Заполнить указанный ToolStrip по настройкам меню</summary>
        public void FillMenu(ToolStrip tools) {
            Action<ToolStripItemCollection, object> fn = null;

            fn = (tsc, p) => {
                foreach (var item in menus.Where(x => x["parent"].Equals(p)).OrderBy(x => x["ord"])) {
                    ToolStripItem tsi;
                    if (item["execType"].Equals(1))
                        tsi = new ToolStripDropDownButton(item["caption"].ToString());
                    else
                        tsi = new ToolStripButton() {
                            Name = item["code"].ToString(),
                            Text = item["caption"].ToString(),
                        };

                    var imgName = item["img"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(imgName))
                        tsi.Image = GetImage(ImgAsmName, imgName);

                    tsi.Width += 20;
                    tsc.Add(tsi);
                    if (tsi is ToolStripDropDownButton)
                        fn(((ToolStripDropDownButton)tsi).DropDownItems, item["code"]); // дочернее меню
                    if (tsi is ToolStripButton)
                        tsi.Click += MenuClick;
                }
            };
            fn(tools.Items, DBNull.Value);
        }

        /// <summary>Получить картинку из ресурсов</summary>
        public Image GetImage(string imgAsmName, string imgName) { 
            Image img = null;
            try {
                var asm = Assembly.LoadFrom(imgAsmName);
                img = (Image)(new ResourceManager(asm.GetName().Name + ".Properties.Resources", asm)).GetObject(imgName);
                if (img == null)
                    Loger.SendMess($"Не найдена картинка \"{imgName}\" в ресурсах {imgAsmName}", true);
            }
            catch (Exception e) {
                Loger.SendMess(e, $"Ошибка получения картинки \"{imgName}\" из ресурсов {imgAsmName}");
            }
            return img;
        }

        // обработка события выбора пункта меню в соответствии с настройками меню
        void MenuClick(object sender, EventArgs e) {
            var menuOpt = menus.FirstOrDefault(x => x["code"].Equals((sender as ToolStripItem).Name));
            if (menuOpt != null) {
                var execType = menuOpt["execType"];
                var command = menuOpt["command"]?.ToString();
                if (execType.Equals(0) && !string.IsNullOrWhiteSpace(command)) {
                    var cmdOpt = cmds.FirstOrDefault(x => x["code"].Equals(command));
                    if (cmdOpt == null) {
                        Loger.SendMess($"Не найдена команда по коду '{command}'", true);
                        return;
                    }
                    if ((int)cmdOpt["cmdType"] == 0)
                        Loger.SendMess("В меню не поддерживается команда с типом 0 (sql)", true);
                    if ((int)cmdOpt["cmdType"] == 1)
                        ExecForm(GetForm(cmdOpt["code"]?.ToString()), MainForm, FormModes.Single);
                    if ((int)cmdOpt["cmdType"] == 2)
                        ExecMethod(cmdOpt["cmd"]?.ToString());
                }
            }
        }
        
        /// <summary>Получить метод из сборки</summary>
        /// <param name="assemblyPath">[путь]файл сборки</param>
        /// <param name="className">namespace.class</param>
        /// <param name="methodName">метод</param>
        /// <returns></returns>
        public MethodInfo GetMethod(string assemblyPath, string className, string methodName) {
            MethodInfo method = null;
            try {
                assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyPath);
                var asm = Assembly.LoadFrom(assemblyPath);
                var type = asm.GetType(className);
                method = type.GetMethod(methodName);
            }
            catch (Exception e) {
                Loger.SendMess(e, $"Ошибка получения метода {className}.{methodName} из {assemblyPath}");
            }
            return method;
        }

        /// <summary>Вызов метода по команде из настроек</summary>
        /// <param name="command">Команда из настроек - строка формата: "[path]assembly;namespace.class;method"</param>
        public void ExecMethod(string command) {
            var s = command.Split(';');
            if (s.Length != 3) {
                Loger.SendMess($"'{command}' не соответствует формату '[path]assembly;namespace.class;method'", true);
                return;
            }
            GetMethod(s[0], s[1], s[2])?.Invoke(null, null);

        }
        
        /// <summary>Создать форму по коду из настроек</summary>
        /// <param name="formCode">Код, для которого в настройках определена команда: [path]assembly;namespace.form</param>
        public Form GetForm(string formCode) {
            var formOpt = cmds.FirstOrDefault(x => x["code"].Equals(formCode) && (int)x["cmdType"] == 1);
            if (formOpt == null) {
                Loger.SendMess($"Не найдена настройка для формы по коду '{formCode}'", true);
                return null;
            }
            var command = formOpt["cmd"].ToString();
            var s = command.Split(';');
            if (s.Length != 2) {
                Loger.SendMess($"Команда запуска формы '{command}' не соответствует формату '[path]assembly;namespace.form'", true);
                return null;
            }
            return GetForm(s[0], s[1]);
        }

        /// <summary>Создать форму из сборки</summary>
        /// <param name="assemblyPath">[путь]файл сборки</param>
        /// <param name="className">namespace.form</param>
        public Form GetForm(string assemblyPath, string className) {
            Form form = null;
            try {
                assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyPath);
                var asm = Assembly.LoadFrom(assemblyPath);
                var type = asm.GetType(className);
                if (!typeof(Form).IsAssignableFrom(type))
                    throw new Exception($"Тип {type.Name} не является формой");
                form = (Form)type.GetConstructor(Type.EmptyTypes).Invoke(null);
                if (!(form is Form))
                    throw new Exception($"Невозможно создать форму типа {type.Name}");
            }
            catch (Exception e) {
                Loger.SendMess(e, $"Ошибка загрузки формы {className} из {assemblyPath}");
            }
            return form;
        }

        /// <summary>Вызов формы</summary>
        /// <param name="form">Форма</param>
        /// <param name="parent">Родительская форма</param>
        /// <param name="formModes">Режимы запуска</param>
        /// <param name="extParams">Параметры для запросов</param>
        /// <param name="key">Ключ записи (например чтобы встать на нужной строке в главном гриде формы списка)</param>
        /// <returns>True только в случае положительного результата (OK) для модальной формы</returns>
        public bool ExecForm(Form form, Form parent = null, FormModes formModes = FormModes.Default, Dictionary<string, object> extParams = null, object key = null) {
            bool res = false;

            if (form == null || form.IsDisposed)
                return res;
            if (form.Visible)
                return res;

            string typeName = (parent != null ? parent.GetType().Name + "." : "") + form.GetType().Name;

            // проверка уже запущенных
            if (formModes.HasFlag(FormModes.Single)) {
                if (LivingForms.ContainsKey(typeName) && LivingForms[typeName] != null && !LivingForms[typeName].IsDisposed) {
                    if (LivingForms[typeName].WindowState == FormWindowState.Minimized)
                        LivingForms[typeName].WindowState = FormWindowState.Normal;
                    LivingForms[typeName].Activate();
                    form.Dispose();
                    return res;
                }
                LivingForms.Add(typeName, form);
            }

            Cursor.Current = Cursors.WaitCursor;
            try {
                form.Load += AnyForm_Load;
                form.FormClosed += AnyForm_Closed;
                form.KeyDown += AnyForm_KeyDown;
                // особенности для бибилиотечных форм
                if (form is IDataForm)
                    ((IDataForm)form).Init(this, formModes, extParams, key);
                // запуск
                if (formModes.HasFlag(FormModes.Modal)) {
                    form.StartPosition = FormStartPosition.CenterParent;
                    res = (form.ShowDialog(parent) == DialogResult.OK);
                    form?.Dispose();
                } else {
                    form.StartPosition = FormStartPosition.Manual;
                    if (MainForm != null) { // позиционирование                   
                        int h = form.RectangleToScreen(form.ClientRectangle).Top - form.Top;
                        int top = MainForm.Bottom, left = 0;
                        for (int i = 0; i < 5; i++) {
                            if (!LivingForms.Any(x => x.Value.Top >= top && x.Value.Top < top + 25))
                                break;
                            top += h; left += h;
                        }
                        form.Top = top; form.Left = left;
                    }
                    if (parent == null)
                        form.Show();
                    else
                        form.Show(parent);
                }
            }
            catch (Exception e) {
                form?.Dispose();
                if (LivingForms.ContainsKey(typeName))
                    LivingForms.Remove(typeName);
                Loger.SendMess(e);
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
            return res;
        }

        /// <summary>Загрузить параметры отображения формы</summary>
        public void LoadFormOptions(Form form, FormOptionsSetType setType = FormOptionsSetType.All) {
            if (AppConfig.Has("UserOptionsInDB"))
                FormOptions.LoadFromXML(form, userFormOptions, setType);
            if (AppConfig.Has("UserOptionsInFile"))
                FormOptions.LoadFromFile(form, null, setType);
        }

        /// <summary>Сохранить параметры отображения формы</summary>
        public void SaveFormOptions(Form form) {
            if (AppConfig.Has("UserOptionsInDB")) {
                userFormOptions = FormOptions.GetInXML(form, userFormOptions);
                Conn?.ExecCommand(@"
                    if exists(select 1 from dm.tFormOptions where code = @user and appcode = @appcode)
                        update dm.tFormOptions set options = @opt where code = @user and appcode = @appcode
                    else
                        insert dm.tFormOptions(code, appcode, options) values (@user, @appcode, @opt)",
                    new Dictionary<string, object>() { { "user", username }, { "appcode", appcode }, { "opt", userFormOptions } });
            }
            if (AppConfig.Has("UserOptionsInFile"))
                FormOptions.SaveToFile(form);
        }

        /// <summary>Показать главную форму приложения</summary>
        /// <param name="form">Текущая форма</param>
        public void ShowMain(Form form) //  
        {
            if (MainForm != null) {
                foreach (var f in MainForm.OwnedForms.Where(x => x.WindowState == FormWindowState.Maximized || x.Top < MainForm.Bottom)) {
                    f.WindowState = FormWindowState.Normal;
                    if (f.Top < MainForm.Bottom) f.Top = MainForm.Bottom;
                }
                if (MainForm.WindowState != FormWindowState.Maximized)
                    MainForm.WindowState = FormWindowState.Maximized;
                LastActiveForm = form;
                form.Activate();
                MainForm.Activate();
                MainForm.GetControls<ToolStrip>().ForEach(x => { if (x.Items.Count > 0) x.Items[0].Select(); });
            }
        }

        /// <summary>Разместить форму с учетом главной формы приложения</summary>
        /// <param name="form">Форма</param>
        /// <param name="max">Развернуть на весь экран под главной формой</param>
        public void FormDefaultPos(Form form, bool max) //  
        {
            if (MainForm != null && MainForm.WindowState == FormWindowState.Maximized) {
                if (form.WindowState == FormWindowState.Maximized)
                    form.WindowState = FormWindowState.Normal;
                form.Left = 0;
                form.Top = MainForm.Bottom;
                if (max) {
                    form.Width = MainForm.Right;
                    form.Height = Screen.GetWorkingArea(MainForm).Height - MainForm.Bottom;
                }
            }
        }

        /// <summary>Выбор из списка активных форм</summary>
        public void SelectForm(Form sender) {
            var forms = MainForm.OwnedForms.OrderBy(x => x.Text).ToArray();
            int idx = Array.FindIndex(forms, x => x == sender);
            var f = new FOpenedForms(forms, idx);
            if (f.ShowDialog(MainForm) == DialogResult.OK && f.listForms.SelectedIndex >= 0 )
                forms[f.listForms.SelectedIndex].Activate();
            f.Dispose();
        }

        // обработка клавиатуры на главной форме
        void MainForm_KeyDown(object sender, KeyEventArgs e) {
            // esc - возврат к последней активной форме
            if (e.KeyCode == Keys.Escape) {
                if (LastActiveForm == null || LastActiveForm.IsDisposed)
                    MainForm.OwnedForms.Where(x => x.TopLevel).LastOrDefault()?.Activate();
                else
                    LastActiveForm.Activate();
            }
        }

        // обработка события загрузки обслуживаемой формы
        void AnyForm_Load(object sender, EventArgs e) {
            if (!(sender is IDataForm)) // для библиотечных форм - в FormBase
                LoadFormOptions((Form)sender); 
        }

        // обработка закрытия обслуживаемой формы
        void AnyForm_Closed(object sender, FormClosedEventArgs e) {
            Form f = (Form)sender;
            if (!(f is IDataForm)) // для библиотечных форм - в FormBase
                SaveFormOptions(f);
            string t = (f.Owner != null ? f.Owner.GetType().Name + "." : "") + f.GetType().Name;
            if (LivingForms.ContainsKey(t))
                LivingForms.Remove(t);
            if (LivingForms.Count == 0)
                MainForm.Focus();
        }

        // обработка клавиатуры обслуживаемой формы
        void AnyForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F9 && (Form)sender != MainForm) {
                e.Handled = true;
                ManageForm((Form)sender, e.Modifiers);
            }
            if (e.KeyCode == Keys.L && e.Modifiers == (Keys.Control | Keys.Alt)) {
                e.Handled = true;
                GetKernelData();
                Loger.SendMess("Системные настройки перезагружены!");
            }
            SetTrassa(e);
        }

        void SetTrassa(KeyEventArgs e) {
            if (e.KeyCode == Keys.Q && e.Modifiers == (Keys.Control | Keys.Alt)) {
                e.Handled = true;
                trassa = !trassa;
                Loger.SendMess($"Режим трассировки {(trassa ? "включен" : "выключен ")}!");
            }
        }

        /// <summary>Обработка событий по управлению формой (в зависимости от сочетания клавиш - вызов главной формы, выбор формы, позиционирование, возврат настроек</summary>
        /// <param name="form">Форма</param>
        /// <param name="keys">Сочетание служебных клавиш</param>
        public void ManageForm(Form form, Keys keys) {
            if (form.Modal) return;
            if (keys == Keys.None)
                ShowMain(form);
            if (keys == Keys.Control || keys == Keys.Shift)
                FormDefaultPos(form, keys == Keys.Control);
            if (keys == (Keys.Control | Keys.Shift) || keys == (Keys.Alt | Keys.Shift))
                LoadFormOptions(form, keys == (Keys.Control | Keys.Shift) ? FormOptionsSetType.Size : FormOptionsSetType.All);
            if (keys == Keys.Alt)
                SelectForm(form);
        }

        #endregion

        #region Работа с БД

        /// <summary>Проверка подключения</summary>
        public bool CheckConnection(SqlConnection conn) {
            var f = new FWait("Подключаемся...");
            f.Show();
            f.Refresh();
            try {
                if (conn == null)
                    throw new Exception("Не задано подключение!");
                conn.Open();
                conn.Close();
                f.Close();
                return true;
            }
            catch (Exception e) {
                f.Close();
                Loger.SendMess(e, "Ошибка подключения");
                return false;
            }
        }

        // заполнить объекты и коллекции настроек
        void GetKernelData() {
            DataSet ds = null;
            try {
                using (SqlDataAdapter da = new SqlDataAdapter("dm.pKernel", Conn)) {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("appcode", appcode);
                    ds = new DataSet();
                    da.Fill(ds);
                    menus = ds.Tables[0].AsEnumerable().ToList();
                    cmds = ds.Tables[1].AsEnumerable().ToList();
                    userFormOptions = Conn?.GetValue("select options from dm.tFormOptions where code = @user and appcode = @appcode",
                                    new Dictionary<string, object>() { { "user", username }, { "appcode", appcode } }, Trassa)?.ToString();
                }
            }
            catch (Exception e) {
                throw new Exception($"Ошибка получения настроек\n{e.Message}", e);
            }
        }

        /// <summary>Выполнить запрос, вернуть таблицу</summary>
        /// <param name="sql">Текст запроса</param>
        /// <param name="cmdCode">Код команды из настроек, содержащий текст запроса (используется, если не задан текст запроса)</param>
        /// <param name="pars">Параметры запроса</param>
        /// <returns>Таблица (пустая если нет resultset) или null, если ошибка</returns>
        public DataTable GetTable(string sql, string cmdCode, Dictionary<string, object> pars = null) {
            if (string.IsNullOrWhiteSpace(sql))
                sql = GetCommandText(cmdCode);
            return !string.IsNullOrWhiteSpace(sql) ? Conn?.GetTable(sql, pars, Trassa) : null;
        }

        /// <summary>Выполнить запрос, вернуть список строк</summary>
        /// <param name="sql">Текст запроса</param>
        /// <param name="cmdCode">Код команды из настроек, содержащий текст запроса (используется, если не задан текст запроса)</param>
        /// <param name="pars">Параметры запроса</param>
        /// <returns>Список DataRow (пустой если нет resultset) или null, если ошибка</returns>
        public List<DataRow> GetTableList(string sql, string cmdCode, Dictionary<string, object> pars = null) {
            if (string.IsNullOrWhiteSpace(sql))
                sql = GetCommandText(cmdCode);
            return !string.IsNullOrWhiteSpace(sql) ? Conn?.GetTableList(sql, pars, Trassa) : null;
        }


        /// <summary>Выполнить запрос, вернуть кол-во обработанных строк</summary>
        /// <param name="sql">Текст запроса</param>
        /// <param name="cmdCode">Код команды из настроек, содержащий текст запроса (используется, если не задан текст запроса)</param>
        /// <param name="pars">Параметры запроса</param>
        /// <returns>Количество обработанных строк, -1 если ошибка</returns>
        public int ExecCommand(string sql, string cmdCode, Dictionary<string, object> pars = null) {
            if (string.IsNullOrWhiteSpace(sql))
                sql = GetCommandText(cmdCode);
            return !string.IsNullOrWhiteSpace(sql) ? Conn?.ExecCommand(sql, pars, Trassa) ?? -1 : -1;
        }

        /// <summary>Вернуть текст команды по коду из настроек</summary>
        public string GetCommandText(string cmdCode) {
            if (string.IsNullOrWhiteSpace(cmdCode)) {
                Loger.SendMess($"Не указан код команды", true);
                return null;
            }
            var queryOpt = cmds.FirstOrDefault(x => x["code"].Equals(cmdCode) && (int)x["cmdType"] == 0);
            if (queryOpt == null) {
                Loger.SendMess($"Не найдена команда по коду '{cmdCode}'", true);
                return null;
            }
            return queryOpt["cmd"].ToString();
        }
        
        /// <summary>Вывод трассировки выполняемого запроса</summary>
        /// <param name="sql">текст запроса</param>
        /// <param name="pars">параметры</param>
        /// <param name="header">заголовок окна трассировки</param>
        public void Trassa(string sql, List<SqlParameter> pars, string header = null) {
            if (!trassa) return;
            var msg = new StringBuilder();
            if (pars != null && pars.Count > 0) {
                foreach (var p in pars)
                    msg.AppendLine(p.GetSqlDeclare("declare @"));
                msg.AppendLine();
            }
            msg.AppendLine(sql);
            //MessageBox.Show(msg.ToString());
            var f = new FTrassa();
            f.KeyDown += (o, e) => SetTrassa(e);
            f.Text = header ?? Conn.ConnectionString;
            f.trassa.Text = msg.ToString();
            f.ShowDialog();
        }

        #endregion

        /// <summary>Принудительная прочистка мозгов</summary>
        public void GcCollect() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}