namespace Manager {
    partial class FOpenedForms {
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
            this.listForms = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listForms
            // 
            this.listForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listForms.DisplayMember = "Text";
            this.listForms.FormattingEnabled = true;
            this.listForms.ItemHeight = 15;
            this.listForms.Items.AddRange(new object[] {
            ""});
            this.listForms.Location = new System.Drawing.Point(12, 12);
            this.listForms.Name = "listForms";
            this.listForms.ScrollAlwaysVisible = true;
            this.listForms.Size = new System.Drawing.Size(226, 289);
            this.listForms.TabIndex = 0;
            this.listForms.DoubleClick += new System.EventHandler(this.listForms_DoubleClick);
            // 
            // FOpenedForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 315);
            this.Controls.Add(this.listForms);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(267, 349);
            this.Name = "FOpenedForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите форму:";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FOpenedForms_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listForms;
    }
}