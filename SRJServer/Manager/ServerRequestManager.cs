using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSRJ;

namespace SRJServer.Manager
{
    internal class ServerRequestManager
    {


        CommandProcessor CP;
        ServerDBManager DB;

        ServerRequestManager()
        {
            DB = new ServerDBManager();
            CP = new CommandProcessor(DB);
        }

        Member ExampleOfUsage()
        {
            ServerRequestManager Server = new ServerRequestManager();
            
            bool isSuccess;
            object cmdResult;

            (isSuccess, cmdResult) = Server.DoCommand("/search member name kim");
            if (isSuccess )
            {
                Member theMember = (Member)cmdResult;
                return theMember;
            }
            else
            {
                string ErrorMsg = (string)cmdResult;
                throw new Exception(ErrorMsg);
            }
        }

        public (bool, object) DoCommand(string str)
        {
            try
            {
                return (true, CP.OnCommandRecieved(str));
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }            
        }       

        private object Search(string args)
        {
            string[] strings = args.Split(',');
            string category = strings[0];
            string keyword = strings[1];
            switch(category.ToLower())
            {
                case "member":
                    return DB.SearchMember(keyword);
                default:
                    throw new Exception($"Undefined Category : {category}");
            }
        }

        

    }
}
