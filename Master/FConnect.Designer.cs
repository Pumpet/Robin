namespace Master {
    partial class FConnect {
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
            this.dataList1 = new Ctrls.DataList();
            this.connStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Size = new System.Drawing.Size(491, 29);
            // 
            // dataList1
            // 
            this.dataList1.AllowUserToAddRows = false;
            this.dataList1.AllowUserToDeleteRows = false;
            this.dataList1.AllowUserToOrderColumns = true;
            this.dataList1.AutoGenerateColumns = false;
            this.dataList1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.connStr});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.KeyNames = "connStr";
            this.dataList1.Location = new System.Drawing.Point(0, 54);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = null;
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
            this.dataList1.Size = new System.Drawing.Size(491, 186);
            this.dataList1.TabIndex = 5;
            // 
            // connStr
            // 
            this.connStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.connStr.DataPropertyName = "connStr";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.connStr.DefaultCellStyle = dataGridViewCellStyle2;
            this.connStr.HeaderText = "Строка подключения";
            this.connStr.Name = "connStr";
            this.connStr.ReadOnly = true;
            this.connStr.Width = 136;
            // 
            // FConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 262);
            this.Controls.Add(this.dataList1);
            this.LoadDataWithForm = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(309, 287);
            this.Name = "FConnect";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Выбор подключения";
            this.SelectFromList += new System.EventHandler<Ctrls.FormList.SelectFromListEventArgs>(this.FConnect_SelectClick);
            this.RefreshList += new System.EventHandler<Ctrls.FormList.RefreshListEventArgs>(this.FConnect_RefreshList);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.dataList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Ctrls.DataList dataList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn connStr;
    }
}