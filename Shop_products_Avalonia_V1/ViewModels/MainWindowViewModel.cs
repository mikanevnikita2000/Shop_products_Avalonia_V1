using System;
using System.Collections.Generic;
using Avalonia.Controls;
using ReactiveUI;
using Shop_products_Avalonia_V1.Models;
using Shop_products_Avalonia_V1.Views;


namespace Shop_products_Avalonia_V1.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {

        public string _datePurchases = "Дата";
        public int _pricePurchases = 0;
        public string _products = "Продукт";
        public string _category = "Категория";
        Purchase purchase = new Purchase();
        OutputOfRecords outputOfRecords = new OutputOfRecords();
        Products products = new Products();
        DeletePurchaes deletePurchaes = new DeletePurchaes();
        public List<object> ret = new List<object>();
        public string _record1 = "";
        public string _record2 = "";
        public string _record3 = "";
        public string _record4 = "";
        //public string _numberRecordDelete = "";

        public void Record()
        {
            if (Products != "Продукт")// DatePurchases != null
            {
                int idproducts = products.GetProductId(Products);
                purchase.RequestWriteMain(idproducts, Category, PricePurchases);
                ret = outputOfRecords.Output();
                Record1 = Convert.ToString(ret[1]);
                Record2 = Convert.ToString(ret[2]);
                Record3 = Convert.ToString(ret[3]);
                Record4 = Convert.ToString(ret[4]);
                ret.Clear();
            }

        }

        public void Date()
        {
            DateTime dateTime = DateTime.Now;
            Date date = new();
            date.Show();
            var cal1 = this.FindControl<Calendar>("DisplayDatesCalendar");
            dateTime = Convert.ToDateTime(cal1.DisplayDate);
        }
        public void DeleteWindows()
        {
            
            DeleteWindow deleteWindow = new ();
            deleteWindow.Show();
            Products = "Продукт";
            DatePurchases = "Дата";
        }
        public void DeletePurchaes()
        {
            deletePurchaes.Delete(Products, DatePurchases);
        }


        //public DateTime DisplayDate { get; set; }
        public string DatePurchases
        {
            get => _datePurchases;
            set => this.RaiseAndSetIfChanged(ref _datePurchases, value);
        }
        public string Category
        {
            get => _category;
            set => this.RaiseAndSetIfChanged(ref _category, value);
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