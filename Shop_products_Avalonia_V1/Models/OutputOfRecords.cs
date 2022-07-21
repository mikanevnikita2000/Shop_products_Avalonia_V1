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

        public List<string> Output()
        {
            (idproduct,records, product) = requestProcessing.Question_Read($"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;");
            return records;
        }
    }
}
//(idproduct, records) = requestProcessing.Question_Read($"SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT {numberOfRecords};");
