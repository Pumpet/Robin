namespace Master {
    partial class FUserList {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listUsers = new Ctrls.DataList();
            this.pnlRoles = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRolesTools = new System.Windows.Forms.ToolStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.app = new System.Windows.Forms.ComboBox();
            this.listRoles = new Ctrls.DataList();
            this.appcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listUsers)).BeginInit();
            this.pnlRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this.app);
            this.pnlParams.Controls.Add(this.label3);
            this.pnlParams.Size = new System.Drawing.Size(608, 29);
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
            this.splitContainer1.Panel1.Controls.Add(this.listUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listRoles);
            this.splitContainer1.Panel2.Controls.Add(this.pnlRoles);
            this.splitContainer1.Size = new System.Drawing.Size(608, 323);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 5;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.login,
            this.name});
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.EnableHeadersVisualStyles = false;
            this.listUsers.ExtParamsMap = null;
            this.listUsers.KeyNames = "id";
            this.listUsers.Location = new System.Drawing.Point(0, 0);
            this.listUsers.Name = "listUsers";
            this.listUsers.ParamPanel = this.pnlParams;
            this.listUsers.ParentGrid = null;
            this.listUsers.QueryCmdCode = null;
            this.listUsers.QueryParamsSet = null;
            this.listUsers.QuerySql = null;
            this.listUsers.ReadOnly = true;
            this.listUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.listUsers.RowHeadersWidth = 23;
            this.listUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listUsers.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.listUsers.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listUsers.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listUsers.Size = new System.Drawing.Size(608, 188);
            this.listUsers.TabIndex = 0;
            // 
            // pnlRoles
            // 
            this.pnlRoles.ColumnCount = 3;
            this.pnlRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlRoles.Controls.Add(this.label1, 0, 0);
            this.pnlRoles.Controls.Add(this.pnlRolesTools, 2, 0);
            this.pnlRoles.Controls.Add(this.label2, 1, 0);
            this.pnlRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoles.Location = new System.Drawing.Point(0, 0);
            this.pnlRoles.Name = "pnlRoles";
            this.pnlRoles.Padding = new System.Windows.Forms.Padding(0, 3, 0, 1);
            this.pnlRoles.RowCount = 1;
            this.pnlRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlRoles.Size = new System.Drawing.Size(608, 29);
            this.pnlRoles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Роли";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRolesTools
            // 
            this.pnlRolesTools.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRolesTools.CanOverflow = false;
            this.pnlRolesTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRolesTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.pnlRolesTools.Location = new System.Drawing.Point(49, 3);
            this.pnlRolesTools.Name = "pnlRolesTools";
            this.pnlRolesTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.pnlRolesTools.Size = new System.Drawing.Size(559, 25);
            this.pnlRolesTools.TabIndex = 1;
            this.pnlRolesTools.Text = "toolStrip1";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(44, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 25);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Приложение";
            // 
            // app
            // 
            this.app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.app.FormattingEnabled = true;
            this.app.Location = new System.Drawing.Point(86, 3);
            this.app.Name = "app";
            this.app.Size = new System.Drawing.Size(146, 23);
            this.app.TabIndex = 1;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appcode,
            this.code,
            this.note});
            this.listRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRoles.EnableHeadersVisualStyles = false;
            this.listRoles.ExtParamsMap = "userId=id";
            this.listRoles.KeyNames = "roleId";
            this.listRoles.Location = new System.Drawing.Point(0, 29);
            this.listRoles.Name = "listRoles";
            this.listRoles.ParamPanel = this.pnlRoles;
            this.listRoles.ParentGrid = this.listUsers;
            this.listRoles.QueryCmdCode = null;
            this.listRoles.QueryParamsSet = null;
            this.listRoles.QuerySql = null;
            this.listRoles.ReadOnly = true;
            this.listRoles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listRoles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listRoles.RowHeadersWidth = 23;
            this.listRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listRoles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listRoles.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.listRoles.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listRoles.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listRoles.Size = new System.Drawing.Size(608, 102);
            this.listRoles.TabIndex = 0;
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
            this.note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.note.DataPropertyName = "note";
            this.note.HeaderText = "Описание";
            this.note.Name = "note";
            this.note.ReadOnly = true;
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
            // FUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 399);
            this.Controls.Add(this.splitContainer1);
            this.FocusedControlName = "listUsers";
            this.LoadDataWithForm = true;
            this.MinimumSize = new System.Drawing.Size(624, 438);
            this.Name = "FUserList";
            this.SelectionGridName = "listUsers";
            this.ShowIcon = false;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.FUserList_Load);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listUsers)).EndInit();
            this.pnlRoles.ResumeLayout(false);
            this.pnlRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Ctrls.DataList listUsers;
        private System.Windows.Forms.TableLayoutPanel pnlRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip pnlRolesTools;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox app;
        private Ctrls.DataList listRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn appcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}