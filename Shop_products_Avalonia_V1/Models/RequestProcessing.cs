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


        List<object> ret = new List<object>();
       

        public List<object> ReadFromDB(string request)
        {
            ReadingInformationFromTheDB readingInformationFromTheDB = new ReadingInformationFromTheDB();
            int idproduct = 0;
            var connection = databaseConnection.ConDB();
            string product = "";
            connection.Open();
            ret.Add(idproduct);
            ret.Add(product);
            SqliteCommand command = new SqliteCommand(request, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    ret= readingInformationFromTheDB.IFChec(ret,request, reader);
                    return ret;
                }
            }
            connection.Close();
            idproduct = 0;
            ret[0] = idproduct;
            return ret;
        }

        //ret[0] = idproduct,ret[1] = product,ret[2] = records

        
    }
}
