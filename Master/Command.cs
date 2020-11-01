//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pumpet.net@gmail.com
//  Git: https://github.com/Pumpet/Robin
//  Copyright (C) Alex Rozanov, 2020 
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;

namespace Master {
    public class Command {
        public string Code { get; set; }
        public string Appcode { get; set; }
        public int CmdType { get; set; }
        public string Cmd { get; set; }
        public string CmdTestHead { get; set; }
        public string Comment { get; set; }
        public string Marker { get; set; }

        public static bool SaveScript(string appcode, IEnumerable<Command> cmds, IEnumerable<DataRow> menus, string path, string comment) {
            if ((cmds == null || cmds.Count() == 0) && (menus == null || menus.Count() == 0)) {
                Loger.SendMess("Нет данных для формирования");
                return false;
            }
            var sb = new StringBuilder();
            sb.AppendLine($"-- {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} {comment}");
            sb.AppendLine($"-- Script for '{appcode}'");

            // команды
            foreach (var cmd in cmds) {
                sb.AppendLine();
                sb.AppendLine(new string('-', 80));
                sb.AppendLine($"-- {(cmd.CmdType == 0 ? "sql" : cmd.CmdType == 1 ? "form" : "method")}: {cmd.Code}");
                sb.AppendLine();
                sb.AppendLine($"delete dm.tCommand where code = '{cmd.Code}' and appcode = '{cmd.Appcode}'");
                if (cmd.CmdType > 0)
                    sb.AppendLine($"insert dm.tCommand (code, appcode, cmdType, cmd, comment, marker) values ('{cmd.Code}', '{cmd.Appcode}', {cmd.CmdType}, '{cmd.Cmd}', '{cmd.Comment}', '{cmd.Marker}')");
                else {
                    sb.AppendLine($"insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment, marker) values ('{cmd.Code}', '{cmd.Appcode}', {cmd.CmdType}, '', '', '{cmd.Comment}', '{cmd.Marker}')");
                    sb.AppendLine($"update dm.tCommand set cmdTestHead = '");
                    sb.AppendLine(cmd.CmdTestHead?.Replace("'", "''"));
                    sb.AppendLine($"' where code = '{cmd.Code}' and appcode = '{cmd.Appcode}'");
                    sb.AppendLine($"update dm.tCommand set cmd = '");
                    sb.AppendLine(cmd.Cmd.Replace("'", "''"));
                    sb.AppendLine($"' where code = '{cmd.Code}' and appcode = '{cmd.Appcode}'");
                }
            }

            if (menus != null && menus.Count() > 0) {
                // меню
                sb.AppendLine();
                sb.AppendLine(new string('-', 80));
                sb.AppendLine($"-- меню");
                sb.AppendLine();
                sb.AppendLine($"delete dm.tMenu where appcode = '{appcode}'");
                sb.AppendLine($"declare @parentId int");
                foreach (var menu in menus) {
                    sb.AppendLine($@"
select @parentId = (select id from dm.tMenu where appcode = '{appcode}' and code = {menu["parent"].ToSqlValue()})
insert dm.tMenu (code, appcode, parentId, ord, caption, img, execType, command, marker) 
    values ({menu["code"].ToSqlValue()}, '{appcode}', @parentId, {menu["ord"].ToSqlValue()}, {menu["caption"].ToSqlValue()}, {menu["img"].ToSqlValue()}, {menu["execType"].ToSqlValue()}, {menu["command"].ToSqlValue()}, {menu["marker"].ToSqlValue()})");
                }
            }
            try {
                File.WriteAllText(path, sb.ToString());
            }
            catch (Exception ex) {
                Loger.SendMess(ex, $"Ошибка сохранения в {path}");
                return false;
            }
            return true;
        }

        public static string SelectNewSql { get; set; }  = @"select code = '', appcode = @appcode, cmdType = 1, cmd = '', cmdTestHead = '', comment = '', marker = ''";
        public static string SelectSql { get; set; } = @"select code as oldCode, * from dm.tCommand where code = @code and appcode = @appcode";
        public static string InsertSql { get; set; } = @"
                if @marker = '' select @marker = null
                insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment, marker)
                    select @code, @appcode, @cmdType, @cmd, @cmdTestHead, @comment, @marker
                select code = @code, appcode = @appcode
                ";
        public static string UpdateSql { get; set; } = @"
                if @marker = '' select @marker = null
                update dm.tCommand set code = @code, cmdType = @cmdType, cmd = @cmd, cmdTestHead = @cmdTestHead, comment = @comment, marker = @marker
                    where code=@oldCode and appcode=@appcode
                select code = @code, appcode = @appcode
                ";

    }
}
