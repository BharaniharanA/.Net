using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Assignment_1
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    internal class Program
    {
        static void Main(String[] args)
        {
            Linq();
        }
        static void Display(List<Employee> emp)
        {
            foreach (var item in emp)
            {
                Console.WriteLine($"EmployeeId: {item.EmployeeID} , FirstName: {item.FirstName} , LastName: {item.LastName} , Title: {item.Title} , DOB: {item.DOB} , DOJ: {item.DOJ} , City: {item.City}");
            }
        }

        static List<Employee> GetEmployees()
        {
            List<Employee> Emplist = new List<Employee>()
            {
                new Employee{EmployeeID=1001,FirstName="Malcolm",LastName="Daruwalla",Title="Manager",DOB=DateTime.Parse("1984-11-16"),DOJ=DateTime.Parse("2011-06-08"),City="Mumbai"},
                new Employee{EmployeeID=1002,FirstName="Asdin",LastName="Dhalla",Title="AsstManager",DOB=DateTime.Parse("1984-08-20"),DOJ=DateTime.Parse("2012-07-07"),City="Mumbai"},
                new Employee{EmployeeID=1003,FirstName="Madhavi",LastName="Oza",Title="Consultant",DOB=DateTime.Parse("1987-11-14"),DOJ=DateTime.Parse("2015-04-12"),City="Pune"},
                new Employee{EmployeeID=1004,FirstName="Saba",LastName="Shaikh",Title="SE",DOB=DateTime.Parse("1990-06-03"),DOJ=DateTime.Parse("2016-02-02"),City="Pune"},
                new Employee{EmployeeID=1005,FirstName="Nazia",LastName="Shaikh",Title="SE",DOB=DateTime.Parse("1991-03-08"),DOJ=DateTime.Parse("2016-02-02"),City="Mumbai"},
                new Employee{EmployeeID=1006,FirstName="Amit",LastName="Pathak",Title="Consultant",DOB=DateTime.Parse("1989-11-07"),DOJ=DateTime.Parse("2014-08-08"),City="Chennai"},
                new Employee{EmployeeID=1007,FirstName="Vijay",LastName="Natrajan",Title="Consultant",DOB=DateTime.Parse("1989-12-02"),DOJ=DateTime.Parse("2015-06-01"),City="Mumbai"},
                new Employee{EmployeeID=1008,FirstName="Rahul",LastName="Dubey",Title="Associate",DOB=DateTime.Parse("1993-11-11"),DOJ=DateTime.Parse("2014-11-06"),City="Chennai"},
                new Employee{EmployeeID=1009,FirstName="Suresh",LastName="Mistry",Title="Associate",DOB=DateTime.Parse("1992-08-12"),DOJ=DateTime.Parse("2014-12-03"),City="Chennai"},
                new Employee{EmployeeID=1010,FirstName="Sumit",LastName="Shah",Title="Manager",DOB=DateTime.Parse("1991-04-12"),DOJ=DateTime.Parse("2016-01-02"),City="Pune"},
            };

            return Emplist;
        }

        static void Linq()
        {
            List<Employee> employees = GetEmployees();

            //1. Display a list of all the employee who have joined before 1/1/2015
            Console.WriteLine("1) All the employee who have joined before 1/1/2015");
            Console.WriteLine();
            var q1 = employees.Where(e => e.DOJ < DateTime.Parse("2015-1-1")).ToList();
            Display(q1);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //2. Display a list of all the employee whose date of birth is after 1/1/1990
            Console.WriteLine("2) All the employee whose date of birth is after 1/1/1990");
            Console.WriteLine();
            var q2 = employees.Where(e => e.DOB > DateTime.Parse("1990-1-1")).ToList();
            Display(q2);

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //3.Display a list of all the employee whose designation is Consultant and Associate
            Console.WriteLine("3) All the employee whose designation is Consultant and Associate");
            Console.WriteLine();
            var q3 = employees.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            Display(q3);

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //4. Display total number of employees
            Console.WriteLine($"4) Total Employees: {employees.Count()}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //5. Display total number of employees belonging to “Chennai”
            Console.WriteLine($"5) Total Employees belonging to Chennai: {employees.Count(e => e.City == "Chennai")}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //6. Display highest employee id from the list
            Console.WriteLine($"6) Highest employee id: {employees.Max(e => e.EmployeeID)}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //7. Display total number of employee who have joined after 1/1/2015
            Console.WriteLine($"7) Total number of employee who have joined after 1/1/2015: {employees.Count(e => e.DOJ > DateTime.Parse("2015-1-1"))}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //8. Display total number of employee whose designation is not “Associate"
            Console.WriteLine($"8) Total number of employee designation is not Associate: {employees.Count(e => e.Title != "Associate")}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //9. Display total number of employee based on City
            Console.WriteLine($"9) Total number of employee based on City: ");
            var q9 = employees.GroupBy(e => e.City);

            foreach (var group in q9)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //10.Display total number of employee based on city and title
            Console.WriteLine($"10) Total number of employee based on City and Title : ");
            Console.WriteLine();
            var q10 = employees.GroupBy(e => new { e.City, e.Title });

            foreach (var group in q10)
            {
                Console.WriteLine(group.Key.City + " - " + group.Key.Title + " : " + group.Count());
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();

            //11.Display total number of employee who is youngest in the list
            Console.WriteLine($"11) The employee who is youngest in the list: ");
            Console.WriteLine();
            var emp = employees.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"EmployeeId: {emp.EmployeeID} , FirstName: {emp.FirstName} , LastName: {emp.LastName} , Title: {emp.Title} , DOB: {emp.DOB} , DOJ: {emp.DOJ} , City: {emp.City}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine();
        }

    }
}
