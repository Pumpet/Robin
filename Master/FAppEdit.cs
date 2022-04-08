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
    public partial class FAppEdit : FormEdit {
        public FAppEdit() {
            InitializeComponent();
        }

        private void FAppEdit_Load(object sender, EventArgs e) {
            SelectNewSql = @"select code = '', caption = '', note = '', checkUserRights = 0, logAll = 0, logSQL = 0";
            SelectSql = @"select code as oldCode, * from robin.tApp where code = @code";
            InsertSql = @"
                if @logAll = 0 select @logSQL = 0                
                insert robin.tApp(code, caption, note, checkUserRights, logAll, logSQL) values (@code, @caption, @note, @checkUserRights, @logAll, @logSQL)
                select code = @code
                ";
            UpdateSql = @"
                if @logAll = 0 select @logSQL = 0
                update robin.tApp set code = @code, caption = @caption, note = @note, checkUserRights = @checkUserRights, logAll = @logAll, logSQL = @logSQL where code = @oldCode
                select code = @code
                ";
        }

        private void FAppEdit_SaveParamsCheck(object sender, ParamsCheckEventArgs e) {
            if (string.IsNullOrWhiteSpace(code.Text)) e.CheckResult.Add("code", "!!!");
            if (string.IsNullOrWhiteSpace(caption.Text)) e.CheckResult.Add("caption", "!!!");
            if (string.IsNullOrWhiteSpace(note.Text)) e.CheckResult.Add("note", "!!!");
        }

        private void FAppEdit_ControlTrigger(object sender, ControlTriggerEventArgs e) {
            if (e.Ctrl == logAll && e.EventType == CtrlEventType.StateChange) 
                SetLogChecks();
        }

        void SetLogChecks() {
            logSQL.Visible = logAll.Checked;
            if (!logAll.Checked) logSQL.Checked = false;
        }

        private void FAppEdit_AfterBinding(object sender, EventArgs e) {
            SetLogChecks();
        }
    }
}
