namespace Master
{
    partial class FAppEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logSQL = new System.Windows.Forms.CheckBox();
            this.logAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.caption = new System.Windows.Forms.TextBox();
            this.note = new System.Windows.Forms.TextBox();
            this.checkUserRights = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.logSQL, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.logAll, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.code, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.caption, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.note, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkUserRights, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 261);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // logSQL
            // 
            this.logSQL.AutoSize = true;
            this.logSQL.Location = new System.Drawing.Point(89, 227);
            this.logSQL.Name = "logSQL";
            this.logSQL.Size = new System.Drawing.Size(169, 19);
            this.logSQL.TabIndex = 9;
            this.logSQL.Text = "Записывать SQL в журнал";
            this.logSQL.UseVisualStyleBackColor = true;
            // 
            // logAll
            // 
            this.logAll.AutoSize = true;
            this.logAll.Location = new System.Drawing.Point(89, 200);
            this.logAll.Name = "logAll";
            this.logAll.Size = new System.Drawing.Size(102, 19);
            this.logAll.TabIndex = 8;
            this.logAll.Text = "Вести журнал";
            this.logAll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Заголовок";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(70, 106);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // code
            // 
            this.code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.code.Location = new System.Drawing.Point(89, 13);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(236, 23);
            this.code.TabIndex = 4;
            // 
            // caption
            // 
            this.caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caption.Location = new System.Drawing.Point(89, 40);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(236, 23);
            this.caption.TabIndex = 5;
            // 
            // note
            // 
            this.note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.note.Location = new System.Drawing.Point(89, 67);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(236, 100);
            this.note.TabIndex = 6;
            // 
            // checkUserRights
            // 
            this.checkUserRights.AutoSize = true;
            this.checkUserRights.Location = new System.Drawing.Point(89, 173);
            this.checkUserRights.Name = "checkUserRights";
            this.checkUserRights.Size = new System.Drawing.Size(205, 19);
            this.checkUserRights.TabIndex = 7;
            this.checkUserRights.Text = "Проверять права пользователей";
            this.checkUserRights.UseVisualStyleBackColor = true;
            // 
            // FAppEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CheckChanges = true;
            this.ClientSize = new System.Drawing.Size(346, 286);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ExtParamsMap = "code=code";
            this.KeepOpenAfterSave = true;
            this.MinimumSize = new System.Drawing.Size(362, 249);
            this.Name = "FAppEdit";
            this.ShowIcon = false;
            this.Text = "Приложение";
            this.AfterBinding += new System.EventHandler<System.EventArgs>(this.FAppEdit_AfterBinding);
            this.SaveParamsCheck += new System.EventHandler<Ctrls.ParamsCheckEventArgs>(this.FAppEdit_SaveParamsCheck);
            this.ControlTrigger += new System.EventHandler<Ctrls.FormBase.ControlTriggerEventArgs>(this.FAppEdit_ControlTrigger);
            this.Load += new System.EventHandler(this.FAppEdit_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.TextBox caption;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.CheckBox checkUserRights;
        private System.Windows.Forms.CheckBox logSQL;
        private System.Windows.Forms.CheckBox logAll;
    }
}