using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class RequestProcessing
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public void Record_Write(string question)
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
        public int idproduct = 0;
        string product = "";
        List<string> records = new List<string>();

        public List<object> Record_Read(string request)
        {
            var connection = databaseConnection.ConDB();
            string product = "";
            connection.Open();
            ret.Add(idproduct);
            ret.Add(product);
            ret.Add(product);
            SqliteCommand command = new SqliteCommand(request, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    ret=IFChec(request, reader);
                    return ret;
                }
            }
            connection.Close();
            idproduct = 0;
            ret[0] = idproduct;
            return ret;
        }

        //ret[0] = idproduct,ret[1] = records,ret[2] = product
       
        public List<object> IFChec(string request, SqliteDataReader reader)
        {
            OutputOfRecords outputOfRecords = new OutputOfRecords();
            
            if (request == $"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT {outputOfRecords.numberOfRecords};")
            {
                int i=2;
                while (reader.Read())
                {
                    string datePurchase = Convert.ToString(reader["data"]);
                    idproduct = Convert.ToInt32(reader["products"]);
                    int pricePurchase = Convert.ToInt32(reader["price"]);
                    request = $"SELECT * FROM type_products WHERE id_products = {idproduct};";
                    ret = Record_Read(request);
                    string category = Convert.ToString(reader["category"]);
                    ret[i]=$"{datePurchase} : {ret[1]} : {pricePurchase} : {category}";
                    i++;
                }
            }
            if (request == $"SELECT * FROM type_products WHERE id_products = {idproduct};")
            {
                while (reader.Read())
                {
                    product = Convert.ToString(reader["products"]);
                }
                ret[1] = product;
            }
            while (reader.Read())
            {
                idproduct = Convert.ToInt32(reader["id_products"]);
                ret[0] = idproduct;
            }
            
            return ret;
        }
    }
}
