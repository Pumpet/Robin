namespace Master {
    partial class FCommandList {
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
            this.dataList1 = new Ctrls.DataList();
            this.app = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdTestHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this.label2);
            this.pnlParams.Controls.Add(this.label1);
            this.pnlParams.Controls.Add(this.type);
            this.pnlParams.Controls.Add(this.app);
            this.pnlParams.Size = new System.Drawing.Size(756, 29);
            // 
            // dataList1
            // 
            this.dataList1.AllowUserToAddRows = false;
            this.dataList1.AllowUserToDeleteRows = false;
            this.dataList1.AllowUserToOrderColumns = true;
            this.dataList1.AutoGenerateColumns = false;
            this.dataList1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataList1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataList1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataList1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appcode,
            this.typeName,
            this.code,
            this.comment,
            this.marker,
            this.cmd,
            this.cmdTestHead});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.KeyNames = "code; appcode";
            this.dataList1.Location = new System.Drawing.Point(0, 54);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = this.pnlParams;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = null;
            this.dataList1.QueryParamsSet = null;
            this.dataList1.QuerySql = null;
            this.dataList1.ReadOnly = true;
            this.dataList1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataList1.RowHeadersWidth = 23;
            this.dataList1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataList1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataList1.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.dataList1.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataList1.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataList1.Size = new System.Drawing.Size(756, 295);
            this.dataList1.TabIndex = 0;
            this.dataList1.WhatsUp += new System.EventHandler<Ctrls.WhatsUpEventArgs>(this.dataList1_WhatsUp);
            // 
            // app
            // 
            this.app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.app.FormattingEnabled = true;
            this.app.Location = new System.Drawing.Point(86, 3);
            this.app.Name = "app";
            this.app.Size = new System.Drawing.Size(121, 23);
            this.app.TabIndex = 0;
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "",
            "sql",
            "form",
            "method"});
            this.type.Location = new System.Drawing.Point(253, 3);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 23);
            this.type.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Приложение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип";
            // 
            // appcode
            // 
            this.appcode.DataPropertyName = "appcode";
            this.appcode.HeaderText = "Приложение";
            this.appcode.Name = "appcode";
            this.appcode.ReadOnly = true;
            // 
            // typeName
            // 
            this.typeName.DataPropertyName = "typeName";
            this.typeName.HeaderText = "Тип";
            this.typeName.Name = "typeName";
            this.typeName.ReadOnly = true;
            this.typeName.Width = 70;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "Код";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 150;
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "Описание";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Width = 150;
            // 
            // marker
            // 
            this.marker.DataPropertyName = "marker";
            this.marker.HeaderText = "Маркер";
            this.marker.Name = "marker";
            this.marker.ReadOnly = true;
            // 
            // cmd
            // 
            this.cmd.DataPropertyName = "cmd";
            this.cmd.HeaderText = "Данные";
            this.cmd.Name = "cmd";
            this.cmd.ReadOnly = true;
            // 
            // cmdTestHead
            // 
            this.cmdTestHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmdTestHead.DataPropertyName = "cmdTestHead";
            this.cmdTestHead.HeaderText = "Параметры для теста";
            this.cmdTestHead.Name = "cmdTestHead";
            this.cmdTestHead.ReadOnly = true;
            this.cmdTestHead.Width = 110;
            // 
            // FCommandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 371);
            this.Controls.Add(this.dataList1);
            this.LoadDataWithForm = true;
            this.Name = "FCommandList";
            this.ShowIcon = false;
            this.Text = "Настройки команд";
            this.RefreshList += new System.EventHandler<Ctrls.FormList.RefreshListEventArgs>(this.FCommandList_RefreshList);
            this.Load += new System.EventHandler(this.FCommandList_Load);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.dataList1, 0);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctrls.DataList dataList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.ComboBox app;
        private System.Windows.Forms.DataGridViewTextBoxColumn appcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn marker;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmdTestHead;
    }
}