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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Manager;
using System.Data;

namespace Ctrls {

    /// <summary>Аргументы для события запуска формы для выбора</summary>
    public class ExecSelectionFormEventArgs : EventArgs {
        /// <summary>Параметры вызова формы (в дополнение к полям SourceObject)</summary>
        public Dictionary<string, object> ExtPars { get; set; } = new Dictionary<string, object>();
        /// <summary>Форма (по умолчанию определена по коду формы, заданному SelectionForm)</summary>
        public Form Form { get; set; } = null;
        /// <summary>Признак завершения обработки - для запрета выполнения стандартного вызова формы</summary>
        public bool Handled { get; set; } = false;
    }

    /// <summary>Аргументы для события обработки результата выбора</summary>
    public class SetResultEventArgs : EventArgs {
        /// <summary>Поля результата (из SelectedObject, с учетом ResultMap)</summary>
        public Dictionary<string, object> ResultPars { get; set; } = new Dictionary<string, object>();
        /// <summary>Признак завершения обработки - для запрета выполнения стандартной обработки результата (занесению в TargetObject из ResultPars)</summary>
        public bool Handled { get; set; } = false;
    }

    public partial class SelectBox : ComboBox {

        Color unlockedColor;
        ComboBoxStyle unlockedStyle;
        bool disabled = false;

        /// <summary>Контекст приложения</summary>
        [Browsable(false)]
        public Context Ctx { get { return (FindForm() as FormBase)?.Ctx; } }

        /// <summary>Объект-источник параметров для вызова формы (строка или словарь или произвольный объект)</summary>
        [Browsable(false)]
        public object SourceObject { get; set; }

        /// <summary>Выбранный объект - возвращается из формы (строка или словарь или произвольный объект)</summary>
        [Browsable(false)]
        public object SelectedObject { get; set; }

        /// <summary>Полученные значения (из выбранного объекта с учетом ResultMap)</summary>
        [Browsable(false)]
        public Dictionary<string, object> SelectedValues { get; set; }

        /// <summary>Целевой объект - строка (DataRow) или объект с данными (напр. BindingSource) или контейнер (Panel) или словарь (string-object)</summary>
        [Browsable(false)]
        public object TargetObject { get; set; }

        #region Props & Events

        [Category("Robin options"), DefaultValue(""), Description("Пары \"поле ключа формы для выбора = поле объекта-источника\" через ;")]
        public string KeyMap { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("Пары \"поле фильтра формы для выбора = поле объекта-источника\" через ;")]
        public string FilterMap { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("Пары \"поле целевого объекта = поле выбранного объекта\" через ;")]
        public string ResultMap { get; set; }

        [Category("Robin options"), DefaultValue(""), Description("Форма для выбора - код из настроек")]
        public string SelectionForm { get; set; }

        [Category("Robin options"), DefaultValue(false), Description("Допустимо ли пустое значение")]
        public bool Nullable { get; set; }

        [Category("Robin options"), DefaultValue(false), Description("Допустимо ли редактирование текста")]
        public bool Editable { get; set; }

        [Category("Robin options"), DefaultValue(false), Description("Элемент управления недоступен")]
        public bool Disabled {
            get { return disabled; }
            set {
                if (value && !disabled) {
                    unlockedColor = BackColor;
                    unlockedStyle = DropDownStyle;
                    BackColor = SystemColors.Control;
                    DropDownStyle = ComboBoxStyle.Simple;
                }
                if (!value) {
                    BackColor = unlockedColor;
                    DropDownStyle = unlockedStyle;
                }
                disabled = value;
            }
        }
       
        /// <summary>Вызов формы для выбора</summary>
        [Category("Robin options"), Description("Вызов формы для выбора")]
        public event EventHandler<ExecSelectionFormEventArgs> ExecSelectionForm;

        /// <summary>Обработка выбранного объекта</summary>
        [Category("Robin options"), Description("Обработка выбранного объекта")]
        public event EventHandler<SetResultEventArgs> SetResult;
            
        /// <summary>После обработки выбранного объекта и установки значений</summary>
        [Category("Robin options"), Description("После обработки выбранного объекта и установки значений")]
        public event EventHandler<EventArgs> AfterSetResult;

        #endregion

        public SelectBox() {
            InitializeComponent();
            StartValues();
        }

        public SelectBox(IContainer container) {
            container.Add(this);
            InitializeComponent();
            StartValues();
        }

        protected void StartValues() {
            unlockedColor = BackColor;
            unlockedStyle = ComboBoxStyle.DropDown;
            DropDownHeight = 1;
            DropDownWidth = 1;
        }

        #region Overrides

        protected override void OnKeyDown(KeyEventArgs e) {
            if (!Editable || Disabled)
                e.SuppressKeyPress = !((e.KeyValue >= 33 && e.KeyValue <= 40)
                  || e.KeyCode == Keys.Shift || e.KeyCode == Keys.Control || e.KeyCode == Keys.Escape
                  || (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
                  || e.KeyCode == Keys.F4
                  || (e.KeyCode == Keys.Delete && Nullable && !Disabled));

            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.None && !Disabled) {
                e.Handled = true;
                OnDropDown(new EventArgs());
            }
            // сброс для случая Nullable по Ctrl+Delete
            if (Nullable && !Disabled && e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control) {
                e.Handled = true;
                OnSetResult(null);
            }
        }

        protected override void OnDropDown(EventArgs e) {
            if (Disabled) {
                SendKeys.Send("{ESC}");
                return;
            }

            var ea = new ExecSelectionFormEventArgs() {
                ExtPars = null,
                Form = null,
                Handled = false
            };
            ExecSelectionForm?.Invoke(this, ea);
            if (ea.Handled) {
                SendKeys.Send("{ESC}");
                return;
            }

            (FindForm() as FormBase)?.ExecFormSelect(ea.Form, SelectionForm, SourceObject, KeyMap, FilterMap, ea.ExtPars, OnSetResult);
            SendKeys.Send("{ESC}");
        }

        protected virtual void OnSetResult(object resObject) {
            SelectedObject = resObject;
            var ea = new SetResultEventArgs {
                ResultPars = CtrlsProc.PrepareParams(resObject, null, ResultMap),
                Handled = false
            };
            SetResult?.Invoke(this, ea);
            SelectedValues = ea.ResultPars;
            if (!ea.Handled) {
                CtrlsProc.SetValues(TargetObject, SelectedValues);
                if (TargetObject is DataRow)
                    (TargetObject as DataRow).EndEdit();
                if (TargetObject is BindingSource)
                    (TargetObject as BindingSource).EndEdit();
            }
            AfterSetResult?.Invoke(this, new EventArgs());
        }

        protected override void OnDropDownClosed(EventArgs e) {
            base.OnDropDownClosed(e);
            Select(0, 0);
        }

        #endregion

    }
}
