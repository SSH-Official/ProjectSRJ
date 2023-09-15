using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ProjectSRJ.DataModel;

namespace ProjectSRJ
{
    public class DBManager
    {
        static string DefaultServer = "localhost";
        static string DefaultDatabase = "test";
        static string DefaultUid = "root";
        static string DefaultPwd = "1234";
        static int DefaultPort = 3306;
        static string DefaultServerIP = "58.....";



        


        class Server{
            static public (bool, object) request(string str) {

                //Server에 리퀘스트를 보내는 로직 작성필요
                throw new NotImplementedException();
            }
        }

        public List<(Board, string, int)> GetSearchList()
        {
            bool isSuccess; 
            object result;
            (isSuccess, result) = Server.request("/search member name kim");
            if (isSuccess)
            {
                return result as List<(Board, string, int)>;
            }
            else
            {
                throw new Exception($"{result}");
            }
        }

        public bool request(string command)
        {
            


            return false;
        }


        public List<Member> SelectMembers()
        {
            List<Member> members = new List<Member>();            
            
            string strConn = 
                $"Server={DefaultServer};" +
                $"Database={DefaultDatabase};" +
                $"Uid={DefaultUid};" +
                $"Pwd={DefaultPwd};" +
                $"Port={DefaultPort}";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                
                string strQuery = 
                    $"SELECT " +
                    $"idx " +       $"{GetAlias(Member.Alias.Index)}, " +
                    $"id " +        $"{GetAlias(Member.Alias.ID)}, " +
                    $"password " +  $"{GetAlias(Member.Alias.Password)}, " +
                    $"name " +      $"{GetAlias(Member.Alias.Name)}, " +
                    $"age " +       $"{GetAlias(Member.Alias.Age)}, " +
                    $"gender " +    $"{GetAlias(Member.Alias.Gender)}" +
                    $"FROM member";

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader rdr =  cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Member MemberNew = new Member(
                        rdr.GetString($"{Member.Alias.ID}"),
                        rdr.GetString($"{Member.Alias.Password}"),
                        rdr.GetString($"{Member.Alias.Name}"),
                        rdr.GetInt32($"{Member.Alias.Age}"),
                        rdr.GetString($"{Member.Alias.Gender}"));
                    members.Add(MemberNew);
                }
                
                conn.Close();
            }

            return members;
            #region <<< Nested Functions >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string GetAlias(Member.Alias selName)
            {
                return $"AS '{selName}'";
            }
            #endregion
        }

        public object SearchMember(string args)
        {
            throw new NotImplementedException();
        }
    }
}
