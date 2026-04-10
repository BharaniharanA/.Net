using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateConsession
{
    public class Class1
    {
        public static void CalculateConcession(int age, double fare)
        {
            if (age <= 5 && age >0)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if (age > 60)
                Console.WriteLine("Senior Citizen - Fare: " + (fare * 0.7));
            else
                Console.WriteLine("Ticket Booked - Fare: " + fare);
        }
    }
}