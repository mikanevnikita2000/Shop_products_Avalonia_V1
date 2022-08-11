using System.Collections.Generic;

namespace Shop_products_Avalonia_V1.Models
{
    public class OutputOfRecords
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        public int numberOfRecords = 4;
        public int idproduct = 0;
        public string product = "";
        public List<string> records =new List<string>();
        List<object> ret = new List<object>();

        public List<object> Output()
        {
            ret.Add($"SELECT idmain, data, product, price, category  FROM purchase_information INNER JOIN  type_products ON type_products.id_products = purchase_information.products ORDER BY idmain DESC LIMIT {numberOfRecords};");
            ret = requestProcessing.ReadFromDB(ret);
            return ret;
        }
    }
}

