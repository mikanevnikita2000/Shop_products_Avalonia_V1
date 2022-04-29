using MySql.Data.MySqlClient;
using System;
using Tutorial.SqlConn;

namespace Shop_products_Avalonia_V1
{
    internal class Query
    {
        public void Question_Write(string question)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            MySqlCommand cmd1 = new MySqlCommand(question, conn);
            try
            {
                cmd1.ExecuteNonQuery();
                Console.WriteLine("Запрос выполнен");
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнения запроса ");

                return;
            }

            conn.Close();
            conn.Dispose();
        }

        public int Question_read(string question)
        {

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                Console.WriteLine("подключение");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            MySqlCommand cmd1 = new MySqlCommand("show schemas;", conn);   // ("use new;");

            cmd1.ExecuteNonQuery();

            MySqlCommand cmd2 = new MySqlCommand(question, conn);

            MySqlDataReader read = cmd2.ExecuteReader();

            int idmain = 0;
            int idproducts = 0;
            if (question != "SELECT idnew_table FROM products;" && question != "SELECT idmain FROM main;")
            {

                while (read.Read())
                {
                    try
                    {
                        idproducts = Convert.ToInt32(read["idnew_table"]);
                        Console.WriteLine(idproducts);
                        Console.WriteLine("есть такой продукт");
                        return idproducts;
                    }
                    catch
                    {
                        Console.WriteLine("нет такого продукта");
                        return idproducts;
                    }
                }
            }
            if (question == "SELECT idnew_table FROM products;")
            {
                while (read.Read())
                {
                    idproducts = Convert.ToInt32(read["idnew_table"]);
                }
                Console.WriteLine("возращает idproducts + 1");
                idproducts = idproducts + 1;
                return idproducts;
            }
            if (question == "SELECT idmain FROM main;")
            {
                while (read.Read())
                {
                    idmain = Convert.ToInt32(read["idmain"]);
                }
                Console.WriteLine("id main");
                return idmain;
            }

            conn.Close();
            conn.Dispose();
            return idmain;
        }



        public int Question_read_last_id_products(string products)
        {
            string question = "SELECT idnew_table FROM products;";
            int idproducts = Question_read(question);
            Question_write_idproduct_products(idproducts, products);
            return idproducts;
        }

        public int Question_read_id_main()
        {
            string question = "SELECT idmain FROM main;";
            int id = Question_read(question);
            return id;
        }

        public int Question_read_product_products(string products, int id)
        {
            string question = $"SELECT * FROM products WHERE products ='{products}';";
            id = Question_read(question);
            return id;
        }



        public void Question_write_idproduct_products(int idproducts, string products)
        {
            string question = $"INSERT INTO products (idnew_table, products) VALUES({idproducts},'{products}');";
            Question_Write(question);
        }

        public void Question_write_main(string products, string data, int price)
        {
            int idmain = 0;
            idmain = Question_read_id_main();
            int idproduct = Question_read_product_products(products, 0);
            if (idproduct == 0)
            {
                idproduct = Question_read_last_id_products(products);
            }
            idmain = idmain + 1;
            Question_write_idproduct_products(idproduct, products);
            string question = $"INSERT INTO main (idmain,data, products,price,category) VALUES({idmain},'{data}', {idproduct} ,{price},'продукт');";
            Question_Write(question);
        }
    }
}