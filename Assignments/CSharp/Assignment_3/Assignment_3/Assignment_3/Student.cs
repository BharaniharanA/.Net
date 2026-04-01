using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Student
    {
        int rollNo;
        string name;
        string studentClass;
        int sem;
        string branch;
        int[] marks = new int[5];

        public Student(int rollNo, string name, string studentClass, int sem, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.sem = sem;
            this.branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool fail = false;

            foreach (int m in marks)
            {
                if (m < 35)
                    fail = true;

                total += m;
            }

            double avg = total / 5.0;

            Console.WriteLine("Average Marks: " + avg);

            if (fail || avg < 50)
                Console.WriteLine("Result: Failed");
            else
                Console.WriteLine("Result: Passed");
        }

        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine("Roll No: " + rollNo);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + studentClass);
            Console.WriteLine("Semester: " + sem);
            Console.WriteLine("Branch: " + branch);
        }
    }
}
