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

namespace Master {
    public partial class FMarkerList : FormList {
        public FMarkerList(bool checks = false) {
            InitializeComponent();
            dataList1.ShowCheckBoxes = checks;
        }
    }
}
