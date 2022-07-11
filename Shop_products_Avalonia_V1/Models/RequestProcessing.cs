using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class RequestProcessing
    {
        ConnectingToTheDatebase connectingToTheDatebase = new ConnectingToTheDatebase();

        public ViewModels.MainWindowViewModel MainWindowViewModel
        {
            get => default;
            set
            {
            }
        }

        public ReadAndWriteRequests ReadAndWriteRequests
        {
            get => default;
            set
            {
            }
        }

        public ConnectingToTheDatebase ConnectingToTheDatebase
        {
            get => default;
            set
            {
            }
        }

        public void Question_Write(string question)
        {
                SqliteConnection connection =  connectingToTheDatebase.ConDB();
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                command.CommandText = $"{question}";
                int number = command.ExecuteNonQuery();
        }

        public (int, string, List<string>) Question_read(string question)
        {
            int idproducts = 0;
            string product = "";
            List<string> records = new List<string>(4);
            SqliteConnection connection = connectingToTheDatebase.ConDB();
            connection.Open();

                SqliteCommand command = new SqliteCommand(question, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (question == "SELECT id_products FROM type_products;")
                        {
                            while (reader.Read())
                            {
                                idproducts = Convert.ToInt32(reader["id_products"]);
                            }
                            return (idproducts, product, records);
                        }
                        if (question == "SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;")
                        {
                            List<string> record = new List<string>(5);
                            while (reader.Read())
                            {
                                string dataPurchases = Convert.ToString(reader["data"]);
                                int id_products = Convert.ToInt32(reader["products"]);
                                int pricePurchases = Convert.ToInt32(reader["price"]);
                                question = $"SELECT * FROM type_products WHERE id_products = {id_products};";
                                (idproducts, product, record) = Question_read(question);
                                string category = Convert.ToString(reader["category"]);
                                records.Add($"{dataPurchases} : {product} : {pricePurchases} : {category}");
                            }
                            return (idproducts, product, records);
                        }

                        while (reader.Read())
                        {
                            product = Convert.ToString(reader["products"]);
                            idproducts = Convert.ToInt32(reader["id_products"]);
                        }
                        return (idproducts, product, records);
                    }
                }
            return (idproducts, product, records);
        }
    }
}
