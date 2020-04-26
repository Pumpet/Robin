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
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;
using Manager;

namespace Master {
    public partial class FSaveScript : Form {
        Context ctx;
        public string ResPath { get; private set; }
        public FSaveScript() {
            InitializeComponent();
        }

        private void FSaveScript_Shown(object sender, EventArgs e) {
            ctx = Context.Self;
            app.DataSource = ctx.GetTable("select distinct appcode from dm.tCommand order by 1", null);
            app.DisplayMember = "appcode";
            folder.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppConfig.Prop("Path"));
        }

        private void bFolder_Click(object sender, EventArgs e) {
            folderDialog.SelectedPath = folder.Text;
            if (folderDialog.ShowDialog(this) == DialogResult.OK)
                folder.Text = folderDialog.SelectedPath;
        }

        private void bOK_Click(object sender, EventArgs e) {
            if (!Directory.Exists(folder.Text)) {
                Loger.SendMess($"Не существует папка {folder.Text}", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(app.Text)) {
                Loger.SendMess($"Не указано приложение", true);
                return;
            }
            AppConfig.config.Props[AppConfig.config.Props.FindIndex(x => x.Name == "Path")].Value = folder.Text;
            AppConfig.Save();

            var rows = ctx.GetTableList("select * from dm.tCommand c where c.appcode = @app order by c.cmdType desc, c.code", null, new Dictionary<string, object>() { ["app"] = app.Text });
            var cmds = rows.Select(x => new Command() {
                Code = (string)x["code"],
                Appcode = (string)x["appcode"],
                CmdType = (int)x["cmdType"],
                Cmd = (string)x["cmd"],
                CmdTestHead = !x["cmdTestHead"].Equals(DBNull.Value) ? (string)x["cmdTestHead"] : null,
                Comment = !x["comment"].Equals(DBNull.Value) ? (string)x["comment"] : null
            }).AsEnumerable();

            var comment = $"{ctx.Conn.DataSource}.{ctx.Conn.Database} {this.comment.Text}";
            var file = $"{app.Text} {DateTime.Now.ToString("yyyyMMdd_HHmmss")} {comment}".Trim();
            file = Regex.Replace(file, @"\s+", "_"); ;
            Path.GetInvalidFileNameChars().ToList().ForEach(x => file = file.Replace(x, '_'));

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder.Text, $"{file}.sql");

            if (Command.SaveScript(cmds, path, comment)) {
                ResPath = path;
                DialogResult = DialogResult.OK;
            }
        }

        private void FSaveScript_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
            if (e.KeyCode == Keys.Enter)
                bSave.PerformClick();
        }   
    }
}
