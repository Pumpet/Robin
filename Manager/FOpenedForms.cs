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
using System.Windows.Forms;

namespace Manager {
    public partial class FOpenedForms : Form {
        public FOpenedForms(Form[] forms, int idx) {
            InitializeComponent();
            listForms.Items.Clear();
            var oc = new ListBox.ObjectCollection(listForms, forms);
            listForms.Items.AddRange(oc);
            listForms.SelectedIndex = idx;
            listForms.Focus();
        }

        private void FOpenedForms_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) 
                DialogResult = DialogResult.Cancel;
            if (e.KeyCode == Keys.Enter)
                DialogResult = DialogResult.OK;
        }

        private void listForms_DoubleClick(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
    }
}
