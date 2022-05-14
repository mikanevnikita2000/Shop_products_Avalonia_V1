using System;
using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static void SQLite_Conn ()
        {
            using (var connection = new SqliteConnection("Data Source=shop.db"))
            {
                connection.Open();
            }
            Console.Read();
        }

        /*public static MySqlConnection
         GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }*/

    }
}