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
    public partial class FRoleEdit : FormEdit {
        public FRoleEdit() {
            InitializeComponent();
        }

        private void FRoleEdit_Load(object sender, EventArgs e) {
            GetDataToCombo(appcode, "appcode", "select appcode = code from robin.tApp order by 1", null);
            SelectNewSql = @"select code = '', appcode = '', note = ''";
            SelectSql = @"select * from robin.tRole where id = @id";
            InsertSql = @"
                insert robin.tRole(code, appcode, note) values (@code, @appcode, @note)
                select id = convert(int,SCOPE_IDENTITY())
                ";
            UpdateSql = @"
                update robin.tRole set code = @code, appcode = @appcode, note = @note where id = @id
                select id = @id
                ";
        }

        private void FRoleEdit_SaveParamsCheck(object sender, ParamsCheckEventArgs e) {
            if (string.IsNullOrWhiteSpace(code.Text)) e.CheckResult.Add("code", "!!!");
            if (string.IsNullOrWhiteSpace(appcode.Text)) e.CheckResult.Add("appcode", "!!!");
            if (string.IsNullOrWhiteSpace(note.Text)) e.CheckResult.Add("note", "!!!");
        }
    }
}
