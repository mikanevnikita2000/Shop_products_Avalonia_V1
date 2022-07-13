using System.Collections.Generic;
using ReactiveUI;
using Shop_products_Avalonia_V1.Models;

namespace Shop_products_Avalonia_V1.Models 
{ 
    public class Purchase : ReactiveObject
    {
        public string datePurchases ;
        public int pricePurchases ;
        public string products;
        public int idproduct;
        public List<string> records = new List<string>(4);
        public string question ;
        public string category ="Продукт";

        public string DatePurchase
        {
            get => datePurchases;
            set => this.RaiseAndSetIfChanged(ref datePurchases, value);
        }

        public int PricePurchase
        {
            get => pricePurchases;
            set => this.RaiseAndSetIfChanged(ref pricePurchases, value);
        }

        public string Product
        {
            get => products;
            set => this.RaiseAndSetIfChanged(ref products, value);
        }

        public int Idproduct
        {
            get => idproduct;
            set => this.RaiseAndSetIfChanged(ref idproduct, value);
        }

        public List<string> Records
        {
            get => records;
            set => this.RaiseAndSetIfChanged(ref records, value);
        }

        public string Question
        {
            get => question;
            set => this.RaiseAndSetIfChanged(ref question, value);
        }

       
        /*public void OverwriteValues(string products,string datePurchases, int pricePurchases)
        {
            _datePurchases = datePurchases;
            _pricePurchases = pricePurchases;
            _products = products;
        }*/
    }
}
