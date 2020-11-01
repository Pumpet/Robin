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
    public partial class FUserList : FormList {
        public FUserList() {
            InitializeComponent();
        }

        private void FUserList_Load(object sender, EventArgs e) {
            if (formModes.HasFlag(FormModes.GetResult)) {
                splitContainer1.Panel2Collapsed = true;
                listUsers.ShowCheckBoxes = true;
                listUsers.AddCheckColumn();
            }

            listUsers.QuerySql = @"
                select @app = isnull(@app,'')
                select distinct u.* 
                    from dm.tUser u 
                        left join (dm.tUserRole ur join dm.tRole r on r.id = ur.roleId)
                            on ur.userId = u.id
                    where (@app = ''
                            or (@app not in ('','(нет)') and r.appcode = @app)
                            or (@app = '(нет)' and not exists(select 1 from dm.tUserRole ur1 where ur1.userId = u.id)))
                    order by u.login
                ";
            listRoles.QuerySql = @"
                select r.appcode, ur.roleId, ur.userId, r.code, r.note
                    from dm.tUserRole ur
                        join dm.tRole r on ur.roleId = r.id
                    where ur.userId = @userId
                    order by r.appcode
                ";
            GetDataToCombo(app, "appcode", "select appcode = code from dm.tApp union select appcode = '(нет)' union select appcode = '' order by 1", null);
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
            pnlRolesTools.Items[
                pnlRolesTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "add"), ToolTipText = "Добавить роли пользователя (Ins)", Name = "AddRoles" })
                ].Click += (o, ek) => DoCommands("addRoles");
            pnlRolesTools.Items[
                pnlRolesTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "del"), ToolTipText = "Удалить роль пользователя (Ctrl+Del)" })
                ].Click += (o, ek) => DoCommands("delRoles");

            if (!formModes.HasFlag(FormModes.GetResult))
                listUsers.DoubleClick += (o, ek) => listUsers.DoubleClickCell((g) => DoCommands("edit"));

            listUsers.KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("add"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Enter && ea.Modifiers == Keys.Control) { DoCommands("edit"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("del"); ea.Handled = true; }
            };

            listRoles.KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("addRoles"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("delRoles"); ea.Handled = true; }
            };
        }

        void DoCommands(string cm) {
            bool ok = false;

            if (cm == "del") {
                if (listUsers.CurrentRow == null) return;
                ok = (ExecCommand(@"delete dm.tUser where id = @id", null, listUsers, warning: $"Удалить {(listUsers.GetRowObject() as DataRow)?["login"]} ?") != null);
            }
            if (cm == "add" || cm == "edit") {
                var isnew = cm == "add";
                if (!isnew && listUsers.CurrentRow == null) return;
                ok = ExecFormEdit(new FUserEdit(), null, (isnew ? FormModes.NewRecEdit : FormModes.Default), listUsers, "id=id");
            }
            if (cm == "delRoles") {
                if (listRoles.CurrentRow == null) return;
                ok = (ExecCommand(@"delete dm.tUserRole where userId = @userId and roleId = @roleId", null, listRoles) != null);
            }
            if (cm == "addRoles") {
                if (listUsers.CurrentRow == null) return;
                ok = ExecFormSelect(new FRoleList(), null, listRoles.GetKey(), "id=roleId", getMulti: true);
                if (ok && Context.Self.TransferObject != null) {
                    var userPars = CtrlsProc.PrepareParams(listUsers.GetKey(), null, "userId=id");
                    var cmd = @"
                        if not exists(select 1 from dm.tUserRole where userID = @userId and roleId = @roleId)
                            insert dm.tUserRole (userId, roleId) values (@userId, @roleId)
                    ";
                    foreach (var row in (Context.Self.TransferObject as List<object>).OfType<DataRow>()) {
                        var pars = CtrlsProc.PrepareParams(row, userPars, "roleId=id");
                        ExecCommand(cmd, null, customParams: pars);
                    }
                    LoadGrid(listRoles);
                }
            }

            if (ok && Ctx.LivingForms.ContainsKey("FMain.FRoleList")) {
                var g = ActiveGrid;
                (Ctx.LivingForms["FMain.FRoleList"] as FormList).LoadGrid();
                g.Focus();
            }
        } 
    }
}
