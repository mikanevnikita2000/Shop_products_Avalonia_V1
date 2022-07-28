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


        public List<object> IFChec(List<object> ret,string request, SqliteDataReader reader)
        {
            OutputOfRecords outputOfRecords = new OutputOfRecords();

            if (request == $"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT {outputOfRecords.numberOfRecords};")
            {
                int i = 2;
                while (reader.Read())
                {
                    string datePurchase = Convert.ToString(reader["data"]);
                    idproduct = Convert.ToInt32(reader["products"]);
                    int pricePurchase = Convert.ToInt32(reader["price"]);
                    request = $"SELECT * FROM type_products WHERE id_products = {idproduct};";
                    ret = requestProcessing.ReadFromDB(request);
                    string category = Convert.ToString(reader["category"]);
                    ret[i] = $"{datePurchase} : {ret[1]} : {pricePurchase} : {category}";
                    i++;
                }
            }
            if (request == $"SELECT * FROM type_products WHERE id_products = {idproduct};")
            {
                while (reader.Read())
                {
                    product = Convert.ToString(reader["products"]);
                }
                ret[1] = product;
            }
            while (reader.Read())
            {
                idproduct = Convert.ToInt32(reader["id_products"]);
                ret[0] = idproduct;
            }

            return ret;
        }
    }
}
