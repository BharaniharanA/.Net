using System;

namespace Assessment_2
{
    abstract class Student
    {
        public string name;
        public int StudentId;
        public double Grade;
        public Student(string name, int id, double grade)
        {
            this.name = name;
            StudentId = id;
            Grade = grade;
        }

        public abstract bool Ispassed(double Grade);

    }
    class Undergraduate : Student
    {
        public Undergraduate(string name, int id, double grade) : base(name, id, grade)
        {
        }
        public override bool Ispassed(double Grade)
        {
            return Grade >= 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, int id, double grade) : base(name, id, grade)
        {
        }
        public override bool Ispassed(double Grade)
        {
            return Grade >= 80.0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student u = new Undergraduate("Rahul", 101, 75);
            Student g = new Graduate("Anita", 102, 78);
            Console.WriteLine($"Undergraduate Passed: {u.Ispassed(u.Grade)}");
            Console.WriteLine($"Graduate Passed: {g.Ispassed(g.Grade)}");
        }
    }
}
