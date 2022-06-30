using System;
using System.Collections.Generic;
using ReactiveUI;

namespace Shop_products_Avalonia_V1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
       
        public string _date ="";
        public int _price = 0;
        public string _products = "Продукт";
        Requests requests = new Requests();
        public string _record1 = "";
        public string _record2 = "";
        public string _record3 = "";
        public string _record4 = "";
        public string _record5 = "";


        public void Question_Con()
        {
            List<string> records = new List<string>(4);
            requests.Question_write_main(Products, Date, Price);
            (Record1, Record2, Record3, Record4) = requests.Question_read_String_products(records);
        }
        

        public string Date
        {
            get => _date;
            set => this.RaiseAndSetIfChanged(ref _date, value);
        }
        public int Price
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
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