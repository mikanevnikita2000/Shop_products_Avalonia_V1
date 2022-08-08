using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class ReadingInformationFromTheDB
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        public int idproduct = 0;
        string product = "";
        List<object> purchase = new List<object>();
        List<object> product_name = new List<object>();


        public List<object> IFChec(List<object> ret, SqliteDataReader reader)
        {
            OutputOfRecords outputOfRecords = new OutputOfRecords();
            if (ret.Count==0)
            {
                ret.Add(idproduct);
                ret.Add(product);
            }
            

            if (Convert.ToString(ret[0]) == $"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT {outputOfRecords.numberOfRecords};")
            {
               
                while (reader.Read())
                {
                    purchase.Add(Convert.ToString(reader["data"]));//0
                    purchase.Add(Convert.ToInt32(reader["products"]));//1
                    product_name.Add($"SELECT * FROM type_products WHERE id_products = {Convert.ToString(purchase[1])};");
                    product_name.Add(purchase[1]);
                    purchase.Add(Convert.ToInt32(reader["price"]));//1
                    purchase.Add(Convert.ToString(reader["category"]));//2
                    product_name = requestProcessing.ReadFromDB(product_name);
                    purchase.Add(product_name[2]);//3
                    ret.Add($"{purchase[0]} : {purchase[4]} : {purchase[2]} : {purchase[3]}");
                    purchase.Clear();
                    product_name.Clear();


                }
            }
            if (Convert.ToString(ret[0]) == $"SELECT * FROM type_products WHERE id_products = {ret[1]};")
            {
                while (reader.Read())
                {
                    product = Convert.ToString(reader["products"]);
                }
                ret.Add(product);
            }
            while (reader.Read())
            {
                ret.Add(Convert.ToInt32(reader["id_products"]));
            }

            return ret;
            ret.Clear();
        }
    }
}
