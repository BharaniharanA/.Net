using System;
using System.Collections.Generic;

namespace Assessment_1
{
      class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;

    }
    class Program
    {
        static List<Employee> employee = new List<Employee>();
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== Employee Management Menu ====");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. View all employee");
                Console.WriteLine("3. Search employee by Id");
                Console.WriteLine("4. Update employee details");
                Console.WriteLine("5. Delete employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("=======================================");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewAllEmployee();
                        break;
                    case 3:
                        SearchEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exited.........");
                        break;
                    default:
                        Console.WriteLine("Invalid Input.....");
                        break;
                }
            } while (choice != 6);
        }

        public static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter Id: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            employee.Add(emp);

            Console.WriteLine("New employee added successfully!....");
        }

        public static  void ViewAllEmployee()
        {
            if (employee.Count > 0)
            {
                foreach (var emp in employee)
                {
                    Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
                }
            }
            else
            {
                Console.WriteLine("Employee Data is empty");
            }
             
        }

        public static void SearchEmployee()
        { 
            Console.Write("Enter Employee Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool flag = false;
            foreach (var emp in employee)
            {
                
                if (emp.Id == id)
                {
                    Console.WriteLine("Employee found....");
                    Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
                    flag = true;
                }
                
            }
            if(!flag)
            {
                Console.WriteLine("Employee  not found....");
            }
        }

        public static void UpdateEmployee()
        {
            Console.Write("Enter Employee Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool flag = false;
            foreach (var emp in employee)
            {

                if (emp.Id == id)
                {
                    Console.Write("Enter Name: ");
                    emp.Name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    emp.Department = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    emp.Salary = Convert.ToDouble(Console.ReadLine());
                    flag = true;
                    Console.WriteLine("Employee Updated....");
                }

            }
            if (!flag)
            {
                Console.WriteLine("Employee  not found....");
            }

        }

        public static void DeleteEmployee()
        {
            Console.Write("Enter the employee Id: ");

            int id= Convert.ToInt32(Console.ReadLine());

            bool flag = false;

            for (int i=0;i<employee.Count;i++)
            {

                if (employee[i].Id == id)
                {
                    employee.Remove(employee[i]);
                    flag = true;
                    Console.WriteLine("Employee Deleted....");
                    break;
                }

            }
            if (!flag)
            {
                Console.WriteLine("Employee  not found....");
            }
        }
    }
}
