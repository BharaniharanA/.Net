using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message)
        {
        }
    }


    internal class NegativeNumException
    {
        public static void Number()
        {
            Console.Write("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
            {
                throw new NegativeNumberException("The number is Negative....");
            }
            else
            {
                Console.WriteLine($"You entered positive number: {num}");
            }
        }
        public static void Main(string[] args)
        {
            try
            {
                Number();
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
