using Ctrls;
using Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonds {
    public partial class FCompEdit : FormEdit {
        public FCompEdit() {
            InitializeComponent();
        }

        private void FCompEdit_Load(object sender, EventArgs e) {
            GetDataToCombo(comp_type, "comp_type", "select distinct comp_type from companies where isnull(ltrim(comp_type),'') <> ''", null);
            cmp_code_nsd.ReadOnly = !formModes.HasFlag(FormModes.NewRecEdit);
        }
    }
}
