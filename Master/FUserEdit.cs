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
    public partial class FUserEdit : FormEdit {
        public FUserEdit() {
            InitializeComponent();
        }

        private void FUserEdit_Load(object sender, EventArgs e) {
            SelectNewSql = @"select login = '', name = ''";
            SelectSql = @"select * from robin.tUser where id = @id";
            InsertSql = @"
                insert robin.tUser(login, name) values (@login, @name)
                select id = convert(int,SCOPE_IDENTITY())
                ";
            UpdateSql = @"
                update robin.tUser set login = @login, name = @name where id = @id
                select id = @id
                ";
        }

        private void FUserEdit_SaveParamsCheck(object sender, ParamsCheckEventArgs e) {
            if (string.IsNullOrWhiteSpace(login.Text)) e.CheckResult.Add("login", "!!!");
            if (string.IsNullOrWhiteSpace(name.Text)) e.CheckResult.Add("name", "!!!");
        }
    }
}
