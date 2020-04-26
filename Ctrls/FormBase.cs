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
using System.Windows.Forms;
using Manager;
using Common;
using System.Linq;
using System.ComponentModel;

namespace Ctrls {

    /// <summary>
    /// Базовая форма для списка и редактора.
    /// Реализует IDataForm, который позволяет взаимодействовать с классом контекста приложения (Manager.Context) и сохранять текущие значения полей-параметров запросов.
    /// </summary>
    public partial class FormBase : Form, IDataForm {

        /// <summary>тип события контрола - выход, вход, изменение состояния</summary>
        public enum CtrlEventType { Leave, Enter, StateChange }

        /// <summary>Аргументы общего события для событий контролов формы</summary>
        public class ControlTriggerEventArgs {
            public Control Ctrl { get; set; }
            public CtrlEventType EventType { get; set; }
        };

        protected object key;
        protected Dictionary<string, object> extParams = new Dictionary<string, object>();
        protected FormModes formModes;

        /// <summary>Контекст приложения</summary>
        [Browsable(false)]
        public Context Ctx { get; protected set; }

        [Browsable(true), Category("Robin options"), Description("Имя контрола для установки фокуса при показе формы")]
        public string FocusedControlName { get; set; }

        [Category("Robin options"), Description("Общее событие для событий определенных контролов формы: изменение состояния (Cheked, Selected, ...), входа (Enter), выхода (Leave). Подписку можно переопределить через SubscribeControlTrigger.")]
        public event EventHandler<ControlTriggerEventArgs> ControlTrigger;

        public FormBase() {
            InitializeComponent();
        }

        /// <summary>Инициализация формы</summary>
        /// <param name="ctx">Контекст приложения</param>
        /// <param name="formModes">Режимы запуска</param>
        /// <param name="extParams">Параметры для запросов</param>
        /// <param name="key">Ключ записи (например чтобы встать на нужной строке в главном гриде формы списка)</param>
        public virtual void Init(Context ctx, FormModes formModes = FormModes.Default, Dictionary<string, object> extParams = null, object key = null) {
            this.Ctx = ctx;
            this.formModes = formModes;
            this.extParams.AddFromDictionary(extParams);
            this.key = key;
        }

        /// <summary>Подготовка значений полей параметров для сохранения</summary>
        public virtual List<ControlValue> PrepareUiParamsProperties(List<ControlValue> props) {
            return props;
        }

        /// <summary>Установка загруженных значений полей параметров</summary>
        public virtual void SetUiParamsProperties(List<ControlValue> props) {
            return;
        }

        /// <summary>Обработка события грида по получению данных - приходит из LoadData() -> OnGetData() объекта DataList</summary>
        protected virtual void DataList_GetData(object sender, ProcessDataEventArgs e) {
            var list = (sender as DataList);
            if (e.Handled || list == null || (string.IsNullOrWhiteSpace(list.QuerySql) && string.IsNullOrWhiteSpace(list.QueryCmdCode)))
                return;
            // почистить от предыдущих
            list.Clear();
            Ctx.GcCollect();
            // получить данные
            e.Result = Ctx?.GetTable(list.QuerySql, list.QueryCmdCode, e.Pars);
        }

        ///<summary>Проверка, подходит ли контрол в качестве поля параметра</summary>
        /// <param name="type">Тип контрола</param>
        protected bool ValidParamControlType(Type type) {
            return (type == typeof(NumberBox)
                || type == typeof(NumericUpDown)
                || type == typeof(DateTimeBox)
                || type == typeof(DateTimePicker)
                || type == typeof(CheckBox)
                || type == typeof(RadioButton)
                || type == typeof(TextBox)
                || type == typeof(MaskedTextBox)
                || type == typeof(ComboBox)
                || type == typeof(CheckedComboBox)
                || type == typeof(SelectBox)
                || type == typeof(FastColoredTextBoxNS.FastColoredTextBox)
            );
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            // загрузим текущее состояние - размеры, порядок и размеры столбцов гридов, сплиттеры, значения полей параметров
            Ctx?.LoadFormOptions(this);
        }

        protected override void OnClosed(EventArgs e) {
            // сохраним текущее состояние
            Ctx?.SaveFormOptions(this);
            base.OnClosed(e);
            // почистимся
            foreach (var g in this.GetControls<DataList>())
                g.Clear(true);
            Ctx.GcCollect();
        }

