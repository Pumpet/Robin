namespace Master {
    partial class FMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonConnect,
            this.toolStripDropDownButton1,
            this.toolStripButton4,
            this.toolStripDropDownButton2,
            this.toolStripButton2});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1211, 44);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.Image = global::Master.Properties.Resources.dbconn;
            this.toolStripButtonConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(121, 41);
            this.toolStripButtonConnect.Text = "Подключение";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ToolStripMenuItem33,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton1.Image = global::Master.Properties.Resources.options;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(186, 41);
            this.toolStripDropDownButton1.Text = "Настройки приложений";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Master.Properties.Resources.home;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 38);
            this.toolStripMenuItem1.Text = "Приложения";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem33
            // 
            this.ToolStripMenuItem33.Image = global::Master.Properties.Resources.right;
            this.ToolStripMenuItem33.Name = "ToolStripMenuItem33";
            this.ToolStripMenuItem33.Size = new System.Drawing.Size(215, 38);
            this.ToolStripMenuItem33.Text = "Меню";
            this.ToolStripMenuItem33.Click += new System.EventHandler(this.менюToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Master.Properties.Resources.clasp;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(215, 38);
            this.toolStripMenuItem2.Text = "Команды";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::Master.Properties.Resources.sql;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 38);
            this.toolStripMenuItem3.Text = "Сформировать скрипт";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::Master.Properties.Resources.forms;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(138, 41);
            this.toolStripButton4.Text = "Настройки форм";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripDropDownButton2.Image = global::Master.Properties.Resources.galka;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(98, 41);
            this.toolStripDropDownButton2.Text = "Допуска";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::Master.Properties.Resources.users;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(168, 38);
            this.toolStripMenuItem4.Text = "Пользователи";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::Master.Properties.Resources.role;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(168, 38);
            this.toolStripMenuItem5.Text = "Роли";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Master.Properties.Resources.log;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(87, 41);
            this.toolStripButton2.Text = "Журнал";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 44);
            this.Controls.Add(this.tools);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(11664, 89);
            this.MinimumSize = new System.Drawing.Size(16, 82);
            this.Name = "FMain";
            this.Text = "Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FMain_Shown);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem33;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

