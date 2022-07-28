using System;
using System.Collections.Generic;
using ReactiveUI;
using Shop_products_Avalonia_V1.Models;

namespace Shop_products_Avalonia_V1.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {

        public string _datePurchases = "";
        public int _pricePurchases = 0;
        public string _products = "Продукт";
        Purchase purchase = new Purchase();
        OutputOfRecords outputOfRecords = new OutputOfRecords();
        Products products = new Products();
        public List<object> ret = new List<object>();
        public string _record1 = "";
        public string _record2 = "";
        public string _record3 = "";
        public string _record4 = "";

        public void Record()
        {
            if (DatePurchases != "")
            {
                int idproducts = products.GetProductId(Products);
                purchase.RequestWriteMain(idproducts, DatePurchases, PricePurchases);
            }
            ret = outputOfRecords.Output();
            Record1 = Convert.ToString(ret[2]);
            Record2 = Convert.ToString(ret[3]);
            Record3 = Convert.ToString(ret[4]);
            Record4 = Convert.ToString(ret[5]);
            ret.Clear();
        }


        public string DatePurchases
        {
            get => _datePurchases;
            set => this.RaiseAndSetIfChanged(ref _datePurchases, value);
        }
        public int PricePurchases
        {
            get => _pricePurchases;
            set => this.RaiseAndSetIfChanged(ref _pricePurchases, value);
        }
        public string Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public string Record1
        {
            get => _record1;
            set => this.RaiseAndSetIfChanged(ref _record1, value);
        }
        public string Record2
        {
            get => _record2;
            set => this.RaiseAndSetIfChanged(ref _record2, value);
        }
        public string Record3
        {
            get => _record3;
            set => this.RaiseAndSetIfChanged(ref _record3, value);
        }
        public string Record4
        {
            get => _record4;
            set => this.RaiseAndSetIfChanged(ref _record4, value);
        }
    }
}