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
        private DateTime datePurchases;
        private int pricePurchases;
        private int idproducts ;
        private string category;

        public string Category { get { return category; } set { category = value; } }
        public DateTime DatePurchases { get { return datePurchases; } set { datePurchases = value; } }
        public int PricePurchases { get { return pricePurchases; } set { pricePurchases = value; } }
        public int Idproducts { get { return idproducts; } set { idproducts = value; } }

        public void RequestWriteMain(int idproducts ,string category ,int pricePurchases)
        {
            Category = category;
            Idproducts = idproducts;
            DatePurchases = DateTime.Now;
            DatePurchases.ToShortDateString();
            PricePurchases = pricePurchases;
            requestProcessing.WriteToDB($"INSERT INTO purchase_information (data, products,price,category) VALUES('{DatePurchases}', {Idproducts} ,{PricePurchases},'{Category}');");

        }
    }
}
