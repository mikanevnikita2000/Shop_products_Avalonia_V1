using System;
using System.Collections.Generic;
using ReactiveUI;

namespace Shop_products_Avalonia_V1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
       
        public string _datePurchases = "";
        public int _pricePurchases = 0;
        public string _products = "�������";
        Requests requests = new Requests();
        public string _record1 = "";
        public string _record2 = "";
        public string _record3 = "";
        public string _record4 = "";


        public void Record()
        {
            List<string> records = new List<string>(4);
            if (DatePurchases != "")
            {
                requests.Question_write_main(Products, DatePurchases, PricePurchases);
            }
            (Record1, Record2, Record3, Record4) = requests.Read_String_products(records);
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