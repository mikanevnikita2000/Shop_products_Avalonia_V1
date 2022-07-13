using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Shop_products_Avalonia_V1.Models;

namespace Shop_products_Avalonia_V1.Models
{
    public class RequestProcessing
    {
       // ConnectingToTheDatebase connectingToTheDatebase = new ConnectingToTheDatebase();
       // RequestProcessing requestProcessing = new RequestProcessing();
        Purchase purchase = new Purchase();

        public void Question_Write()
        {
            using (var connection = new SqliteConnection("Data Source = shop.db"))
            {
                RequestProcessing requestProcessing = new RequestProcessing();
                /*ConnectingToTheDatebase connectingToTheDatebase = new ConnectingToTheDatebase();
                SqliteConnection connection = connectingToTheDatebase.ConDB();*/
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                command.CommandText = $"{purchase.Question}";
                int number = command.ExecuteNonQuery();
            }
        }

        public void Question_read()
        {
            
            /*ConnectingToTheDatebase connectingToTheDatebase = new ConnectingToTheDatebase();
            SqliteConnection connection = connectingToTheDatebase.ConDB();*/
           
            using (var connection = new SqliteConnection("Data Source = shop.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(purchase.Question, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (purchase.Question == "SELECT id_products FROM type_products;")
                        {
                            while (reader.Read())
                            {
                                purchase.Idproduct = Convert.ToInt32(reader["id_products"]);
                            }
                        }
                        if (purchase.Question == "SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;")
                        {
                            while (reader.Read())
                            {
                                purchase.DatePurchase = Convert.ToString(reader["data"]);
                                purchase.Idproduct = Convert.ToInt32(reader["products"]);
                                purchase.PricePurchase = Convert.ToInt32(reader["price"]);
                                purchase.Question = $"SELECT * FROM type_products WHERE id_products = {purchase.Idproduct};";
                                Question_read();
                                string category = Convert.ToString(reader["category"]);
                                purchase.Records.Add($"{purchase.DatePurchase} : {purchase.Product} : {purchase.PricePurchase} : {purchase.category}");
                            }
                        }

                        while (reader.Read())
                        {
                            purchase.Product = Convert.ToString(reader["products"]);
                            purchase.Idproduct = Convert.ToInt32(reader["id_products"]);
                        }
                    }
                }
            }
        }
    }
}
