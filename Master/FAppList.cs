using Common;
using Ctrls;
using Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master {
    public partial class FAppList : FormList {
        public FAppList() {
            InitializeComponent();
        }

        private void FAppList_Load(object sender, EventArgs e) {
            SetCommands();
        }

        void SetCommands() {
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "add"), ToolTipText = "Добавить (Ins)", Name = "Add" })
                ].Click += (o, ek) => DoCommands("add");
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "edit"), ToolTipText = "Изменить (Ctrl+Enter)" })
                ].Click += (o, ek) => DoCommands("edit");
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "del"), ToolTipText = "Удалить (Ctrl+Del)" })
                ].Click += (o, ek) => DoCommands("del");

            dataList1.DoubleClick += (o, ek) => dataList1.DoubleClickCell((g) => DoCommands("edit"));

            dataList1.KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("add"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Enter && ea.Modifiers == Keys.Control) { DoCommands("edit"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("del"); ea.Handled = true; }
            };
        }

        void DoCommands(string cm) {
            //delete task
            if (cm == "del") {
                if (dataList1.CurrentRow == null) return;
                ExecCommand(@"delete dm.tApp where code = @code", null, dataList1, warning: $"Удалить {(dataList1.GetRowObject() as DataRow)?["code"]} ?");
            }
            //insert|update task
            if (Regex.IsMatch(cm, "(add|edit)")) {
                var isnew = cm == "add";
                if (!isnew && dataList1.CurrentRow == null) return;
                ExecFormEdit(new FAppEdit(), null, (isnew ? FormModes.NewRecEdit : FormModes.Default), dataList1, "code=code;appcode=appcode");
            }
        }
    }
}
