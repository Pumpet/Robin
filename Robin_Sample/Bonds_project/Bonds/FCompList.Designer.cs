
namespace Bonds {
    partial class FCompList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompList));
            this.dataList1 = new Ctrls.DataList();
            this.cmp_code_nsd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comp_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit_cmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.only_credit_cmp = new System.Windows.Forms.CheckBox();
            this._comp_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._cmp_code_nsd = new System.Windows.Forms.TextBox();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this._cmp_code_nsd);
            this.pnlParams.Controls.Add(this.label3);
            this.pnlParams.Controls.Add(this.label2);
            this.pnlParams.Controls.Add(this._comp_type);
            this.pnlParams.Controls.Add(this.only_credit_cmp);
            this.pnlParams.Controls.Add(this.label1);
            this.pnlParams.Controls.Add(this.name);
            this.pnlParams.Size = new System.Drawing.Size(925, 29);
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
            this.cmp_code_nsd,
            this.full_name,
            this.short_name,
            this.inn,
            this.comp_type,
            this.credit_cmp,
            this.bik});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.InsertCmdCode = null;
            this.dataList1.InsertSql = null;
            this.dataList1.KeyNames = "cmp_code_nsd";
            this.dataList1.Location = new System.Drawing.Point(0, 54);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = this.pnlParams;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = "CompList";
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
            this.dataList1.Size = new System.Drawing.Size(925, 346);
            this.dataList1.TabIndex = 0;
            this.dataList1.UpdateCmdCode = null;
            this.dataList1.UpdateSql = null;
            // 
            // cmp_code_nsd
            // 
            this.cmp_code_nsd.DataPropertyName = "cmp_code_nsd";
            this.cmp_code_nsd.HeaderText = "Код НРД";
            this.cmp_code_nsd.Name = "cmp_code_nsd";
            this.cmp_code_nsd.ReadOnly = true;
            this.cmp_code_nsd.Width = 80;
            // 
            // full_name
            // 
            this.full_name.DataPropertyName = "full_name";
            this.full_name.HeaderText = "Наименование полное";
            this.full_name.Name = "full_name";
            this.full_name.ReadOnly = true;
            this.full_name.Width = 300;
            // 
            // short_name
            // 
            this.short_name.DataPropertyName = "short_name";
            this.short_name.HeaderText = "Наименование краткое";
            this.short_name.Name = "short_name";
            this.short_name.ReadOnly = true;
            this.short_name.Width = 200;
            // 
            // inn
            // 
            this.inn.DataPropertyName = "inn";
            this.inn.HeaderText = "ИНН";
            this.inn.Name = "inn";
            this.inn.ReadOnly = true;
            this.inn.Width = 80;
            // 
            // comp_type
            // 
            this.comp_type.DataPropertyName = "comp_type";
            this.comp_type.HeaderText = "Форма";
            this.comp_type.Name = "comp_type";
            this.comp_type.ReadOnly = true;
            this.comp_type.Width = 80;
            // 
            // credit_cmp
            // 
            this.credit_cmp.DataPropertyName = "credit_cmp";
            this.credit_cmp.HeaderText = "Банк";
            this.credit_cmp.Name = "credit_cmp";
            this.credit_cmp.ReadOnly = true;
            this.credit_cmp.Width = 50;
            // 
            // bik
            // 
            this.bik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.bik.DataPropertyName = "bik";
            this.bik.HeaderText = "БИК";
            this.bik.Name = "bik";
            this.bik.ReadOnly = true;
            this.bik.Width = 54;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(243, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(257, 23);
            this.name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование";
            // 
            // only_credit_cmp
            // 
            this.only_credit_cmp.AutoSize = true;
            this.only_credit_cmp.Location = new System.Drawing.Point(772, 5);
            this.only_credit_cmp.Name = "only_credit_cmp";
            this.only_credit_cmp.Size = new System.Drawing.Size(100, 19);
            this.only_credit_cmp.TabIndex = 2;
            this.only_credit_cmp.Text = "только банки";
            this.only_credit_cmp.UseVisualStyleBackColor = true;
            // 
            // _comp_type
            // 
            this._comp_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comp_type.FormattingEnabled = true;
            this._comp_type.Location = new System.Drawing.Point(642, 3);
            this._comp_type.Name = "_comp_type";
            this._comp_type.Size = new System.Drawing.Size(121, 23);
            this._comp_type.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Форма собственности";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Код НРД";
            // 
            // _cmp_code_nsd
            // 
            this._cmp_code_nsd.Location = new System.Drawing.Point(72, 3);
            this._cmp_code_nsd.Name = "_cmp_code_nsd";
            this._cmp_code_nsd.Size = new System.Drawing.Size(70, 23);
            this._cmp_code_nsd.TabIndex = 7;
            // 
            // FCompList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 422);
            this.Controls.Add(this.dataList1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LoadDataWithForm = true;
            this.Name = "FCompList";
            this.Text = "Эмитенты";
            this.RefreshList += new System.EventHandler<Ctrls.FormList.RefreshListEventArgs>(this.FCompList_RefreshList);
            this.ControlTrigger += new System.EventHandler<Ctrls.FormBase.ControlTriggerEventArgs>(this.FCompList_ControlTrigger);
            this.Load += new System.EventHandler(this.FCompList_Load);
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
        private System.Windows.Forms.ComboBox _comp_type;
        private System.Windows.Forms.CheckBox only_credit_cmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmp_code_nsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn inn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comp_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit_cmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn bik;
        private System.Windows.Forms.TextBox _cmp_code_nsd;
        private System.Windows.Forms.Label label3;
    }
}