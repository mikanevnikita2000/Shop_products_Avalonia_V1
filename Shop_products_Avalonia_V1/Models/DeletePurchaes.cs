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
        List<object> ret = new List<object>();
        public void Delete(string product, string datePurchaes)
        {
            ret.Add($"SELECT id_products FROM type_products;");
            requestProcessing.ReadFromDB(ret);
            string request = $"DELETE FROM books WHERE data='{datePurchaes}' and products='{ret[1]}'";
            requestProcessing.WriteToDB(request);
        }
    }
}
