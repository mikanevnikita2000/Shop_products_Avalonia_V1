using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_products_Avalonia_V1.Models
{
    public class DeletePurchaes
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        
        
        public void Delete(string product, string datePurchaes)
        {
            List<object> ret = new List<object>();
            ret.Add($"SELECT id_products FROM type_products WHERE product ='{product}';");
            ret = requestProcessing.ReadFromDB(ret);
            DateTime dateTime = Convert.ToDateTime(datePurchaes);
            string request = $"DELETE FROM purchase_information WHERE data='{datePurchaes}' and products='{ret[1]}';";
            requestProcessing.WriteToDB(request);
        }
    }
}
