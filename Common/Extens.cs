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
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Threading;

namespace Common {

    public enum ExecSqlType { Scalar, NonQuery, Table }
    
    /// <summary>
    /// Методы расширения
    /// </summary>
    public static class Extens {

        /// <summary>
        /// Добавить в словарь из словаря
        /// </summary>
        /// <param name="source">Словарь, из которого добавляем</param>
        /// <param name="addOnly">Только добавить (true) или обновить, если ключ уже есть (false)</param>
        public static void AddFromDictionary<T,S>(this Dictionary<T,S> dst, Dictionary<T, S> source, bool addOnly = false) {
            if (source == null)
                return;
            foreach (var item in source) 
                if (!dst.ContainsKey(item.Key))
                    dst.Add(item.Key, item.Value);
                else if (!addOnly)
                    dst[item.Key] = item.Value;
        }

        /// <summary>
        /// Установить-снять закрытое свойство объекта
        /// </summary>
        /// <param name="name">Имя свойства</param>
        /// <param name="value">Значение свойства</param>
        public static void SetNonPublicProperty(this object obj, string name, object value) {
            BindingFlags bFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            obj.GetType().GetProperty(name, bFlags).SetValue(obj, value, null);
        }

        /// <summary>
        /// Установка цветов узла у дерева 
        /// </summary>
        /// <param name="activeBrush">Цвет активного узла (по умолчанию SystemBrushes.ActiveCaption)</param>
        /// <param name="inactiveBrush">Цвет неактивного узла (по умолчанию SystemBrushes.GradientInactiveCaption)</param>
        public static void SetNodeBackColor(this TreeView tree, Brush activeBrush = null, Brush inactiveBrush = null) {
            activeBrush = activeBrush ?? SystemBrushes.ActiveCaption;
            inactiveBrush = inactiveBrush ?? SystemBrushes.GradientInactiveCaption;
            tree.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tree.DrawNode += (object sender, DrawTreeNodeEventArgs e) => {
                if (e.Node == null) return;
                var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
                var focused = e.Node.TreeView.Focused;
                if (selected) {
                    var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                    e.Graphics.FillRectangle(focused ? activeBrush : inactiveBrush, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, focused ? SystemColors.HighlightText : SystemColors.WindowText, TextFormatFlags.GlyphOverhangPadding);
                } else {
                    e.DrawDefault = true;
                }
            };
        }

        /// <summary>
        /// Выравнивание дат с - по
        /// </summary>
        /// <param name="dcheck">текущий контрол</param>
        /// <param name="dmin">контрол с мин.датой</param>
        /// <param name="dmax">контрол с макс.датой</param>
        /// <param name="setToNow">установить текущую дату</param>
        public static void CheckDates(this DateTimePicker dcheck, DateTimePicker dmin, DateTimePicker dmax, bool setToNow = true) {
            if (setToNow) {
                if (dmin.Value.Date.Equals(dmin.MinDate.Date))
                    dmin.Value = DateTime.Now.Date;
                if (dmax.Value.Date.Equals(dmax.MinDate.Date))
                    dmax.Value = DateTime.Now.Date;
            }
            if (dmin.Value.Date > dmax.Value.Date)
                if (dcheck == dmin)
                    dmax.Value = dmin.Value.Date;
                else
                    dmin.Value = dmax.Value.Date;
        }

        public static object GetSelectedRowValue(this ComboBox combo, string column, object defaultValue = null) {
            return (combo.SelectedItem as DataRowView)?.Row[column] ?? defaultValue;
        }

        #region Расширения для SqlConnection (выполнение sql и др.)

        /// <summary>Выполнить sql, вернуть список строк</summary>
        /// <param name="sql">SQL</param>
        /// <param name="pars">Словарь параметров</param>
        /// <param name="trassa">Метод для трассировки</param>
        /// <returns>Строки полученной таблицы в виде списка</returns>
        public static List<DataRow> GetTableList(this SqlConnection conn, string sql, Dictionary<string, object> pars = null,
            Action<string, List<SqlParameter>, string> trassa = null,
            SynchronizationContext sync = null, DataRowChangeEventHandler onRowChange = null, Action<object> onFinish = null) {
            return conn.GetTable(sql, pars, trassa)?.AsEnumerable().ToList() ?? new List<DataRow>();
        }

