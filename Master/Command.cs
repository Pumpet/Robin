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

namespace Master {
    public class Command {
        public string Code { get; set; }
        public string Appcode { get; set; }
        public int CmdType { get; set; }
        public string Cmd { get; set; }
        public string CmdTestHead { get; set; }
        public string Comment { get; set; }

        public static bool SaveScript(IEnumerable<Command> cmds, string path, string comment) {
            if (cmds == null || cmds.Count() == 0) {
                Loger.SendMess("Нет данных для формирования");
                return false;
            }
            var sb = new StringBuilder();
            sb.AppendLine($"-- {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} {comment}");
            sb.AppendLine($"-- Script for '{cmds.First().Appcode}'");
            foreach (var cmd in cmds) {
                sb.AppendLine();
                sb.AppendLine(new string('-', 80));
                sb.AppendLine($"-- {(cmd.CmdType == 0 ? "sql" : cmd.CmdType == 1 ? "form" : "method")}: {cmd.Code}");
                sb.AppendLine();
                sb.AppendLine($"delete dm.tCommand where code = '{cmd.Code}' and appcode = '{cmd.Appcode}'");
                if (cmd.CmdType > 0)
                    sb.AppendLine($"insert dm.tCommand (code, appcode, cmdType, cmd, comment) values ('{cmd.Code}', '{cmd.Appcode}', {cmd.CmdType}, '{cmd.Cmd}', '{cmd.Comment}')");
                else {
                    sb.AppendLine($"insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment) values ('{cmd.Code}', '{cmd.Appcode}', {cmd.CmdType}, '', '', '{cmd.Comment}')");
                    sb.AppendLine($"update dm.tCommand set cmdTestHead = '");
                    sb.AppendLine(cmd.CmdTestHead?.Replace("'", "''"));
                    sb.AppendLine($"' where code = '{cmd.Code}' and appcode = '{cmd.Appcode}'");
                    sb.AppendLine($"update dm.tCommand set cmd = '");
                    sb.AppendLine(cmd.Cmd.Replace("'", "''"));
                    sb.AppendLine($"' where code = '{cmd.Code}' and appcode = '{cmd.Appcode}'");
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

        public static string SelectNewSql { get; set; }  = @"select code = '', appcode = @appcode, cmdType = 1, cmd = '', cmdTestHead = '', comment = ''";
        public static string SelectSql { get; set; } = @"select * from dm.tCommand where code = @code and appcode = @appcode";
        public static string InsertSql { get; set; } = @"
                insert dm.tCommand (code, appcode, cmdType, cmd, cmdTestHead, comment)
                    select @code, @appcode, @cmdType, @cmd, @cmdTestHead, @comment
                select code = @code, appcode = @appcode
                ";
        public static string UpdateSql { get; set; } = @"
                update dm.tCommand set cmdType = @cmdType, cmd = @cmd, cmdTestHead = @cmdTestHead, comment = @comment 
                    where code=@code and appcode=@appcode
                select code = @code, appcode = @appcode
                ";

    }
}
