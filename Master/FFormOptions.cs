﻿//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pumpet.net@gmail.com
//  Git: https://github.com/Pumpet/Robin
//  Copyright (C) Alex Rozanov, 2020 
//

using Ctrls;
using System;
using System.Windows.Forms;

namespace Master {
    public partial class FFormOptions : FormList {
        public FFormOptions() {
            InitializeComponent();
        }

        private void FFormOptions_Load(object sender, EventArgs e) {
            pnlTools.Items[
                pnlTools.Items.Add(new ToolStripButton() { Image = Ctx.GetImage(Ctx.ImgAsmName, "del"), ToolTipText = "Удалить (Ctrl+Del)", Name = "del" })
            ].Click += (o, ek) => DoCommands("del");
        }

        private void DoCommands(string cmd) {
            if (cmd == "del")
                ExecCommand("delete from dm.tFormOptions where appcode = @appcode and code = @code", null, dataList1, null, null, "Удалить отмеченные записи ?", true);
        }

        private void dataList1_WhatsUp(object sender, WhatsUpEventArgs e) {
            pnlTools.Items["del"].Enabled = e.CheckedKeys.Count > 0;
        }
    }
}
