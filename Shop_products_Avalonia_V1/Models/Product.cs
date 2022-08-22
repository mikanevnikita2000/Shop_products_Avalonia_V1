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
            ret.Add($"SELECT * FROM type_products WHERE product ='{Product}';");
            
            ret = requestProcessing.ReadFromDB(ret);
            
            if (ret.Count == 1)
            {
                requestProcessing.WriteToDB($"INSERT INTO type_products (product) VALUES('{Product}');");
                ret.Clear();
                ret.Add("SELECT id_products FROM type_products;");
                ret = requestProcessing.ReadFromDB(ret);
                Idproduct = Convert.ToInt32(ret[1]);
                ret.Clear();
                return Idproduct;
            }
            Idproduct = Convert.ToInt32(ret[1]);
            ret.Clear();
            return Idproduct;
        }
    }
}
