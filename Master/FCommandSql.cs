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
// Special thanks to Pavel Torgashov for his excellent FastColoredTextBox component!
// https://github.com/PavelTorgashov/FastColoredTextBox
//

using Common;
using Ctrls;
using FastColoredTextBoxNS;
using Manager;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Master {
    public partial class FCommandSql : FormEdit {

        Thread task;
        System.Threading.Timer tim;
        DateTime dt;
        bool taskCancel;
        DataTable dtRes = null;

        SynchronizationContext Sync { get; set; }

        public FCommandSql() {
            InitializeComponent();
        }

        private void FCommandSql_Load(object sender, EventArgs e) {
            Sync = SynchronizationContext.Current;

            tim = new System.Threading.Timer(
                new TimerCallback(o => {
                    var ts = DateTime.Now.Subtract(dt);
                    Sync.Send(x => info2.Text = ts.ToString(@"hh\:mm\:ss"), null);
                }), null, Timeout.Infinite, 1000);
            info1.Text = "";
            info2.Text = "";
            info3.Text = "";

            SelectNewSql = Command.SelectNewSql;
            SelectSql = Command.SelectSql;
            InsertSql = Command.InsertSql;
            UpdateSql = Command.UpdateSql;
            GetDataToCombo(appcode, "appcode", "select appcode = code from robin.tApp union select appcode = '' order by 1", null);

            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "email"), ToolTipText = "Добавить declare @параметр" })
                ].Click += (o, ek) => DeclareParam();
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "exec"), ToolTipText = "Выполнить (Ctrl+E)", Name = "exec" })
                ].Click += (o, ek) => ExecCmdAsync("exec");
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "stop"), ToolTipText = "Остановить (Ctrl+B)", Name = "stop", Enabled = false })
                ].Click += (o, ek) => ExecCmdAsync("stop");
            KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.E && ModifierKeys == Keys.Control) { ExecCmdAsync("exec"); ea.Handled = true; }
                if (ea.KeyCode == Keys.B && ModifierKeys == Keys.Control) { ExecCmdAsync("stop"); ea.Handled = true; }
            };
        }



        private void FCommandSql_FormClosing(object sender, FormClosingEventArgs e) {
            if (taskCancel || (task != null && task.IsAlive)) {
                Loger.SendMess("Дождитесь окончания чтения данных или прервите его!");
                e.Cancel = true;
            }
        }

        private void DeclareParam() {
            var mc = Regex.Matches(cmd.Text, @"\B@\w+").OfType<Match>().Select(x=>x.Value)
                .Except(Regex.Matches(cmdTestHead.Text, @"\B@\w+").OfType<Match>().Select(x => x.Value))
                .Distinct();
            foreach (var m in mc) {
                cmdTestHead.Text = $"{cmdTestHead.Text}\r\ndeclare {m}";
            }
        }

        private void FCommandSql_AfterBinding(object sender, EventArgs e) {
            if (!formModes.HasFlag(FormModes.NewRecEdit)) {
                appcode.Enabled = false;
                //code.ReadOnly = true;
            }
            FillDefault();
        }

        private void FCommandSql_SaveParamsCheck(object sender, ParamsCheckEventArgs e) {
            if (string.IsNullOrWhiteSpace(appcode.Text)) e.CheckResult.Add("appcode", "!!!");
            if (string.IsNullOrWhiteSpace(code.Text)) e.CheckResult.Add("code", "!!!");
            if (string.IsNullOrWhiteSpace(cmd.Text)) e.CheckResult.Add("", "Не задан текст команды!");
        }

        private void FCommandSql_SetData(object sender, ProcessDataEventArgs e) {
            e.Pars["cmdType"] = 0;
        }

        private void FCommandSql_ControlTrigger(object sender, ControlTriggerEventArgs e) {
            //if (e.EventType == CtrlEventType.Leave && (e.Ctrl == cmdTestHead || e.Ctrl == cmd))
            //    FillDefault();
        }

        void FillDefault() {
            if (IsNewRec && string.IsNullOrWhiteSpace(cmdTestHead.Text))
                cmdTestHead.Text = "-- Объявления параметров - только для тестирования команды";
            if (IsNewRec && string.IsNullOrWhiteSpace(cmd.Text))
                cmd.Text = "-- Текст команды для вызова из приложения";
        }

        #region exec sql

        private void ExecCmdAsync(string cm) {
            if (cm == "exec") {
                dataList1.Clear(true);
                Context.GcCollect();

                pnlTools.Items["exec"].Enabled = false;
                pnlTools.Items["stop"].Enabled = true;

                var sql = $"{cmdTestHead.Text}\r\n{new string('-', 80)}\r\n{cmd.Text}";
                taskCancel = false;
                task = new Thread(GetDataTask);
                task.Name = "GetDataTask";
                task.IsBackground = true;

                info1.Text = "Строк: 0";
                info3.Text = "";
                dt = DateTime.Now;
                tim.Change(0, 1000);
                task.Start(sql);
            }
            if (cm == "stop") {
                if (task != null && task.IsAlive) {
                    taskCancel = true;
                    task.Abort();
                    task.Join(0);
                    info3.Text = "Остановка...";
                }
            }
        }

        private void GetDataTask(object sql) {
            Ctx.Conn?.GetTable(sql.ToString(), null, Ctx.Trassa, Sync, ResultRowChange, OnGetTaskResult);
        }

        void ResultRowChange(object sender, DataRowChangeEventArgs e) {
            var cnt = e.Row.Table.Rows.Count;
            if (e.Action == DataRowAction.Commit && cnt % (taskCancel ? 1 : 100) == 0) 
                Sync.Send(OnTaskProgress, cnt);
        }

        void OnTaskProgress(object state) {
            //info1.Text = $"Строк: {state} {(taskCancel ? "Остановка..." : "")}";
            info1.Text = $"Строк: {state}";
        }

        void OnGetTaskResult(object res) {
            try {
                info3.Text = "Выдача...";
                tim.Change(Timeout.Infinite, Timeout.Infinite);
                dtRes = (res as DataTable);
                dataList1.GetData += GetDataToGrid; 
                dataList1.LoadData();
                info1.Text = $"Строк: {dtRes?.Rows.Count}";
                dataList1.GetData -= GetDataToGrid;
                dtRes = null;
                
            }
            catch (Exception e) {
                Loger.SendMess(e, "Ошибка выдачи данных!"); info1.Text =
                info1.Text = "";
            }
            finally {
                OnTaskFinish();
            }
        }

        void GetDataToGrid(object sender, ProcessDataEventArgs e) {
            e.Result = dtRes;
        }

        void OnTaskFinish() {
            tim.Change(Timeout.Infinite, Timeout.Infinite);
            pnlTools.Items["exec"].Enabled = true;
            pnlTools.Items["stop"].Enabled = false;
            taskCancel = false;
            info3.Text = "";
        }


        #endregion

        private void FCommandSql_NewRecInit(object sender, EventArgs e) {
            DataLists.Add(dataList1);
            dataList1.GetData += DataList_GetData;
            dataList1.Visible = dataList1.Enabled = true;
        }

        // обработчики нужны, т.к. FastColoredTextBox почему то не поддерживает Ctrl+Tab | Ctrl+Shift+Tab
        void cmdTestHead_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Control)
                cmd.Focus();
            if (e.KeyCode == Keys.Tab && e.Modifiers == (Keys.Control | Keys.Shift))
                comment.Focus();
        }

        void cmd_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Control)
                dataList1.Focus();
            if (e.KeyCode == Keys.Tab && e.Modifiers == (Keys.Control | Keys.Shift))
                cmdTestHead.Focus();
        }

        private void marker_ExecSelectionForm(object sender, ExecSelectionFormEventArgs e) {
            e.Form = new FMarkerList();
        }
    }
}
