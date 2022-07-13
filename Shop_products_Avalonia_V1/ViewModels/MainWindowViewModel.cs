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
        ReadAndWriteRequests readAndWriteRequests = new ReadAndWriteRequests();
        public string _record1 = "";
        public string _record2 = "";
        public string _record3 = "";
        public string _record4 = "";

        public void Record()
        {
            Purchase purchase = new Purchase();
            readAndWriteRequests.Read_String_products();
            Record1 = purchase.records[0];
            Record2 = purchase.records[1];
            Record3 = purchase.records[2];
            Record4 = purchase.records[3];

            if (DatePurchases != "")
            {
                (purchase.Product, purchase.DatePurchase, purchase.PricePurchase) = (Products, DatePurchases, PricePurchases);
                readAndWriteRequests.Question_write_main();
            }
            
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