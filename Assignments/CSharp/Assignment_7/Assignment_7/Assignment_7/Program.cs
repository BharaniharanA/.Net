using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CalculateConsession;
namespace Assignment_7
{
    public class AgeException : Exception
    {
        public AgeException(string message) : base(message)
        {
        }
    }
    internal class Program
    {
        const int TotalFare = 500;
        static string name;
        static int Age;

        public static void Main(string[] args)
        {
            Consoleapp();
        }
        public static void Consoleapp()
        {
            Console.WriteLine("==== Ticket Booking ====");

            Console.Write("Enter your name:");
            name = Console.ReadLine();
            Console.Write("Enter Age:");
            try
            {
               
                Age = Convert.ToInt32(Console.ReadLine());
                if (Age > 0)
                {
                    Console.Write(name + ":");
                    Class1.CalculateConcession(Age, TotalFare);
                }
                else
                {
                    throw new AgeException("Age must be greater than 0.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for age. Please enter a valid integer.");
                
            }
            catch (AgeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
