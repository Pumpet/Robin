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
    public partial class FMenuList : FormList {
        public FMenuList() {
            InitializeComponent();
        }

        private void FMenuList_Load(object sender, EventArgs e) {
            GetDataToCombo(app, "appcode", "select appcode = code from robin.tApp order by 1", null);

            dataList1.QuerySql = @"
            ;with menu as (
                select 
                  m.id
                , m.parentId
                , lvl = 0
                , lvlord = convert(varchar(max), '0' + convert(varchar, m.ord) + convert(varchar,m.id))
                from robin.tMenu m
                where m.appcode = @app
                  and m.parentId is null
                union all
                select 
                  m.id
                , m.parentId
                , lvl = t.lvl + 1
                , lvlord = convert(varchar(max), t.lvlord + convert(varchar, t.lvl + 1) + convert(varchar, m.ord) + convert(varchar,m.id))
                from robin.tMenu m
                  join menu t on t.id = m.parentId
            )
            select 
              t.lvl
            , lvlsymb = replicate(nchar(32), t.lvl) + case m.execType when 0 then nchar(9679) else nchar(9658) end
            , m.*
            , p.code as parent
            , t.lvlord
            , execTypeName = case m.execType when 0 then 'меню' else 'группа' end
              from menu t
                  join robin.tMenu m on m.id = t.id
                  left join robin.tMenu p on p.id = m.parentId
              order by t.lvlord
            ";
                
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
            var currRow = (dataList1.GetRowObject() as DataRow);
            if (cm == "del") {
                if (currRow == null) return;
                var cmdDel = @"
                    if exists(select 1 from robin.tMenu where parentId = @id and execType = 1)
                        raiserror('Существуют вложенные группы, удаление невозможно!', 16, 1)
                    else begin
                        delete robin.tMenu where parentId = @id
                        delete robin.tMenu where id = @id
                    end
                ";
                var warDel = $"Удалить {((bool)currRow?["execType"].Equals(1) ? "группу" : "меню")} \"{currRow?["caption"]}\" ?";
                ExecCommand(cmdDel, null, dataList1, warning: warDel);
            }
            //insert|update task
            if (Regex.IsMatch(cm, "(add|edit)")) {
                var isnew = cm == "add";
                if (!isnew && currRow == null) return;
                var pars = CtrlsProc.PrepareParams(currRow, CtrlsProc.PrepareParams(uiParams[dataList1], null, "appcode=app"), 
                    (currRow?["execType"].Equals(1) ?? false) ? "id=id;parent=code;parentId=id" : "id=id;parent=parent;parentId=parentId");
                ExecFormEdit(new FMenuEdit(), null, (isnew ? FormModes.NewRecEdit : FormModes.Default), dataList1, null, pars);
            }
        }
    }
}
