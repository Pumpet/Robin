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
    public partial class FRoleList : FormList {
        public FRoleList() {
            InitializeComponent();
        }

        private void FRoleList_Load(object sender, EventArgs e) {
            if (!DesignMode) {
                if (formModes.HasFlag(FormModes.GetResult)) {
                    splitContainer1.Panel2Collapsed = true;
                    listRoles.ShowCheckBoxes = true;
                    listRoles.AddCheckColumn();
                }
                listRoles.QuerySql = @"
                select @app = isnull(@app,'')
                select r.*
                    from robin.tRole r
                    where @app = '' or (@app <> '' and r.appcode = @app)
                    order by r.appcode
                ";
                listUsers.QuerySql = @"
                select distinct ur.userId, ur.roleId, u.login, u.name
                    from robin.tUserRole ur
                        join robin.tUser u on u.id = ur.userId
                    where ur.roleId = @roleId
                    order by u.login
                ";
                listMarkers.QuerySql = @"
                select distinct rm.roleId, rm.marker, m.note
                    from robin.tRoleMarker rm
                        join robin.tMarker m on m.code = rm.marker
                    where rm.roleId = @roleId
                    order by rm.marker
                ";

                GetDataToCombo(app, "appcode", "select appcode = code from robin.tApp union select appcode = '' order by 1", null);
                SetCommands();
            }
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
            toolUsers.Items[
                toolUsers.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "add"), ToolTipText = "Добавить пользователей роли (Ins)", Name = "AddRoles" })
                ].Click += (o, ek) => DoCommands("addUsers");
            toolUsers.Items[
                toolUsers.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "del"), ToolTipText = "Удалить пользователей роли (Ctrl+Del)" })
                ].Click += (o, ek) => DoCommands("delUsers");
            toolMarkers.Items[
                toolMarkers.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "add"), ToolTipText = "Привязать маркеры (Ins)", Name = "AddRoles" })
                ].Click += (o, ek) => DoCommands("addMarkers");
            toolMarkers.Items[
                toolMarkers.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "del"), ToolTipText = "Удалить привязки маркеров (Ctrl+Del)" })
                ].Click += (o, ek) => DoCommands("delMarkers");

            if (!formModes.HasFlag(FormModes.GetResult))
                listRoles.DoubleClick += (o, ek) => listRoles.DoubleClickCell((g) => DoCommands("edit"));

            listRoles.KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("add"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Enter && ea.Modifiers == Keys.Control) { DoCommands("edit"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("del"); ea.Handled = true; }
            };

            listUsers.KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("addUsers"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("delUsers"); ea.Handled = true; }
            };

            listMarkers.KeyDown += (o, ea) => {
                if (ea.KeyCode == Keys.Insert && ea.Modifiers == Keys.None) { DoCommands("addMarkers"); ea.Handled = true; }
                if (ea.KeyCode == Keys.Delete && ea.Modifiers == Keys.Control) { DoCommands("delMarkers"); ea.Handled = true; }
            };
        }

        void DoCommands(string cm) {
            bool ok = false;

            if (cm == "del") {
                if (listRoles.CurrentRow == null) return;
                ok = (ExecCommand(@"delete robin.tRole where id = @id", null, listRoles, 
                    warning: $"Удалить роль {(listRoles.GetRowObject() as DataRow)?["code"]} для {(listRoles.GetRowObject() as DataRow)?["appcode"]} ?") != null);
            }
            if (cm == "add" || cm == "edit") {
                var isnew = cm == "add";
                if (!isnew && listRoles.CurrentRow == null) return;
                ok = ExecFormEdit(new FRoleEdit(), null, (isnew ? FormModes.NewRecEdit : FormModes.Default), listRoles, "id=id");
            }
            if (cm == "delUsers") {
                if (listUsers.CurrentRow == null) return;
                ok = (ExecCommand(@"delete robin.tUserRole where userId = @userId and roleId = @roleId", null, listUsers) != null);
            }
            if (cm == "addUsers") {
                if (listRoles.CurrentRow == null) return;
                ok = ExecFormSelect(new FUserList(), null, listUsers.GetKey(), "id=userId", getMulti: true);
                if (ok = Context.Self.TransferObject != null) {
                    var rolePars = CtrlsProc.PrepareParams(listRoles.GetKey(), null, "roleId=id");
                    var cmd = @"
                        if not exists(select 1 from robin.tUserRole where userID = @userId and roleId = @roleId)
                            insert robin.tUserRole (userId, roleId) values (@userId, @roleId)
                    ";
                    foreach (var row in (Context.Self.TransferObject as List<object>).OfType<DataRow>()) {
                        var pars = CtrlsProc.PrepareParams(row, rolePars, "userId=id");
                        ExecCommand(cmd, null, customParams: pars);
                    }
                    LoadGrid(listUsers);
                }
            }
            if (cm == "delMarkers") {
                if (listMarkers.CurrentRow == null) return;
                ExecCommand(@"delete robin.tRoleMarker where marker = @marker and roleId = @roleId", null, listMarkers);
            }
            if (cm == "addMarkers") {
                if (listRoles.CurrentRow == null) return;
                var sel = ExecFormSelect(new FMarkerList(true), null, listMarkers.GetKey(), "code=marker", getMulti: true);

                if (sel && Context.Self.TransferObject != null) {
                    var rolePars = CtrlsProc.PrepareParams(listRoles.GetKey(), null, "roleId=id");
                    var cmd = @"
                        if not exists(select 1 from robin.tRoleMarker where marker = @marker and roleId = @roleId)
                            insert robin.tRoleMarker (marker, roleId) values (@marker, @roleId)
                    ";
                    foreach (var row in (Context.Self.TransferObject as List<object>).OfType<DataRow>()) {
                        var pars = CtrlsProc.PrepareParams(row, rolePars, "marker=code");
                        ExecCommand(cmd, null, customParams: pars);
                    }
                    LoadGrid(listMarkers);
                }
            }


            if (ok && Ctx.LivingForms.ContainsKey("FMain.FUserList")) {
                var g = ActiveGrid;
                (Ctx.LivingForms["FMain.FUserList"] as FormList).LoadGrid();
                g.Focus();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            var g = tabControl1.SelectedTab.Controls.OfType<DataGridView>().FirstOrDefault();
            if (g != null) {
                g.Focus();
                (g as DataList)?.LoadData();
            }
        }
    }
}
