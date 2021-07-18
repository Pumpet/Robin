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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Ctrls {

    /* Грид-наследник стандартного DataGridView

    Особенности:
    установка фокуса на строке по ключу
    сохранение фокуса после обновления, фильтрации и сортировки
    возможность обработать момент получения данных (событие GetData) и инициировать загрузку данных (метод LoadData), с возможностью передачи параметров запроса и текущего ключа
    выделение строк посредством выделения произвольных ячеек
    настройка цвета выделенных строк и текущей строки
    привязка к родительскому гриду с указанием соответствия полей родительского грида и параметров запроса для дочернего грида
    обновление дочерного грида при перемещении по родительскому 
        (в целях оптимизации обновление не происходит для каждой строки в процессе перемещения по строкам с нажатой клавишей клавиатуры или мыши)
    поиск и фильтрация по текущим данным
    выдача в эксель
    установка видимости столбцов

    Свойства:
    ShowCheckBoxes - отображать или нет столбец с check-box-ами с возможностью отметить пробелом текущую или Ctrl+пробел все выделенные
    Disable... - отключение соответствующих возможностей: фильтр, поиск, сортировка, управление столбцами, выдача в эксель, подсветка строк
    KeyNames - имена ключевых полей через ";" - необходимо для установки фокуса на строку с полями в соответствии с ключом, переданным в LoadData
        а также после обновления, фильтрации и сортировки - на текущую строку
    QuerySql - sql-запрос, который можно затем использовать например в обработчике события GetData
    QueryCmdCode  - идентификатор (код и т.п.), по которому можно отработать логику получения данных - например достать запрос из настроек
    SelectedRow...Color - расцветка отмеченной строки
    SelectedRowBackColor - цвет выделенных строк
    SelectedCellFocusedBackColor - цвет текущей строки (с фокусом)
    SelectedCellNotFocusedBackColor - цвет текущей строки (без фокуса)
    ParentGrid - родительский грид
    ParamPanel - панель с полями параметров
    ExtParamsMap - соответствие имени параметра запроса и имени параметра снаружи (например имени поля строки родительского грида): "имя_параметра_запроса=имя_внешнего_параметра;..."
        если пусто - используются все внешние параметры
    AutoColumns - управляет установками скрытого поля DataGridView - AutoGenerateColumns
    QueryParamsSet - делегат, устанавливающий параметры запроса, устанавливается в FormList для формирования параметров из полей-параметров формы
        вызывается в LoadData -> OnGetData, перед QueryParamsCheck и GetData
        возвращает словарь параметров (имя-значение), который предзаполнен внешними параметрами
            - внешние параметры приходят в LoadData снаружи или из родительского грида (как поля текущей строки родительского грида, отфильтрованные и переименованные посредством ExtParamsMap)
        далее параметры могут быть проверены/скорректированы в обработчике события QueryParamsCheck

    События:
    QueryParamsCheck - момент после установки параметров (QueryParamsSet) и до выполнения запроса (GetData)
    GetData - момент запроса данных из источника - в обработчике делаем запрос, которому передаем словарь параметров e.Pars
        результат запроса должен быть присвоен e.Result
        для запрета стандартной обработки в FormList необходимо установить e.Handled = true
    SendInfo - изменения статусных данных грида - получает: кол-во строк, кол-во выделенных и отмеченных строк, прочая информация
        может быть использовано для выдачи данных например в StatusBar
        для запрета стандартной обработки в FormList необходимо установить e.Handled = true
    WhatsUp - изменения в гриде - получает: ключи отмеченных строк, ключ текущей строки, объект текущей строки и имя источника события (имя метода)
        может быть например для какой-то логики в зависимости данных от текущей строки (например доступность действий)

    Важные методы:
    LoadData	        - Загрузка данных в список
                            Заполняет параметры из внешних параметров (если переданы)
                            Вызывает OnGetData для установки параметров и получения нового набора данных
                            Форматирует полученные данные
                            Восстанавливает сортировку, фильтры, позицию
                            Загружает данные в дочерние списки
                            Вызывает OnWhatsUp
    Clear	            - Сбрасывает источники данных - Обнуляет/уничтожает BindingSource, обнуляет DataSource
    OnGetData	        - Установка параметров и получение нового набора данных -	Запуск событий QueryParamsSet, QueryParamsCheck, GetData
    OnWhatsUp	        - Запуск событий WhatsUp и SendInfo
    GetKey	            - Получить ключ из указанной или текущей строки - Вернет словарь строка-объект как object
    GetRowObject	    - Получить объект из указанной или текущий строки - Вернет object = DataRow или DataBoundItem, если это не DataRow
    GetCheckedRowsIdx	- Получить список индексов отмеченных строк
    GetCheckedRowsKeys	- Получить список ключей отмеченных строк
    SetCheckedRows	    - Отметить строки, соответствующие ключам
    SelectColumns	    - Вызов формы выбора столбцов
    ExecExcel	        - Выдача содержимого грида в эксель
    Search	            - Вызов формы поиска
    Filter	            - Вызов формы фильтра
    ClearFilter	        - Сбросить все фильтры
    
    Горячие клавиши:
    F5 - загрузка данных (c Shift - сброс фильтров)
    Ctrl+F - поиск и далее комбинации с F3 для перемещения по результатам поиска
    Shift+F - фильтр
    F11 - выбор столбцов
    F12 - выдача в Excel
    Alt+S - сортировка столбца
    Ctrl+K - получить имя/значение ключевых полей в буфер
    */

    public class SendInfoEventArgs : EventArgs {
        public string rows = null, selected = null, info = null, checks = null;
        public bool handled = false;
    }

    public class WhatsUpEventArgs : EventArgs {
        public object Key { get; set; }
        public object RowObj { get; set; }
        public List<object> CheckedKeys { get; set; } = new List<object>();
        public string Method { get; set; }
    }

    public partial class DataList : DataGridView {

        //todo1 = режим редактирования

        enum EditModes { None, Edit, AddNew, AddCopy }; //todo1
        EditModes editMode = EditModes.None; // в режиме редактирования //todo1 идея чтобы проверять и не давать выйти из редактируемой строки (только по Esc или Ctrl+S)
        object editRowKey; // ключ редактируемой строки до редактирования (для возврата) //todo1 может лучше старые данные сохранять для возврата, чтобы не перечитывать весь резалтсет
        bool enableLoadChilds = true; // возможность обновлять связанные гриды
        bool disableRedrawHighlight = true; // запретить перерисовку подсветки строк при загрузке данных
        bool autoColumns; // для установки AutoGenerateColumns
        int lastRow = -1; // текущая строка
        int firstRowPressed = -1; // строка, на которой нажали кнопку мыши или клавишу - устанавливается одновременно с enableLoadChilds == false в начале выделения мышкой или перемещение
        object prevKey = null; // ключ, чтобы на него вернуться
        List<int> prevRowSelected = new List<int>();
        Search search; // текущий поиск
        List<Filter> filters = new List<Filter>(); // установленные фильтры
        List<Filter> filters_copy = new List<Filter>(); // копия фильтров перед обновлением

        readonly string checkColumnName = "#check"; // имя контрольного столбца с checkBox
        List<object> prevCheckedKeys = null; // ключи отмеченных строк, чтобы проставить после сортировки
        int checkedRowsCount = 0;

        BindingSource bs = new BindingSource();
        protected Dictionary<string, object> extParams = new Dictionary<string, object>();

        /// <summary>подготовка параметров запроса</summary>
        public Func<DataList, Dictionary<string, object>, Dictionary<string, object>> QueryParamsSet { get; set; }

        [Category("Robin options"), Description("проверка параметров запроса")]
        public event EventHandler<ParamsCheckEventArgs> QueryParamsCheck;
        [Category("Robin options"), Description("запрос данных из источника")]
        public event EventHandler<ProcessDataEventArgs> GetData;
        [Category("Robin options"), Description("активизация грида (получение фокуса)")]
        public event EventHandler<EventArgs> ActivateList;
        [Category("Robin options"), Description("передача текущей информации - кол-во строк и прочее")]
        public event EventHandler<SendInfoEventArgs> SendInfo;
        [Category("Robin options"), Description("изменилось содержимое, позиция, порядок и т.д.")]
        public event EventHandler<WhatsUpEventArgs> WhatsUp;

        // возможности
        [Category("Robin options"), DefaultValue(false), Description("возможность редактировать записи")]
        public bool Editable { get; set; }

        [Category("Robin options"), DefaultValue(false), Description("возможность отмечать строки (показывать столбец с checkbox)")]
        public bool ShowCheckBoxes { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить возможность фильтрации")]
        public bool DisableFilter { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить возможность поиска")]
        public bool DisableSearch { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить возможность выгрузки в эксель")]
        public bool DisableExcel { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить возможность управления столбцами")]
        public bool DisableColsOperate { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить возможность фильтрации")]
        public bool DisableSort { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить подсветку выделенных строк")]
        public bool DisableHighlightSelected { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("отменить выделение отмеченных строк")]
        public bool DisableHighlightChecked { get; set; }

        // параметры
        [Category("Robin options"), DefaultValue(""), Description("имена ключевых полей через ;")]
        public string KeyNames { get; set; }
        [Category("Robin options"), DefaultValue(""),
            Description("соответствие имени параметра запроса и имени параметра снаружи:\nимя_параметра_запроса=имя_внешнего_параметра;...\nесли пусто - используются все внешние параметры")]
        public string ExtParamsMap { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("текст запроса"),
            Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string QuerySql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды для запроса")]
        public string QueryCmdCode { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("текст sql добавления новой записи"),
            Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string InsertSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды добавления новой записи")]
        public string InsertCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql обновления записи"),
            Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string UpdateSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды обновления записи")]
        public string UpdateCmdCode { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("текст sql для проверки"),
            Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string CheckSql { get; set; }
        [Category("Robin options"), DefaultValue(""), Description("код команды для проверки")]
        public string CheckCmdCode { get; set; }

        // поведение
        [Category("Robin options"), Description("цвет выделенных строк")]
        public Color SelectedRowBackColor { get; set; } = SystemColors.GradientInactiveCaption;
        [Category("Robin options"), Description("цвет шрифта отмеченных строк")]
        public Color CheckedRowFontColor { get; set; } = SystemColors.Info;
        [Category("Robin options"), Description("цвет отмеченных строк")]
        public Color CheckedRowBackColor { get; set; } = SystemColors.ActiveCaption;
        [Category("Robin options"), Description("цвет текущей строки (с фокусом)")]
        public Color SelectedCellFocusedBackColor { get; set; } = SystemColors.Info;
        [Category("Robin options"), Description("цвет текущей строки (без фокуса)")]
        public Color SelectedCellNotFocusedBackColor { get; set; } = SystemColors.InactiveCaption;
        [Category("Robin options"), Description("родительский грид")]
        public DataList ParentGrid { get; set; }
        [Category("Robin options"), Description("панель с параметрами")]
        public Panel ParamPanel { get; set; }
        [Category("Robin options"), DefaultValue(false), Description("устанавливает AutoGenerateColumns")]
        public bool AutoColumns { get { AutoGenerateColumns = autoColumns; return autoColumns; } set { autoColumns = value; AutoGenerateColumns = autoColumns; } }

        public DataList() {
            InitializeComponent();
            KeyNames = "";
            BackgroundColor = SystemColors.Control;
            BorderStyle = BorderStyle.Fixed3D;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EnableHeadersVisualStyles = false;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersWidth = 23;
            RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption;
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = true;
            ReadOnly = true;
            TabIndex = 0;
            this.SetDoubleBuffered(true);
        }

        //____________ Overrides _________________________________________________________________________________________________________________________________________________________

        #region Overrides

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            if (Columns.Count > 0) {
                DataGridViewColumn cc = null;
                foreach (DataGridViewColumn c in Columns) {
                    if (c.Visible && (cc == null || c.DisplayIndex > cc.DisplayIndex))
                        cc = c;
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                }
                if (cc != null) {
                    int w = cc.Width;
                    if (cc.Displayed)
                        cc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    else
                        cc.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    if (w > cc.Width) {
                        cc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                        cc.Width = w;
                    }
                }
            }
        }

        protected override void OnSelectionChanged(EventArgs e) {
            base.OnSelectionChanged(e);
            RowsHighlight();
        }

        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
            ActivateList?.Invoke(this, e);
            disableRedrawHighlight = false;
            RowsHighlight();
        }

        protected override void OnLostFocus(EventArgs e) {
            base.OnLostFocus(e);
            RowsHighlight();
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            var h = HitTest(e.X, e.Y);
            base.OnMouseDown(e);

            if (h.Type == DataGridViewHitTestType.ColumnHeader)
                this.SetDoubleBuffered(false);

            if (h.Type == DataGridViewHitTestType.Cell) {
                CheckRow(h.RowIndex, h.ColumnIndex);
                if (e.Button == MouseButtons.Right && !SelectedCells.OfType<DataGridViewCell>().Select(x => x.RowIndex).Distinct().Any(r => r == h.RowIndex)) {
                    if (this[h.ColumnIndex, h.RowIndex].Visible)
                        CurrentCell = this[h.ColumnIndex, h.RowIndex];
                    else if (FirstDisplayedCell != null && FirstDisplayedCell.Visible)
                        CurrentCell = FirstDisplayedCell;
                    RowsHighlight(h.RowIndex);
                }
            }

            if (e.Button == MouseButtons.Right) {
                Focus();
            }

            // для запрета обновления при выделении 
            if (enableLoadChilds && h.Type == DataGridViewHitTestType.Cell) {
                firstRowPressed = h.RowIndex;
                enableLoadChilds = false;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            var h = HitTest(e.X, e.Y);
            if (h.Type == DataGridViewHitTestType.ColumnHeader)
                this.SetDoubleBuffered(true);
            ForceLoadChilds();
            base.OnMouseUp(e);
            OnWhatsUp("OnMouseUp");
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e) {
            this.SetDoubleBuffered(true);
            prevKey = GetKey();
            prevCheckedKeys = GetCheckedRowsKeys();
            base.OnColumnHeaderMouseClick(e);
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyCode == Keys.F2 && ModifierKeys == Keys.None)
                Edit();
            if (e.KeyCode == Keys.Insert && ModifierKeys == Keys.None)
                AddNew();
            if (e.KeyCode == Keys.Insert && ModifierKeys == Keys.Control)
                AddCopy();

            // это - в ProcessCmdKey, т.к. тут не обрабатывается при нажатии в процессе редактирования ячейки
            //if (e.KeyCode == Keys.Enter && ModifierKeys == Keys.Control)
            //    Save();
            //if (e.KeyCode == Keys.Escape && ModifierKeys == Keys.None)
            //    UndoSave();

            if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
                Search();
            if (e.KeyCode == Keys.F && e.Modifiers == Keys.Shift)
                Filter();
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Alt && !DisableSort)
                Sort(CurrentCell.OwningColumn, CurrentCell.OwningColumn == SortedColumn && SortOrder == SortOrder.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);

            if (e.KeyCode == Keys.F3 && ModifierKeys == Keys.None)
                DoSearch(null, SearchMode.Left);
            else if (e.KeyCode == Keys.F3 && ModifierKeys == Keys.Shift)
                DoSearch(null, SearchMode.Right);
            else if (e.KeyCode == Keys.F3 && ModifierKeys == Keys.Control)
                DoSearch(null, SearchMode.Down);
            else if (e.KeyCode == Keys.F3 && ModifierKeys == (Keys.Control | Keys.Shift))
                DoSearch(null, SearchMode.Up);

            if (e.KeyCode == Keys.F5 && (ModifierKeys == Keys.None || ModifierKeys == Keys.Shift)) {
                if (ModifierKeys == Keys.Shift)
                    ClearFilter();
                LoadData();
            }

            if (e.KeyCode == Keys.F11 && e.Modifiers == Keys.None)
                SelectColumns();
            if (e.KeyCode == Keys.F12 && e.Modifiers == Keys.None)
                ExecExcel();

            if (e.KeyCode == Keys.K && e.Modifiers == (Keys.Control | Keys.Alt))
                Clipboard.SetDataObject(KeyToString(GetKey()));

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
                    FormatColumns(""); // чтобы нормально скопировать числа в буфер

            if (e.KeyCode == Keys.Space && (ModifierKeys == Keys.None || ModifierKeys == Keys.Control) && CurrentCell != null)
                CheckRow(CurrentCell.RowIndex, null, ModifierKeys == Keys.Control);

            base.OnKeyDown(e);

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
                FormatColumns();

            // для запрета обновления при выделении или перемещении с нажатой клавишей
            if (enableLoadChilds) {
                firstRowPressed = (CurrentCell == null ? -1 : CurrentCell.RowIndex);
                enableLoadChilds = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {

            // для обработки нажатия в процессе редактирования ячейки //todo1
            if (keyData == (Keys.S | Keys.Control))
                Save();
            if (keyData == (Keys.Escape))
                UndoSave();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyUp(KeyEventArgs e) {
            ForceLoadChilds();
            base.OnKeyUp(e);
            OnWhatsUp("OnKeyUp");
        }

        protected override void OnSorted(EventArgs e) {
            base.OnSorted(e);
            
            if (prevKey != null) {
                SetRowFocus(prevKey);
                prevKey = null;
            }
            if (prevCheckedKeys != null) {
                SetCheckedRows(prevCheckedKeys);
                prevCheckedKeys = null;
            }
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e) {
            base.OnCellFormatting(e);
            if (e.CellStyle.FormatProvider is ICustomFormatter) {
                e.Value = (e.CellStyle.FormatProvider.GetFormat(typeof(ICustomFormatter)) as ICustomFormatter).Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
                e.FormattingApplied = true;
            }
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e) {
            base.OnRowEnter(e);
            // обновить дочерние гриды            
            if (enableLoadChilds 
                && ((CurrentCell != null && CurrentCell.RowIndex != e.RowIndex)
                    || (CurrentCell != null && firstRowPressed >= 0 && CurrentCell.RowIndex != firstRowPressed)
                    || (CurrentCell == null && e.RowIndex != firstRowPressed)))
                LoadChildren(e.RowIndex);
        }

        protected override void OnCreateControl() {
            base.OnCreateControl();
            if (!DesignMode && ShowCheckBoxes) {
                AddCheckColumn();
            }
            if (!DesignMode && DisableSort)
                foreach (DataGridViewColumn c in Columns) {
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e) {
            if (!DisableHighlightChecked && ShowCheckBoxes && Columns.Contains(checkColumnName)) {
                var val = Rows[e.RowIndex].Cells[checkColumnName]?.Value;
                if (val != null && (bool)(val)) {
                    if (CheckedRowFontColor != DefaultCellStyle.ForeColor)
                        Rows[e.RowIndex].DefaultCellStyle.ForeColor = CheckedRowFontColor;
                    if (CheckedRowBackColor != DefaultCellStyle.BackColor)
                        Rows[e.RowIndex].DefaultCellStyle.BackColor = CheckedRowBackColor;
                }
                if (val != null && !(bool)val) {
                    Rows[e.RowIndex].DefaultCellStyle.ForeColor = DefaultCellStyle.ForeColor;
                    Rows[e.RowIndex].DefaultCellStyle.BackColor = DefaultCellStyle.BackColor;
                    Rows[e.RowIndex].Cells[checkColumnName].Value = null; // чтобы повторно не перерисовывался после подсветкм выделенных строк
                }
                
            }
        }

        #endregion

        //____________ Custom _________________________________________________________________________________________________________________________________________________________

        #region Custom

        /// <summary>Добавить столбик с галками</summary>
        public void AddCheckColumn(int pos = 0, string name = null) {
            var col = new DataGridViewCheckBoxColumn(false);
            col.ReadOnly = true;
            col.Width = 20;
            col.Resizable = DataGridViewTriState.False;
            col.Name = name ?? checkColumnName;
            col.HeaderText = "";
            col.ToolTipText = name ?? "Пробел - отметить/снять отметку для текущей строки\r\nCtrl+Пробел - отметить/снять отметку для выделенных строк";
            Columns.Insert(pos, col);
        }

        /// <summary>Подсветить строку (по умолчанию - текущую) и другие с выделенными ячейками </summary>
        public virtual void RowsHighlight(int row = -1) {
            if (DisableHighlightSelected)
                return;

            if (row == -1 && CurrentRow != null)
                row = CurrentRow.Index;
            if (disableRedrawHighlight || row < 0 || row >= RowCount) 
                return;

            if (lastRow >= 0 && lastRow < RowCount) {
                if (Rows[lastRow].DefaultCellStyle.BackColor != CheckedRowBackColor || CheckedRowBackColor == DefaultCellStyle.BackColor) // здесь и далее - проверка, что строка подсвечена как отмеченная
                    Rows[lastRow].DefaultCellStyle.BackColor = SystemColors.Window;
                lastRow = -1;
            }

            ClearSelectedRowsHighlight();

            foreach (int r in SelectedCells.OfType<DataGridViewCell>().Select(x => x.RowIndex).Distinct()) {
                if (Rows[r].DefaultCellStyle.BackColor != CheckedRowBackColor || CheckedRowBackColor == DefaultCellStyle.BackColor)
                    Rows[r].DefaultCellStyle.BackColor = SelectedRowBackColor;
                prevRowSelected.Add(r);
            }

            if (SelectedCells.OfType<DataGridViewCell>().Any(x => x.RowIndex == row)) {
                if (Rows[row].DefaultCellStyle.BackColor != CheckedRowBackColor || CheckedRowBackColor == DefaultCellStyle.BackColor)
                    Rows[row].DefaultCellStyle.BackColor = Focused ? SelectedCellFocusedBackColor : SelectedCellNotFocusedBackColor;
                lastRow = row;
            }
        }

        // снять выделение со строк
        void ClearSelectedRowsHighlight(bool all = false) {
            foreach (int r in prevRowSelected) {
                if (r >= 0 && r < RowCount 
                    && (all || !SelectedCells.OfType<DataGridViewCell>().Any(x => x.RowIndex == r))
                    && (Rows[r].DefaultCellStyle.BackColor != CheckedRowBackColor || CheckedRowBackColor == DefaultCellStyle.BackColor)) {
                    Rows[r].DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }
            prevRowSelected.Clear();
        }

        /// <summary>Вызов формы выбора столбцов</summary>
        public void SelectColumns() {
            if (DisableColsOperate)
                return;

            if (Columns.Count == 0)
                return;

            Action<List<string>> doSelectCols = (colNames) => {
                for (int i = 0; i < Columns.Count; i++)
                    Columns[i].Visible = colNames.Contains(Columns[i].Name);
                if (Columns.Count > 0 && !Columns.OfType<DataGridViewColumn>().Any(x => x.Visible))
                    Columns[0].Visible = true;
            };
            FormSelectCols fs = new FormSelectCols(doSelectCols, Columns.OfType<DataGridViewColumn>().Where(x => x.Name != checkColumnName).ToList());
            fs.Top = PointToScreen(Point.Empty).Y + ColumnHeadersHeight * 2;
            fs.Left = PointToScreen(Point.Empty).X + RowHeadersWidth * 2;
            fs.ShowDialog(this.FindForm());
            OnResize(null);
        }

        /// <summary>Выдача в эксель</summary>
        public void ExecExcel() {
            if (!DisableExcel)
                this.ToExcel();
        }

        /// <summary>Загрузка данных в грид и установка фокуса на указанной/текущей строке</summary>
        public void LoadData(object key = null, Dictionary<string, object> pars = null) {
            if (!ShowCheckBoxes && Columns.Contains(checkColumnName))
                Columns.Remove(checkColumnName);

            firstRowPressed = -1;

            this.SetDoubleBuffered(true);
            disableRedrawHighlight = true;
            RowsHighlight();
            prevKey = null;
            key = key ?? GetKey();

            if (pars != null)
                extParams = CtrlsProc.PrepareParams(pars, null, ExtParamsMap);

            DataGridViewColumn sortedColumn = SortedColumn;
            ListSortDirection sortDirection = SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            filters_copy.Clear();
            filters_copy.AddRange(filters);
            ClearFilter();

            ClearSelectedRowsHighlight();
            SetCheckedRows(GetCheckedRowsKeys(), false);

            if (ParentGrid == null) // для сброса дочерних перед обновлением главного, чтобы в них не "висели" прошлые записи 
                ClearChildren(); 

            var saveFlagLoadChilds = enableLoadChilds; // отключить обновление дочерних в OnRowEnter, куда попадает при установке BindingSource в OnGetData и SetRowFocus
            enableLoadChilds = false; 
            OnGetData();
            
            FormatColumns();

            foreach (var item in filters_copy)
                SetFilter(item);

            if (!DisableSort && sortedColumn != null && Columns.Contains(sortedColumn.Name))
                Sort(Columns[sortedColumn.Name], sortDirection);

            if (Rows.Count > 0) {
                OnResize(null);
                SetRowFocus(key);
                // обновление дочерних
                if (CurrentRow != null && CurrentRow.Index >= 0)
                        LoadChildren(CurrentRow.Index);
                // чтобы фокус не слетал
                if (ParentGrid == null || Focused)
                    Select();
            } else // данных нет => и в дочерних их быть не должно (OnRowEnter не отрабатывает => вызываем загрузку в дочерний грид без параметров)
                ClearChildren(); 
            
            enableLoadChilds = saveFlagLoadChilds; // вернуть флаг обновления дочерних для OnRowEnter
            OnWhatsUp("LoadData");
        }

        void LoadChildren(int rowIdx) {
            var dataRow = (Rows[rowIdx]?.DataBoundItem as DataRowView)?.Row;
            if (dataRow == null) 
                return;
            var pars = CtrlsProc.PrepareParams(dataRow);
            foreach (var g in FindForm()?.GetControls<DataList>().Where(x => x.ParentGrid == this))
                g.LoadData(null, pars);
        }

        void ClearChildren() {
            foreach (var g in FindForm()?.GetControls<DataList>().Where(x => x.ParentGrid == this)) {
                g.ClearChildren();
                g.Clear();
            }
        }

        /// <summary>Получить данные</summary>
        protected virtual void OnGetData() {
            Cursor.Current = Cursors.WaitCursor;
            try {
                bs = new BindingSource();
                if (ParentGrid != null && (extParams == null || extParams.Count == 0)) // загрузка в дочерний грид без параметров не производится!
                    bs.DataSource = null;
                else {
                    var queryParams = new Dictionary<string, object>(extParams);
                    if (QueryParamsSet != null)
                        queryParams = QueryParamsSet.Invoke(this, queryParams);
                    var qp = new ParamsCheckEventArgs { Pars = queryParams };
                    QueryParamsCheck?.Invoke(this, qp);
                    var ea = new ProcessDataEventArgs() { Pars = qp.Pars };
                    GetData?.Invoke(this, ea);
                    bs.DataSource = ea.Result;
                }

                DataSource = bs;
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>Реакция на изменение содержимого, позиции, порядка и т.д.</summary>
        protected virtual void OnWhatsUp(string method) {
            SendInfo?.Invoke(this, new SendInfoEventArgs() {
                rows = Rows.Count.ToString(),
                selected = SelectedCells.OfType<DataGridViewCell>().Select(x => x.RowIndex).Distinct().Count().ToString(), 
                checks = checkedRowsCount > 0 ? checkedRowsCount.ToString() : null,
                info = null
            }); ; ;

            WhatsUp?.Invoke(this, new WhatsUpEventArgs() {
                CheckedKeys = GetCheckedRowsKeys(),
                Key = GetKey(),
                RowObj = GetRowObject(),
                Method = method          
            });
        }

        /// <summary>Сбросить источники</summary>
        public void Clear(bool full = false) {
            if (bs != null && full) {
                bs.DataSource = null;
                bs.Dispose();
                bs = null;
            }
            DataSource = null;
            //GetData = null;
            Refresh();
        }
        
        // принудительно вызываем OnRowEnter - по окончании выделения или перемещения - чтобы обновить дочерние гриды для строки, на которой остановились
        void ForceLoadChilds() {
            if (!enableLoadChilds) {
                enableLoadChilds = true;
                if (CurrentCell != null)
                    OnRowEnter(new DataGridViewCellEventArgs(CurrentCell.ColumnIndex, CurrentCell.RowIndex));
            }
        }

        // форматирование ячеек в зависимости от типа данных
        void FormatColumns(string numericFormat = null) {
            DataTable dt = (bs.DataSource as DataTable);
            PropertyDescriptorCollection props = (dt == null && bs.Current != null) ? TypeDescriptor.GetProperties(bs.Current) : null;
            if (dt == null && props == null) return;
            foreach (DataGridViewColumn col in Columns.OfType<DataGridViewColumn>()
                .Where(c => !c.HasDefaultCellStyle || (c.DefaultCellStyle.Tag?.Equals(c.GetHashCode()) ?? false))) {
                Type type = dt != null ? dt.Columns[col.DataPropertyName]?.DataType : props.OfType<PropertyDescriptor>().FirstOrDefault(x => x.Name == col.DataPropertyName)?.PropertyType;
                if (type != null) {
                    DataGridViewCellStyle cs = col.DefaultCellStyle;
                    if (type == typeof(DateTime))
                        cs.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if (type == typeof(decimal) || type == typeof(double) || type == typeof(int)) {
                        cs.Alignment = DataGridViewContentAlignment.MiddleRight;
                        cs.Format = numericFormat ?? "#,##0.################";
                        cs.Tag = col.GetHashCode(); // чтобы прийти сюда потом, т.к. HasDefaultCellStyle станет true
                    }
                    if (type == typeof(bool)) {
                        cs.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        cs.FormatProvider = new BoolFormatter();
                        cs.Format = "Mark";
                    }
                }
            }
        }

        // установить фокус на строку, содержащую объект с указанным ключом
        void SetRowFocus(object key) {
            int col = CurrentCell != null ? CurrentCell.ColumnIndex : 0;
            int pos = GetKeyRow(key);
            if (pos >= 0)
                bs.Position = pos;

            int row = CurrentRow != null ? CurrentRow.Index : Rows.Count > 0 ? 0 : -1;

            if (row != -1 && !this[col, row].Visible && FirstDisplayedCell != null) {
                row = FirstDisplayedCell.RowIndex;
                col = FirstDisplayedCell.ColumnIndex;
            }

            CurrentCell = row != -1 && this[col, row].Visible ? this[col, row] : null;

            if (CurrentRow != null
                && (CurrentRow.Index > FirstDisplayedScrollingRowIndex + DisplayedRowCount(true)
                    || CurrentRow.Index < FirstDisplayedScrollingRowIndex))
                FirstDisplayedScrollingRowIndex = CurrentRow.Index;

            disableRedrawHighlight = false;
            RowsHighlight();
        }

        /// <summary>Получить ключ из строки</summary>
        public object GetKey(int row = -1, string keyNames = null) {
            Dictionary<string, object> res = new Dictionary<string, object>();
            if (row == -1 && CurrentRow != null)
                row = CurrentRow.Index;
            if (row < 0 || row >= RowCount || Rows[row].DataBoundItem == null)
                return res;
            if (string.IsNullOrWhiteSpace(keyNames))
                keyNames = KeyNames;

            var keys = keyNames.Split(';').Where(x => !string.IsNullOrWhiteSpace(x));
            object obj = Rows[row].DataBoundItem;
            if (obj is DataRowView) {
                DataRowView drv = (DataRowView)obj;
                foreach (string key in keys)
                    if (drv.Row.Table.Columns[key] != null)
                        res.Add(key, drv.Row[key]);
            } else {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
                foreach (string key in keys)
                    if (props.OfType<PropertyDescriptor>().Any(x => x.Name == key))
                        res.Add(key, props[key].GetValue(obj));
            }
            return res;
        }

        /// <summary>Получить объект указанной строки или текущий</summary>
        public object GetRowObject(int row = -1) {
            if (row == -1 && CurrentRow != null)
                row = CurrentRow.Index;
            if (row < 0 || row >= RowCount || Rows[row].DataBoundItem == null)
                return null;
            object obj = Rows[row].DataBoundItem;
            if (obj is DataRowView) 
                return ((DataRowView)obj).Row;
            else
                return obj;
        }

        // ключевые поля - в строку: "имя_поля1 [значение_поля1] имя_поля2 [значение_поля2] ..."
        string KeyToString(object key) {
            StringBuilder s = new StringBuilder("");
            if (key is Dictionary<string, object>) {
                ((Dictionary<string, object>)key)
                    .ToList()
                    .ForEach(x => s.Append($"{x.Key} [{(x.Value == null ? "null" : x.Value)}] "));
            }
            return s.ToString();
        }

        // строка по ключу
        public int GetKeyRow(object key) {
            int row = -1;
            object li = null;
            if (key is Dictionary<string, object>) {
                Dictionary<string, object> keys = (Dictionary<string, object>)key;
                if (bs == null || bs.Current == null || keys.Count == 0)
                    return row;
                if (bs.Current is DataRowView) { 
                    DataRowView drv = (DataRowView)bs.Current;
                    if (keys.Any(k => drv.Row.Table.Columns[k.Key] == null))
                        return row;
                    li = bs.List.OfType<DataRowView>().FirstOrDefault(o => keys.All(k => o.Row[k.Key].Equals(k.Value)));
                } else {
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(bs.Current);
                    if (keys.Any(k => !props.OfType<PropertyDescriptor>().Any(x => x.Name == k.Key)))
                        return row;
                    li = bs.List.OfType<object>().FirstOrDefault(o => keys.All(k => props[k.Key].GetValue(o).Equals(k.Value)));
                }
            } else
                li = key;
            row = bs.IndexOf(li);
            return row;
        }

        // отметить строку галкой
        void CheckRow(int row, int? col, bool multi = false) {
            if (!ShowCheckBoxes || !Columns.Contains(checkColumnName)
                || (col != null && col != Columns[checkColumnName].Index))
                return;
            bool v = (bool)(this[checkColumnName,row].Value ?? false);
            if (multi)
                foreach (int r in SelectedCells.OfType<DataGridViewCell>().Select(x => x.RowIndex).Distinct())
                    this[checkColumnName,r].Value = !v;
            else
                this[checkColumnName,row].Value = !v;
            checkedRowsCount = Rows.OfType<DataGridViewRow>().Where(x => (x.Cells[checkColumnName].Value ?? false).Equals(true)).Count();
        }

        /// <summary>Индексы отмеченных строк</summary>
        public List<int> GetCheckedRowsIdx() {
            var ret = new List<int>();
            if (!ShowCheckBoxes || !Columns.Contains(checkColumnName))
                return ret;
            ret.AddRange(Rows.OfType<DataGridViewRow>().Where(x => (x.Cells[checkColumnName].Value ?? false).Equals(true)).Select(y => y.Index));
            return ret;
        }

        /// <summary>Ключи отмеченных строк</summary>
        public List<object> GetCheckedRowsKeys() {
            var ret = GetCheckedRowsIdx().Select(x => GetKey(x)).ToList();
            return ret;
        }

        /// <summary>Отметить строки, соответствующие ключам</summary>
        public void SetCheckedRows(List<object> keys, bool check = true) {
            if (!ShowCheckBoxes || !Columns.Contains(checkColumnName) || keys == null)
                return;
            foreach (var key in keys) {
                var row = GetKeyRow(key);
                if (row >= 0)
                    this[checkColumnName, row].Value = check;
            }
            checkedRowsCount = Rows.OfType<DataGridViewRow>().Where(x => (x.Cells[checkColumnName].Value ?? false).Equals(true)).Count();
        }

        #endregion

        //____________ Search _________________________________________________________________________________________________________________________________________________________

        #region Search

        /// <summary>Вызов формы поиска</summary>
        public void Search() {
            if (!DisableSearch && CurrentCell != null) {
                FormSearch fs = new FormSearch(DoSearch);
                fs.Top = PointToScreen(Point.Empty).Y + ColumnHeadersHeight * 2;
                fs.Left = PointToScreen(Point.Empty).X + RowHeadersWidth * 2;
                fs.ShowDialog(this.FindForm());
                ForceLoadChilds();
            }
        }

        bool DoSearch(Search newSearch, SearchMode mode) {
            if (newSearch != null)
                search = newSearch;

            if (search == null || CurrentCell == null || search.Check(null))
                return false;

            bool fwd = (mode == SearchMode.Left || mode == SearchMode.Down),
              incol = (mode == SearchMode.Up || mode == SearchMode.Down);

            Func<int, int, List<int>> fn = (r, c) => {
                return Rows[r].Cells.OfType<DataGridViewCell>()
                  .Where(x => x.OwningColumn.Index >= 0 && (!incol ? (fwd ? x.OwningColumn.Index > c : c > x.OwningColumn.Index) : c == x.OwningColumn.Index))
                  .Where(y => search.Check(y.Value))
                  .Select(z => z.OwningColumn.Index).ToList();
            };

            if (MoveCell(fwd, incol, false, fn)) {
                RowsHighlight();
                return true;
            } else {
                Loger.SendMess($"Значение \"{search.Str}\" не найдено");
                return false;
            }
        }

        // перемещение в определенную ячейку из отобранных делегатом
        bool MoveCell(bool fwd, bool inCol, bool inRow, Func<int, int, List<int>> GetNextPosInRow) {
            // fwd - двигаться вперед, inCol/inRow - двигаться в пределах текущего столбца/строки
            bool res = false;
            if (CurrentCell == null || (inCol && inRow))
                return res;
            Cursor.Current = Cursors.WaitCursor;
            try {
                int step = fwd ? 1 : -1; // шаг по строкам
                int row = CurrentRow.Index; // текущая строка
                int r = row + (inCol ? step : 0); // стартовая строка
                int c = CurrentCell.OwningColumn.Index; // стартовый столбец
                bool start = true;
                List<int> cn = null;

                while (start || (!inRow && (fwd ? r <= row : r >= row))) // если только начали или еще не пошли столбец по второму кругу
                {
                    if (fwd ? r >= RowCount : r < 0) // дошли до конца/начала столбца - начнем сначала/сконца столбца
                    {
                        r = fwd ? 0 : (RowCount - 1);
                        start = false;
                    }
                    cn = null;
                    if (GetNextPosInRow != null)
                        cn = GetNextPosInRow(r, c).Where(x => Columns[x].Visible).ToList(); // подходящие ячейки в этой строке
                    if (cn != null && cn.Count > 0)
                        break;
                    if (!inRow) //
                        r = r + step;
                    else if (c == (fwd ? -1 : ColumnCount)) // строка пошла еще раз сначала/сконца
                        start = false;
                    if (!inCol) c = fwd ? -1 : ColumnCount; // строку - сначала/сконца
                }

                if (cn != null && cn.Count > 0) // есть подходящие ячейки в строке r
                {
                    c = (fwd ? cn.Min() : cn.Max()); // нужная с учетом направления
                    CurrentCell = this[c, r];
                    res = true;
                }
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
            return res;
        }

        #endregion

        //____________ Filter _________________________________________________________________________________________________________________________________________________________

        #region Filter

        /// <summary>Вызов формы фильтра</summary>
        public void Filter() {
            if (!DisableFilter && CurrentCell != null) {
                FormFilter ff = new FormFilter(CurrentCell.OwningColumn, CurrentCell.Value, SetFilter);
                ff.Top = PointToScreen(Point.Empty).Y + ColumnHeadersHeight * 2;
                ff.Left = PointToScreen(Point.Empty).X + RowHeadersWidth * 2;
                ff.ShowDialog(this.Parent);
            }
        }

        // установить фильтр
        int SetFilter(Filter filter) {
            prevKey = GetKey();
            ClearSelectedRowsHighlight(true);

            int res = DoFilter(filter);

            if (res < 0)
                return res;

            filters.Add(filter);
            MarkFilteredHeader(Columns[filter.ColName]);

            enableLoadChilds = true;
            firstRowPressed = -1;

            if (Rows.Count > 0)
                SetRowFocus(prevKey);
            else // данных нет => и в дочерних их быть не должно (OnRowEnter не отрабатывает => вызываем загрузку в дочерний грид без параметров)
                ClearChildren(); 

            OnWhatsUp("SetFilter");

            prevKey = null;
            return res; 
        }

        // сбросить все фильтры и пометки столбцов
        public void ClearFilter() {
            foreach (var item in filters)
                MarkFilteredHeader(Columns[item.ColName], true);
            filters.Clear();
        }

        // если есть фильтры для этого столбца и родительского ключа - пометить столбец и вывести описание в тултип, если нет - очистить пометки 
        void MarkFilteredHeader(DataGridViewColumn col, bool clear = false) {
            string filter = clear ? ""
              : string.Join("; ", filters.Where(f => f.ColName == col.Name)
                .Select(x => x.FilterName).Distinct());

            if (filter != "") {
                col.HeaderCell.Style.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.DarkRed;
                col.HeaderCell.ToolTipText = filter;
            } else {
                col.HeaderCell.Style.Font = new Font(DefaultCellStyle.Font, FontStyle.Regular);
                col.HeaderCell.Style.ForeColor = SystemColors.ControlText;
                col.HeaderCell.ToolTipText = "";
            }
        }

        // фильтрация - вернет -1 если нельзя установить или ошибка, иначе вернет кол-во оставшихся записей
        int DoFilter(Filter filter) {
            if (filter == null)
                return -1;
            int res = 0;
            SuspendLayout();
            ScrollBars sb = ScrollBars;
            ScrollBars = ScrollBars.None;
            Cursor.Current = Cursors.WaitCursor;
            try {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                for (int r = 0; r < Rows.Count; r++) {
                    DataGridViewRow row = Rows[r];
                    if (!filter.Check(row.Cells[filter.ColName].Value))
                        rows.Add(row);
                }
                res = Rows.Count - rows.Count;
                if (res >= 0 && res < Rows.Count) {
                    bs.SuspendBinding();
                    bs.Position = -1;
                    for (int i = rows.Count - 1; i >= 0; i--)
                        Rows.RemoveAt(rows[i].Index);
                }
            }
            catch (Exception e) {
                Loger.SendMess(e, "Ошибка установки фильтра!");
                return -1;
            }
            finally {
                bs.ResumeBinding();
                ScrollBars = sb;
                ResumeLayout();
                Cursor.Current = Cursors.Default;
            }
            return res;
        }

        #endregion

        //____________ Edit _________________________________________________________________________________________________________________________________________________________

        #region Edit //todo1

        /// <summary>Добавить строку</summary>
        public void AddNew() => StartEdit(EditModes.AddNew);

        /// <summary>Добавить строку на основе текущей</summary>
        public void AddCopy() => StartEdit(EditModes.AddCopy);

        /// <summary>Редактировать строку</summary>
        public void Edit() => StartEdit(EditModes.Edit);

        void StartEdit(EditModes mode) {
            if (!Editable || editMode != EditModes.None) return;
            editMode = mode;
            ReadOnly = false;
            editRowKey = GetKey();
            try {

            }
            catch (Exception e) {
                Loger.SendMess(e, "Ошибка перехода в режим редактирования");
                editMode = EditModes.None;
                ReadOnly = true;
            }
            finally {
                //
            }
        }

        /// <summary>Сохранить данные редактируемой строки</summary>
        public void Save() {
            if (editMode == EditModes.None) return;
            //
            editMode = EditModes.None;
            ReadOnly = true;
        }

        /// <summary>Отменить редактирование строки</summary>
        public void UndoSave() {
            if (editMode == EditModes.None) return;
            //
            editMode = EditModes.None;
            ReadOnly = true;
            LoadData(editRowKey); //todo1 может не перечитывать, а только вернуть данные старой строки
        }

        #endregion
    }
}
