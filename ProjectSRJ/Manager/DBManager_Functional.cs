using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSRJ
{
    internal class DBManager_Functional
    {
        static string DefaultServer = "localhost";
        static string DefaultDatabase = "test";
        static string DefaultUid = "root";
        static string DefaultPwd = "1234";
        static int DefaultPort = 3306;
        static string DefaultConnectionString 
        { 
            get 
            { 
                return $"Server={DefaultServer + 1};" +
                $"Database={DefaultDatabase};" +
                $"Uid={DefaultUid};" +
                $"Pwd={DefaultPwd};" +
                $"Port={DefaultPort}";
            } 
        }


        /// <summary>
        /// returns null if not available
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public bool TryGetMemberList(out List<Member> output)
        {
            output = GetMemberList();
            return (output != null);
        }
        public List<Member> GetMemberList()
        {
            string strQuery = "SELECT * FROM member";
            return ExecuteQuery(strQuery, (rdr) =>
            {
                List<Member> members = new List<Member>();
                while (rdr.Read())
                {
                    Member MemberNew = new Member(
                        rdr.GetString(1),
                        rdr.GetString(2),
                        rdr.GetString(3),
                        rdr.GetInt32(4),
                        rdr.GetString(5));
                    members.Add(MemberNew);
                }
                return members;
            }) as List<Member>;
        }

        public List<(Member, Party)> GetParty()
        {
            return null;
        }
        

        public object ExecuteQuery(string Query, Func<MySqlDataReader, object> ParseMethod)
        {
            string strConn = DefaultConnectionString;
            object theResult = null;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();

                cmd = new MySqlCommand(Query, conn);
                rdr = cmd.ExecuteReader();

                theResult = ParseMethod(rdr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }                
            }

            
            return theResult;
        }
    }
}
