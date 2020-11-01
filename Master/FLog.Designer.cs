namespace Master {
    partial class FLog {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataList1 = new Ctrls.DataList();
            this.dtFrom = new Ctrls.DateTimeBox(this.components);
            this.dtTo = new Ctrls.DateTimeBox(this.components);
            this._login = new System.Windows.Forms.TextBox();
            this._appcode = new System.Windows.Forms.ComboBox();
            this._mess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this.label5);
            this.pnlParams.Controls.Add(this.label4);
            this.pnlParams.Controls.Add(this.label3);
            this.pnlParams.Controls.Add(this.label2);
            this.pnlParams.Controls.Add(this.label1);
            this.pnlParams.Controls.Add(this._mess);
            this.pnlParams.Controls.Add(this._appcode);
            this.pnlParams.Controls.Add(this._login);
            this.pnlParams.Controls.Add(this.dtTo);
            this.pnlParams.Controls.Add(this.dtFrom);
            this.pnlParams.Size = new System.Drawing.Size(1020, 29);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dt,
            this.login,
            this.appcode,
            this.type,
            this.mess});
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.KeyNames = "dt";
            this.dataList1.Location = new System.Drawing.Point(0, 54);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = this.pnlParams;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = null;
            this.dataList1.QueryParamsSet = null;
            this.dataList1.QuerySql = null;
            this.dataList1.ReadOnly = true;
            this.dataList1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataList1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataList1.RowHeadersWidth = 23;
            this.dataList1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataList1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataList1.SelectedCellFocusedBackColor = System.Drawing.SystemColors.Info;
            this.dataList1.SelectedCellNotFocusedBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataList1.SelectedRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataList1.Size = new System.Drawing.Size(1020, 382);
            this.dataList1.TabIndex = 0;
            // 
            // dtFrom
            // 
            this.dtFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dtFrom.Location = new System.Drawing.Point(58, 3);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.NowOnDefault = true;
            this.dtFrom.Size = new System.Drawing.Size(111, 23);
            this.dtFrom.SqlType = Ctrls.DateTimeSqlType.Datetime;
            this.dtFrom.Style = Ctrls.DateTimeStyle.DateTime;
            this.dtFrom.TabIndex = 0;
            this.dtFrom.Text = "01.01.0001";
            this.dtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dtFrom.ValidateOnLeave = false;
            // 
            // dtTo
            // 
            this.dtTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dtTo.Location = new System.Drawing.Point(196, 3);
            this.dtTo.Name = "dtTo";
            this.dtTo.NowOnDefault = true;
            this.dtTo.Size = new System.Drawing.Size(111, 23);
            this.dtTo.SqlType = Ctrls.DateTimeSqlType.Datetime;
            this.dtTo.Style = Ctrls.DateTimeStyle.DateTime;
            this.dtTo.TabIndex = 1;
            this.dtTo.Text = "01.01.0001";
            this.dtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dtTo.ValidateOnLeave = false;
            // 
            // _login
            // 
            this._login.Location = new System.Drawing.Point(354, 3);
            this._login.Name = "_login";
            this._login.Size = new System.Drawing.Size(154, 23);
            this._login.TabIndex = 2;
            // 
            // _appcode
            // 
            this._appcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._appcode.FormattingEnabled = true;
            this._appcode.Location = new System.Drawing.Point(593, 3);
            this._appcode.Name = "_appcode";
            this._appcode.Size = new System.Drawing.Size(121, 23);
            this._appcode.TabIndex = 3;
            // 
            // _mess
            // 
            this._mess.Location = new System.Drawing.Point(793, 3);
            this._mess.Name = "_mess";
            this._mess.Size = new System.Drawing.Size(219, 23);
            this._mess.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Время с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "по";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Приложение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(717, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Сообщение";
            // 
            // dt
            // 
            this.dt.DataPropertyName = "dt";
            dataGridViewCellStyle5.Format = "dd.MM.yyyy HH:mm:ss.fff";
            this.dt.DefaultCellStyle = dataGridViewCellStyle5;
            this.dt.HeaderText = "Время";
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.Width = 150;
            // 
            // login
            // 
            this.login.DataPropertyName = "login";
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 200;
            // 
            // appcode
            // 
            this.appcode.DataPropertyName = "appcode";
            this.appcode.HeaderText = "Приложение";
            this.appcode.Name = "appcode";
            this.appcode.ReadOnly = true;
            this.appcode.Width = 150;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "Тип";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // mess
            // 
            this.mess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mess.DataPropertyName = "mess";
            this.mess.HeaderText = "Сообщение";
            this.mess.Name = "mess";
            this.mess.ReadOnly = true;
            // 
            // FLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 458);
            this.Controls.Add(this.dataList1);
            this.MinimumSize = new System.Drawing.Size(1036, 497);
            this.Name = "FLog";
            this.ShowIcon = false;
            this.Text = "Журнал";
            this.SetUiParamsValuesAfterLoad += new System.EventHandler<Ctrls.FormList.UiParamsEventArgs>(this.FLog_SetUiParamsValuesAfterLoad);
            this.Load += new System.EventHandler(this.FLog_Load);
            this.Controls.SetChildIndex(this.pnlParams, 0);
            this.Controls.SetChildIndex(this.dataList1, 0);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctrls.DataList dataList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _mess;
        private System.Windows.Forms.ComboBox _appcode;
        private System.Windows.Forms.TextBox _login;
        private Ctrls.DateTimeBox dtTo;
        private Ctrls.DateTimeBox dtFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn appcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mess;
    }
}