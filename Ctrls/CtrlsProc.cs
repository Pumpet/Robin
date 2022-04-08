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
using Common;
using System.Data;
using System.ComponentModel;
using Manager;
using System.Linq;

namespace Ctrls {

    /// <summary>Аргументы для события проверки-изменения параметров перед их передачей в sql</summary>
    public class ParamsCheckEventArgs : EventArgs {
        /// <summary>Параметры для последующей передачи в sql</summary>
        public Dictionary<string, object> Pars { get; set; } = new Dictionary<string, object>();
        /// <summary>Результат проверки (код-сообщение), для вывода предупреждений для полей редактора - "имя поля или контрола - сообщение"</summary>
        public Dictionary<string, string> CheckResult { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>Аргументы для события обработки данных (например выполнения sql)</summary>
    public class ProcessDataEventArgs : EventArgs {
        /// <summary>Параметры запроса</summary>
        public Dictionary<string, object> Pars { get; set; } = new Dictionary<string, object>();
        /// <summary>Результат обработки (например объект-набор данных - таблица, коллекция)</summary>
        public object Result { get; set; } = null;
        /// <summary>Признак завершения обработки - для запрета выполнения следующих обработчиков события</summary>
        public bool Handled { get; set; } = false;
    }

    /// <summary>Общие процедуры библиотеки</summary>
    public static class CtrlsProc {

        /// <summary>
        /// Формирование словаря параметров ключ-объект
        /// </summary>
        /// <param name="newParamsObject">Объект, из которого получаем параметры с учетом map (словарь ключ-объект, или коллекция контролов, или строка таблицы, или произвольный объект)</param>
        /// <param name="existingParams">Существующие параметры - переносятся без учета map</param>
        /// <param name="map">Строка соответствий ключей параметров: "формируемый1=полученный1;формируемый2=полученный2..." Если соответствий не задано (по умолчанию) - берем все полученные параметры</param>
        /// <param name="rewrite">Перезаписывать существующий параметр новым (с тем же именем, с учетом map)</param>
        /// <param name="fConvert">Функция преобразования newParamsObject в словарь имя-значение - если не устраивает стандартная обработка</param>
        /// <param name="addNulls">Если true и нет полученного ключа - будет сформирован параметр со значением null</param>
        /// <returns>Новый словарь параметров (пустой, если параметров нет)</returns>
        public static Dictionary<string, object> PrepareParams(object newParamsObject, Dictionary<string, object> existingParams = null, 
                string map = null, bool rewrite = false, Func<object, Dictionary<string, object>> fConvert = null, bool addNulls = true) {
            var res = new Dictionary<string, object>();
            res.AddFromDictionary(existingParams);

            var newpars = new Dictionary<string, object>();

            if (fConvert == null) {
                // в зависимости от того, что передали, формируем новые параметры
                if (newParamsObject is Dictionary<string, object>) // - ключ-значение - как есть
                    newpars.AddFromDictionary((Dictionary<string, object>)newParamsObject);
                else if (newParamsObject is IEnumerable<Control>) { // - массив контролов - имя контрола (без подчеркивания) и его содержимое
                    var cpars = (newParamsObject as IEnumerable<Control>);
                    foreach (var c in cpars) {
                        var name = c.Name.TrimStart('_');
                        if (!string.IsNullOrWhiteSpace(name) && !newpars.ContainsKey(name))
                            newpars.Add(name, c.GetControlValue());
                    }
                } else if (newParamsObject is DataRow) { // - строка - имя столбца и его содержимое
                    var row = (newParamsObject as DataRow);
                    foreach (DataColumn c in row.Table.Columns) 
                        newpars.Add(c.ColumnName, row[c]);
                } else if (newParamsObject != null) { // - произвольный объект - имя свойства - значение
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(newParamsObject);
                    foreach (PropertyDescriptor prop in props)
                        newpars.Add(prop.Name, prop.GetValue(newParamsObject));
                }
            }
            else
                newpars.AddFromDictionary(fConvert(newParamsObject));

            if (!string.IsNullOrWhiteSpace(map))
                newpars = GetParamsForMap(newpars, map, addNulls: addNulls);

            res.AddFromDictionary(newpars, !rewrite);

            return res;
        }

        /// <summary>Формирование словаря с указанными ключами</summary>
        /// <param name="pars">Исходный словарь ключ-объект</param>
        /// <param name="map">Строка соответствий ключей "формируемый=исходный" через разделитель.</param>
        /// <param name="dlm">Разделитель. По умолчанию ";"</param>
        /// <param name="addNulls">Если true и нет исходного ключа - будет сформирован ключ со значением null</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetParamsForMap(Dictionary<string, object> pars, string map, string dlm = ";", bool addNulls = true) {
            if (string.IsNullOrEmpty(map))
                return pars;
            var res = new Dictionary<string, object>();
            foreach (string s in map?.Split(new[] { dlm }, StringSplitOptions.RemoveEmptyEntries)) {
                string[] ss = s.Split('=');
                if (ss.Length == 2 && !string.IsNullOrWhiteSpace(ss[0]) && !string.IsNullOrWhiteSpace(ss[1])) {
                    string key = ss[0].Trim(), ext = ss[1].Trim();
                    if (!res.ContainsKey(key)) {
                        if (pars.ContainsKey(ext))
                            res.Add(key, pars[ext]);
                        else if (addNulls)
                            res.Add(key, null);
                    }
                }
            }
            return res;
        }

        /// <summary>Установка значений словаря в поля объекта (строки, словаря)</summary>
        /// <param name="targetObject">целевой объект (строка, словарь, контейнер контролов)</param>
        /// <param name="pars">словарь значений (ключи соответствуют именам полей объекта)</param>
        public static void SetValues(object targetObject, Dictionary<string, object> pars) {
            if (targetObject is DataRow) {
                var row = (DataRow)targetObject;
                foreach (var key in pars.Keys) {
                    if (row.Table.Columns.Contains(key))
                        row[key] = pars[key] ?? DBNull.Value;
                }
            } else if (targetObject is IEnumerable<Control>) { 
                var cpars = (targetObject as IEnumerable<Control>);
                foreach (var key in pars.Keys) {
                    var par = cpars.FirstOrDefault(x => x.Name.TrimStart('_') == key);
                    if (par != null)
                        SetControlValue(par, pars[key]?.ToString());
                }
            } else if (targetObject is Dictionary<string, object>) {
                ((Dictionary<string, object>)targetObject).AddFromDictionary(pars, false);
            } else if (targetObject != null) {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(targetObject);
                foreach (var key in pars.Keys) {
                    if (props.OfType<PropertyDescriptor>().Any(x => x.Name == key))
                        props[key].SetValue(targetObject, pars[key]);
                }
            }
        }
        /// <summary>Значение контрола для дальнейшего использования (например в параметрах)</summary>
        public static object GetControlValue(this Control c) {
            object res = null;
            if (c is NumberBox)
                res = ((NumberBox)c).GetDecimalOrNull();
            else if (c is NumericUpDown)
                res = ((NumericUpDown)c).Value;
            else if (c is DateTimeBox)
                res = ((DateTimeBox)c).GetDateTime();
            else if (c is DateTimePicker) {
                var dtp = (DateTimePicker)c;
                res = dtp.ShowCheckBox && !dtp.Checked ? null : (object)dtp.Value;
            } else if (c is CheckBox)
                res = ((CheckBox)c).CheckState == CheckState.Indeterminate ? null : (object)((CheckBox)c).Checked;
            else if (c is RadioButton)
                res = ((RadioButton)c).Checked;
            else //if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(MaskedTextBox) || c.GetType() == typeof(ComboBox))
                res = c.Text;
            return res;
        }

        /// <summary>Установить строку в значение контрола в зависимости от его типа </summary>
        /// <param name="c">Контрол</param>
        /// <param name="value">Значение (строка)</param>
        /// <param name="clear">Сбросить значение контрола</param>
        public static void SetControlValue(Control c, string value, bool clear = false) {
            if (c is NumericUpDown) {
                decimal dec;
                if (decimal.TryParse(value, out dec))
                    ((NumericUpDown)c).Value = dec;
                else if (clear)
                    ((NumericUpDown)c).Value = 0;

            } else if (c is DateTimePicker) {
                DateTime dt;
                if (DateTime.TryParse(value, out dt))
                    ((DateTimePicker)c).Value = dt;
                else if (clear)
                    ((DateTimePicker)c).Value = ((DateTimePicker)c).MinDate;

            } else if (c is CheckBox) {
                bool b;
                if (bool.TryParse(value, out b))
                    ((CheckBox)c).CheckState = b ? CheckState.Checked : CheckState.Unchecked;
                else if (clear)
                    ((CheckBox)c).CheckState = ((CheckBox)c).ThreeState ? CheckState.Indeterminate : CheckState.Unchecked;

            } else if (c is RadioButton) {
                bool b;
                if (bool.TryParse(value, out b))
                    ((RadioButton)c).Checked = b;
                else if (clear)
                    ((RadioButton)c).Checked = false;
            } else if (c is CheckedComboBox) {
                var ccb = (c as CheckedComboBox);
                if (value == null && clear) value = string.Empty;
                if (!string.IsNullOrEmpty(value)) {
                    var ss = value.Split(new[] { ccb.ValueSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in ss) {
                        if (ccb.Items.Contains(s))
                            ccb.SetItemChecked(ccb.Items.IndexOf(s), true);
                    }
                }
            } else
                c.Text = (value == null && clear ? string.Empty : value);
        }


    }
}
