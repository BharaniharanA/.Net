using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Accounts
            Accounts acc = new Accounts(101, "Arun", "Savings", 5000);
            acc.Transaction('D', 2000);
            acc.Transaction('W', 1000);
            acc.ShowData();

            // 2. Student
            Student s = new Student(1, "Kumar", "BSc", 3, "CS");
            s.DisplayData();
            s.GetMarks();
            s.DisplayResult();

            // 3. SaleDetails
            SaleDetails sale = new SaleDetails(1, 1001, 50, 10, "01-04-2026");
            sale.Sales();
            sale.ShowData();
        }
    }
}