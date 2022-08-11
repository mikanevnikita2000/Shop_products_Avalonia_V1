﻿using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class ReadingInformationFromTheDB
    {
        public int idproduct = 0;
        List<object> purchase = new List<object>();


        public List<object> IFChec(List<object> ret, SqliteDataReader reader)
        {
            OutputOfRecords outputOfRecords = new OutputOfRecords();

            if (Convert.ToString(ret[0]) == $"SELECT idmain, data, product, price, category  FROM purchase_information INNER JOIN  type_products ON type_products.id_products = purchase_information.products ORDER BY idmain DESC LIMIT {outputOfRecords.numberOfRecords};")
            {
               
                while (reader.Read())
                {
                    ret.Add($"{reader["data"]} : {reader["product"]} : {reader["price"]} : {reader["category"]}");
                    purchase.Clear();
                }
            }
            while (reader.Read())
            {
                ret.Add(Convert.ToInt32(reader["id_products"]));
            }

            return ret;
        }
    }
}
