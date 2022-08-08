using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class RequestProcessing
    {
        
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public void WriteToDB(string question)
        {
            var connection = databaseConnection.ConDB();
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = $"{question}";
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
                    ret.Clear();
                }
            }
            connection.Close();
            ret[0] = 0;
            return ret;
            ret.Clear();
        }

        //ret[0] = idproduct,ret[1] = product,ret[2] = records

        
    }
}
