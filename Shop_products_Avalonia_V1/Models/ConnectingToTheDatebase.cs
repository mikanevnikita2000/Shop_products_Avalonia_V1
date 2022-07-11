using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Shop_products_Avalonia_V1.Models
{
    public class ConnectingToTheDatebase
    {
        public RequestProcessing RequestProcessing
        {
            get => default;
            set
            {
            }
        }

        public SqliteConnection ConDB()
        {
            using (var connection = new SqliteConnection("Data Source = shop.db"))
            {
                return connection;
            }
        }
    }
}
