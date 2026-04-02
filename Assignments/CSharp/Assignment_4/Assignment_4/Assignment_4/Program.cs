using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("==== Select the Operation ====");
            Console.WriteLine("1. Remove a character in string.");
            Console.WriteLine("2. Exchange the first and last character in string.");
            Console.WriteLine("3. Sort the stack.");
            Console.WriteLine("4. To Exit.");
            int n = 0;
            
            do
            {
                Console.Write("Enter the option: ");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        RemoveCharacter();
                        break;
                    case 2:
                        ExchangeChar();
                        break;
                    case 3:
                        SortStack();
                        break;
                    case 4:
                        Console.WriteLine("Exited....");
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;

                }
            } while (n != 4);

            }

        public static void RemoveCharacter()
        {

            Console.Write("Enter a string:");
            string input = Console.ReadLine();
            Console.Write("Enter the position to remove: ");
            int position = Convert.ToInt32(Console.ReadLine());
            input = input.Remove(position, 1);
            Console.WriteLine("String after removing the character: " + input);
        }

        public static void ExchangeChar()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            StringBuilder str = new StringBuilder(input);
            char FirstChar = str[0];
            str[0] = str[str.Length - 1];
            str[str.Length - 1] = FirstChar;

            Console.WriteLine("The output: " + str);
        }

        public static void SortStack()
        {
            Stack<int> stack = new Stack<int>();
            Stack<int> stack1 = new Stack<int>();
            Console.Write("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                stack.Push(num);
            }
            int[] arr= stack.ToArray();
            Array.Sort(arr);
            
            foreach (int i in arr)
            {
                stack1.Push(i);
            }
            Console.WriteLine("Stack elements in descending order:");
            foreach (int num in stack1)
            {
                Console.WriteLine(num);
            }
        }
    }
}
