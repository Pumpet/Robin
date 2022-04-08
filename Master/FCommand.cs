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

using Ctrls;
using Manager;
using System;
using System.Windows.Forms;

namespace Master {
    public partial class FCommand : FormEdit {
        public FCommand() {
            InitializeComponent();
        }

        private void FCommand_Load(object sender, EventArgs e) {
            SelectNewSql = Command.SelectNewSql;
            SelectSql = Command.SelectSql;
            InsertSql = Command.InsertSql;
            UpdateSql = Command.UpdateSql;
            GetDataToCombo(appcode, "appcode", "select appcode = code from robin.tApp union select appcode = '' order by 1", null);
        }

        private void FCommand_AfterBinding(object sender, EventArgs e) {
            rbForm.Checked = (int)SourceRow["cmdType"] == 1;
            rbMet.Checked = !rbForm.Checked;
            lbmet.Visible = rbMet.Checked; nmet.Visible = rbMet.Checked;

            var s = SourceRow["cmd"].ToString().Split(';');
            for (int i = 0; i < s.Length; i++) {
                switch (i) {
                    case 0:
                        nmodul.Text = s[0];
                        break;
                    case 1:
                        var x = s[1].IndexOf('.');
                        if (x > 0) {
                            nspace.Text = s[1].Substring(0, x);
                            nclass.Text = s[1].Substring(x + 1);
                        } else
                            nspace.Text = s[1];
                        break;
                    case 2:
                        nmet.Text = s[2];
                        break;
                    default:
                        break;
                }
            }

            if (!formModes.HasFlag(FormModes.NewRecEdit)) { 
                appcode.Enabled = false;
                //code.ReadOnly = true;
            }

            if (CheckChanges) {
                ((RadioButton)rbMet).CheckedChanged += (o, ea) => Changed = true;
                ((RadioButton)rbForm).CheckedChanged += (o, ea) => Changed = true;
                nmodul.TextChanged += (o, ea) => Changed = true;
                nmet.TextChanged += (o, ea) => Changed = true;
                nclass.TextChanged += (o, ea) => Changed = true;
                nspace.TextChanged += (o, ea) => Changed = true;
            }
        }

        private void FCommand_SaveParamsCheck(object sender, ParamsCheckEventArgs e) {
            if (string.IsNullOrWhiteSpace(appcode.Text)) e.CheckResult.Add("appcode", "!!!");
            if (string.IsNullOrWhiteSpace(code.Text)) e.CheckResult.Add("code", "!!!");
            if (!rbForm.Checked && !rbMet.Checked) e.CheckResult.Add("rbForm", "!!!");
            if (string.IsNullOrWhiteSpace(nmodul.Text)) e.CheckResult.Add("nmodul", "!!!");
            if (string.IsNullOrWhiteSpace(nspace.Text)) e.CheckResult.Add("nspace", "!!!");
            if (string.IsNullOrWhiteSpace(nclass.Text)) e.CheckResult.Add("nclass", "!!!");
            if (string.IsNullOrWhiteSpace(nmet.Text) && rbMet.Checked) e.CheckResult.Add("nmet", "!!!");
        }

        private void FCommand_ControlTrigger(object sender, ControlTriggerEventArgs e) {
            if (e.Ctrl == rbMet && e.EventType == CtrlEventType.StateChange)
                lbmet.Visible = rbMet.Checked; nmet.Visible = rbMet.Checked;
        }

        private void FCommand_SetData(object sender, ProcessDataEventArgs e) {
            e.Pars["cmdType"] = rbForm.Checked ? 1 : 2;
            e.Pars["cmd"] = $"{nmodul.Text.Trim()};{nspace.Text.Trim()}.{nclass.Text.Trim()}{(rbMet.Checked ? $";{nmet.Text.Trim()}" : "")}";
        }

        private void marker_ExecSelectionForm(object sender, ExecSelectionFormEventArgs e) {
            e.Form = new FMarkerList();
        }
    }
}