        void FormBase_Activated(object sender, EventArgs e) {
            if (Ctx != null)
                Ctx.LastActiveForm = this; // запомним себя в контексте приложения как последнюю активную форму
        }

        protected override void OnShown(EventArgs e) {
            // устанавливает фокус на контроле, указанном в FocusedControlName
            Control c = this.GetControls<Control>().FirstOrDefault(x => x.Name == FocusedControlName);
            if (c != null)
            {
                if (c is TextBox)
                    ((TextBox)c).Select(0, 0);
                else
                    c.Select();
                c.Focus();

                if (c is ComboBox)
                    ((ComboBox)c).SelectionLength = 0;
            }
            // подписка общего события на события контролов
            this.ForControls(SubscribeControlTrigger);
        }

        // запуск общего события для контролов
        void OnConrolTrigger(object s, CtrlEventType et) {
            ControlTrigger?.Invoke(s, new ControlTriggerEventArgs() { Ctrl = (Control)s, EventType = et });
        }

        /// <summary>Подписка общего события ControlTrigger на событие контрола</summary>
        /// <param name="ctrl">Подписываемый контрол</param>
        protected virtual void SubscribeControlTrigger(Control ctrl) {
            ctrl.Enter += (s, ev) => { OnConrolTrigger(s, CtrlEventType.Enter); };
            ctrl.Leave += (s, ev) => { OnConrolTrigger(s, CtrlEventType.Leave); };
            if (ctrl is CheckBox) ((CheckBox)ctrl).CheckedChanged += (s, ev) => { OnConrolTrigger(s, CtrlEventType.StateChange); };
            if (ctrl is RadioButton) ((RadioButton)ctrl).CheckedChanged += (s, ev) => { OnConrolTrigger(s, CtrlEventType.StateChange); };
            if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndexChanged += (s, ev) => { OnConrolTrigger(s, CtrlEventType.StateChange); };
        }

        /// <summary>Запуск формы редактора</summary>
        /// <param name="form">Форма</param>
        /// <param name="formCode">Код формы из настроек</param> 
        /// <param name="viewMode">Режим формы для обработки данных: NewRec для новой записи, ReadOnly только для просмотра, Default для редактирования записи</param>
        /// <param name="grid">Грид, из которого запускаем. Если задан - поля источника текущей строки берутся в качестве параметров</param>
        /// <param name="mapForParams">Строка соответствия имен: "формируемый1=полученный1;...", где формируемый - параметр для запроса данных на форму, полученный - параметр из грида и customParams. Если нет полученного, параметр будет сформирован со значением null. Если соответствий не задано (по умолчанию) - берем все полученные параметры</param>
        /// <param name="customParams">Параметры ключ-значение. Если заданы - считаются приоритетнее, чем одноименные поля из грида</param>
        /// <param name="mapForResult">Строка соответствия имен: "формируемый1=полученный1;...", где полученный - поле результата выполнения скрипта вставки/обновления, формируемый - параметр поиска текущей записи после обновления данных в гриде</param>
        /// <param name="formModes">Другие необходимые режимы в дополнение к viewMode, по умолчанию - Modal</param>
        /// <returns>True только в случае положительного результата (OK) для модальной формы</returns>
        protected bool ExecFormEdit(Form form, string formCode, FormModes viewMode, DataList grid = null, string mapForParams = null, Dictionary<string, object> customParams = null, string mapForResult = null, FormModes formModes = FormModes.Modal) {
            if (Ctx == null) return false;
            if (viewMode != FormModes.Default && viewMode != FormModes.NewRecEdit && viewMode != FormModes.ViewOnlyEdit)
                viewMode = FormModes.Default;
            var pars = CtrlsProc.PrepareParams(viewMode == FormModes.NewRecEdit ? null : grid?.GetRowObject(), customParams);
            pars = CtrlsProc.GetParamsForMap(pars, mapForParams);
            Ctx.TransferObject = null;
            if (form == null)
                form = Ctx.GetForm(formCode);
            var ok = Ctx.ExecForm(form, this, formModes | viewMode, pars);
            if (ok && grid != null) {
                var k = Ctx.TransferObject == null || string.IsNullOrEmpty(mapForResult) ? Ctx.TransferObject : CtrlsProc.PrepareParams(Ctx.TransferObject, null, mapForResult);
                if (this is FormList)
                    (this as FormList).LoadGrid(grid, k);
                else
                    grid.LoadData(k);
            }
            return ok;
        }

