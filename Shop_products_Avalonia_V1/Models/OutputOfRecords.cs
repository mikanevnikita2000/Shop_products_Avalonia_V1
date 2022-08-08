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
            ret.Add($"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT {numberOfRecords};");
            ret = requestProcessing.ReadFromDB(ret);
            //ret.Remove(0);
            return ret;
        }
    }
}

