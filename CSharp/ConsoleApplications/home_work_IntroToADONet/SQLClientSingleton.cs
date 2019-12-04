using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace home_work_IntroToADONet
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
        public bool Autorization(string login, string password)
        {
            if (login.Length > 100 || password.Length > 100 ||
                login == null || password == null) return false;

            using (sqlConnection) {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_CheckAccount",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };

                query.Parameters.Add("@login", SqlDbType.VarChar);
                query.Parameters.Add("@password", SqlDbType.VarChar);
                query.Parameters.Add("@result", SqlDbType.Int);

                query.Parameters["@login"].Value = login;
                query.Parameters["@password"].Value = password;
                query.Parameters["@result"].Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();

                return ((int)query.Parameters["@result"].Value == 0) ? false : true;
            }
        }
        public List<object> GetBooks()
        {
            using (sqlConnection)
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_ShowBooks",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    List<object> lines = new List<object>();

                    while (reader.Read())
                    {
                        //Анонимный тип для каждой строки
                        lines.Add(new {
                            ID = reader.GetInt32(0),
                            NameBook = reader.GetString(1),
                            Author = reader.GetString(2),
                            DateOfPublish = reader.GetDateTime(3),
                            Pages = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            QuantityBooks = reader.GetInt32(6),
                            DrawingOfBook = reader.GetInt32(7)
                        });
                    }

                    return lines;
                }
            }
        }
        public List<object> GetSearchBooks(string textSearch)
        {
            if (textSearch.Length > 100 || textSearch == null) return null;

            using (sqlConnection)
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_SearchBooks",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };
                query.Parameters.Add("@textSearch", SqlDbType.VarChar);
                query.Parameters["@textSearch"].Value = textSearch;

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    List<object> lines = new List<object>();

                    while (reader.Read())
                    {
                        //Анонимный тип для каждой строки
                        lines.Add(new
                        {
                            NameBook = reader.GetString(0),
                            Author = reader.GetString(1),
                            DateOfPublish = reader.GetDateTime(2),
                            Pages = reader.GetInt32(3),
                            Price = reader.GetDecimal(4),
                            QuantityBooks = reader.GetInt32(5),
                            DrawingOfBook = reader.GetInt32(6)
                        });
                    }

                    return lines;
                }
            }
        }
        public bool AddBook
        (
            string fName,
            string lName,
            string country,
            string theme,
            string bookName,
            decimal price,
            int drawingOfBook,
            DateTime dateOfPublish,
            int pages,
            int quantityBooks
        )
        {
            using (sqlConnection)
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_AddBook",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };

                query.Parameters.Add("@fName", SqlDbType.VarChar);
                query.Parameters.Add("@lName", SqlDbType.VarChar);
                query.Parameters.Add("@country", SqlDbType.VarChar);
                query.Parameters.Add("@theme", SqlDbType.VarChar);
                query.Parameters.Add("@name", SqlDbType.VarChar);
                query.Parameters.Add("@price", SqlDbType.Money);
                query.Parameters.Add("@drawingOfBook", SqlDbType.Int);
                query.Parameters.Add("@dateOfPublish", SqlDbType.Date);
                query.Parameters.Add("@pages", SqlDbType.Int);
                query.Parameters.Add("@quantityBooks", SqlDbType.Int);

                query.Parameters["@fName"].Value = fName;
                query.Parameters["@lName"].Value = lName;
                query.Parameters["@country"].Value = country;
                query.Parameters["@theme"].Value = theme;
                query.Parameters["@name"].Value = bookName;
                query.Parameters["@price"].Value = price;
                query.Parameters["@drawingOfBook"].Value = drawingOfBook;
                query.Parameters["@dateOfPublish"].Value = dateOfPublish.ToString("yyyy/MM/dd");
                query.Parameters["@pages"].Value = pages;
                query.Parameters["@quantityBooks"].Value = quantityBooks;

                int cntAffectedRows = query.ExecuteNonQuery();

                return (cntAffectedRows > 0) ? true : false;
            }
        }
        public bool EditBook
        (
            int id,
            string bookName,
            decimal? price,
            int? drawingOfBook,
            DateTime? dateOfPublish,
            int? pages,
            int? quantityBooks
        )
        {
            using (sqlConnection)
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_EditBook",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };

                query.Parameters.Add("@id", SqlDbType.Int);
                query.Parameters.Add("@name", SqlDbType.VarChar);
                query.Parameters.Add("@price", SqlDbType.Money);
                query.Parameters.Add("@drawingOfBook", SqlDbType.Int);
                query.Parameters.Add("@dateOfPublish", SqlDbType.Date);
                query.Parameters.Add("@pages", SqlDbType.Int);
                query.Parameters.Add("@quantityBooks", SqlDbType.Int);

                query.Parameters["@id"].Value = id;
                query.Parameters["@name"].Value = (bookName == null) ? SqlString.Null : bookName;
                query.Parameters["@price"].Value = (price == null) ? SqlMoney.Null : (SqlMoney)price;
                query.Parameters["@drawingOfBook"].Value = (drawingOfBook == null) ? SqlInt32.Null : (SqlInt32)drawingOfBook;
                if (dateOfPublish == null) query.Parameters["@dateOfPublish"].Value = SqlDateTime.Null;
                else query.Parameters["@dateOfPublish"].Value = dateOfPublish?.ToString("yyyy/MM/dd");
                query.Parameters["@pages"].Value = (pages == null) ? SqlInt32.Null : (SqlInt32)pages;
                query.Parameters["@quantityBooks"].Value = (quantityBooks == null) ? SqlInt32.Null : (SqlInt32)quantityBooks;

                int cntAffectedRows = query.ExecuteNonQuery();
                return (cntAffectedRows > 0) ? true : false;
            }
        }
        public List<object> GetLogs()
        {
            using (sqlConnection)
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_ShowHistoryBooks",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    List<object> lines = new List<object>();

                    while (reader.Read())
                    {
                        //Анонимный тип для каждой строки
                        lines.Add(new
                        {
                            EventType = reader.GetString(0),
                            NameBook = reader.GetString(1),
                            Author = reader.GetString(2),
                            DateOfPublish = reader.GetDateTime(3),
                            Pages = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            QuantityBooks = reader.GetInt32(6),
                            DrawingOfBook = reader.GetInt32(7),
                            EventDate = reader.GetDateTime(8)
                        });
                    }

                    return lines;
                }
            }
        }
        public bool DelBook(int id)
        {
            using (sqlConnection)
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();

                SqlCommand query = new SqlCommand
                {
                    CommandText = "sp_RemoveBook",
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };
                
                query.Parameters.Add("@id", SqlDbType.Int);
                query.Parameters["@id"].Value = id;

                int cntAffectedRows = query.ExecuteNonQuery();
                return (cntAffectedRows > 0) ? true : false;
            }
        }
        //~SQLClientSingleton()
        //{
        //    if (sqlConnection.Equals(ConnectionState.Closed) != true) sqlConnection.Close();
        //}
    }
}
