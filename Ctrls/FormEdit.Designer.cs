namespace Ctrls {
    partial class FormEdit {
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
            this.pnlTools = new System.Windows.Forms.ToolStrip();
            this.bSaveClose = new System.Windows.Forms.ToolStripButton();
            this.bUndo = new System.Windows.Forms.ToolStripButton();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTools
            // 
            this.pnlTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSaveClose,
            this.bUndo});
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(565, 25);
            this.pnlTools.TabIndex = 0;
            this.pnlTools.Text = "toolStrip1";
            // 
            // bSaveClose
            // 
            this.bSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSaveClose.Image = global::Ctrls.Properties.Resources.save;
            this.bSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSaveClose.Name = "bSaveClose";
            this.bSaveClose.Size = new System.Drawing.Size(23, 22);
            this.bSaveClose.Text = "Сохранить и закрыть (Ctrl+Enter)";
            this.bSaveClose.ToolTipText = "Сохранить и закрыть (Ctrl+Enter)\r\nСохранить (Ctrl+S)";
            this.bSaveClose.Click += new System.EventHandler(this.bSaveClose_Click);
            // 
            // bUndo
            // 
            this.bUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bUndo.Image = global::Ctrls.Properties.Resources.undo;
            this.bUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUndo.Name = "bUndo";
            this.bUndo.Size = new System.Drawing.Size(23, 22);
            this.bUndo.Text = "Отменить и закрыть (Alt+F4)";
            this.bUndo.Click += new System.EventHandler(this.bUndo_Click);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.pnlTools);
            this.Name = "FormEdit";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEdit_KeyDown);
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip pnlTools;
        private System.Windows.Forms.ToolStripButton bUndo;
        private System.Windows.Forms.ToolStripButton bSaveClose;
    }
}