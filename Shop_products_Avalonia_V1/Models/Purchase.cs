using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_products_Avalonia_V1.Models
{
    public class Purchase
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        private string datePurchases;
        private int pricePurchases;
        private int idproducts;

        public string DatePurchases { get { return datePurchases; } set { datePurchases = value; } }
        public int PricePurchases { get { return pricePurchases; } set { pricePurchases = value; } }
        public int Idproducts { get { return idproducts; } set { idproducts = value; } }

        public void Question_write_main(int idproducts, string datePurchases, int pricePurchases)
        {
            Idproducts = idproducts;
            DatePurchases = datePurchases;
            PricePurchases = pricePurchases;
            requestProcessing.Question_Write($"INSERT INTO purchase_information (data, products,price,category) VALUES('{DatePurchases}', {Idproducts} ,{PricePurchases},'продукт');");
        }
    }
}
