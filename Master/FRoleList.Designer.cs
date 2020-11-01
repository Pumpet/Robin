namespace Master {
    partial class FRoleList {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.app = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listRoles = new Ctrls.DataList();
            this.appcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listUsers = new Ctrls.DataList();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolUsers = new System.Windows.Forms.ToolStrip();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listMarkers = new Ctrls.DataList();
            this.marker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolMarkers = new System.Windows.Forms.ToolStrip();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listRoles)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listUsers)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listMarkers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this.app);
            this.pnlParams.Controls.Add(this.label3);
            this.pnlParams.Size = new System.Drawing.Size(624, 29);
            // 
            // app
            // 
            this.app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.app.FormattingEnabled = true;
            this.app.Location = new System.Drawing.Point(89, 3);
            this.app.Name = "app";
            this.app.Size = new System.Drawing.Size(146, 23);
            this.app.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Приложение";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.miniToolStrip.Size = new System.Drawing.Size(516, 25);
            this.miniToolStrip.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listRoles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(624, 307);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 6;
            // 
            // listRoles
            // 
            this.listRoles.AllowUserToAddRows = false;
            this.listRoles.AllowUserToDeleteRows = false;
            this.listRoles.AllowUserToOrderColumns = true;
            this.listRoles.AutoGenerateColumns = false;
            this.listRoles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listRoles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listRoles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.listRoles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appcode,
            this.code,
            this.note});
            this.listRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRoles.EnableHeadersVisualStyles = false;
            this.listRoles.ExtParamsMap = null;
            this.listRoles.KeyNames = "id";
            this.listRoles.Location = new System.Drawing.Point(0, 0);
            this.listRoles.Name = "listRoles";
            this.listRoles.ParamPanel = this.pnlParams;
            this.listRoles.ParentGrid = null;
            this.listRoles.QueryCmdCode = null;
            this.listRoles.QueryParamsSet = null;
            this.listRoles.QuerySql = null;
            this.listRoles.ReadOnly = true;
            this.listRoles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listRoles.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.listRoles.RowHeadersWidth = 23;
            this.listRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listRoles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listRoles.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.listRoles.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listRoles.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listRoles.Size = new System.Drawing.Size(624, 155);
            this.listRoles.TabIndex = 1;
            // 
            // appcode
            // 
            this.appcode.DataPropertyName = "appcode";
            this.appcode.HeaderText = "Приложение";
            this.appcode.Name = "appcode";
            this.appcode.ReadOnly = true;
            this.appcode.Width = 150;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "Роль";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 150;
            // 
            // note
            // 
            this.note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.note.DataPropertyName = "note";
            this.note.HeaderText = "Описание";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 86;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 148);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listUsers);
            this.tabPage1.Controls.Add(this.toolUsers);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 117);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Пользователи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listUsers
            // 
            this.listUsers.AllowUserToAddRows = false;
            this.listUsers.AllowUserToDeleteRows = false;
            this.listUsers.AllowUserToOrderColumns = true;
            this.listUsers.AutoGenerateColumns = false;
            this.listUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listUsers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.listUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.login,
            this.name});
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.EnableHeadersVisualStyles = false;
            this.listUsers.ExtParamsMap = "roleId=id";
            this.listUsers.KeyNames = "userId";
            this.listUsers.Location = new System.Drawing.Point(29, 3);
            this.listUsers.Name = "listUsers";
            this.listUsers.ParamPanel = null;
            this.listUsers.ParentGrid = this.listRoles;
            this.listUsers.QueryCmdCode = null;
            this.listUsers.QueryParamsSet = null;
            this.listUsers.QuerySql = null;
            this.listUsers.ReadOnly = true;
            this.listUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listUsers.RowHeadersWidth = 23;
            this.listUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listUsers.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.listUsers.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listUsers.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listUsers.Size = new System.Drawing.Size(584, 111);
            this.listUsers.TabIndex = 1;
            // 
            // login
            // 
            this.login.DataPropertyName = "login";
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 200;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Имя пользователя";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // toolUsers
            // 
            this.toolUsers.CanOverflow = false;
            this.toolUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolUsers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolUsers.Location = new System.Drawing.Point(3, 3);
            this.toolUsers.Name = "toolUsers";
            this.toolUsers.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolUsers.Size = new System.Drawing.Size(26, 111);
            this.toolUsers.TabIndex = 0;
            this.toolUsers.Text = "toolStrip1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listMarkers);
            this.tabPage2.Controls.Add(this.toolMarkers);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 117);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Маркеры";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listMarkers
            // 
            this.listMarkers.AllowUserToAddRows = false;
            this.listMarkers.AllowUserToDeleteRows = false;
            this.listMarkers.AllowUserToOrderColumns = true;
            this.listMarkers.AutoGenerateColumns = false;
            this.listMarkers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listMarkers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listMarkers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.listMarkers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listMarkers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.listMarkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listMarkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.marker,
            this._note});
            this.listMarkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMarkers.EnableHeadersVisualStyles = false;
            this.listMarkers.ExtParamsMap = "roleId=id";
            this.listMarkers.KeyNames = "marker";
            this.listMarkers.Location = new System.Drawing.Point(29, 3);
            this.listMarkers.Name = "listMarkers";
            this.listMarkers.ParamPanel = null;
            this.listMarkers.ParentGrid = this.listRoles;
            this.listMarkers.QueryCmdCode = null;
            this.listMarkers.QueryParamsSet = null;
            this.listMarkers.QuerySql = null;
            this.listMarkers.ReadOnly = true;
            this.listMarkers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listMarkers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.listMarkers.RowHeadersWidth = 23;
            this.listMarkers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listMarkers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listMarkers.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.listMarkers.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listMarkers.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listMarkers.Size = new System.Drawing.Size(584, 111);
            this.listMarkers.TabIndex = 0;
            // 
            // marker
            // 
            this.marker.DataPropertyName = "marker";
            this.marker.HeaderText = "Маркер";
            this.marker.Name = "marker";
            this.marker.ReadOnly = true;
            this.marker.Width = 150;
            // 
            // _note
            // 
            this._note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._note.DataPropertyName = "note";
            this._note.HeaderText = "Описание";
            this._note.Name = "_note";
            this._note.ReadOnly = true;
            // 
            // toolMarkers
            // 
            this.toolMarkers.CanOverflow = false;
            this.toolMarkers.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolMarkers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolMarkers.Location = new System.Drawing.Point(3, 3);
            this.toolMarkers.Name = "toolMarkers";
            this.toolMarkers.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolMarkers.Size = new System.Drawing.Size(26, 111);
            this.toolMarkers.TabIndex = 0;
            this.toolMarkers.Text = "toolStrip2";
            // 
            // FRoleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 383);
            this.Controls.Add(this.splitContainer1);
            this.FocusedControlName = "listRoles";
            this.LoadDataWithForm = true;
            this.MinimumSize = new System.Drawing.Size(640, 422);
            this.Name = "FRoleList";
            this.SelectionGridName = "listRoles";
            this.ShowIcon = false;
            this.Text = "Роли";
            this.Load += new System.EventHandler(this.FRoleList_Load);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listRoles)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listUsers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listMarkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox app;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Ctrls.DataList listRoles;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolUsers;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolMarkers;
        private Ctrls.DataList listUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn appcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private Ctrls.DataList listMarkers;
        private System.Windows.Forms.DataGridViewTextBoxColumn marker;
        private System.Windows.Forms.DataGridViewTextBoxColumn _note;
    }
}