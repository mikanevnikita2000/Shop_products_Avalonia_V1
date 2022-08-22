using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class ReadingInformationFromTheDB
    {
        public int idproduct = 0;
        public List<object> IFChec(List<object> ret, SqliteDataReader reader)
        {
            OutputOfRecords outputOfRecords = new OutputOfRecords();

            if (Convert.ToString(ret[0]) == $"SELECT idmain, data, product, price, category, id_products  FROM purchase_information INNER JOIN  type_products ON type_products.id_products = purchase_information.products ORDER BY idmain DESC LIMIT {outputOfRecords.numberOfRecords};")
            {
                while (reader.Read())
                {
                    ret.Add($"{reader["data"]} : {reader["product"]} : {reader["price"]} : {reader["category"]}");
                }
            }
            while (reader.Read())
            {
                idproduct=Convert.ToInt32(reader["id_products"]);
            }
            ret.Add(idproduct);
            return ret;
        }
    }
}
