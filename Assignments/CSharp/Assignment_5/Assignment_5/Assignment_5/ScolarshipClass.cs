using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class UserException : Exception
    {
        public UserException(string message) : base(message) { }
    }
    class Scolarship
    {
        int mark;
        double fees;
        public Scolarship(int mark, double fees)
        {
            this.mark = mark;
            this.fees = fees;
        }
        public void Merit()
        {
            if (this.mark > 70 && this.mark <= 80)
                Console.WriteLine("Scolarship amount: " + this.fees * 0.2);
            else if (this.mark > 80 && this.mark <= 90)
                Console.WriteLine("Scolarship amount: " + this.fees * 0.3);
            else if (this.mark > 90 && this.mark <= 100)
                Console.WriteLine("Scolarship amount: " + this.fees * 0.5);
            else if (this.mark > 100 || this.mark < 0)
                throw new UserException("Invalid mark....");
            else
                throw new UserException("Your not eligile for Scolarship....");

        }
    }
    internal class ScolarshipClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Scolarship serivces");
            Console.Write("Enter your mark (out of 100): ");
            int mark= Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your fees : ");
            int fees = Convert.ToInt32(Console.ReadLine());
            Scolarship s = new Scolarship(mark,fees);
            try
            {
                s.Merit();
            }
            catch (UserException ue)
            {
                Console.WriteLine(ue.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}
