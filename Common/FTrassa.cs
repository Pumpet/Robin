//
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

using System;
using System.Text;
using System.Windows.Forms;

namespace Common {
    public partial class FTrassa : Form {
        public FTrassa() {
            InitializeComponent();
        }

        private void Trassa_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.Enter) {
                var sb = new StringBuilder();
                if (e.Modifiers == Keys.Control) {
                    sb.AppendLine(Clipboard.GetText());
                    sb.AppendLine(new string('-', 80));
                    sb.AppendLine();
                }
                sb.AppendLine(trassa.Text);
                Clipboard.SetText(sb.ToString());
                Close();
            }
        }

        private void FTrassa_Load(object sender, EventArgs e) {
            trassa.Focus();
            trassa.Select(0, 0);
        }
    }
}