        /// <summary>Запуск формы выбора из списка</summary>
        /// <param name="form">Форма</param>
        /// <param name="formCode">Код формы из настроек</param>
        /// <param name="sourceObject">Объект-источник параметров вызова формы (ключей и фильтра)</param>
        /// <param name="keyMap">Строка соответствия имен полей входящих в передаваемый ключ: "формируемый1=полученный1;...". Если соответствий не задано (по умолчанию) - берем все полученные параметры</param>
        /// <param name="filterMap">Строка соответствия имен полей входящих в передаваемый фильтр: "формируемый1=полученный1;...". Если соответствий не задано (по умолчанию) - берем все полученные параметры</param>        
        /// <param name="customParams">Параметры ключ-значение. Если заданы - считаются приоритетнее, чем одноименные поля из объекта-источника</param>
        /// <param name="resultAction">Метод разбора результата</param>        
        /// <returns>True только в случае положительного результата (OK) для модальной формы</returns>
        public bool ExecFormSelect(Form form, string formCode, object sourceObject, string keyMap = null, string filterMap = null, Dictionary<string, object> customParams = null, Action<object> resultAction = null) {
            if (Ctx == null) return false;
            var viewMode = FormModes.Modal | FormModes.GetResult;
            var pars = CtrlsProc.PrepareParams(sourceObject, customParams);
            var filters = string.IsNullOrWhiteSpace(filterMap) ? null : CtrlsProc.GetParamsForMap(pars, filterMap);
            var keys = string.IsNullOrWhiteSpace(keyMap) ? null : CtrlsProc.GetParamsForMap(pars, keyMap);
            Ctx.TransferObject = null;
            if (form == null)
                form = Ctx.GetForm(formCode);
            var ok = Ctx.ExecForm(form, this, viewMode, filters, keys);
            if (ok && resultAction != null) {
                resultAction(Ctx.TransferObject);
            }
            return ok;
        }

        /// <summary>Выполнение команды sql</summary>
        /// <param name="sql">Текст команды</param>
        /// <param name="cmdCode">Код команды из настроек, содержащий текст команды. Используется, если не задан текст команды (sql)</param>
        /// <param name="grid">Грид, из которого запускаем. Если задан - поля источника обрабатываемой строки берутся в качестве параметров</param>
        /// <param name="mapForParams">Строка соответствий ключей: "формируемый1=полученный1;...", где формируемый - параметр для команды, полученный - параметр из грида и customParams. Если нет полученного, параметр будет сформирован со значением null. Если соответствий не задано (по умолчанию) - берем все полученные параметры</param>
        /// <param name="customParams">Параметры ключ-значение. Если заданы - считаются приоритетнее, чем одноименные поля из грида</param>
        /// <param name="warning">Строка предупреждения перед выполнением команды. В этом случае будет окно сообщения с возможностью отказаться</param>
        /// <param name="forSelectedRows">True если хотим выполнить для каждой выделенной строки грида, False - только для текущей</param>
        /// <returns>Таблица (пустая, если команда не возвращает resultset) или null</returns>
        protected object ExecCommand(string sql, string cmdCode, DataList grid = null, string mapForParams = null, Dictionary<string, object> customParams = null, string warning = null, bool forSelectedRows = false) {
            if (!string.IsNullOrEmpty(warning) && MessageBox.Show(warning, "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return null;

            List<Dictionary<string, object>> rowParamsList = new List<Dictionary<string, object>>();
            if (grid != null && forSelectedRows)
                //foreach (int r in grid.SelectedCells.OfType<DataGridViewCell>().Select(x => x.RowIndex).Distinct().OrderBy(i => i))
                foreach (int r in grid.GetCheckedRowsIdx())
                    rowParamsList.Add(CtrlsProc.GetParamsForMap(CtrlsProc.PrepareParams(grid.GetRowObject(r), customParams), mapForParams));
            else
                rowParamsList.Add(CtrlsProc.GetParamsForMap(CtrlsProc.PrepareParams(grid?.GetRowObject(), customParams), mapForParams));

            object res = null;
            foreach (var rowParams in rowParamsList)
                res = Ctx?.GetTable(sql, cmdCode, rowParams);

            if (grid != null) {
                if (this is FormList)
                    (this as FormList).LoadGrid(grid);
                else
                    grid.LoadData();
            }

            return res;
        }

        public void GetDataToCombo(ComboBox cb, string sql, string field) {
            var tmp = cb.Text;
            cb.DataSource = Ctx.GetTable(sql, null);
            cb.DisplayMember = field;
            cb.Text = tmp;
        }
    }
}
