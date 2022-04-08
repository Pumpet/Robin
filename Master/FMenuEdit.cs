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
    public partial class FMenuEdit : FormEdit {
        public FMenuEdit() {
            InitializeComponent();
        }

        private void FMenuEdit_Load(object sender, EventArgs e) {
            SelectNewSql = @"
                select 
                  id = null  
                , code = ''
                , appcode = @appcode
                , parentId = @parentId
                , parent = @parent
                , ord = 1
                , caption = ''
                , img = ''
                , execType = 0 
                , command = ''
                , marker = ''
            ";
            SelectSql = @"
                select m.*, p.code as parent 
                from robin.tMenu m 
                    left join robin.tMenu p on p.id = m.parentId
                where m.id = @id";
            InsertSql = @"
                insert robin.tMenu (
                  code    
                , appcode 
                , parentId  
                , ord     
                , caption 
                , img     
                , execType
                , command 
                , marker      
                ) 
                values (
                  @code
                , @appcode 
                , @parentId  
                , @ord     
                , @caption 
                , @img     
                , @execType 
                , @command 
                , @marker  
                )
                  
                if @@rowcount > 0 
                  select id = convert(int,SCOPE_IDENTITY())
                ";
            UpdateSql = @"
                update robin.tMenu set 
                  code     = @code
                , appcode  = @appcode 
                , parentId = @parentId
                , ord      = @ord     
                , caption  = @caption 
                , img      = @img     
                , execType = @execType 
                , command  = @command 
                , marker   = @marker  
                where id = @id
                if @@rowcount > 0   
                    select id = cast(@id as int)
                ";
            CheckSql = @"
                declare @t table (c varchar(30), t varchar(200))
                if exists(select 1 from robin.tMenu where code = @code and appcode = @appcode and id <> @id)
                    insert @t select 'code', 'Код уже используется!'
                if @execType = 0 and exists(select 1 from robin.tMenu where parentId = @id) 
                    insert @t select 'rbMenu', 'Группу нельзя сделать меню, т.к. есть подменю!'
                if isnull(ltrim(rtrim(@code)),'') = '' insert @t select 'code', 'обязательное поле!'                  
                if isnull(ltrim(rtrim(@caption)),'') = '' insert @t select 'caption', 'обязательное поле!'  
                select * from @t
            ";
        }

        private void FMenuEdit_ControlTrigger(object sender, ControlTriggerEventArgs e) {
            if (e.EventType == CtrlEventType.StateChange && e.Ctrl == rbMenu) {
                lbCommand.Visible = rbMenu.Checked;
                command.Visible = rbMenu.Checked;
            }           
        }

        private void FMenuEdit_SaveParamsCheck(object sender, ParamsCheckEventArgs e) {
            e.Pars["execType"] = rbMenu.Checked ? 0 : 1;
            if (!rbMenu.Checked)
                e.Pars["command"] = null;
            if (string.IsNullOrWhiteSpace(e.Pars["marker"].ToString()))
                e.Pars["marker"] = null;
        }

        private void FMenuEdit_AfterBinding(object sender, EventArgs e) {
            GetDataToCombo(command, "code", "select code from robin.tCommand where appcode = @appcode and cmdType in (1,2) union select code = '' order by 1", null, CtrlsProc.PrepareParams(SourceRow, null, "appcode=appcode"));
            rbMenu.Checked = (int)SourceRow["execType"] == 0;
            rbGroup.Checked = !rbMenu.Checked;
            lbCommand.Visible = rbMenu.Checked;
            command.Visible = rbMenu.Checked;
            if (CheckChanges) {
                rbMenu.CheckedChanged += (o, ea) => Changed = true;
                rbGroup.CheckedChanged += (o, ea) => Changed = true;
            }
        }

        private void marker_ExecSelectionForm(object sender, ExecSelectionFormEventArgs e) {
            e.Form = new FMarkerList();
        }

        private void FMenuEdit_SetData(object sender, ProcessDataEventArgs e) {
            //
        }

        private void parent_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                parent.Text = "";
                SourceRow["parentId"] = DBNull.Value;
            }
        }
    }
}
