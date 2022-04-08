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
    public partial class FBondEdit : FormEdit {
        public FBondEdit() {
            InitializeComponent();
        }

        private void FBondEdit_Load(object sender, EventArgs e) {
            GetDataToCombo(sec_type_br_code, "code", "select code from sec_types order by 1", null);
            GetDataToCombo(currency_code, "code", "select code from currencies order by 1", null);
            GetDataToCombo(sec_form, "sec_form", "select distinct sec_form from securs", null);
            code_nsd.ReadOnly = !formModes.HasFlag(FormModes.NewRecEdit);
        }
    }
}
