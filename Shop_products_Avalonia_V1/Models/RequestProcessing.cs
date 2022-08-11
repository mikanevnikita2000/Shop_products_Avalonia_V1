using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class RequestProcessing
    {
        
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public void WriteToDB(string request)
        {
            var connection = databaseConnection.ConDB();
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = $"{request}";
            int number = command.ExecuteNonQuery();
            connection.Close();
        }


       

        public List<object> ReadFromDB(List<object> ret)
        {
            
            ReadingInformationFromTheDB readingInformationFromTheDB = new ReadingInformationFromTheDB();
            var connection = databaseConnection.ConDB();
            connection.Open();
            
            SqliteCommand command = new SqliteCommand(Convert.ToString(ret[0]), connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    ret= readingInformationFromTheDB.IFChec(ret, reader);
                    return ret;
                }
            }
            connection.Close();
            return ret;
        }
    }
}
