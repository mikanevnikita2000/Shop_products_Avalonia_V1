using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_products_Avalonia_V1.Models
{
    public class Products
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        private string product = "";
        private int idproduct = 0;
        public List<string> records = new List<string>();

        public int Idproduct { get { return idproduct; } set { idproduct = value; } }
        public string Product { get { return product; } set { product = value; } }

        public int CheckingIdProduct(string product)
        {
            Idproduct = 0;
            Product = product;
            (Idproduct, records, string value) = requestProcessing.Question_Read($"SELECT * FROM type_products WHERE products ='{Product}';");
            if (Idproduct ==0)
            {
                requestProcessing.Question_Write($"INSERT INTO type_products (products) VALUES('{Product}');");
                (Idproduct, records, value) = requestProcessing.Question_Read("SELECT id_products FROM type_products;");
            }
            return Idproduct;
        }
    }
}
