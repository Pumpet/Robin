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


namespace Ctrls {
    public partial class NumberBox : TextBox, ISupportInitialize {
        bool docheck;
        string old;
        string sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        /// <summary>Текст по умолчанию</summary>
        [Browsable(false)]
        string DefaultText {
            get {
                if (Nullable)
                    return "";
                else
                    return "0";
            }
        }

        /// <summary>Допускает пустое значение при редактировании</summary>
        [Category("Mask options"), DefaultValue(false), Description("Допускает пустое значение при редактировании")]
        public bool Nullable { get; set; }

        [Category("Mask options"), DefaultValue(null), Description("Максимальное количество цифр")]
        public uint? DigitsTotalNumber { get; set; }

        [Category("Mask options"), DefaultValue(null), Description("Количество цифр после запятой")]
        public uint? DigitsDecimalNumber { get; set; }


        public NumberBox() {
            InitializeComponent();
            StartValues();
        }
        public NumberBox(IContainer container) {
            container.Add(this);
            InitializeComponent();
            StartValues();
        }
        protected void StartValues() {
            TextAlign = HorizontalAlignment.Right;
            Nullable = false;
        }

        public void BeginInit() { }
        public void EndInit() {
            if (!DesignMode)
                Init();
        }

        protected void Init() {
            Text = DefaultText;
            old = Text;
            docheck = true;
            if (DataBindings != null)
                DataBindings.CollectionChanged += DataBindings_CollectionChanged;
        }

        // для принудительных параметров биндинга
        private void DataBindings_CollectionChanged(object sender, CollectionChangeEventArgs e) {
            var bind = e.Element as Binding;
            if (e.Action == CollectionChangeAction.Add && bind != null) {
                bind.NullValue = bind.NullValue ?? ""; // чтобы задавить null-ы - иначе не уйти после очистки, если был биндинг и допустимы null
            }
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            int pos = SelectionStart;
            docheck = true;

            bool numKey = (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9);

            // двигаемся через точку
            if ((e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod || e.KeyCode == (Keys)110) && pos < Text.Length && Text[pos] == '.') {
                Select(++pos, 0);
                e.SuppressKeyPress = true;
            }

            // отрезать ноль если вводим после точки
            if (numKey && Text.Length > 1 && Text.Substring(Text.Length - 2, 2) == sep + "0" && pos == Text.Length - 1) {
                docheck = false;
                Text = Text.Substring(0, Text.Length - 1);
                Select(pos, 0);
            }

            // минус - вперед
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == (Keys)109) {
                Text = "-" + Text;
                Select(1, 0);
            }

            e.SuppressKeyPress = (e.SuppressKeyPress
              || e.KeyCode == Keys.Oemplus
              || e.KeyCode == Keys.OemMinus
              || e.KeyCode == Keys.Space
              || e.KeyCode == Keys.Add
              || e.KeyCode == Keys.Subtract);

            base.OnKeyDown(e);
        }

        protected override void OnTextChanged(EventArgs e) {
            int pos = SelectionStart;
            string newtext;

            if (CheckText(Text, out newtext)) // допустимость текста как числа
            {
                old = Text;
                Text = newtext;
            } else {
                Text = old;
                pos = pos - 1;
            }

            // встать после первого нуля
            if (Text.Length > 0 && Text.Substring(0, 1) == "0" && pos == 0)
                pos = 1;

            Select(pos >= 0 ? pos : 0, 0);

            base.OnTextChanged(e);
        }

        /* допустимость текста как числа */
        private bool CheckText(string text, out string outtext) {
            bool check = true;

            if (string.IsNullOrEmpty(text) && !Nullable)
                text = DefaultText;

            string tmp = "";

            // убираем минус из отрицательного
            if (text.Length > 0 && text.Substring(0, 1) == "-") {
                tmp = "-";
                text = text.Substring(1);
            }

            // добавим 0 перед первым разделителем
            if (text.Length > 0 && text.Substring(0, 1) == sep)
                text = "0" + text;

            // добавим 0 после последнего разделителя
            if (text.Length > 0 && text.Substring(text.Length - 1, 1) == sep && docheck)
                text = text + "0";

            // убираем первый ноль перед целой частью
            if (text.Length > 1 && text.Substring(0, 1) == "0"
              && text.Substring(0, 2) != "0" + sep)
                text = text.Substring(1);

            text = tmp + text;

            decimal v;
            check = decimal.TryParse(text, out v) && CheckDecimalSize(v, DigitsTotalNumber, DigitsDecimalNumber);

            // для числа без дробной части (Scale == 0) убрать ".0"
            if (check && DigitsDecimalNumber == 0 && text.Length > 1 && text.Substring(text.Length - 2, 2) == ".0")
                text = text.Substring(0, text.Length - 2);

            outtext = text;
            return check || text == DefaultText || !docheck;
        }

        /// <summary>Значение в decimal или null - обертка нат TryParse</summary>
        public decimal? GetDecimalOrNull() {
            decimal dec;
            return decimal.TryParse(Text, out dec) ? (decimal?)dec : null;
        }

        public bool CheckDecimalSize(decimal value, uint? prec = null, uint? scale = null) {
            if (!(prec > 0))
                return true; // не контролируем
            if (scale > prec)
                scale = prec;

            // поверка целой части
            int intMax = (int)(scale >= 0 ? prec - scale : prec);
            var intVal = Math.Truncate(value);
            var intStr = intVal.ToString().Replace("-", "");
            if (intMax == 0) {
                if (!intStr.Equals("0"))
                    return false;
            } else if (intStr.Length > intMax)
                return false;

            // поверка дробной части
            var decVal = value - intVal;
            var decStr = decVal.ToString().Replace("-", "").Replace("0.", "").TrimEnd('0');
            if (scale >= 0 && decStr.Length > (int)scale)
                return false;

            // всего знаков
            if ((intStr + decStr).Trim('0').Length > (int)prec)
                return false;

            return true;
        }
    }
}
