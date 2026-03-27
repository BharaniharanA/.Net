using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class StringAssignment
    {
        public static void Main(string[] args)
        {
            StringLength();
            StringReverse();
            CheckStringEqual();
        }


        public static void StringLength()
        {
            Console.WriteLine("To find length of string.");
            Console.WriteLine();
            Console.Write("Enter a string:");
            string str = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"The length of the string is: {str.Length}");
        }
        public static void StringReverse()
        {
            Console.WriteLine();
            Console.WriteLine("To reverse the string.");
            Console.WriteLine();
            Console.Write("Enter a string:");
            string str = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"The Reverse of the string is:");
            for (int i=str.Length-1;i>=0;i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }

        public static void CheckStringEqual()
        {
            Console.WriteLine();
            Console.WriteLine("To check the two strings are Equal.");
            Console.WriteLine();
            Console.Write("Enter the first string:");
            string str1 = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter the second string:");
            string str2 = Console.ReadLine();
            Console.WriteLine();
            if (str1==str2)
            {
                Console.WriteLine("The strings are equal.");
            }
            else
            {
                Console.WriteLine("The strings are not equal.");
            }
        }
    }


}
