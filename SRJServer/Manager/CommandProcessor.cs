using ProjectSRJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRJServer.Manager
{
    public class CommandProcessor
    {
        ServerDBManager DB { get; }

        public CommandProcessor(ServerDBManager DB)
        {
            this.DB = DB;
        }

        /// <summary>
        /// 명령어 수정하려면 이 함수를 수정해주세요.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public object OnCommandRecieved(string str)
        {
            string command, args;
            (command, args) = Parse_Command_AndArguments(str);

            switch (command.ToLower())
            {
                case "search":
                    return DB.Search(args);
                case "dosomething":
                    return DB.SelectMembers();
                case "searchmemeber":
                    return DB.SearchMember(args);

                default:
                    return null;
                    throw new Exception("There Is No Command Like That");
            }

        }

        private (string, string) Parse_Command_AndArguments(string str)
        {
            string strExample = $"/Command kim 1 2";
            return ("Command", "kim, 1, 2");
        }
    }
}
