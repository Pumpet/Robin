using Ctrls;
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
    public partial class FCouponEdit : FormEdit {
        public FCouponEdit() {
            InitializeComponent();
        }

        private void FCouponEdit_Load(object sender, EventArgs e) {
            GetDataToCombo(payment_currency, "code", "select code from currencies order by 1", null);
        }
    }
}
