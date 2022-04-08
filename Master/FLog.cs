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
    public partial class FLog : FormList {
        public FLog() {
            InitializeComponent();
        }

        private void FLog_Load(object sender, EventArgs e) {
            GetDataToCombo(_appcode, "appcode", "select appcode = code from robin.tApp union select appcode = '' order by 1", null);
            dataList1.QuerySql = @"
select @login = isnull(ltrim(rtrim(@login)), '')
select @mess = isnull(ltrim(rtrim(@mess)), '')
select * 
    from robin.tLog
    where dt between @dtFrom and @dtTo
        and (@login = '' or (@login <> '' and login like '%' + @login + '%'))
        and (@appcode = '' or (@appcode <> '' and appcode = @appcode))
        and (@mess = '' or (@mess <> '' and mess like '%' + @mess + '%'))
    order by dt desc
";
        }

        private void FLog_SetUiParamsValuesAfterLoad(object sender, UiParamsEventArgs e) {
            dtFrom.Text = DateTime.Now.AddHours(-1).ToString("dd.MM.yyyy HH:mm:ss");
            dtTo.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
