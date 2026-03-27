using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNumWithSpace();
            PrintDays();
            
        }

        public static void PrintNumWithSpace()
        {
            Console.WriteLine("To perform number printing.");
            Console.WriteLine();
            Console.Write("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {1} {2} {3}", num, num, num, num);
                Console.WriteLine("{0}{1}{2}{3}", num, num, num, num);
            }
            Console.WriteLine();

        }

        enum Days
        {
            Monday=1, Tuesday=2, Wednesday=3, Thursday=4, Friday=5, Saturday=6, Sunday=7

        }

        public static void PrintDays()
        {
            Console.WriteLine("To check the number with the days.");
            Console.WriteLine();
            Console.WriteLine("Please enter a number between 1 and 7");
            Console.Write("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 1 || num > 7)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            Console.WriteLine("The corresponding day is: " + Enum.GetName(typeof(Days), num));
        }

    }
}
