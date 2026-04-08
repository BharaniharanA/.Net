using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    public delegate double Operation(double num1, double num2); //delegate declaration
    public class Calculator
    {
       public double Add(double num1, double num2)=> num1 + num2;
       public double Subtract(double num1, double num2) => num1 - num2;
       public double Multiply(double num1, double num2) => num1 * num2;

    }
    internal class CalculatorFunction
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Calculator calculator = new Calculator();

            Operation operation = new Operation(calculator.Add);

            Console.WriteLine("1) Addition: "+operation(num1, num2));
            operation += calculator.Subtract;
            Console.WriteLine("2) Subtraction: "+operation(num1, num2));
            operation += calculator.Multiply;
            Console.WriteLine("3) Multiplication: "+operation(num1, num2));

        }
    }
}
