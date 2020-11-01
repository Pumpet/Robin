namespace Master {
    partial class FMenuList {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.app = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataList1 = new Ctrls.DataList();
            this.lvlsymb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this.app);
            this.pnlParams.Controls.Add(this.label3);
            this.pnlParams.Size = new System.Drawing.Size(821, 29);
            // 
            // app
            // 
            this.app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.app.FormattingEnabled = true;
            this.app.Location = new System.Drawing.Point(88, 3);
            this.app.Name = "app";
            this.app.Size = new System.Drawing.Size(146, 23);
            this.app.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Приложение";
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
            this.lvlsymb,
            this.execTypeName,
            this.ord,
            this.code,
            this.caption,
            this.command,
            this.marker,
            this.img});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.KeyNames = "code;appcode";
            this.dataList1.Location = new System.Drawing.Point(0, 54);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = this.pnlParams;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = null;
            this.dataList1.QueryParamsSet = null;
            this.dataList1.QuerySql = null;
            this.dataList1.ReadOnly = true;
            this.dataList1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataList1.RowHeadersWidth = 23;
            this.dataList1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataList1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataList1.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.dataList1.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataList1.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataList1.Size = new System.Drawing.Size(821, 226);
            this.dataList1.TabIndex = 0;
            // 
            // lvlsymb
            // 
            this.lvlsymb.DataPropertyName = "lvlsymb";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlsymb.DefaultCellStyle = dataGridViewCellStyle2;
            this.lvlsymb.HeaderText = "";
            this.lvlsymb.Name = "lvlsymb";
            this.lvlsymb.ReadOnly = true;
            this.lvlsymb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lvlsymb.Width = 50;
            // 
            // execTypeName
            // 
            this.execTypeName.DataPropertyName = "execTypeName";
            this.execTypeName.HeaderText = "Тип";
            this.execTypeName.Name = "execTypeName";
            this.execTypeName.ReadOnly = true;
            this.execTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.execTypeName.Width = 70;
            // 
            // ord
            // 
            this.ord.DataPropertyName = "ord";
            this.ord.HeaderText = "#";
            this.ord.Name = "ord";
            this.ord.ReadOnly = true;
            this.ord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ord.Width = 50;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "Код";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // caption
            // 
            this.caption.DataPropertyName = "caption";
            this.caption.HeaderText = "Заголовок";
            this.caption.Name = "caption";
            this.caption.ReadOnly = true;
            this.caption.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.caption.Width = 150;
            // 
            // command
            // 
            this.command.DataPropertyName = "command";
            this.command.HeaderText = "Код настройки";
            this.command.Name = "command";
            this.command.ReadOnly = true;
            this.command.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.command.Width = 150;
            // 
            // marker
            // 
            this.marker.DataPropertyName = "marker";
            this.marker.HeaderText = "Маркер";
            this.marker.Name = "marker";
            this.marker.ReadOnly = true;
            this.marker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // img
            // 
            this.img.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.img.DataPropertyName = "img";
            this.img.HeaderText = "Картинка";
            this.img.Name = "img";
            this.img.ReadOnly = true;
            this.img.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FMenuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 302);
            this.Controls.Add(this.dataList1);
            this.LoadDataWithForm = true;
            this.MinimumSize = new System.Drawing.Size(837, 341);
            this.Name = "FMenuList";
            this.ShowIcon = false;
            this.Text = "Настройка меню";
            this.Load += new System.EventHandler(this.FMenuList_Load);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.dataList1, 0);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox app;
        private System.Windows.Forms.Label label3;
        private Ctrls.DataList dataList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lvlsymb;
        private System.Windows.Forms.DataGridViewTextBoxColumn execTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ord;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn caption;
        private System.Windows.Forms.DataGridViewTextBoxColumn command;
        private System.Windows.Forms.DataGridViewTextBoxColumn marker;
        private System.Windows.Forms.DataGridViewTextBoxColumn img;
    }
}