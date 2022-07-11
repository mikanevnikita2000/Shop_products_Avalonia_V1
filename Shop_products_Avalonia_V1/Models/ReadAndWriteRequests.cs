using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_products_Avalonia_V1.Models
{
    public class ReadAndWriteRequests
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        public int Read_product(string products, List<string> records)
        {
            string question = $"SELECT * FROM type_products WHERE products ='{products}';";
            int idproducts = 0;
            string product = "";
            (idproducts, product, records) = requestProcessing.Question_read(question);
            if (idproducts == 0)
            {
                Write_idproduct(products);
                question = "SELECT id_products FROM type_products;";
                (idproducts, product, records) = requestProcessing.Question_read(question);
            }
            return idproducts;
        }

        public (string, string, string, string) Read_String_products(List<string> records)
        {
            string question = "SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;";
            int idproducts = 0;
            string product = "";
            (idproducts, product, records) = requestProcessing.Question_read(question);
            string record1 = records[0];
            string record2 = records[1];
            string record3 = records[2];
            string record4 = records[3];
            return (record1, record2, record3, record4);
        }



        public void Write_idproduct(string products)
        {
            string question = $"INSERT INTO type_products (products) VALUES('{products}');";
            requestProcessing.Question_Write(question);
        }

        internal void Question_write_main(string products, string dataPurchases, int pricePurchases)
        {
            List<string> records = new List<string>(4);
            int idproduct = Read_product(products, records);
            string question = $"INSERT INTO purchase_information (data, products,price,category) VALUES('{dataPurchases}', {idproduct} ,{pricePurchases},'продукт');";
            requestProcessing.Question_Write(question);
        }
    }
}
