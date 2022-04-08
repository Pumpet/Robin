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
    public partial class FMain : Form {
        public FMain() {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e) {
            var Ctx = Context.Self;
            Text = Ctx.GetAppCaption();
            Ctx.FillMenu(tools);
        }
    }
}
