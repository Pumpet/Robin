
namespace Bonds {
    partial class FBondList {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBondList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataList1 = new Ctrls.DataList();
            this.code_nsd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec_type_br_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_reg_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_reg_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry_date_calc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comp_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issued_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.face_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_pmt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issue_name_full = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec_form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataList2 = new Ctrls.DataList();
            this.coupon_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__code_nsd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_date_calc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_date_fact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interest_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolsCoupon = new System.Windows.Forms.ToolStrip();
            this.label4 = new System.Windows.Forms.Label();
            this._no_coupon_pmt = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.no_expired = new System.Windows.Forms.CheckBox();
            this.no_coupon_pmt = new System.Windows.Forms.CheckBox();
            this.cmp_code = new Ctrls.SelectBox(this.components);
            this._sec_type_br_code = new System.Windows.Forms.ComboBox();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataList2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this._sec_type_br_code);
            this.pnlParams.Controls.Add(this.cmp_code);
            this.pnlParams.Controls.Add(this.no_coupon_pmt);
            this.pnlParams.Controls.Add(this.no_expired);
            this.pnlParams.Controls.Add(this.label3);
            this.pnlParams.Controls.Add(this.label2);
            this.pnlParams.Controls.Add(this.code);
            this.pnlParams.Controls.Add(this.label1);
            this.pnlParams.Size = new System.Drawing.Size(1032, 29);
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
            this.splitContainer1.Panel1.Controls.Add(this.dataList1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataList2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(1032, 473);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 5;
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
            this.code_nsd,
            this.isin,
            this.sec_type_br_code,
            this.state_reg_number,
            this.state_reg_date,
            this.expiry_date_calc,
            this.issuer,
            this.comp_name,
            this.issued_size,
            this.face_value,
            this.currency_code,
            this.min_pmt_date,
            this.issue_name_full,
            this.sec_form});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.InsertCmdCode = null;
            this.dataList1.InsertSql = null;
            this.dataList1.KeyNames = "code_nsd";
            this.dataList1.Location = new System.Drawing.Point(0, 0);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = this.pnlParams;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = "BondList";
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
            this.dataList1.Size = new System.Drawing.Size(1032, 280);
            this.dataList1.TabIndex = 0;
            this.dataList1.UpdateCmdCode = null;
            this.dataList1.UpdateSql = null;
            // 
            // code_nsd
            // 
            this.code_nsd.DataPropertyName = "code_nsd";
            this.code_nsd.HeaderText = "Код НРД";
            this.code_nsd.Name = "code_nsd";
            this.code_nsd.ReadOnly = true;
            // 
            // isin
            // 
            this.isin.DataPropertyName = "isin";
            this.isin.HeaderText = "Код ISIN";
            this.isin.Name = "isin";
            this.isin.ReadOnly = true;
            // 
            // sec_type_br_code
            // 
            this.sec_type_br_code.DataPropertyName = "sec_type_br_code";
            this.sec_type_br_code.HeaderText = "Тип";
            this.sec_type_br_code.Name = "sec_type_br_code";
            this.sec_type_br_code.ReadOnly = true;
            this.sec_type_br_code.Width = 60;
            // 
            // state_reg_number
            // 
            this.state_reg_number.DataPropertyName = "state_reg_number";
            this.state_reg_number.HeaderText = "Код госрег";
            this.state_reg_number.Name = "state_reg_number";
            this.state_reg_number.ReadOnly = true;
            // 
            // state_reg_date
            // 
            this.state_reg_date.DataPropertyName = "state_reg_date";
            this.state_reg_date.HeaderText = "Дата регистрации";
            this.state_reg_date.Name = "state_reg_date";
            this.state_reg_date.ReadOnly = true;
            // 
            // expiry_date_calc
            // 
            this.expiry_date_calc.DataPropertyName = "expiry_date_calc";
            this.expiry_date_calc.HeaderText = "Дата погашения";
            this.expiry_date_calc.Name = "expiry_date_calc";
            this.expiry_date_calc.ReadOnly = true;
            // 
            // issuer
            // 
            this.issuer.DataPropertyName = "issuer";
            this.issuer.HeaderText = "Код эмитента";
            this.issuer.Name = "issuer";
            this.issuer.ReadOnly = true;
            // 
            // comp_name
            // 
            this.comp_name.DataPropertyName = "comp_name";
            this.comp_name.HeaderText = "Эмитент";
            this.comp_name.Name = "comp_name";
            this.comp_name.ReadOnly = true;
            this.comp_name.Width = 200;
            // 
            // issued_size
            // 
            this.issued_size.DataPropertyName = "issued_size";
            this.issued_size.HeaderText = "Объем выпуска";
            this.issued_size.Name = "issued_size";
            this.issued_size.ReadOnly = true;
            // 
            // face_value
            // 
            this.face_value.DataPropertyName = "face_value";
            this.face_value.HeaderText = "Номинал";
            this.face_value.Name = "face_value";
            this.face_value.ReadOnly = true;
            // 
            // currency_code
            // 
            this.currency_code.DataPropertyName = "currency_code";
            this.currency_code.HeaderText = "Валюта";
            this.currency_code.Name = "currency_code";
            this.currency_code.ReadOnly = true;
            this.currency_code.Width = 70;
            // 
            // min_pmt_date
            // 
            this.min_pmt_date.DataPropertyName = "min_pmt_date";
            this.min_pmt_date.HeaderText = "Непогашен купон за";
            this.min_pmt_date.Name = "min_pmt_date";
            this.min_pmt_date.ReadOnly = true;
            // 
            // issue_name_full
            // 
            this.issue_name_full.DataPropertyName = "issue_name_full";
            this.issue_name_full.HeaderText = "Наименование";
            this.issue_name_full.Name = "issue_name_full";
            this.issue_name_full.ReadOnly = true;
            this.issue_name_full.Width = 200;
            // 
            // sec_form
            // 
            this.sec_form.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.sec_form.DataPropertyName = "sec_form";
            this.sec_form.HeaderText = "Форма";
            this.sec_form.Name = "sec_form";
            this.sec_form.ReadOnly = true;
            this.sec_form.Width = 69;
            // 
            // dataList2
            // 
            this.dataList2.AllowUserToAddRows = false;
            this.dataList2.AllowUserToDeleteRows = false;
            this.dataList2.AllowUserToOrderColumns = true;
            this.dataList2.AutoGenerateColumns = false;
            this.dataList2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataList2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataList2.CheckCmdCode = null;
            this.dataList2.CheckedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataList2.CheckedRowFontColor = System.Drawing.SystemColors.Info;
            this.dataList2.CheckSql = null;
            this.dataList2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataList2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coupon_number,
            this.@__code_nsd,
            this.payment_date_calc,
            this.payment_date_fact,
            this.interest_rate,
            this.size,
            this.payment_currency,
            this.action_id});
            this.dataList2.DisableHighlightChecked = true;
            this.dataList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList2.EnableHeadersVisualStyles = false;
            this.dataList2.ExtParamsMap = "code_nsd=code_nsd";
            this.dataList2.InsertCmdCode = null;
            this.dataList2.InsertSql = null;
            this.dataList2.KeyNames = "action_id";
            this.dataList2.Location = new System.Drawing.Point(0, 29);
            this.dataList2.Name = "dataList2";
            this.dataList2.ParamPanel = this.panel1;
            this.dataList2.ParentGrid = this.dataList1;
            this.dataList2.QueryCmdCode = "CouponBondList";
            this.dataList2.QueryParamsSet = null;
            this.dataList2.QuerySql = null;
            this.dataList2.ReadOnly = true;
            this.dataList2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataList2.RowHeadersWidth = 23;
            this.dataList2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataList2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataList2.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.dataList2.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataList2.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataList2.ShowCheckBoxes = true;
            this.dataList2.Size = new System.Drawing.Size(1032, 160);
            this.dataList2.TabIndex = 0;
            this.dataList2.UpdateCmdCode = null;
            this.dataList2.UpdateSql = null;
            // 
            // coupon_number
            // 
            this.coupon_number.DataPropertyName = "coupon_number";
            this.coupon_number.HeaderText = "Номер";
            this.coupon_number.Name = "coupon_number";
            this.coupon_number.ReadOnly = true;
            // 
            // __code_nsd
            // 
            this.@__code_nsd.DataPropertyName = "code_nsd";
            this.@__code_nsd.HeaderText = "Код НРД";
            this.@__code_nsd.Name = "__code_nsd";
            this.@__code_nsd.ReadOnly = true;
            this.@__code_nsd.Visible = false;
            // 
            // payment_date_calc
            // 
            this.payment_date_calc.DataPropertyName = "payment_date_calc";
            this.payment_date_calc.HeaderText = "Дата план";
            this.payment_date_calc.Name = "payment_date_calc";
            this.payment_date_calc.ReadOnly = true;
            // 
            // payment_date_fact
            // 
            this.payment_date_fact.DataPropertyName = "payment_date_fact";
            this.payment_date_fact.HeaderText = "Дата факт";
            this.payment_date_fact.Name = "payment_date_fact";
            this.payment_date_fact.ReadOnly = true;
            // 
            // interest_rate
            // 
            this.interest_rate.DataPropertyName = "interest_rate";
            this.interest_rate.HeaderText = "Ставка";
            this.interest_rate.Name = "interest_rate";
            this.interest_rate.ReadOnly = true;
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.HeaderText = "Размер";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // payment_currency
            // 
            this.payment_currency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.payment_currency.DataPropertyName = "payment_currency";
            this.payment_currency.HeaderText = "Валюта";
            this.payment_currency.Name = "payment_currency";
            this.payment_currency.ReadOnly = true;
            this.payment_currency.Width = 72;
            // 
            // action_id
            // 
            this.action_id.DataPropertyName = "action_id";
            this.action_id.HeaderText = "action_id";
            this.action_id.Name = "action_id";
            this.action_id.ReadOnly = true;
            this.action_id.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolsCoupon);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._no_coupon_pmt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 29);
            this.panel1.TabIndex = 0;
            // 
            // toolsCoupon
            // 
            this.toolsCoupon.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsCoupon.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsCoupon.Location = new System.Drawing.Point(305, 2);
            this.toolsCoupon.Name = "toolsCoupon";
            this.toolsCoupon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolsCoupon.Size = new System.Drawing.Size(102, 25);
            this.toolsCoupon.TabIndex = 2;
            this.toolsCoupon.Text = "toolStrip1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Купонное расписание";
            // 
            // _no_coupon_pmt
            // 
            this._no_coupon_pmt.AutoSize = true;
            this._no_coupon_pmt.Location = new System.Drawing.Point(146, 4);
            this._no_coupon_pmt.Name = "_no_coupon_pmt";
            this._no_coupon_pmt.Size = new System.Drawing.Size(157, 19);
            this._no_coupon_pmt.TabIndex = 0;
            this._no_coupon_pmt.Text = "только невыплаченные";
            this._no_coupon_pmt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код";
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(45, 3);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(152, 23);
            this.code.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Эмитент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Тип";
            // 
            // no_expired
            // 
            this.no_expired.AutoSize = true;
            this.no_expired.Location = new System.Drawing.Point(577, 5);
            this.no_expired.Name = "no_expired";
            this.no_expired.Size = new System.Drawing.Size(153, 19);
            this.no_expired.TabIndex = 4;
            this.no_expired.Text = "Только непогашенные";
            this.no_expired.UseVisualStyleBackColor = true;
            // 
            // no_coupon_pmt
            // 
            this.no_coupon_pmt.AutoSize = true;
            this.no_coupon_pmt.Location = new System.Drawing.Point(736, 5);
            this.no_coupon_pmt.Name = "no_coupon_pmt";
            this.no_coupon_pmt.Size = new System.Drawing.Size(223, 19);
            this.no_coupon_pmt.TabIndex = 5;
            this.no_coupon_pmt.Text = "Только с невыплаченным купоном";
            this.no_coupon_pmt.UseVisualStyleBackColor = true;
            // 
            // cmp_code
            // 
            this.cmp_code.DropDownHeight = 1;
            this.cmp_code.DropDownWidth = 1;
            this.cmp_code.Editable = true;
            this.cmp_code.FilterMap = null;
            this.cmp_code.FormattingEnabled = true;
            this.cmp_code.IntegralHeight = false;
            this.cmp_code.KeyMap = "cmp_code_nsd=cmp_code";
            this.cmp_code.Location = new System.Drawing.Point(260, 3);
            this.cmp_code.Name = "cmp_code";
            this.cmp_code.Nullable = true;
            this.cmp_code.ResultMap = "cmp_code=cmp_code_nsd";
            this.cmp_code.SelectedObject = null;
            this.cmp_code.SelectedValues = null;
            this.cmp_code.SelectionForm = "FCompList";
            this.cmp_code.Size = new System.Drawing.Size(169, 23);
            this.cmp_code.SourceObject = null;
            this.cmp_code.TabIndex = 6;
            this.cmp_code.TargetObject = null;
            // 
            // _sec_type_br_code
            // 
            this._sec_type_br_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._sec_type_br_code.FormattingEnabled = true;
            this._sec_type_br_code.Location = new System.Drawing.Point(472, 3);
            this._sec_type_br_code.Name = "_sec_type_br_code";
            this._sec_type_br_code.Size = new System.Drawing.Size(94, 23);
            this._sec_type_br_code.TabIndex = 7;
            // 
            // FBondList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 549);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LoadDataWithForm = true;
            this.Name = "FBondList";
            this.Text = "Облигации";
            this.ControlTrigger += new System.EventHandler<Ctrls.FormBase.ControlTriggerEventArgs>(this.FBondList_ControlTrigger);
            this.Load += new System.EventHandler(this.FBondList_Load);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataList2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Ctrls.DataList dataList1;
        private Ctrls.DataList dataList2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _sec_type_br_code;
        private Ctrls.SelectBox cmp_code;
        private System.Windows.Forms.CheckBox no_coupon_pmt;
        private System.Windows.Forms.CheckBox no_expired;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn code_nsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn isin;
        private System.Windows.Forms.DataGridViewTextBoxColumn sec_type_br_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn state_reg_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn state_reg_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry_date_calc;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuer;
        private System.Windows.Forms.DataGridViewTextBoxColumn comp_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn issued_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn face_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn min_pmt_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn issue_name_full;
        private System.Windows.Forms.DataGridViewTextBoxColumn sec_form;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _no_coupon_pmt;
        private System.Windows.Forms.ToolStrip toolsCoupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn coupon_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn __code_nsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_date_calc;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_date_fact;
        private System.Windows.Forms.DataGridViewTextBoxColumn interest_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn action_id;
    }
}