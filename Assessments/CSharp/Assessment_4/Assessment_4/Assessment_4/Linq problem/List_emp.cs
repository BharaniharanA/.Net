using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4.Linq_problem
{
    public class List_emp
    {
        public static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
        {
            new Employee{EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager", DOB="16/11/1984", DOJ="08/06/2011", City="Mumbai"},
            new Employee{EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager", DOB="20/08/1984", DOJ="07/07/2012", City="Mumbai"},
            new Employee{EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant", DOB="14/11/1987", DOJ="12/04/2015", City="Pune"},
            new Employee{EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE", DOB="03/06/1990", DOJ="02/02/2016", City="Pune"},
            new Employee{EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE", DOB="08/03/1991", DOJ="02/02/2016", City="Mumbai"},
            new Employee{EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant", DOB="07/11/1989", DOJ="08/08/2014", City="Chennai"},
            new Employee{EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant", DOB="02/12/1989", DOJ="01/06/2015", City="Mumbai"},
            new Employee{EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate", DOB="11/11/1993", DOJ="06/11/2014", City="Chennai"},
            new Employee{EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate", DOB="12/08/1992", DOJ="03/12/2014", City="Chennai"},
            new Employee{EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager", DOB="12/04/1991", DOJ="02/01/2016", City="Pune"}
        };
            
            // a. All employees
            Console.WriteLine("\nAll Employees:");
            var allEmployees = from e in empList
                               select e;
            foreach (var e in allEmployees)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title} {e.DOB} {e.DOJ} {e.City}");
            }

            // b. Not Mumbai
            Console.WriteLine("\nEmployees not in Mumbai:");
            var notMumbai = from e in empList
                             where e.City != "Mumbai"
                             select e;
            foreach (var e in notMumbai)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title} {e.DOB} {e.DOJ} {e.City}");
            }


            // c. AsstManager
            Console.WriteLine("\nAsstManager Employees:");
            var asstManagers = from e in empList
                               where e.Title == "AsstManager"
                               select e;
            foreach (var e in asstManagers)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title} {e.DOB} {e.DOJ} {e.City}");
            }


            // d. Last Name starts with 'S'
            Console.WriteLine("\nLast Name starts with S:");
            var lastNameS = from e in empList
                                  where e.LastName.StartsWith("S")
                                  select e;
            foreach (var e in lastNameS)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title} {e.DOB} {e.DOJ} {e.City}");
            }

        }
    }
}
