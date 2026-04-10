using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Query
    {
        static void Main(string[] args)
        {
            //First question call
            SquareOfNumGreaterThan20();

            Console.WriteLine("=====================");
            // Second question call
            LetterSearchInWord();


        }

        // First question implementation
        public static void SquareOfNumGreaterThan20()
        {
            Console.Write("Enter the size of list:");
            int size = Convert.ToInt32(Console.ReadLine());

            List<int> list = new List<int>();

            Console.WriteLine("Enter the elements of the list:");

            for (int i = 0; i < size; i++)
            {
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }

            var list1 = from n in list
                        where n * n > 20
                        select n;

            Console.WriteLine("==== Output ====");

            foreach (var item in list1)
            {
                Console.WriteLine($"{item} - {item * item}");
            }
        }

        // Second question implementation
        public static void LetterSearchInWord()
        {
            Console.Write("Enter the size of list:");
            int size = Convert.ToInt32(Console.ReadLine());

            List<string> list = new List<string>();

            Console.WriteLine("Enter the string of the list:");

            for (int i = 0; i < size; i++)
            {
                list.Add(Console.ReadLine());
            }

            var list1 = from n in list
                        where n.StartsWith("a") && n.EndsWith("m")
                        select n;

            Console.WriteLine("==== Output ====");

            foreach (var item in list1)
            {
                Console.WriteLine($"{item}");
            }
        }




    }

}
