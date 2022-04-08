using Common;
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
    public partial class FCompList : FormList {

        public FCompList() {
            InitializeComponent();
        }

        private void FCompList_Load(object sender, EventArgs e) {
            FillCombo();
            CreateStandardCommands(pnlTools, dataList1, ExecCommands, StandardCommands.all ^ StandardCommands.addcopy);
        }

        private void FCompList_RefreshList(object sender, RefreshListEventArgs e) {
            FillCombo();
        }

        private void FillCombo() => GetDataToCombo(_comp_type, "comp_type", null, "GetCompTypes");

        private void FCompList_ControlTrigger(object sender, ControlTriggerEventArgs e) {
            if ((e.Ctrl == only_credit_cmp) && e.EventType == CtrlEventType.StateChange)
                LoadGrid();
        }

        private void ExecCommands(string cmd, DataList grid) {
            if (cmd == StandardCommands.add.ToString()) {
                ExecFormEdit(null, "FCompEdit", FormModes.NewRecEdit, grid, "cmp_code_nsd=cmp_code_nsd");
            }
            if (cmd == StandardCommands.edit.ToString() && dataList1.CurrentRow != null) {
                ExecFormEdit(null, "FCompEdit", FormModes.Default, grid, "cmp_code_nsd=cmp_code_nsd");
            }
            if (cmd == StandardCommands.del.ToString() && dataList1.CurrentRow != null) {
                ExecCommand(null, "CompDel", grid, null, null, "Удалить организацию ?", false);
            }
        }
    }
}
