namespace Common {
    partial class FTrassa {
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
            this.trassa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // trassa
            // 
            this.trassa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trassa.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trassa.Location = new System.Drawing.Point(5, 5);
            this.trassa.Multiline = true;
            this.trassa.Name = "trassa";
            this.trassa.ReadOnly = true;
            this.trassa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.trassa.Size = new System.Drawing.Size(471, 480);
            this.trassa.TabIndex = 0;
            this.trassa.WordWrap = false;
            // 
            // FTrassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 490);
            this.Controls.Add(this.trassa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "FTrassa";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trassa";
            this.Load += new System.EventHandler(this.FTrassa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Trassa_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox trassa;
    }
}