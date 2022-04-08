namespace Master {
    partial class FCommandSql {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCommandSql));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.marker = new Ctrls.SelectBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.appcode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.StatusStrip();
            this.info2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.info1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.info3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmdTestHead = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cmd = new FastColoredTextBoxNS.FastColoredTextBox();
            this.dataList1 = new Ctrls.DataList();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdTestHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 91);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.Controls.Add(this.marker, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.code, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.appcode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 91);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // marker
            // 
            this.marker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marker.DropDownHeight = 1;
            this.marker.DropDownWidth = 1;
            this.marker.FilterMap = null;
            this.marker.FormattingEnabled = true;
            this.marker.IntegralHeight = false;
            this.marker.KeyMap = "code=marker";
            this.marker.Location = new System.Drawing.Point(93, 57);
            this.marker.Name = "marker";
            this.marker.Nullable = true;
            this.marker.ResultMap = "marker=code";
            this.marker.SelectedObject = null;
            this.marker.SelectedValues = null;
            this.marker.SelectionForm = null;
            this.marker.Size = new System.Drawing.Size(196, 23);
            this.marker.SourceObject = null;
            this.marker.TabIndex = 16;
            this.marker.TargetObject = null;
            this.marker.ExecSelectionForm += new System.EventHandler<Ctrls.ExecSelectionFormEventArgs>(this.marker_ExecSelectionForm);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 27);
            this.label7.TabIndex = 15;
            this.label7.Text = "Маркер";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comment
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comment, 3);
            this.comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comment.Location = new System.Drawing.Point(93, 30);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(492, 23);
            this.comment.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 27);
            this.label8.TabIndex = 4;
            this.label8.Text = "Описание";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // code
            // 
            this.code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.code.Location = new System.Drawing.Point(336, 3);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(249, 23);
            this.code.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(295, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Код";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // appcode
            // 
            this.appcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appcode.FormattingEnabled = true;
            this.appcode.Location = new System.Drawing.Point(93, 3);
            this.appcode.Name = "appcode";
            this.appcode.Size = new System.Drawing.Size(196, 23);
            this.appcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Приложение";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // info
            // 
            this.info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info2,
            this.info1,
            this.info3});
            this.info.Location = new System.Drawing.Point(0, 438);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(599, 24);
            this.info.TabIndex = 0;
            this.info.Text = "statusStrip1";
            // 
            // info2
            // 
            this.info2.Name = "info2";
            this.info2.Size = new System.Drawing.Size(34, 19);
            this.info2.Text = "info2";
            // 
            // info1
            // 
            this.info1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.info1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(38, 19);
            this.info1.Text = "info1";
            // 
            // info3
            // 
            this.info3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.info3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.info3.Name = "info3";
            this.info3.Size = new System.Drawing.Size(38, 19);
            this.info3.Text = "info3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 116);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataList1);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(599, 322);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmdTestHead);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.splitContainer2.Panel1MinSize = 50;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cmd);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.splitContainer2.Panel2MinSize = 100;
            this.splitContainer2.Size = new System.Drawing.Size(599, 235);
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // cmdTestHead
            // 
            this.cmdTestHead.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.cmdTestHead.AutoIndentCharsPatterns = "";
            this.cmdTestHead.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.cmdTestHead.BackBrush = null;
            this.cmdTestHead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cmdTestHead.CharHeight = 15;
            this.cmdTestHead.CharWidth = 7;
            this.cmdTestHead.CommentPrefix = "--";
            this.cmdTestHead.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmdTestHead.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmdTestHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdTestHead.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cmdTestHead.IsReplaceMode = false;
            this.cmdTestHead.Language = FastColoredTextBoxNS.Language.SQL;
            this.cmdTestHead.LeftBracket = '(';
            this.cmdTestHead.Location = new System.Drawing.Point(8, 0);
            this.cmdTestHead.Name = "cmdTestHead";
            this.cmdTestHead.Paddings = new System.Windows.Forms.Padding(0);
            this.cmdTestHead.RightBracket = ')';
            this.cmdTestHead.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.cmdTestHead.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cmdTestHead.ServiceColors")));
            this.cmdTestHead.Size = new System.Drawing.Size(583, 50);
            this.cmdTestHead.TabIndex = 0;
            this.cmdTestHead.TabLength = 2;
            this.cmdTestHead.Zoom = 100;
            this.cmdTestHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdTestHead_KeyDown);
            // 
            // cmd
            // 
            this.cmd.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.cmd.AutoIndentCharsPatterns = "";
            this.cmd.AutoIndentExistingLines = false;
            this.cmd.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.cmd.BackBrush = null;
            this.cmd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cmd.CharHeight = 15;
            this.cmd.CharWidth = 7;
            this.cmd.CommentPrefix = "--";
            this.cmd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmd.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cmd.IsReplaceMode = false;
            this.cmd.Language = FastColoredTextBoxNS.Language.SQL;
            this.cmd.LeftBracket = '(';
            this.cmd.Location = new System.Drawing.Point(8, 0);
            this.cmd.Name = "cmd";
            this.cmd.Paddings = new System.Windows.Forms.Padding(0);
            this.cmd.RightBracket = ')';
            this.cmd.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.cmd.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cmd.ServiceColors")));
            this.cmd.Size = new System.Drawing.Size(583, 177);
            this.cmd.TabIndex = 0;
            this.cmd.TabLength = 2;
            this.cmd.Zoom = 100;
            this.cmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmd_KeyDown);
            // 
            // dataList1
            // 
            this.dataList1.AllowUserToAddRows = false;
            this.dataList1.AllowUserToDeleteRows = false;
            this.dataList1.AllowUserToOrderColumns = true;
            this.dataList1.AutoColumns = true;
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
            this.dataList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataList1.EnableHeadersVisualStyles = false;
            this.dataList1.ExtParamsMap = null;
            this.dataList1.InsertCmdCode = null;
            this.dataList1.InsertSql = null;
            this.dataList1.Location = new System.Drawing.Point(0, 0);
            this.dataList1.Name = "dataList1";
            this.dataList1.ParamPanel = null;
            this.dataList1.ParentGrid = null;
            this.dataList1.QueryCmdCode = null;
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
            this.dataList1.Size = new System.Drawing.Size(599, 100);
            this.dataList1.TabIndex = 0;
            this.dataList1.UpdateCmdCode = null;
            this.dataList1.UpdateSql = null;
            // 
            // FCommandSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CheckChanges = true;
            this.ClientSize = new System.Drawing.Size(599, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.info);
            this.Controls.Add(this.panel1);
            this.FocusedControlName = "code";
            this.KeepOpenAfterSave = true;
            this.MinimumSize = new System.Drawing.Size(615, 500);
            this.Name = "FCommandSql";
            this.Text = "Настройка SQL";
            this.AfterBinding += new System.EventHandler<System.EventArgs>(this.FCommandSql_AfterBinding);
            this.NewRecInit += new System.EventHandler<System.EventArgs>(this.FCommandSql_NewRecInit);
            this.SaveParamsCheck += new System.EventHandler<Ctrls.ParamsCheckEventArgs>(this.FCommandSql_SaveParamsCheck);
            this.SetData += new System.EventHandler<Ctrls.ProcessDataEventArgs>(this.FCommandSql_SetData);
            this.ControlTrigger += new System.EventHandler<Ctrls.FormBase.ControlTriggerEventArgs>(this.FCommandSql_ControlTrigger);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCommandSql_FormClosing);
            this.Load += new System.EventHandler(this.FCommandSql_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.info, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdTestHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox appcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.StatusStrip info;
        private System.Windows.Forms.ToolStripStatusLabel info1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FastColoredTextBoxNS.FastColoredTextBox cmdTestHead;
        private FastColoredTextBoxNS.FastColoredTextBox cmd;
        private Ctrls.DataList dataList1;
        private System.Windows.Forms.ToolStripStatusLabel info2;
        private System.Windows.Forms.ToolStripStatusLabel info3;
        private Ctrls.SelectBox marker;
        private System.Windows.Forms.Label label7;
    }
}