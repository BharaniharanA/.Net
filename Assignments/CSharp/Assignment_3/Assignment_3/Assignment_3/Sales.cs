using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class SaleDetails
    {
        int salesNo;
        int productNo;
        double price;
        int qty;
        string dateOfSale;
        double totalAmount;

        public SaleDetails(int salesNo, int productNo, double price, int qty, string dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;
        }

        public void Sales()
        {
            totalAmount = qty * price;
        }

        public void ShowData()
        {
            Console.WriteLine("\n--- Sales Details ---");
            Console.WriteLine("Sales No: " + salesNo);
            Console.WriteLine("Product No: " + productNo);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Quantity: " + qty);
            Console.WriteLine("Date of Sale: " + dateOfSale);
            Console.WriteLine("Total Amount: " + totalAmount);
        }
    }
}
