
namespace Bonds {
    partial class FCouponEdit {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCouponEdit));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.code_nsd = new System.Windows.Forms.TextBox();
            this.coupon_number = new Ctrls.NumberBox(this.components);
            this.interest_rate = new Ctrls.NumberBox(this.components);
            this.size = new Ctrls.NumberBox(this.components);
            this.payment_currency = new System.Windows.Forms.ComboBox();
            this.payment_date_calc = new Ctrls.DateTimeBox(this.components);
            this.payment_date_fact = new Ctrls.DateTimeBox(this.components);
            this.action_id = new Ctrls.NumberBox(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coupon_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interest_rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_date_calc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_date_fact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.action_id)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.code_nsd, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.coupon_number, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.interest_rate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.size, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.payment_currency, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.payment_date_calc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.payment_date_fact, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.action_id, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 162);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер купона";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(265, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Код НРД облигации";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата погашения план";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(265, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата погашения факт";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ставка купона";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 27);
            this.label6.TabIndex = 5;
            this.label6.Text = "Размер купона";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(265, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 27);
            this.label7.TabIndex = 6;
            this.label7.Text = "Валюта платежа";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // code_nsd
            // 
            this.code_nsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.code_nsd.Location = new System.Drawing.Point(402, 3);
            this.code_nsd.Name = "code_nsd";
            this.code_nsd.ReadOnly = true;
            this.code_nsd.Size = new System.Drawing.Size(126, 23);
            this.code_nsd.TabIndex = 1;
            // 
            // coupon_number
            // 
            this.coupon_number.DigitsDecimalNumber = ((uint)(0u));
            this.coupon_number.DigitsTotalNumber = ((uint)(5u));
            this.coupon_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coupon_number.Location = new System.Drawing.Point(140, 3);
            this.coupon_number.Name = "coupon_number";
            this.coupon_number.Size = new System.Drawing.Size(119, 23);
            this.coupon_number.TabIndex = 0;
            this.coupon_number.Text = "0";
            this.coupon_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // interest_rate
            // 
            this.interest_rate.DigitsDecimalNumber = ((uint)(10u));
            this.interest_rate.DigitsTotalNumber = ((uint)(28u));
            this.interest_rate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interest_rate.Location = new System.Drawing.Point(140, 57);
            this.interest_rate.Name = "interest_rate";
            this.interest_rate.Size = new System.Drawing.Size(119, 23);
            this.interest_rate.TabIndex = 4;
            this.interest_rate.Text = "0";
            this.interest_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // size
            // 
            this.size.Dock = System.Windows.Forms.DockStyle.Fill;
            this.size.Location = new System.Drawing.Point(140, 84);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(119, 23);
            this.size.TabIndex = 5;
            this.size.Text = "0";
            this.size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // payment_currency
            // 
            this.payment_currency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payment_currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_currency.FormattingEnabled = true;
            this.payment_currency.Location = new System.Drawing.Point(402, 84);
            this.payment_currency.Name = "payment_currency";
            this.payment_currency.Size = new System.Drawing.Size(126, 23);
            this.payment_currency.TabIndex = 6;
            // 
            // payment_date_calc
            // 
            this.payment_date_calc.DefaultDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.payment_date_calc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payment_date_calc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.payment_date_calc.Location = new System.Drawing.Point(140, 30);
            this.payment_date_calc.Name = "payment_date_calc";
            this.payment_date_calc.Size = new System.Drawing.Size(119, 23);
            this.payment_date_calc.TabIndex = 2;
            this.payment_date_calc.Text = "01.01.0001";
            this.payment_date_calc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // payment_date_fact
            // 
            this.payment_date_fact.DefaultDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.payment_date_fact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payment_date_fact.ForeColor = System.Drawing.SystemColors.WindowText;
            this.payment_date_fact.Location = new System.Drawing.Point(402, 30);
            this.payment_date_fact.Name = "payment_date_fact";
            this.payment_date_fact.Size = new System.Drawing.Size(126, 23);
            this.payment_date_fact.TabIndex = 3;
            this.payment_date_fact.Text = "01.01.0001";
            this.payment_date_fact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // action_id
            // 
            this.action_id.Location = new System.Drawing.Point(140, 111);
            this.action_id.Name = "action_id";
            this.action_id.ReadOnly = true;
            this.action_id.Size = new System.Drawing.Size(100, 23);
            this.action_id.TabIndex = 7;
            this.action_id.Text = "0";
            this.action_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FCouponEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CheckCmdCode = "CouponCheck";
            this.ClientSize = new System.Drawing.Size(550, 187);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FocusedControlName = "coupon_number";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.InsertCmdCode = "CouponAdd";
            this.Name = "FCouponEdit";
            this.SelectCmdCode = "CouponEdit";
            this.SelectNewCmdCode = "CouponNewEdit";
            this.Text = "Купон";
            this.UpdateCmdCode = "CouponUpdate";
            this.Load += new System.EventHandler(this.FCouponEdit_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coupon_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interest_rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_date_calc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payment_date_fact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.action_id)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox code_nsd;
        private Ctrls.NumberBox coupon_number;
        private Ctrls.NumberBox interest_rate;
        private Ctrls.NumberBox size;
        private System.Windows.Forms.ComboBox payment_currency;
        private Ctrls.DateTimeBox payment_date_calc;
        private Ctrls.DateTimeBox payment_date_fact;
        private Ctrls.NumberBox action_id;
    }
}