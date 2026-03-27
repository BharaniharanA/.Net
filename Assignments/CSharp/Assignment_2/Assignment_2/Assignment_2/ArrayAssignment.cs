using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Assignment_2
{
    internal class ArrayAssignment
    {
        public static void Main()
        {
            FuncArray();
            Marks();
            CopyArray();
        }

        public static void FuncArray()
        {
            Console.WriteLine("To find average and maximum of the Array.");
            Console.WriteLine();
            Console.Write("Enter the length of Array :");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine($"Enter the integer values");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine($"The Average value of the array is:{arr.Average()}");
            Console.WriteLine($"The Maximum value of the array is:{arr.Max()} and the Minimum value of the array is:{arr.Min()}");
            Console.WriteLine();
        }

        public static void Marks()
        {
            Console.WriteLine("To perform marks array.");
            Console.WriteLine();
            double[] marks = new double[10];

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter the mark of subject {i + 1}: ");
                marks[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The total marks : {marks.Sum()}");
            Console.WriteLine();
            Console.WriteLine($"The average marks : {marks.Average()}");
            Console.WriteLine();
            Console.WriteLine($"The highest mark : {marks.Max()}");
            Console.WriteLine();
            Console.WriteLine($"The lowest mark : {marks.Min()}");
            Console.WriteLine();

            Console.WriteLine("The marks in ascending order:");
            Array.Sort(marks);
            Console.WriteLine();
            foreach (double mark in marks)
            {
                Console.WriteLine(mark);
            }
            Console.WriteLine();
            Console.WriteLine("The marks in descending order:");
            for (int i = 9; i >= 0; i--)
            {
                Console.WriteLine(marks[i]);

            }
            Console.WriteLine();
        }

        public static void CopyArray()
        {
            Console.WriteLine("To copy the Array.");
            Console.WriteLine();
            Console.Write("Enter the length of Array :");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine($"Enter the integer values");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();

            int[] CopyArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                CopyArr[i] = arr[i];
            }
            Console.WriteLine("The values in the copied array are");
            foreach (int val in CopyArr)
            {
                Console.WriteLine(val);
            }
        }
    }
}
