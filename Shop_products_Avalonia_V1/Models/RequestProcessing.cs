using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class RequestProcessing
    {
        ConnectingToTheDatebase connectingToTheDatebase = new ConnectingToTheDatebase();

        public void Question_Write(string question)
        {
            var connection = connectingToTheDatebase.ConDB();
            connection.Open();
            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;

            command.CommandText = $"{question}";
            int number = command.ExecuteNonQuery();
        }

        public int idproduct = 0;
        public (int, List<string>,string) Question_Read(string question)
        {
            List<string> records = new List<string>();
            string product ="";
            var connection = connectingToTheDatebase.ConDB();
            connection.Open();
            SqliteCommand command = new SqliteCommand(question, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    
                    if (question==$"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;")
                    {
                        while (reader.Read())
                        {
                            string datePurchase = Convert.ToString(reader["data"]);
                            idproduct = Convert.ToInt32(reader["products"]);
                            int pricePurchase = Convert.ToInt32(reader["price"]);
                            question = $"SELECT * FROM type_products WHERE id_products = {idproduct};";
                            (idproduct, List<string> records1, product) = Question_Read(question);
                            string category = Convert.ToString(reader["category"]);
                            records.Add($"{datePurchase} : {product} : {pricePurchase} : {category}");
                        }
                    }
                    if (question == $"SELECT * FROM type_products WHERE id_products = {idproduct};")
                    {
                        while (reader.Read())
                        {
                            product = Convert.ToString(reader["products"]);
                        }

                    }
                    while (reader.Read())
                    {
                        idproduct = Convert.ToInt32(reader["id_products"]);
                    }
                    return (idproduct, records, product);
                }
            }
            idproduct = 0;
            return (idproduct,records, product);
        }
    }
}
