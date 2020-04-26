namespace Manager
{
  partial class FWait
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
            this.lbMess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbMess
            // 
            this.lbMess.BackColor = System.Drawing.SystemColors.Info;
            this.lbMess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbMess.Location = new System.Drawing.Point(0, 0);
            this.lbMess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMess.Name = "lbMess";
            this.lbMess.Size = new System.Drawing.Size(237, 79);
            this.lbMess.TabIndex = 0;
            this.lbMess.Text = "Что-то происходит... Ждем...";
            this.lbMess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 79);
            this.Controls.Add(this.lbMess);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FWait";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lbMess;
  }
}