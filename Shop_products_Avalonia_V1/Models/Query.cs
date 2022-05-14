using System;
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
        public int Question_read(string question)
        {
            int idproducts = 0;
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
                            return idproducts;
                        }

                        while (reader.Read())
                        {
                            idproducts = Convert.ToInt32(reader["id_products"]);
                        }
                        return idproducts;

                    }
                }
            }
            return idproducts;
        }



        public int Question_read_product_products(string products)
        {
            string question = $"SELECT * FROM products WHERE products ='{products}';";
            int idproduct = Question_read(question);
            if (idproduct == 0)
            {
                Question_write_idproduct_products(products);
                question = "SELECT id_products FROM products;";
                idproduct = Question_read(question);
            }
            return idproduct;
        }



        public void Question_write_idproduct_products(string products)
        {
            string question = $"INSERT INTO products (products) VALUES('{products}');";
            Question_Write(question);
        }

        internal void Question_write_main(string products, string data, int price)
        {
            int idproduct = Question_read_product_products(products);
            string question = $"INSERT INTO main (data, products,price,category) VALUES('{data}', {idproduct} ,{price},'продукт');";
            Question_Write(question);
        }
    }
}