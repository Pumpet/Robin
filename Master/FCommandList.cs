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
using System.Data;
using System.Windows.Forms;
using Ctrls;
using Manager;
using Common;
using System.Text.RegularExpressions;

namespace Master {
    public partial class FCommandList : FormList {
        public FCommandList() {
            InitializeComponent();
        }

        void FillCombo() {
            GetDataToCombo(app, "appcode", "select appcode = code from robin.tApp union select appcode = '' order by 1", null);
        }

        void SetCommands() {
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "add"), ToolTipText = "Добавить настройку вызова (Ctrl+Ins)", Name = "Add" })
                ].Click += (o, ek) => DoCommands("add");
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "addsql"), ToolTipText = "Добавить SQL (Ins)" })
                ].Click += (o, ek) => DoCommands("addsql");
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "edit"), ToolTipText = "Изменить (Ctrl+Enter)" })
                ].Click += (o, ek) => DoCommands("edit");
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "del"), ToolTipText = "Удалить (Ctrl+Del)" })
                ].Click += (o, ek) => DoCommands("del");

            dataList1.DoubleClick += (o, ek) => dataList1.DoubleClickCell((g) => DoCommands("edit"));

            KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.Control) { DoCommands("addsql"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("add"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Enter && ea.Modifiers == Keys.Control) { DoCommands("edit"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("del"); ea.Handled = true; }
            };
        }

        private void FCommandList_Load(object sender, EventArgs e) {
            dataList1.QuerySql = @"
                select @app = isnull(ltrim(rtrim(@app)),'')
                declare @types table (id int, typeName varchar(30))
                insert @types values (0, 'sql'), (1, 'form'), (2, 'method')
                select 
                  c.appcode
                , t.typeName
                , c.code 
                , c.cmd
                , c.cmdType
                , c.comment
                , c.cmdTestHead
                , c.marker
                  from robin.tCommand c
                    join @types t on t.id = c.cmdType
                  where (@app = '' or c.appcode = @app)
                    and (@type = '' or t.typeName = @type)
                  order by c.appcode, t.typeName, c.code
            ";

            FillCombo();
            SetCommands();
        }

        private void FCommandList_RefreshList(object sender, RefreshListEventArgs e) {
            FillCombo();
        }

        void DoCommands(string cm) {
            //delete task
            if (cm == "del") {
                if (dataList1.CurrentRow == null) return;
                ExecCommand(@"delete robin.tCommand where code = @code and appcode = @appcode", null, dataList1, warning: $"Удалить {(dataList1.GetRowObject() as DataRow)?["code"]} ?");
            }
            //insert|update task
            if (Regex.IsMatch(cm,"(add|addsql|edit)")) {
                var isnew = (Regex.IsMatch(cm, "(add|addsql)"));
                if (!isnew && dataList1.CurrentRow == null) return;
                var f = (cm == "addsql" || (cm == "edit" && (dataList1.GetRowObject() as DataRow)["cmdType"].Equals(0))) ? new FCommandSql() as Form: new FCommand();
                ExecFormEdit(f, null, (isnew ? FormModes.NewRecEdit : FormModes.Default), dataList1, "code=code;appcode=appcode");
            }
        }

        private void dataList1_WhatsUp(object sender, WhatsUpEventArgs e) {
            //pnlTools.Items["Add"].Enabled = (e.RowObj as DataRow)?["appcode"].ToString() == "Robin";
        }
    }
}