        /// <summary>Выполнить sql, вернуть таблицу</summary>
        /// <param name="sql">SQL</param>
        /// <param name="pars">Словарь параметров</param>
        /// <param name="trassa">Метод для трассировки</param>
        /// <returns>Таблица (пустая если нет resultset) или null, если ошибка</returns>
        public static DataTable GetTable(this SqlConnection conn, string sql, Dictionary<string, object> pars = null,
                Action<string, List<SqlParameter>, string> trassa = null, 
                SynchronizationContext sync = null, DataRowChangeEventHandler onRowChange = null, Action<object> onFinish = null) {
            var dt = conn.ExecSql(ExecSqlType.Table, sql, pars, trassa, sync, onRowChange, onFinish);
            return (dt is DataTable ? (DataTable)dt : null);
        }

        /// <summary>Выполнить sql, вернуть скалярный результат</summary>
        /// <param name="sql">SQL</param>
        /// <param name="pars">Словарь параметров</param>
        /// <param name="trassa">Метод для трассировки</param>
        /// <returns>Скалярный результат (object) или null, если ошибка или нет результата</returns>
        public static object GetValue(this SqlConnection conn, string sql, Dictionary<string, object> pars = null,
            Action<string, List<SqlParameter>, string> trassa = null,
            SynchronizationContext sync = null, DataRowChangeEventHandler onRowChange = null, Action<object> onFinish = null) {
            return conn.ExecSql(ExecSqlType.Scalar, sql, pars, trassa);
        }

        /// <summary>Выполнить sql, вернуть кол-во обработанных строк</summary>
        /// <param name="sql">SQL</param>
        /// <param name="pars">Словарь параметров ключ-значение</param>
        /// <param name="trassa">Метод для трассировки</param>
        /// <returns>Количество обработанных строк, -1 если ошибка</returns>
        public static int ExecCommand(this SqlConnection conn, string sql, Dictionary<string, object> pars = null, 
            Action<string, List<SqlParameter>, string> trassa = null,
            SynchronizationContext sync = null, DataRowChangeEventHandler onRowChange = null, Action<object> onFinish = null) { 
            return (int)conn.ExecSql(ExecSqlType.NonQuery, sql, pars, trassa);
        }

