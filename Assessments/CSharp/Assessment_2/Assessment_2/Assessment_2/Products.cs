using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Products(int id,string name, decimal price)
        {
            ProductId = id;
            ProductName = name;
            Price = price;
           
        }
    }

    public class ProductIndexer
    {
        public static void Main(string[] args)
        {
            Products[] products = new Products[10];

            for(int i = 0; i < 10; i++)
            {
                Console.Write("Enter Product Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Product Name:");
                string name = Console.ReadLine();
                Console.Write("Enter Product Price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();
                products[i] = new Products(id, name, price);
            }
            Products[] sortedProducts = products.OrderBy(p => p.Price).ToArray();
            Console.WriteLine("==== The Sorted Output =====");
            DisplayProducts(sortedProducts);

        }
        public static void DisplayProducts(Products[] products)
        {
            int i = 1;
            foreach (var product in products)
            {
                Console.WriteLine($"Product{i}\nID: {product.ProductId}\nName: {product.ProductName}\nPrice: {product.Price}\n");
                Console.WriteLine();
                i++;
            }
        }
}

}
