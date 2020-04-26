using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Ctrls;

namespace Master {
    public partial class FConnect : FormList {
        public FConnect() {
            InitializeComponent();
            pnlParams.Visible = false;
            pnlTools.Visible = false;
        }

        private void FConnect_SelectClick(object sender, SelectFromListEventArgs e) {
            var res = dataList1.GetRowObject();
            var connStr = (string)res?.GetType().GetProperty("connStr").GetValue(res);
            var conn = new SqlConnection(connStr);
            if (!Ctx.CheckConnection(conn)) {
                e.Handled = true;
                DialogResult = DialogResult.Cancel;
            } else {
                Ctx.Conn = conn;
                e.SelectedObject = connStr;
                DialogResult = DialogResult.OK;
            }
        }

        private void FConnect_RefreshList(object sender, RefreshListEventArgs e) {
            //
        }
    }
}