        /// <summary>Выполнить sql</summary>
        /// <param name="execType">Определяет тип выполнения и результат (Table - через DataAdapter вернет DataTable, Scalar - через ExecuteScalar вернет object, NonQuery - через ExecuteNonQuery вернет int)</param>
        /// <param name="sql">SQL</param>
        /// <param name="pars">Словарь параметров</param>
        /// <param name="trassa">Метод для трассировки</param>
        /// <returns>В зависимости от execType. В случае ошибки вернет null или -1 для NonQuery</returns>
        public static object ExecSql(this SqlConnection conn, ExecSqlType execType, string sql, Dictionary<string, object> pars,
                Action<string, List<SqlParameter>, string> trassa = null,
                SynchronizationContext sync = null, DataRowChangeEventHandler onRowChange = null, Action<object> onFinish = null,
                int? cmdTimeout = null) {

            object res = null;
            if (sync == null)
                sync = SynchronizationContext.Current;
            if (cmdTimeout == null) {
                int t;
                if (int.TryParse(AppConfig.GetPropValue("CommandTimeout"), out t))
                    cmdTimeout = t;
            }

            if (string.IsNullOrWhiteSpace(sql)) {
                sync.Send(o => Loger.SendMess($"Не указан запрос", true), null);
                return res;
            }

            try {
                List<SqlParameter> ps = null;
                if (pars != null) {
                    ps = new List<SqlParameter>();
                    foreach (var p in pars) {
                        object value = p.Value;
                        if (value is DateTime && ((DateTime)value).Equals(DateTime.MinValue))
                            value = null;
                        if (value is bool)
                            value = ((bool)value ? 1 : 0);
                        ps.Add(new SqlParameter(p.Key, value ?? DBNull.Value));
                    }
                }

                sync.Send(o => trassa?.Invoke(sql, ps, conn.ConnectionString), null);

                if (execType == ExecSqlType.NonQuery || execType == ExecSqlType.Scalar) {
                    var cmd = new SqlCommand(sql, conn);
                    if (cmdTimeout != null)
                        cmd.CommandTimeout = (int)cmdTimeout;
                    if (ps != null)
                        cmd.Parameters.AddRange(ps.ToArray());
                    conn.Open();
                    res = (execType == ExecSqlType.NonQuery ? cmd.ExecuteNonQuery() : cmd.ExecuteScalar());
                }
                if (execType == ExecSqlType.Table) {
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn)) {
                        if (cmdTimeout != null)
                            da.SelectCommand.CommandTimeout = (int)cmdTimeout;
                        if (ps != null)
                            da.SelectCommand.Parameters.AddRange(ps.ToArray());
                        res = new DataTable();
                        if (onRowChange != null)
                            ((DataTable)res).RowChanged += onRowChange;
                        da.Fill((DataTable)res);
                    }
                }
            }
            catch (ThreadAbortException) {
                //  
            }
            catch (Exception e) {
                sync.Send(o => Loger.SendMess(e, "Ошибка выполнения запроса"), null);
                res = null;
            }
            finally {
                if (res is DataTable && onRowChange != null)
                    ((DataTable)res).RowChanged -= onRowChange;
                conn.Close();
                if (onFinish != null)
                    sync.Send(o => onFinish(res), null);
            }
            if (execType == ExecSqlType.NonQuery && res == null) res = -1;
            return res;
        }

        #endregion

        /// <summary>
        /// Вернуть sql-определение параметра: [префикс]имя тип = значение
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pfx">Префикс, по умолчанию @</param>
        /// <returns>Sql-определение параметра: [префикс]имя тип[(размерность)] = значение (в т.ч. null). Для дат/времени - в виде строки 'yyyyMMdd hh:mm:ss'</returns>
        public static string GetSqlDeclare(this SqlParameter p, string pfx = "@") {
            SqlDbType[] typeNum = {
                  SqlDbType.BigInt
                , SqlDbType.Bit
                , SqlDbType.Decimal
                , SqlDbType.Float
                , SqlDbType.Int
                , SqlDbType.Money
                , SqlDbType.Real
                , SqlDbType.SmallInt
                , SqlDbType.SmallMoney };

            string type = p.SqlDbType.ToString().ToLower();

            if (type.Contains("char") && p.Size > 0)
                type += $"({p.Size})";
            if (type == "decimal" && (p.Precision > 0 || p.Scale > 0))
                type += $"({p.Precision},{p.Scale})";

            string value = p.Value == null || p.Value == DBNull.Value ? "null" 
                : typeNum.Contains(p.SqlDbType) ? p.SqlValue.ToString()
                : p.Value is DateTime ? $"'{((DateTime)p.Value).ToString("yyyyMMdd hh:mm:ss")}'"
                : $"'{p.SqlValue}'";

            return $"{pfx}{p.ParameterName} {type} = {value}";
        }

        /// <summary>Вернуть значение объекта для использования при формировании скрипта</summary>
        public static string ToSqlValue(this object o) {
            string value = o == null || o.Equals(DBNull.Value) ? "null"
                : o is string || o is char ? $"'{o}'"
                : o is bool ? ((bool)o ? "1" : "0")
                : o is DateTime ? $"'{((DateTime)o).ToString("yyyyMMdd hh:mm:ss")}'"
                : o.ToString();

            return value;
        }

        #region Расширения для Control

        /// <summary>Получить список контролов указанного типа из контейнера (с учетом вложенных контейнеров)</summary>
        public static List<T> GetControls<T>(this Control c) where T : Control {
            List<T> res = new List<T>();
            if (c == null)
                return res;
            foreach (Control item in c.Controls) {
                if (item is T)
                    res.Add((T)item);
                res.AddRange(GetControls<T>(item));
            }
            return res;
        }

        /// <summary>Находит контрол в контейнере (с учетом вложенных контейнеров) по имени контрола или связанного поля (из указанного или любого объекта)</summary>
        /// <param name="name">Имя контрола или имя поля, связанного с контролом</param>
        /// <param name="onBinding">Искать по имени связанного поля</param>
        /// <param name="dataSource">Объект-источник привязки (по умолчанию любой)</param>
        /// <param name="type">Тип контрола (по умолчанию любой)</param>
        public static Control GetControl(this Control c, string name, bool onBinding = false, object dataSource = null, Type type = null) {
            Control res = null;
            if (c == null || string.IsNullOrEmpty(name))
                return res;
            foreach (Control item in c.Controls) {
                res = (((!onBinding && item.Name == name)
                        || (onBinding && item.DataBindings != null && item.DataBindings.Count > 0
                            && (item.DataBindings[0].DataSource == dataSource
                                || (item.DataBindings[0].DataSource is BindingSource && ((BindingSource)item.DataBindings[0].DataSource).DataSource == dataSource)
                                || dataSource == null)
                            && item.DataBindings[0].BindingMemberInfo.BindingField == name))
                      && (item.GetType() == type || type == null)) ? item : GetControl(item, name, onBinding, dataSource, type);
                if (res != null)
                    break;
            }
            return res;
        }

        /// <summary>Выполнение метода для каждого контрола контейнера (с учетом вложенных контейнеров)</summary>
        /// <param name="doIt">Метод</param>
        /// <param name="type">Тип контрола (по умолчанию любой)</param>
        public static void ForControls(this Control c, Action<Control> doIt, Type type = null) {
            if (c == null || doIt == null)
                return;
            foreach (Control item in c.Controls) {
                if (item.GetType() == type || type == null)
                    doIt(item);
                ForControls(item, doIt, type);
            }
        }

        #endregion

        #region Расширения для DataGridView

        /// <summary>Установить/снять DoubleBuffered</summary>
        public static void SetDoubleBuffered(this DataGridView dgv, bool value) {
            //BindingFlags bFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            //dgv.GetType().GetProperty("DoubleBuffered", bFlags).SetValue(dgv, value, null);
            dgv.SetNonPublicProperty("DoubleBuffered", value);
        }

        /// <summary>Выполнить метод на ячейке грида (например для использования в обработке DoubleClick)</summary>
        /// <param name="grid"></param>
        /// <param name="doIt">Метод с параметром для этого грида</param>
        public static void DoubleClickCell(this DataGridView grid, Action<DataGridView> doIt) {
            var p = grid.PointToClient(Control.MousePosition);
            if (grid.HitTest(p.X, p.Y).Type == DataGridViewHitTestType.Cell)
                doIt(grid);
        }

        /// <summary>Выдать данные в эксель</summary>
        public static void ToExcel(this DataGridView dg, int maxRows = 1000000) { 
            List<DataGridViewColumn> cols = dg.Columns.OfType<DataGridViewColumn>().Where(x => x.Visible).OrderBy(o => o.DisplayIndex).ToList();
            int colCnt = cols.Count;

            if (colCnt == 0) return;

            if (maxRows > 0 && dg.RowCount > maxRows) // ограничение, чтобы не подвешивать надолго
                Loger.SendMess(string.Format("Максимальное количество строк для выдачи в Excel = {0}", maxRows));
            else
                maxRows = dg.RowCount;

            object[,] data = new object[maxRows, colCnt];

            Form f = dg.FindForm();
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlsApp = null;
            Excel.Workbook xlsWb = null;
            Excel.Worksheet ws = null;
            Excel.Range rg = null;
            try {
                xlsApp = new Excel.Application();
                xlsApp.Visible = false;
                xlsApp.ScreenUpdating = false;
                xlsWb = xlsApp.Workbooks.Add();
                xlsApp.Calculation = Excel.XlCalculation.xlCalculationManual;
                ws = (Excel.Worksheet)xlsWb.Worksheets.Add();
                Excel.Range cell = ws.get_Range("A1");

                //----- caps
                string[] caps = new string[colCnt];
                for (int c = 0; c < colCnt; c++)
                    caps[c] = cols[c].HeaderText;
                rg = ws.get_Range(cell, cell.get_Offset(0, colCnt - 1));
                rg.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, caps);
                rg.Font.Bold = true;
                rg.HorizontalAlignment = Excel.Constants.xlCenter;
                cell = cell.get_Offset(1, 0);

                //----- data
                object cellValue;
                decimal tmpDec;
                for (int r = 0; r < data.GetLength(0); r++)
                    for (int c = 0; c < colCnt; c++) {
                        cellValue = dg.Rows[r].Cells[cols[c].Index].Value;
                        if (cellValue is Guid)
                            data[r, c] = cellValue.ToString();
                        // не дать строке, содержащей число длиной > 11, преобразоваться к экспотенциальному виду
                        else if (cellValue is string && (cellValue as string).Length > 11 && decimal.TryParse((cellValue as string), out tmpDec))
                            data[r, c] = $"'{cellValue}";
                        else
                            data[r, c] = cellValue;
                    }

                rg = ws.get_Range(cell, cell.get_Offset(maxRows - 1, colCnt - 1));
                rg.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, data);

                ws.UsedRange.Columns.AutoFit();
                xlsApp.ScreenUpdating = true;
                xlsApp.Visible = true;
            }
            catch (Exception) {
                if (xlsWb != null && xlsApp.Workbooks.Count > 0)
                    xlsWb.Close(false);
                if (xlsApp != null) xlsApp.Quit();
                throw;
            }
            finally {
                ReleaseCom(ref rg);
                ReleaseCom(ref ws);
                ReleaseCom(ref xlsWb);
                ReleaseCom(ref xlsApp);
                Cursor.Current = Cursors.Default;
            }
        }

        static void ReleaseCom<T>(T o) where T : class {
            ReleaseCom(ref o);
        }
        static void ReleaseCom<T>(ref T o) where T : class {
            if (o != null) {
                Marshal.FinalReleaseComObject(o);
                o = null;
                GC.Collect();
            }
        }

        #endregion

        /// <summary>Выгрузка коллекций объектов в Excel (по листам)
        /// </summary>
        /// <param name="collections">массив коллекций объектов - по количеству листов</param>
        /// <param name="patternFile">путь к файлу-шаблону</param>
        public static void CollectionsToExcel(this IEnumerable<object>[] collections, string patternFile = null, string[] headers = null, string[] footers = null) {
            Excel.Application xls = null;
            Excel.Workbook wb = null, wbPatt = null;
            Excel.Worksheet ws = null, wsPatt = null;

            try {
                xls = new Excel.Application();
                xls.Visible = false;
                xls.ScreenUpdating = false;
                wb = xls.Workbooks.Add();
                xls.Calculation = Excel.XlCalculation.xlCalculationManual;

                if (File.Exists(patternFile)) {
                    wbPatt = xls.Workbooks.Open(patternFile);
                    if (wbPatt == null)
                        throw new Exception($"Невозможно обработать файл шаблона \"{patternFile}\"");
                    ws = (Excel.Worksheet)wb.Worksheets.Add();
                    for (int i = 1; i <= wbPatt.Worksheets.Count; i++) {
                        if (i > collections.Length)
                            break;
                        wbPatt.Worksheets[i].Copy(ws);
                    }
                    wbPatt.Close(false);
                } else if (!string.IsNullOrWhiteSpace(patternFile))
                    Loger.SendMess($"Не найден файл шаблона \"{patternFile}\"");

                var c = wb.Worksheets.Count;
                for (int i = c; i > collections.Length; i--) 
                    wb.Worksheets[i].Delete();

                for (int i = 0; i < collections.Length; i++) {
                    if (i + 1 > wb.Worksheets.Count)
                        ws = (Excel.Worksheet)wb.Worksheets.Add();
                    else
                        ws = wb.Worksheets[i + 1];
                    CollectionToExcelSheet(collections[i], ws, headers?[i], footers?[i]);
                }
                if (wb.Worksheets.Count > 0)
                    wb.Worksheets[1].Activate();

                xls.ScreenUpdating = true;
                xls.Visible = true;
            }
            catch (Exception ex) {
                if (wb != null && xls.Workbooks.Count > 0)
                    wb.Close(false);
                if (xls != null) xls.Quit();
                Loger.SendMess(ex, "Ошибка формирования Excel");
            }
            finally {
                ReleaseCom(ref ws);
                ReleaseCom(ref wsPatt);
                ReleaseCom(ref wb);
                ReleaseCom(ref wbPatt);
                ReleaseCom(ref xls);
            }
        }

        // Выдача коллекции объектов на лист Excel
        static void CollectionToExcelSheet(this IEnumerable<object> objects, Excel.Worksheet ws, string header = null, string footer = null) {
            List<object> list = objects.Where(x => x != null).ToList();
            if (list.Count == 0) return;

            var type = list.FirstOrDefault().GetType();
            list = list.Where(x => x.GetType() == type).ToList();
            if (list.Count == 0) return;

            List<PropertyInfo> props = type.GetProperties().ToList();
            int colCnt = props.Count;
            if (colCnt == 0) return;

            object[,] data = new object[list.Count, colCnt];

            Excel.Range rg = null;
            try {
                ws.Activate();
                Excel.Range cell = ws.get_Range("A1");

                bool emptyWs = (ws.UsedRange.Columns.Count == 1 && ws.UsedRange.Rows.Count == 1 && ws.UsedRange.Value2 == null);
                //----- caps - если новый лист
                if (emptyWs) {
                    if (!string.IsNullOrEmpty(header)) {
                        cell.Value2 = header;
                        cell = cell.get_Offset(1, 0);
                    }
                    string[] caps = new string[colCnt];
                    for (int c = 0; c < colCnt; c++)
                        caps[c] = props[c].Name;
                    rg = ws.get_Range(cell, cell.get_Offset(0, colCnt - 1));
                    rg.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, caps);
                    rg.Font.Bold = true;
                    rg.HorizontalAlignment = Excel.Constants.xlCenter;
                    cell = cell.get_Offset(1, 0);
                } else {
                    if (!string.IsNullOrEmpty(header) && (string)cell.Value2 == "header") {
                        cell.Value2 = header;
                    }
                    cell = cell.get_Offset(ws.UsedRange.Rows.Count, 0);
                }

                //----- data
                for (int r = 0; r < data.GetLength(0); r++)
                    for (int c = 0; c < colCnt; c++) {
                        object value = props[c].GetValue(list[r]);
                        if (value is Guid)
                            data[r, c] = value.ToString();
                        else
                            data[r, c] = value;
                    }
                rg = ws.get_Range(cell, cell.get_Offset(data.GetLength(0) - 1, colCnt - 1));
                rg.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, data);

                if (emptyWs) {
                    ws.UsedRange.Columns.WrapText = true;
                    ws.UsedRange.Columns.AutoFit();
                }

                //footer
                if (!string.IsNullOrEmpty(footer)) {
                    cell = cell.get_Offset(data.GetLength(0) + 1, 0);
                    cell.HorizontalAlignment = Excel.Constants.xlLeft;
                    cell.WrapText = false;
                    cell.Value2 = footer;
                }
            }
            finally {
                ReleaseCom(ref rg);
            }
        }
    }
}
