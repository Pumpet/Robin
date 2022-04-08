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
    public partial class FBondList : FormList {
        public FBondList() {
            InitializeComponent();
        }

        private void FBondList_Load(object sender, EventArgs e) {
            GetDataToCombo(_sec_type_br_code, "code", "select '' as code union select code from sec_types order by 1", null);
            cmp_code.SourceObject = new List<Control> { cmp_code };
            cmp_code.TargetObject = cmp_code.SourceObject;
            CreateStandardCommands(pnlTools, dataList1, ExecCommandBonds, StandardCommands.all ^ StandardCommands.addcopy);
            CreateStandardCommands(toolsCoupon, dataList2, ExecCommandCoupons);

            toolsCoupon.Items[
                toolsCoupon.Items.Add(
                new ToolStripButton() {
                    Name = "pmt",
                    Image = Ctx.GetImage(Ctx.ImgAsmName, "accept"),
                    ToolTipText = "Погасить отмеченные запланированной датой"
                })
            ].Click += (o, ek) => ExecCommandCoupons("pmt", dataList2);
        }

        private void FBondList_ControlTrigger(object sender, ControlTriggerEventArgs e) {
            if ((e.Ctrl == no_coupon_pmt || e.Ctrl == no_expired || e.Ctrl == _sec_type_br_code) && e.EventType == CtrlEventType.StateChange)
                LoadGrid(dataList1);
            if (e.Ctrl == _no_coupon_pmt && e.EventType == CtrlEventType.StateChange)
                LoadGrid(dataList2);
        }

        private void ExecCommandBonds(string cmd, DataList grid) {
            if (cmd == StandardCommands.add.ToString()) {
                ExecFormEdit(null, "FBondEdit", FormModes.NewRecEdit, grid, "code_nsd=code_nsd");
            }
            if (cmd == StandardCommands.edit.ToString() && grid.CurrentRow != null) {
                ExecFormEdit(null, "FBondEdit", FormModes.Default, grid, "code_nsd=code_nsd");
            }
            if (cmd == StandardCommands.del.ToString() && grid.CurrentRow != null) {
                ExecCommand(null, "BondDel", grid, null, null, "Удалить облигацию ?", false);
            }
        }

        private void ExecCommandCoupons(string cmd, DataList grid) {

            if (cmd == StandardCommands.add.ToString() || (cmd == StandardCommands.addcopy.ToString() && grid.CurrentRow != null)) {
                if (dataList1.CurrentRow == null) return;
                var pars = CtrlsProc.PrepareParams(grid.GetRowObject(), CtrlsProc.PrepareParams(dataList1.GetRowObject(), map: "code_nsd=code_nsd"), "action_id=action_id");
                pars["isCopy"] = (cmd == StandardCommands.addcopy.ToString());
                ExecFormEdit(null, "FCouponEdit", FormModes.NewRecEdit, grid, null, pars);
            }
            
            if (cmd == StandardCommands.edit.ToString() && grid.CurrentRow != null) {
                ExecFormEdit(null, "FCouponEdit", FormModes.Default, grid, "action_id=action_id");
            }
            
            if (cmd == StandardCommands.del.ToString() && grid.GetCheckedRowsIdx().Count > 0) {
                ExecCommand(null, "CouponDel", grid, null, null, "Удалить отмеченные купоны ?", true);
            }

            if (cmd == "pmt" && grid.GetCheckedRowsIdx().Count > 0) {
                var k = grid.GetKey();
                ExecCommand(null, "CouponPmt", grid, null, null, "Погасить отмеченные купоны запланированной датой?", true);
                LoadGrid(dataList1);
                LoadGrid(dataList2, k);
            }
        }

    }
}
