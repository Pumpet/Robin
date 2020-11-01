//
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

using Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Ctrls {

    /* Форма - базовая для форм редактирования данных - наследник FormBase
    Особенности:
    Стандартный способ запуска - через FormBase.ExecFormEdit.
    При вызове получает параметры для запроса (как правило это DataRow под текущей строкой грида, который указываем при вызове через ExecFormEdit).
    При инициализации:
        - в случае новой записи: скрывает контролы для детальных данных (по умолчанию только гриды DataList), вызывается событие NewRecInit
        - в случае режима просмотра: контролы будут недоступны для редактирования, отсутствует кнопка сохранения, вызывается событие ViewOnlyInit
    Загрузка данных поисходит при загрузке формы, в методе LoadData - порядок действий:
        1. Подготовка параметров запроса на основе ExtParamsMap
        2. Вызов события QueryParamsCheck для уточнения параметров
        3. Вызов события GetData - если обработчик не задан и не возвращает ProcessDataEventArgs.Нandled = true - вызывается стандартный обработчик (FormEdit_GetData) для выполнения SelectNewSql/SelectSql или SelectNewCmdCode/SelectCmdCode
        4. Полученный в ProcessDataEventArgs.Result объект (источник) заносится в Source.DataSource (это может быть DataTable с одной записью или произвольный объект)
        5. Для каждого поля источника ищем одноименный допустимый для маппинга контрол на форме и добавляем в коллекцию DataMap элемент DataMapItem, описывающий соответствие поля контрола и поля источника
        6. Вызов события DataMapCreate для уточнения содержания DataMap
        7. Установка биндингов на контролы в соответствии с DataMap
        8. Вызов AfterBinding для необходимых коррекций или доп.установки биндингов
        9. Заполнение гридов из DataLists (в качестве параметра запроса передается источник данных)
    Возможна реализация логики взаимодействия элементов формы через событие ControlTrigger - общее событие для определенных событий контролов формы: 
        - по умолчанию обрабатывются изменение состояния (Cheked, Selected, ...), входа (Enter), выхода (Leave)
        - подписку можно переопределить через SubscribeControlTrigger
    Проверка и сохранение данных - при нажатии на кнопку "Сохранить" (Ctrl+Enter) или Ctrl+S - вызывается метод SaveData - порядок действий:
        1. Уточнение параметров для команды сохранения данных - через обработку событие SaveParamsCheck. Здесь же можно сделать проверку данных и заполнить словарь ошибок в ParamsCheckEventArgs.CheckResult
            (Параметры для команды сохранения - это поля источника данных формы)
        2. Проверка данных через специально для этого нарисованный CheckSql или команду CheckCmdCode, возвращающие таблицу с полями "код" и "значение" для заполнения словаря ошибок
        3. При наличии ошибок - выдача сообщений в полях, соответствующих ключам словаря ошибок или, если таких полей нет - в выдача окна сообщений об ошибке. Возврат к работе с формой.
        4. Вызов события SetData - если обработчик не задан и не возвращает ProcessDataEventArgs.Нandled = true - вызывается стандартный обработчик (FormEdit_SetData) для выполнения InsertSql/UpdateSql или InsertCmdCode/UpdateCmdCode
        5. Полученный в ProcessDataEventArgs.Result объект заносится в Context.TransferObject. Предполагается, что это должен быть словарь с ключевыми полями обработанной записи.
            - если объект задан и вызов формы осуществлялся через ExecFormEdit с указанием грида - будет попытка найти обработанную запись по ключу и установить на ней фокус.
            - если объект не задан - будет сообщение об ошибке и возврат к работе с формой
        6. При отсутствии ошибок форма будет закрыта с DialogResult.OK (кроме варианта вызова сохранения по Ctrl+S)
    Отмена изменений 
        - при нажатии на кнопку "Отменить" (Alt+F4) форма будет закрыта с DialogResult.Cancel
        - возможен вариант контроля случайного закрытия формы, для чего необходимо установить CheckChanges = true
    */

    /// <summary>Форма для редактора записи и размещения связанных списков</summary>
    public partial class FormEdit : FormBase {

        /// <summary>Данные для биндинга - задает соответствие поля контрола и поля источника</summary>
        protected class DataMapItem {
            public string field;
            public Control control;
            public string propName;
            public DataMapItem(string sourceFieldName, Control control, string controlPropertyName = null) {
                field = sourceFieldName;
                this.control = control;

                if (string.IsNullOrEmpty(controlPropertyName)) {
                    if (control is NumericUpDown || control is DateTimePicker)
                        controlPropertyName = "Value";
                    else if (control is CheckBox || control is RadioButton)
                        controlPropertyName = "Checked";
                    else
                        controlPropertyName = "Text";
                }
                propName = controlPropertyName;
            }
        }

        ErrorProvider error;
        bool changed;
        string tmpText;

        // устанвливается в true после сохранения - для обновления списков при выходе
        [Browsable(false)]
        public bool WasSaved { get; set; } = false;

        // устанавливается в false после сохранения 
        // может быть установлен в true при необходимости - см.пример формы редактированя команды в Master
        // перед закрытием формы проверяется на true
        [Browsable(false)]
        public bool Changed {
            get { return changed; }
            set {
                changed = value;
                if (string.IsNullOrEmpty(tmpText))
                    tmpText = Text;
                if (value) {
                    Text = tmpText + "*";
                } else 
                    Text = tmpText;
            }
        } 
        
        protected List<DataList> DataLists { get; set; } = new List<DataList>();
        protected BindingSource Source { get; private set; } = new BindingSource();

        public object SourceObject {
            get {
                var o = Source.Current;
                if (o is DataRowView) o = ((DataRowView)o).Row;
                return o;
            }
        }

        public DataRow SourceRow {
            get {
                return (Source.Current as DataRowView)?.Row;
            }
        }
        protected List<DataMapItem> DataMap { get; private set; } = new List<DataMapItem>();

        protected bool IsNewRec { get; private set; } = false;

        protected bool IsViewOnly { get; private set; } = false;

        #region Events & Properties
        [Category("Robin options"), Description("Уточнение параметров запроса")]
        public event EventHandler<ParamsCheckEventArgs> QueryParamsCheck;
        [Category("Robin options"), Description("Запрос данных из источника")]
        public event EventHandler<ProcessDataEventArgs> GetData;
        [Category("Robin options"), Description("Уточнение параметров биндинга (в DataMap)")]
        public event EventHandler<EventArgs> DataMapCreate;
        [Category("Robin options"), Description("После биндинга")]
        public event EventHandler<EventArgs> AfterBinding;
        [Category("Robin options"), Description("Инициализация для новой записи")]
        public event EventHandler<EventArgs> NewRecInit;
        [Category("Robin options"), Description("Инициализация для режима просмотра")]
        public event EventHandler<EventArgs> ViewOnlyInit;
        [Category("Robin options"), Description("Уточнение параметров команды сохранения")]
        public event EventHandler<ParamsCheckEventArgs> SaveParamsCheck;
        [Category("Robin options"), Description("Сохранение данных")]
        public event EventHandler<ProcessDataEventArgs> SetData;

        [Category("Robin options"), DefaultValue(""),
            Description("соответствие имени параметра запроса и имени параметра снаружи:\nимя_параметра_запроса=имя_внешнего_параметра;...\nесли пусто - используются все внешние параметры")]
        public string ExtParamsMap { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql запроса существующей записи")]
        public string SelectSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды запроса существующей записи")]
        public string SelectCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql запроса новой записи")]
        public string SelectNewSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды запроса новой записи")]
        public string SelectNewCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql добавления новой записи")]
        public string InsertSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды добавления новой записи")]
        public string InsertCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql обновления записи")]
        public string UpdateSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды обновления записи")]
        public string UpdateCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql для проверки")]
        public string CheckSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды для проверки")]
        public string CheckCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(false), Description("проверять при закрытии на наличие изменений")]
        public bool CheckChanges { get; set; }

        [Category("Robin options"), DefaultValue(false), Description("оставить открытым после сохранения в режиме изменения")]
        public bool KeepOpenAfterSave { get; set; }

        #endregion

        public FormEdit() {
            InitializeComponent();
        }

        /// <summary>Инициализация формы</summary>
        /// <param name="ctx">Контекст приложения</param>
        /// <param name="formModes">Режимы запуска</param>
        /// <param name="extParams">Параметры для запроса</param>
        /// <param name="key">Ключ записи (не используется)</param>
        public override void Init(Context ctx, FormModes formModes = FormModes.Default, Dictionary<string, object> extParams = null, object key = null) {
            base.Init(ctx, formModes, extParams, key);
            error = new ErrorProvider();
            error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            IsNewRec = formModes.HasFlag(FormModes.NewRecEdit);
            IsViewOnly = formModes.HasFlag(FormModes.ViewOnlyEdit);
            KeepOpenAfterSave = KeepOpenAfterSave && !IsNewRec && !IsViewOnly;
        }

        protected override void OnLoad(EventArgs e) {
            InitFormEdit();
            base.OnLoad(e);
            LoadData();
        }

        void FormEdit_KeyDown(object sender, KeyEventArgs e) {
            if (!IsViewOnly && e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                PerformSave(false);
            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)
                PerformSave(true);
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
                bUndo.PerformClick();
        }

        void bSaveClose_Click(object sender, EventArgs e) {
            PerformSave(!KeepOpenAfterSave);
        }

        void PerformSave(bool close) {
            var res = SaveData();
            if (res && close) {
                if (Modal)
                    DialogResult = DialogResult.OK;
                else
                    Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (e.Cancel)
                return;
            if (!IsViewOnly && Changed) {
                var quest = MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if ((quest == DialogResult.Yes && !SaveData()) || quest == DialogResult.Cancel) {
                    e.Cancel = true;
                    return;
                }
            }
            if (Modal && DialogResult != DialogResult.OK)
                DialogResult = WasSaved ? DialogResult.OK : DialogResult.Cancel;
        }

        void bUndo_Click(object sender, EventArgs e) {
            Close();
        }

        #region Инициализация редактора, получение данных и биндинг

        // Инициализация формы редактора
        void InitFormEdit() {

            bSaveClose.Text = KeepOpenAfterSave ? "Сохранить (Ctrl+S)" : "Сохранить и закрыть (Ctrl+Enter)";
            bSaveClose.ToolTipText = bSaveClose.Text;

            if (IsNewRec) {
                Text += " - Добавить";
            }

            if (IsNewRec) {
                foreach (var g in this.GetControls<DataList>())
                    g.Enabled = g.Visible = false;
                NewRecInit?.Invoke(this, new EventArgs());
            }

            if (IsViewOnly) {
                bSaveClose.Enabled = bSaveClose.Visible = false;
                this.ForControls(x => {
                    if (x is TextBoxBase)
                        ((TextBoxBase)x).ReadOnly = true;
                    else if (!(x is ScrollableControl) && !(x is DataList) && !(x is Label))
                        x.Enabled = false;
                });
                ViewOnlyInit?.Invoke(this, new EventArgs());
            }

            GetData += FormEdit_GetData;
            if (!IsViewOnly)
                SetData += FormEdit_SetData;

            if (!IsNewRec) {
                DataLists = this.GetControls<DataList>();
                foreach (var g in DataLists)
                    g.GetData += DataList_GetData;
            }
        }

        /// <summary>Процесс загрузки данных в редактор</summary>
        protected void LoadData() {
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;

            try {
                var queryParams = CtrlsProc.PrepareParams(extParams, null, ExtParamsMap);

                // уточнение параметров
                var eaParams = new ParamsCheckEventArgs { Pars = queryParams };
                QueryParamsCheck?.Invoke(this, eaParams);

                // запрос данных (если в потомке есть обработчик события - он вызовется первым и необходимо установить handled=true, чтобы не продолжать через FormEdit_GetData)
                var eaGetData = new ProcessDataEventArgs() { Pars = eaParams.Pars };
                GetData?.Invoke(this, eaGetData);

                // проверка допустимости набора данных
                if (eaGetData.Result == null)
                    throw new Exception("Нет данных");
                if (eaGetData.Result is DataTable) {
                    var dt = (DataTable)eaGetData.Result;
                    if (dt.Rows.Count == 0)
                        throw new Exception("Нет данных");
                    if (dt.Rows.Count > 1)
                        throw new Exception("Получено несколько записей");
                }

                Source.DataSource = eaGetData.Result;

                // подготовка списка для биндинга
                var fields = new List<string>();
                if (Source.DataSource is DataTable)
                    fields = (Source.DataSource as DataTable)?.Columns.OfType<DataColumn>().Select(x => x.ColumnName).ToList();
                else
                    fields = TypeDescriptor.GetProperties(Source.DataSource).OfType<PropertyDescriptor>().Select(x => x.Name).ToList();
                foreach (var f in fields) {
                    var c = this.GetControl(f);
                    if (c != null && ValidParamControlType(c.GetType())) {
                        DataMap.Add(new DataMapItem(f, c));
                    }
                }
                DataMapCreate?.Invoke(this, new EventArgs());

                // настройки комбо для выбора из формы
                foreach (var sb in this.GetControls<SelectBox>()) {
                    if (sb.SourceObject == null)
                        sb.SourceObject = SourceRow;
                    if (sb.TargetObject == null)
                        sb.TargetObject = SourceObject;
                }
                // биндинг
                SetBindings();
                AfterBinding?.Invoke(this, new EventArgs());
                //Source.ResetBindings(false);

                // детальные данные
                if (!IsNewRec) {
                    var pars = CtrlsProc.PrepareParams(SourceObject);
                    foreach (var g in DataLists)
                        g.LoadData(null, pars);
                }
            }
            catch (Exception ex) {
                Loger.SendMess(ex, "Ошибка получения данных на форму:");
                Close();
            }
            finally {
                Changed = false;
            }
        }

        // Обработчик получения данных по умолчанию
        void FormEdit_GetData(object sender, ProcessDataEventArgs e) {
            if (e.Handled) return;
            string sql = IsNewRec ? SelectNewSql : SelectSql;
            string cmdCode = IsNewRec ? SelectNewCmdCode : SelectCmdCode;
            if (string.IsNullOrWhiteSpace(sql) && string.IsNullOrWhiteSpace(cmdCode))
                return;
            e.Result = Ctx?.GetTable(sql, cmdCode, e.Pars);
        }

        // Стандартная установка биндингов
        void SetBindings() {
            foreach (var map in DataMap) {
                map.control.DataBindings.Add(map.propName, Source, map.field, true, DataSourceUpdateMode.OnPropertyChanged);
                if (!IsViewOnly && CheckChanges) {
                    //if (map.control is TextBox || map.control is FastColoredTextBoxNS.FastColoredTextBox)
                    map.control.TextChanged += (o, ea) => Changed = true;
                    if (map.control is CheckBox) ((CheckBox)map.control).CheckedChanged += (o, ea) => Changed = true;
                    if (map.control is RadioButton) ((RadioButton)map.control).CheckedChanged += (o, ea) => Changed = true;
                    if (map.control is ComboBox) ((ComboBox)map.control).SelectedIndexChanged += (o, ea) => Changed = true;
                    if (map.control is SelectBox) ((SelectBox)map.control).AfterSetResult += (o, ea) => Changed = true;
                }
            }
        }

        #endregion

        #region Проверка и сохранение данных

        /// <summary>Процесс сохранения данных из редактора</summary>
        protected bool SaveData() {
            error.Clear();

            // принудительно заносим из контролов в объект-источник
            foreach (var b in Source.CurrencyManager.Bindings)
                (b as Binding).WriteValue();

            var eaSaveParams = new ParamsCheckEventArgs { Pars = CtrlsProc.PrepareParams(SourceObject) };

            SaveParamsCheck?.Invoke(this, eaSaveParams);
            var errs = eaSaveParams.CheckResult;
            CheckData(eaSaveParams.Pars, errs);

            if (errs?.Count > 0) {
                var msg = new StringBuilder();
                foreach (var err in errs) {
                    var c = this.GetControl(err.Key, true, Source) ?? this.GetControl(err.Key);
                    if (c != null)
                        error.SetError(c, err.Value);
                    else
                        msg.AppendLine(err.Value);
                }
                if (msg.Length > 0)
                    Loger.SendMess($"Ошибки ввода данных!\n{msg}", true);
                return false;
            }

            var eaSetData = new ProcessDataEventArgs() { Pars = eaSaveParams.Pars };
            SetData?.Invoke(this, eaSetData);

            object res = null;
            var dt = (eaSetData.Result as DataTable);
            if (dt != null)
                res = dt.Rows.Count > 0 ? CtrlsProc.PrepareParams(dt.Rows[0]) : null;
            else if (eaSetData.Result != null)
                res = CtrlsProc.PrepareParams(eaSetData.Result);

            Ctx.TransferObject = res;
            if (res == null)
                Loger.SendMess("Не получен результат операции!", true);

            var ok = (res != null);
            if (ok) {
                Changed = false;
                WasSaved = true;
                Ctx.SaveLog("SAVE_FORM", $"Form {Name} ({Text}) was saved");
            }
            return ok;
        }

        // Проверка данных через специально для этого нарисованный sql или команду
        void CheckData(Dictionary<string,object> pars, Dictionary<string, string> errs) {
            if (string.IsNullOrWhiteSpace(CheckSql) && string.IsNullOrWhiteSpace(CheckCmdCode))
                return;
            var res = Ctx?.GetTable(CheckSql, CheckCmdCode, pars);
            var e = new Dictionary<string, string>();
            var cc = res.Columns.Count;
            for (int i = 0; i < res.Rows.Count; i++) {
                var key = cc > 1 ? res.Rows[i][0] : $"err{i}";
                var value = cc > 1 ? res.Rows[i][1] : res.Rows[i][0];
                e[key.ToString()] = value.ToString();
            }
            errs.AddFromDictionary(e);
        }

        // Обработчик сохранения данных по умолчанию
        void FormEdit_SetData(object sender, ProcessDataEventArgs e) {
            if (e.Handled) return;
            string sql = IsNewRec ? InsertSql : UpdateSql;
            string cmdCode = IsNewRec ? InsertCmdCode : UpdateCmdCode;
            if (string.IsNullOrWhiteSpace(sql) && string.IsNullOrWhiteSpace(cmdCode)) {
                e.Result = false;
                Loger.SendMess("Не задана команда для сохранения данных!", true);
                return;
            }
            e.Result = Ctx?.GetTable(sql, cmdCode, e.Pars);
        }

        #endregion


    }
}
