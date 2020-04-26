namespace Ctrls {
    partial class FormList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormList));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.pnlStatus = new System.Windows.Forms.StatusStrip();
            this.lbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.pnlTools = new System.Windows.Forms.ToolStrip();
            this.bSelect = new System.Windows.Forms.ToolStripButton();
            this.bRefresh = new System.Windows.Forms.ToolStripButton();
            this.bFind = new System.Windows.Forms.ToolStripButton();
            this.bFilter = new System.Windows.Forms.ToolStripButton();
            this.bSelectCols = new System.Windows.Forms.ToolStripButton();
            this.bToExcel = new System.Windows.Forms.ToolStripButton();
            this.bWin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlStatus.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(484, 237);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(101, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(104, 25);
            this.miniToolStrip.TabIndex = 2;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInfo,
            this.lbRows});
            this.pnlStatus.Location = new System.Drawing.Point(0, 280);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.pnlStatus.Size = new System.Drawing.Size(565, 22);
            this.pnlStatus.TabIndex = 4;
            // 
            // lbInfo
            // 
            this.lbInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(432, 17);
            this.lbInfo.Spring = true;
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRows
            // 
            this.lbRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbRows.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(116, 17);
            this.lbRows.Tag = "";
            this.lbRows.Text = "Строк 0 выделено 0";
            this.lbRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlParams
            // 
            this.pnlParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlParams.Location = new System.Drawing.Point(0, 25);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(565, 29);
            this.pnlParams.TabIndex = 3;
            // 
            // pnlTools
            // 
            this.pnlTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSelect,
            this.bRefresh,
            this.bFind,
            this.bFilter,
            this.bSelectCols,
            this.bToExcel,
            this.bWin,
            this.toolStripSeparator1});
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(565, 25);
            this.pnlTools.TabIndex = 2;
            // 
            // bSelect
            // 
            this.bSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSelect.Image = global::Ctrls.Properties.Resources.select;
            this.bSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(23, 22);
            this.bSelect.Text = "Выбрать";
            this.bSelect.ToolTipText = "Выбрать (Enter)";
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // bRefresh
            // 
            this.bRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bRefresh.Image = global::Ctrls.Properties.Resources.refresh;
            this.bRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(23, 22);
            this.bRefresh.Text = "Обновить";
            this.bRefresh.ToolTipText = "Обновить (F5)\r\n+ Shift - сбросить фильтр и обновить\r\n+ Ctrl - сбросить параметры\r" +
    "\n+ Alt - перейти к параметрам\r\n";
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // bFind
            // 
            this.bFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bFind.Image = global::Ctrls.Properties.Resources.find;
            this.bFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(23, 22);
            this.bFind.Text = "Поиск";
            this.bFind.ToolTipText = "Поиск  по текущему содержимому (Ctrl+F)";
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // bFilter
            // 
            this.bFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bFilter.Image = global::Ctrls.Properties.Resources.filter;
            this.bFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(23, 22);
            this.bFilter.Text = "Фильтр";
            this.bFilter.ToolTipText = "Фильтр по текущему содержимому (Shift+F)";
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // bSelectCols
            // 
            this.bSelectCols.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSelectCols.Image = global::Ctrls.Properties.Resources.selcol;
            this.bSelectCols.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSelectCols.Name = "bSelectCols";
            this.bSelectCols.Size = new System.Drawing.Size(23, 22);
            this.bSelectCols.Text = "Выбор столбцов";
            this.bSelectCols.ToolTipText = "Выбор столбцов (F11)";
            this.bSelectCols.Click += new System.EventHandler(this.bSelectCols_Click);
            // 
            // bToExcel
            // 
            this.bToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bToExcel.Image = global::Ctrls.Properties.Resources.excel;
            this.bToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bToExcel.Name = "bToExcel";
            this.bToExcel.Size = new System.Drawing.Size(23, 22);
            this.bToExcel.Text = "Выгрузить в Excel";
            this.bToExcel.ToolTipText = "Выгрузить в Excel (F12)";
            this.bToExcel.Click += new System.EventHandler(this.bToExcel_Click);
            // 
            // bWin
            // 
            this.bWin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bWin.Image = global::Ctrls.Properties.Resources.windows;
            this.bWin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bWin.Name = "bWin";
            this.bWin.Size = new System.Drawing.Size(23, 22);
            this.bWin.Text = "Управление";
            this.bWin.ToolTipText = resources.GetString("bWin.ToolTipText");
            this.bWin.Click += new System.EventHandler(this.bWin_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // FormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlParams);
            this.Controls.Add(this.pnlTools);
            this.MinimumSize = new System.Drawing.Size(267, 254);
            this.Name = "FormList";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormList_KeyDown);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        public System.Windows.Forms.ToolStrip pnlTools;
        private System.Windows.Forms.ToolStripButton bSelect;
        private System.Windows.Forms.ToolStripButton bRefresh;
        private System.Windows.Forms.ToolStripButton bFind;
        private System.Windows.Forms.ToolStripButton bFilter;
        public System.Windows.Forms.Panel pnlParams;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip pnlStatus;
        private System.Windows.Forms.ToolStripButton bSelectCols;
        private System.Windows.Forms.ToolStripButton bToExcel;
        public System.Windows.Forms.ToolStripStatusLabel lbInfo;
        public System.Windows.Forms.ToolStripStatusLabel lbRows;
        private System.Windows.Forms.ToolStripButton bWin;
    }
}