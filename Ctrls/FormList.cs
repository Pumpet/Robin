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

using System.Collections.Generic;
using Manager;
using Common;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Ctrls {

    /* Форма - базовая для форм со списками данных - наследник FormBase

    Особенности:
    обязательно должна содержать только один "главный грид" - это DataList, у которого не заполнено ParentGrid
    гридов типа DataList, у которых указан ParentGrid, может быть сколько угодно
    запрос для главного грида выполняется сразу после запуска формы если установлено LoadDataWithForm = true, 
        или ждем команду с кнопки/клавиатуры (F5) - это вариант, когда нужно предварительно установить какие-то параметры, чтобы не грузить большой объем данных
    если форма ожидает обновления данных - после запуска или после изменения полей-параметров - свойство NeedRefresh = true
    определяет ряд событий, позволяющих вмешаться в логику определения и обработки полей-параметров и параметров запросов
    
    Методы:
    IDataForm.Init - принимает параметры при запуске (может быть вызван явно или через ExecForm контекста):
        ссылка на контекст, режим запуска, параметры запроса, ключ текущей записи
        определяет главный грид
    IDataForm.PrepareUiParamsProperties - подготовка значений полей-параметров запроса для сохранения (сериализации)
        вызывает событие PrepareUiParamsForSave
    IDataForm.SetUiParamsProperties - установка загруженных значений полей-параметров запроса
        вызывает событие SetLoadedUiParams

    Перегружает:
    OnLoad - до базового - вызывает события CreateUiParamsList, SetUiParamsDefaultValues
            после базового - событие SetUiParamsValuesAfterLoad и инициирует загрузку в главный грид
    
    События:
    ControlTrigger - общее событие, подписанное наопределенные события контролов формы: изменение состояния (Cheked, Selected, ...), входа (Enter), выхода (Leave)
                    подписку можно переопределить через SubscribeControlTrigger
    CreateUiParamsList - возможность коррекции списка полей-параметров после его создания
    SetUiParamsDefaultValues - момент до загрузки сохраненных зачений полей-параметров или момент после очистки полей-параметров конкретного грида (по Ctrl+F5)
        используем для установки параметров по умолчанию
    SetUiParamsValuesAfterLoad - момент после загрузки сохраненных значений полей-параметров используем для принудительной установки параметров после старта формы
    PrepareUiParamsForSave - возможность коррекции сформированного списка значений полей-параметров запроса перед сохранением
    SetLoadedUiParams - возможность доп.обработки полученного списка значений полей-параметров запроса

    Подписывается на: 
    DataList -> delegate QueryParamsSet - установка параметров
    DataList -> event GetData - если у грида задан QuerySql или QueryID - выполняет запрос
    DataList -> event SendInfo - выдает инфу на StatusBar

    Горячие клавиши:
    F5 или Enter - для полей-параметров - обновляет грид, к которому относится параметр
    Ctrl+F5 - сброс полей-параметров, относящихся к определенному гриду
    Alt+F5  - переход к первому полю-параметру, относящемуся к определенному гриду

    */

    public partial class FormList : FormBase {

        /// <summary>Аргументы событий для полей параметров</summary>
        public class UiParamsEventArgs {
            /// <summary>Список полей параметров для гридов</summary>
            public Dictionary<DataList, List<Control>> UiParams { get; set; }
        }
        /// <summary>Аргументы событий загрузки/сохранения значений полей параметров</summary>
        public class UiParamsPropsEventArgs {
            /// <summary>Список объектов ControlValue со строковыми значениями полей параметров</summary>
            public List<ControlValue> Props { get; set; }
        }

        /// <summary>Аргументы событий выбора из списка</summary>
        public class SelectFromListEventArgs {
            /// <summary>Возвращаемый объект</summary>
            public object SelectedObject { get; set; }
            public bool Handled { get; set;}
        }

        /// <summary>Аргументы событий обновления списка</summary>
        public class RefreshListEventArgs {
            public bool Handled { get; set; }
            public DataList Grid { get; set; }
            public object Key { get; set; }
        }


        protected bool needRefresh = false;
        protected List<DataList> grids = new List<DataList>();
        public DataList MainGrid; // главный грид - один, у которого не заполнено ParentGrid
        protected bool gridFirstTime = true; // грид загружается впервые после запуска формы
        protected Dictionary<DataList,List<Control>> uiParams = new Dictionary<DataList, List<Control>>(); // список полей параметров для каждого грида, может быть изменен в CreateUiParamList

        /// <summary>Активный контрол (без учета контейнеров)</summary>
        protected Control ActiveCtrl {
            get {
                var ac = ActiveControl;
                while (ac is SplitContainer)
                    ac = ((SplitContainer)ac).ActiveControl;
                return ac;
            }
        }

        /// <summary>Активный грид (с учетом полей параметров). По умолчанию - главный</summary>
        protected DataList ActiveGrid {
            get {
                var g = grids?.FirstOrDefault(x => x.Focused);
                if (g == null)
                    g = uiParams.Where(x => x.Value.Any(y => y == ActiveCtrl)).Select(x => x.Key).FirstOrDefault();
                return g ?? MainGrid;
            }
        }

        /// <summary>Грид нуждается в обновлении (признак и смена цвета кнопки)</summary>
        [Browsable(false)]
        public bool NeedRefresh {
            get {
                return needRefresh;
            }
            set {
                bRefresh.Image = value ? Properties.Resources.refresh_red : Properties.Resources.refresh;
                needRefresh = value;
            }
        }

        [Browsable(true), Category("Robin options"), DefaultValue(true), Description("Получить данные в процессе загрузки формы. Если нет - ждем нажатия кнопки (F5)")]
        public bool LoadDataWithForm { get; set; }

        [Browsable(true), Category("Robin options"), Description("Имя грида для выбора из него (по умолчанию - MainGrid)")]
        public string SelectionGridName { get; set; }

        [Category("Robin options"), Description("Определение списка полей параметров")]
        public event EventHandler<UiParamsEventArgs> CreateUiParamsList;

        [Category("Robin options"), Description("Установка значений по умолчанию для полей параметров. Если качестве объекта - грид, значит идет обработка именно его параметров")]
        public event EventHandler<UiParamsEventArgs> SetUiParamsDefaultValues;

        [Category("Robin options"), Description("Установка значений полей параметров после загрузки формы")]
        public event EventHandler<UiParamsEventArgs> SetUiParamsValuesAfterLoad;

        [Category("Robin options"), Description("Подготовка полей параметров для сохранения")]
        public event EventHandler<UiParamsPropsEventArgs> PrepareUiParamsForSave;

        [Category("Robin options"), Description("Установка загруженных значений полей параметров")]
        public event EventHandler<UiParamsPropsEventArgs> SetLoadedUiParams;

        [Category("Robin options"), Description("Click на кнопке выбора")]
        public event EventHandler<SelectFromListEventArgs> SelectFromList;

        [Category("Robin options"), Description("Click на кнопке обновления")]
        public event EventHandler<RefreshListEventArgs> RefreshList;

        public FormList() {
            InitializeComponent();
        }

        /// <summary>Инициализация формы</summary>
        /// <param name="ctx">Контекст приложения</param>
        /// <param name="formModes">Режимы запуска</param>
        /// <param name="extParams">Параметры для запросов</param>
        /// <param name="key">Ключ записи (например чтобы встать на нужной строке в главном гриде формы списка)</param>
        public override void Init(Context ctx, FormModes formModes = FormModes.Default, Dictionary<string, object> extParams = null, object key = null) {
            base.Init(ctx, formModes, extParams, key);
            grids = this.GetControls<DataList>();
            MainGrid = grids.FirstOrDefault(x => x.ParentGrid == null);
            if (MainGrid == null)
                throw new Exception("На форме не определен основной компонент типа DataList");
        }

        protected override void OnLoad(EventArgs e) {
            InitFormList();

            base.OnLoad(e); // там загрузка сохраненных свойств формы и значений полей параметров

            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;

            // установка полей параметров из внешнего фильтра
            SetUiParamsFromDictionary(extParams);

            // событие для кастомной установки полей параметров после всех предустановок
            SetUiParamsValuesAfterLoad?.Invoke(this, new UiParamsEventArgs() { UiParams = uiParams });

            // обработчики для полей параметров
            SetUiParamsHandlers();

            if (LoadDataWithForm) {
                LoadGrid(MainGrid, key); //LoadGrid(MainGrid);
                key = null;
                gridFirstTime = false;
            } else {
                SetFocusOnUIParam(MainGrid);
                NeedRefresh = true;
            }
        }

        protected override void DataList_GetData(object sender, ProcessDataEventArgs e) {
            base.DataList_GetData(sender, e);
            NeedRefresh = false;
        }

        // инициализация формы списка
        void InitFormList() {
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            // управление формой только для не-модальных
            bWin.Enabled = bWin.Visible = !Modal;

            // форма вернет результат
            bSelect.Enabled = bSelect.Visible = (formModes.HasFlag(FormModes.GetResult));

            // определение полей параметров 
            foreach (var g in grids) {
                var p = new List<Control>();
                if (g.ParamPanel != null && g.ParamPanel.Visible)
                    p.AddRange(g.ParamPanel.GetControls<Control>().Where(x => ValidParamControlType(x.GetType())));
                uiParams.Add(g, p);
            }
            // событие для определения полей параметров
            CreateUiParamsList?.Invoke(this, new UiParamsEventArgs() { UiParams = uiParams});
            // событие для установки значений по умолчанию для полей параметров (до загрузки сохраненных)
            SetUiParamsDefaultValues?.Invoke(this, new UiParamsEventArgs() { UiParams = uiParams });

            // обработчики для гридов
            foreach (var g in grids) {
                g.QueryParamsSet += GridQueryParamsSet;
                g.GetData += DataList_GetData;
                g.SendInfo += DataList_SendInfo;
                g.DoubleClick += (o, ek) => g.DoubleClickCell((gr) => OnSelectFromList());
            } 
        }

        /// <summary>Загрузка данных в грид</summary>
        public void LoadGrid(DataList grid = null, object key = null) {
            var g = grid ?? ActiveGrid;
            if (g == null || g.FindForm() != this)
                return;

            var handled = false;
            if (RefreshList != null) {
                var ea = new RefreshListEventArgs() { Handled = false, Grid = g, Key = key };
                RefreshList.Invoke(this, ea);
                handled = ea.Handled;
            }

            if (!handled) {
                if (!gridFirstTime && ModifierKeys == Keys.Shift)
                    g.ClearFilter();

                if (g == MainGrid) {
                    MainGrid.LoadData(key, extParams);
                    if (gridFirstTime)
                        Ctx?.LoadFormOptions(this, FormOptionsSetType.Grid);
                } else {
                    g.LoadData(key);
                }
            }

            g.Select();
            g.Focus();
            NeedRefresh = false;
        }

        /// <summary>Выбор строки</summary>
        public void OnSelectFromList(EventArgs e = null) {
            if (!(formModes.HasFlag(FormModes.GetResult)
                && (ActiveGrid.Name.Equals(SelectionGridName) || string.IsNullOrWhiteSpace(SelectionGridName))
                && ActiveGrid.Focused
                ))
                return;

            var ea = new SelectFromListEventArgs() { SelectedObject = CtrlsProc.PrepareParams(ActiveGrid.GetRowObject()), Handled = false };
            SelectFromList?.Invoke(this, ea);

            if (!ea.Handled) {
                Ctx.TransferObject = ea.SelectedObject;
                if (Ctx.TransferObject == null)
                    Loger.SendMess("Не получен выбранный объект!", true);
                DialogResult = Ctx.TransferObject != null && Modal ? DialogResult.OK : DialogResult.Cancel;
            }

            var keyEvt = (e as KeyEventArgs);
            if (keyEvt != null)
                keyEvt.Handled = true;

            Close();
        }

        /// <summary>делегат для грида на установку параметров - вызывается в grid.LoadData() -> OnGetData()</summary>
        protected Dictionary<string, object> GridQueryParamsSet(DataList list, Dictionary<string, object> extParams) {
            var res = CtrlsProc.PrepareParams(uiParams.Where(x => x.Key == list).SelectMany(x => x.Value), extParams, rewrite: true);
            return res;
        }

        // обработка статистики из грида
        void DataList_SendInfo(object sender, SendInfoEventArgs e) {
            if (e.handled) return;
            if (e.info != null) lbInfo.Text = e.info;
            if (e.rows != null) lbRows.Text = $"Строк {e.rows} выделено {e.selected}{(!string.IsNullOrWhiteSpace(e.checks) ? $" отмечено {e.checks}" : "")}";
        }

        #region handlers

        private void bSelect_Click(object sender, EventArgs e) {
            OnSelectFromList();
        }

        void bRefresh_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        void bFind_Click(object sender, EventArgs e) {
            var g = ActiveGrid;
            g?.Search();
            g?.Focus();
        }

        void bFilter_Click(object sender, EventArgs e) {
            var g = ActiveGrid;
            g?.Filter();
            g?.Focus();
        }

        void bSelectCols_Click(object sender, EventArgs e) {
            var g = ActiveGrid;
            g?.SelectColumns();
            g?.Focus();
        }

        void bToExcel_Click(object sender, EventArgs e) {
            var g = ActiveGrid;
            g?.ExecExcel();
        }

        void bWin_Click(object sender, EventArgs e) {
            var g = ActiveGrid;
            g?.SetDoubleBuffered(true);
            Ctx?.ManageForm(this, ModifierKeys);
        }

        void FormList_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.Enter) {
                var isParam = uiParams.SelectMany(x => x.Value).Any(x => x == ActiveCtrl);
                if (e.KeyCode == Keys.F5 && (ModifierKeys == Keys.None || ModifierKeys == Keys.Shift)) {
                    LoadGrid();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.F5 && ModifierKeys == Keys.Control) { 
                    ClearUiParams(ActiveGrid);
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.F5 && ModifierKeys == Keys.Alt && !isParam) { 
                    SetFocusOnUIParam(ActiveGrid);
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Enter && (ModifierKeys == Keys.None || ModifierKeys == Keys.Shift) && isParam) {
                    LoadGrid();
                    e.Handled = true;
                }
            }

            if (!e.Handled && e.KeyCode == Keys.Enter && ModifierKeys == Keys.None)
                OnSelectFromList(e);
        }

        #endregion

        #region ui-parameters

        /// <summary>Подготовка значений полей параметров для сохранения</summary>
        public override List<ControlValue> PrepareUiParamsProperties(List<ControlValue> props) {
            foreach (var par in uiParams.SelectMany(x => x.Value)) {
                var prop = new ControlValue() { TypeName = par.GetType().Name, Name = par.Name };
                object value = par.GetControlValue();
                prop.Value = (value is DateTime ? ((DateTime)value).ToString("dd.MM.yyyy HH:mm:ss") : value?.ToString());
                props.Add(prop);
            }
            PrepareUiParamsForSave?.Invoke(this, new UiParamsPropsEventArgs() { Props = props });
            return props;
        }

        /// <summary>Установка загруженных значений полей параметров</summary>
        public override void SetUiParamsProperties(List<ControlValue> props) {
            SetLoadedUiParams?.Invoke(this, new UiParamsPropsEventArgs() { Props = props });
            foreach (var prop in props) {
                var par = uiParams.SelectMany(x => x.Value).FirstOrDefault(x => x.Name == prop.Name && x.GetType().Name == prop.TypeName);
                if (par != null)
                    CtrlsProc.SetControlValue(par, prop.Value);
            }
        }

        /// <summary>Установка значений полей параметров из словаря</summary>
        public void SetUiParamsFromDictionary(Dictionary<string, object> props) {
            if (props == null)
                return;
            foreach (var prop in props) {
                var par = uiParams.SelectMany(x => x.Value).FirstOrDefault(x => x.Name.TrimStart('_') == prop.Key);
                if (par != null)
                    CtrlsProc.SetControlValue(par, prop.Value?.ToString());
            }
        }



        // обработчики полей параметров
        void SetUiParamsHandlers() {
            // установка признака необходимости обновления
            EventHandler eh = (o, e) => { NeedRefresh = true; };
            foreach (var c in uiParams.SelectMany(x => x.Value)) {
                if (c is CheckBox)
                    ((CheckBox)c).CheckStateChanged += eh;
                else if (c is RadioButton)
                    ((RadioButton)c).CheckedChanged += eh;
                else if (c is TreeView)
                    ((TreeView)c).AfterSelect += (o,e) => { eh.Invoke(o, e); };
                else
                    c.TextChanged += eh;
            }
        }

        // сбросить значения полей параметров
        void ClearUiParams (DataList g) {
            foreach (var c in uiParams.Where(x => x.Key == g).SelectMany(x => x.Value))
                CtrlsProc.SetControlValue(c, null, true);
            SetUiParamsDefaultValues?.Invoke(g, new UiParamsEventArgs() { UiParams = uiParams });
        }
        
        void SetFocusOnUIParam(DataList g) {
            Control c = uiParams.Where(x => x.Key == g).SelectMany(x => x.Value).OfType<TextBox>().OrderBy(x => x.Parent?.Left).ThenBy(x => x.Left).FirstOrDefault();
            if (c == null) {
                c = uiParams.Where(x => x.Key == g).SelectMany(x => x.Value).OfType<Control>().OrderBy(x => x.Parent?.Left).ThenBy(x => x.Left).FirstOrDefault();
                c?.Select();
            } else
                ((TextBox)c).Select(0, 0);
            c?.Focus();
        }


        #endregion


    }
}
