using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1
{
    internal class Query
    {
        public void Question_Write(string question)
        {
            using (var connection = new SqliteConnection("Data Source = shop.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                command.CommandText = $"{question}";
                Console.WriteLine("В таблицу отправлен запрос");
                int number = command.ExecuteNonQuery();

                Console.WriteLine($"В таблицу Users добавлено объектов: {number}");
            }
        }
        public (int, List<string>) Question_read(string question)
        {
            int idproducts = 0;
            
            List<string> records = new List<string>(5);
            using (var connection = new SqliteConnection("Data Source=shop.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(question, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (question == "SELECT id_products FROM products;")
                        {
                            while (reader.Read())
                            {
                                idproducts = Convert.ToInt32(reader["id_products"]);
                            }
                            return (idproducts, records);
                        }
                        if (question == "SELECT * FROM main ORDER BY idmain DESC LIMIT 4;")
                        {
                            int i = 1;
                            while (reader.Read())
                            {
                                string data = Convert.ToString(reader["data"]);
                                int products = Convert.ToInt32(reader["products"]);
                                int price = Convert.ToInt32(reader["price"]);
                                string category = Convert.ToString(reader["category"]);
                                records[1] = "gfgf";
                                records[i] = $"{data} : {products} : {price} : {category}";
                                //2022-05-19
                                i = i + 1;
                            }
                            return (idproducts, records);
                        }

                        while (reader.Read())
                        {
                            idproducts = Convert.ToInt32(reader["id_products"]);
                        }
                        return (idproducts, records);

                    }
                }
            }
            return (idproducts, records);
        }



        public int Question_read_product_products(string products,List<string> records)
        {
            string question = $"SELECT * FROM products WHERE products ='{products}';";
            int idproducts=0;
            (idproducts, records) = Question_read(question);
            if (idproducts == 0)
            {
                Question_write_idproduct_products(products);
                question = "SELECT id_products FROM products;";
                (idproducts, records) = Question_read(question);
            }
            return idproducts;
        }

        public (string, string, string, string) Question_read_String_products(List<string> records)
        {
            string question = "SELECT * FROM main ORDER BY idmain DESC LIMIT 4;";
            int idproducts = 0;
            (idproducts, records) = Question_read(question);
            string record1 = records[1];
            string record2 = records[2];
            string record3 = records[3];
            string record4 = records[4];
            return (record1, record2, record3, record4);
        }



        public void Question_write_idproduct_products(string products)
        {
            string question = $"INSERT INTO products (products) VALUES('{products}');";
            Question_Write(question);
        }

        internal void Question_write_main(string products, string data, int price)
        {
            List<string> records = new List<string>(5);
            int idproduct = Question_read_product_products(products, records);
            string question = $"INSERT INTO main (data, products,price,category) VALUES('{data}', {idproduct} ,{price},'продукт');";
            Question_Write(question);
        }
    }
}