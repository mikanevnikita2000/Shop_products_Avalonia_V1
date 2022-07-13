using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_products_Avalonia_V1.Models
{
    public class ReadAndWriteRequests
    {
        RequestProcessing requestProcessing = new RequestProcessing();
        Purchase purchase = new Purchase();


        public void Read_product()
        {
            purchase.Question = $"SELECT * FROM type_products WHERE products ='{purchase.Product}';";
            
           
            if (purchase.Idproduct == 0)
            {
                Write_idproduct();
                purchase.Question = "SELECT id_products FROM type_products;";
                requestProcessing.Question_read();
            }
            requestProcessing.Question_read();
        }

        public void Read_String_products()
        {
            purchase.Question = "SELECT * FROM purchase_information ORDER BY idmain DESC LIMIT 4;";
            requestProcessing.Question_read();
        }



        public void Write_idproduct()
        {
            purchase.Question = $"INSERT INTO type_products (products) VALUES('{purchase.Product}');";
            requestProcessing.Question_Write();
        }

        internal void Question_write_main()
        {
            Read_product();
            purchase.Question = $"INSERT INTO purchase_information (data, products,price,category) VALUES('{purchase.DatePurchase}', {purchase.Idproduct} ,{purchase.PricePurchase},'продукт');";
            requestProcessing.Question_Write();
        }
    }
}
