namespace Master {
    partial class FSaveScript {
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
            this.app = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bFolder = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // app
            // 
            this.app.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.app.FormattingEnabled = true;
            this.app.Location = new System.Drawing.Point(103, 12);
            this.app.Name = "app";
            this.app.Size = new System.Drawing.Size(214, 21);
            this.app.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Для приложения";
            // 
            // folder
            // 
            this.folder.Location = new System.Drawing.Point(6, 62);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(287, 20);
            this.folder.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сохранить в папку";
            // 
            // bFolder
            // 
            this.bFolder.Location = new System.Drawing.Point(297, 62);
            this.bFolder.Name = "bFolder";
            this.bFolder.Size = new System.Drawing.Size(20, 20);
            this.bFolder.TabIndex = 4;
            this.bFolder.UseVisualStyleBackColor = true;
            this.bFolder.Click += new System.EventHandler(this.bFolder_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(221, 143);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(97, 30);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "Сформировать";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Примечание";
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(6, 111);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(311, 20);
            this.comment.TabIndex = 7;
            // 
            // FSaveScript
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 183);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.folder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.app);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FSaveScript";
            this.ShowInTaskbar = false;
            this.Text = "Сохранить настройки в скрипт";
            this.Shown += new System.EventHandler(this.FSaveScript_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FSaveScript_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox app;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bFolder;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox comment;
    }
}