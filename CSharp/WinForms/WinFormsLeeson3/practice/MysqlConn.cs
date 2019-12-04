using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace practice
{
    class SQLClientSingleton
    {
        public static SQLClientSingleton SQLConn { get; private set; } = new SQLClientSingleton();
        SqlConnection sqlConnection;
        string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SQLClientSingleton()
        {
            sqlConnection = new SqlConnection(ConnectionString);
        }
        private void ConnectionOpen()
        {
            sqlConnection.ConnectionString = ConnectionString;
            sqlConnection.Open();
        }
        public int GetAmountMessages()
        {
            using (sqlConnection)
            {
                ConnectionOpen();

                var query = new SqlCommand
                {
                    CommandText = @"select count(*) from [messages]",
                    Connection = sqlConnection
                };

                return (int)query.ExecuteScalar();
            }
        }
        public List<string> GetMessages(int amMessages)
        {
            using (sqlConnection)
            {
                ConnectionOpen();

                var query = new SqlCommand
                {
                    CommandText = $"select username,text,date from (select * from [messages] order by id desc offset 0 rows fetch first {amMessages} row only) as q order by id asc",
                    Connection = sqlConnection
                };

                using (SqlDataReader r = query.ExecuteReader())
                {
                    var lst = new List<string>();

                    while (r.Read())
                        lst.Add($"{r.GetString(0)}" + Environment.NewLine + $"{r.GetString(1)}" + Environment.NewLine + $"{r.GetDateTime(2)}" + Environment.NewLine + Environment.NewLine);

                    return lst;
                }
            }
        }
        public void AddMessage(string userName, string text)
        {
            using (sqlConnection)
            {
                ConnectionOpen();

                var query = new SqlCommand
                {
                    CommandText = $"insert into [messages] (username,text) values('{userName}', '{text}')",
                    Connection = sqlConnection
                };

                query.ExecuteNonQuery();
            }
        }
    }
}
