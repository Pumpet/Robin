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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;
using Ctrls;
using Manager;

namespace Master {
    public partial class FMain : Form {
        Context ctx;
        Action setCaption;
        public FMain() {
            InitializeComponent();
            //setCaption = () => { Text = $"{AppConfig.Prop("AppName") ?? Text} ({ctx.Conn.DataSource}.{ctx.Conn.Database})"; };
            setCaption = () => { Text = ctx.GetAppCaption(); };
        }

        private void FMain_Shown(object sender, EventArgs e) {
            ctx = Context.Self;
            setCaption();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            var cons = AppConfig.GetGroupValues("ConnStrings").Select(x => new { connStr = x }); ;
            var fc = new FConnect();
            fc.dataList1.GetData += (o, ea) => ea.Result = cons;
            if (ctx.ExecForm(fc, null, FormModes.Single | FormModes.Modal | FormModes.GetResult, null, new Dictionary<string, object>() { ["connStr"] = ctx.Conn.ConnectionString })) {
                setCaption();
                foreach (var f in ctx.LivingForms.Values.OfType<FormList>())
                    f.LoadGrid(f.MainGrid);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            ctx.ExecForm(new FFormOptions(), this, FormModes.Single);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ctx.ExecForm(new FAppList(), this, FormModes.Single);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ctx.ExecForm(new FCommandList(), this, FormModes.Single);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var f = new FSaveScript();
            if (f.ShowDialog() == DialogResult.OK && File.Exists(f.ResPath))
            {
                if (MessageBox.Show($"Сформирован скрипт:\r\n{f.ResPath}\r\nОткрыть?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(f.ResPath);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            ctx.ExecForm(new FUserList(), this, FormModes.Single);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) {
            ctx.ExecForm(new FRoleList(), this, FormModes.Single);
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e) {
            ctx.ExecForm(new FMenuList(), this, FormModes.Single);
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            ctx.ExecForm(new FLog(), this, FormModes.Single);
        }
    }
}
