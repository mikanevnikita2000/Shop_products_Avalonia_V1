using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1
{
    internal class Requests
    {
        public void Question_Write(string question)
        {
            using (var connection = new SqliteConnection("Data Source = shop.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                command.CommandText = $"{question}";
                int number = command.ExecuteNonQuery();
            }
        }

        public (int, string, List<string>) Question_read(string question)
        {
            int idproducts = 0;
            string product ="";
            List<string> records = new List<string>(5);
            using (var connection = new SqliteConnection("Data Source=shop.db"))
            {
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
                                string data = Convert.ToString(reader["data"]);
                                int id_products = Convert.ToInt32(reader["products"]);
                                int price = Convert.ToInt32(reader["price"]);
                                question = $"SELECT * FROM type_products WHERE id_products = {id_products};";
                                (idproducts, product, record) = Question_read(question);
                                string category = Convert.ToString(reader["category"]);
                                records.Add ($"{data} : {product} : {price} : {category}");
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
            }
            return (idproducts, product, records);
        }



        public int Question_read_product_products(string products,List<string> records)
        {
            string question = $"SELECT * FROM type_products WHERE products ='{products}';";
            int idproducts=0;
            string product = "";
            (idproducts, product, records) = Question_read(question);
            if (idproducts == 0)
            {
                Question_write_idproduct_products(products);
                question = "SELECT id_products FROM type_products;";
                (idproducts, product, records) = Question_read(question);
            }
            return idproducts;
        }

        public (string, string, string, string) Question_read_String_products(List<string> records)
        {
            string question = "SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;";
            int idproducts = 0;
            string product = "";
            (idproducts, product, records) = Question_read(question);
            string record1 = records[0];
            string record2 = records[1];
            string record3 = records[2];
            string record4 = records[3];
            return (record1, record2, record3, record4);
        }



        public void Question_write_idproduct_products(string products)
        {
            string question = $"INSERT INTO type_products (products) VALUES('{products}');";
            Question_Write(question);
        }

        internal void Question_write_main(string products, string data, int price)
        {
            List<string> records = new List<string>(5);
            int idproduct = Question_read_product_products(products, records);
            string question = $"INSERT INTO purchase_information (data, products,price,category) VALUES('{data}', {idproduct} ,{price},'продукт');";
            Question_Write(question);
        }
    }
}