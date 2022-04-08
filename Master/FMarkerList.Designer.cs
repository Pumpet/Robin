﻿namespace Master {
    partial class FMarkerList {
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
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Size = new System.Drawing.Size(493, 29);
            this.pnlParams.Visible = false;
            // 
            // dataList1
            // 
            this.dataList1.AllowUserToAddRows = false;
            this.dataList1.AllowUserToDeleteRows = false;
            this.dataList1.AllowUserToOrderColumns = true;
            this.dataList1.AutoGenerateColumns = false;
            this.dataList1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataList1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataList1.CheckCmdCode = null;
            this.dataList1.CheckedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataList1.CheckedRowFontColor = System.Drawing.SystemColors.Info;
            this.dataList1.CheckSql = null;
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
            this.code,
            this.note});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.Editable = true;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.InsertCmdCode = null;
            this.dataList1.InsertSql = null;
            this.dataList1.KeyNames = "code";
            this.dataList1.Location = new System.Drawing.Point(0, 54);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = null;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = null;
            this.dataList1.QueryParamsSet = null;
            this.dataList1.QuerySql = "select * from robin.tMarker order by code";
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
            this.dataList1.Size = new System.Drawing.Size(493, 140);
            this.dataList1.TabIndex = 0;
            this.dataList1.UpdateCmdCode = null;
            this.dataList1.UpdateSql = null;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "Код маркера";
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
            // FMarkerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 216);
            this.Controls.Add(this.dataList1);
            this.LoadDataWithForm = true;
            this.Name = "FMarkerList";
            this.ShowIcon = false;
            this.Text = "Маркеры";
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.dataList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        public Ctrls.DataList dataList1;
    }
}