using System;
using System.Collections.Generic;

namespace Shop_products_Avalonia_V1.Models
{
    public class Products
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        private string product = "";
        private int idproduct = 0;
        List<object> ret = new List<object>();

        public int Idproduct { get { return idproduct; } set { idproduct = value; } }
        public string Product { get { return product; } set { product = value; } }

        public int GetProductId(string product)
        {
            Idproduct = 0;
            Product = product;
            ret = requestProcessing.ReadFromDB($"SELECT * FROM type_products WHERE products ='{Product}';");
            Idproduct = Convert.ToInt32(ret[0]);
            if (Idproduct ==0)
            {
                requestProcessing.ReadFromDB($"INSERT INTO type_products (products) VALUES('{Product}');");
                ret = requestProcessing.ReadFromDB("SELECT id_products FROM type_products;");
                Idproduct = Convert.ToInt32(ret[0]);
            }
            return Idproduct;
        }
    }
}
