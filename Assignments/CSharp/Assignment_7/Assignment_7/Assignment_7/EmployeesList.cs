using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class Employee
    {
        public int EmpId;
        public string EmpName;
        public string EmpCity;
        public double EmpSalary;

        public Employee(int Id,string Name,string City,double Salary)
        {
            EmpId = Id;
            EmpName = Name;
            EmpCity = City;
            EmpSalary = Salary;
        }
    }
    internal class EmployeesList
    {
        
        public static void Main(string[] args)
        {
            List<Employee> employees = Initializaition();
         
            Menu(employees); 
        }

        public static List<Employee> Initializaition()
        {
            List<Employee> employees = new List<Employee>();
            Console.Write("Enter the size of Employee list:");
            int size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the details of Employee {i + 1}:");
                Console.Write("EmpId:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("EmpName:");
                string name = Console.ReadLine();
                Console.Write("EmpCity:");
                string city = Console.ReadLine();
                Console.Write("EmpSalary:");
                double salary = Convert.ToDouble(Console.ReadLine());
                Employee employee = new Employee(id, name, city, salary);
                employees.Add(employee);
            }
            return employees;
        }
        public static void Menu(List<Employee> employees)
        {
            int n;
            do
            {
                Console.WriteLine();
                Console.WriteLine("==== Employee Management System ====");
                Console.WriteLine("1) To display all employees data");
                Console.WriteLine("2) To display all employees data whose salary is greater than 45000");
                Console.WriteLine("3) To display all employees data who belong to Bangalore Region");
                Console.WriteLine("4) To display all employees data by their names in Ascending order");
                Console.WriteLine("5) To exit");
                Console.Write("Enter the choice:");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        DisplayAllEmpData(employees);
                        break;
                    case 2:
                        SalaryGreaterThan(employees);
                        break;
                    case 3:
                        RegionInEmployee(employees);
                        break;
                    case 4:
                        SortingEmpByName(employees);
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program....");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (n!=5);
            
        }
        public static void DisplayAllEmpData(List<Employee> employees)
        {
            Console.WriteLine("==== All Employees Data ====");
            foreach (var employee in employees)
            {
                Console.WriteLine($"EmpId:{employee.EmpId} , EmpName:{employee.EmpName} , EmpCity:{employee.EmpCity} , EmpSalary:{employee.EmpSalary}");
            }
        }

        public static void SalaryGreaterThan(List<Employee> employees)
        {
            Console.WriteLine("==== Employees with Salary Greater Than 45000 ====");
            foreach (var employee in employees)
            {
                if (employee.EmpSalary > 45000)
                {
                    Console.WriteLine($"EmpId:{employee.EmpId} , EmpName:{employee.EmpName} , EmpCity:{employee.EmpCity} , EmpSalary:{employee.EmpSalary}");
                }
            }
        }

        public static void  RegionInEmployee(List<Employee> employees)
        {
            Console.WriteLine("==== Employees from Bangalore ====");
            foreach (var employee in employees)
            {
                if (employee.EmpCity == "Bangalore" || employee.EmpCity == "bangalore")
                {
                    Console.WriteLine($"EmpId:{employee.EmpId} , EmpName:{employee.EmpName} , EmpCity:{employee.EmpCity} , EmpSalary:{employee.EmpSalary}");
                }
            }
        }

        public static void SortingEmpByName(List<Employee> employees)
        {
            Console.WriteLine("==== Employees Sorted by Name ====");
            var SortedEmployee = from n in employees
                                 orderby n.EmpName
                                 select n;
            foreach (var employee in SortedEmployee)
            {
                Console.WriteLine($"EmpId:{employee.EmpId} , EmpName:{employee.EmpName} , EmpCity:{employee.EmpCity} , EmpSalary:{employee.EmpSalary}");
            }
        }
    }
}
