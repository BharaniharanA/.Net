using System;
using System.Collections.Generic;

namespace Assessment_1
{
    struct DateOfBirth
    {
        public int Day;
        public int Month;
        public int Year;
    }
    struct EmployeeDetails
    {
        public string Name;
        public DateOfBirth Dob;
    }
    internal class EmployeeDob
    {
        static List<EmployeeDetails> employeedetails = new List<EmployeeDetails>();
        static void Main(String[] Args)
        {

            Console.Write("Enter the Number of employee details to be entered: ");
            int n = Convert.ToInt32(Console.ReadLine());
            AddEmployeeDetails(n);
            ShowEmployeeDetails();
        }

        public static void AddEmployeeDetails(int n)
        {
            Console.WriteLine("Enter the Employee Details");

            for (int i = 0; i < n; i++)
            {

                EmployeeDetails details = new EmployeeDetails();

                Console.Write("Name of the employee: ");
                details.Name = Console.ReadLine();

                Console.Write("Input day of the birth: ");
                details.Dob.Day = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input month of the birth: ");
                details.Dob.Month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input year of the birth: ");
                details.Dob.Year = Convert.ToInt32(Console.ReadLine());

                employeedetails.Add(details);
                Console.WriteLine();
            }

        }

        public static void ShowEmployeeDetails()
        {
            Console.WriteLine("==== Employee Details ====");
            foreach (var em in employeedetails)
            {

                Console.WriteLine($"\nName: {em.Name}");
                Console.WriteLine($"DOB: {em.Dob.Day}/{em.Dob.Month}/{em.Dob.Year}");

            }
        }
    }
}
