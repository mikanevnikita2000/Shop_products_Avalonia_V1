using System;
using Avalonia.Media;
using ReactiveUI;

namespace Shop_products_Avalonia_V1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        public string _date = "";
        public int _price = 0;
        public string _products = "";
        Query query = new Query();
        public void Read()
        {
            Products = "Продукт";
            Date = "Дата";
            Price = 123;

        }
        public void Query_Con()
        {
            query.Question_write_main(Products, Date, Price);
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
    }
}
/*Console.WriteLine("Введите продукт:");
            string products = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Введите дату:");
            string date = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Введите цену:");
            int price = Convert.ToInt32(Console.ReadLine());
        query.Question_write_main(products, date, price);*/