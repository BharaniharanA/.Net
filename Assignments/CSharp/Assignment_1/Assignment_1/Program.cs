using System;


namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                int n = Menu();
                if (n == 6)
                {
                    break;
                }
            }


        }
        static int Menu()

        {
            Console.WriteLine();
            Console.WriteLine("To perform the following tasks, choose an option");
            Console.WriteLine();
            Console.WriteLine("To check the two Integers are equal. press: 1");
            Console.WriteLine("To check the number sign. press: 2");
            Console.WriteLine("To perform Arithmetic Operations for two numbers. press: 3");
            Console.WriteLine("To Create Multiplication tables press: 4");
            Console.WriteLine("To perform Sum of Integers press: 5");
            Console.WriteLine("To exit press: 6");

            Console.WriteLine();
            Console.Write("Enter the option:");
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine();

                switch (a)
                {
                    case 1:
                        CheckEquality();
                        break;
                    case 2:
                        CheckSignofNumber();
                        break;
                    case 3:
                        ArithmeticOperations();
                        break;
                    case 4:
                        MultiplicationTables();
                        break;
                    case 5:
                        SumofInt();
                        break;
                    case 6:
                        Console.WriteLine("You exited.");
                        return a;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
            return 0;
        }


        static void CheckEquality()
        {

            Console.WriteLine("To check Equality");
            Console.Write("Enter the First number:");
            if (!long.TryParse(Console.ReadLine(), out long a))
            {
                Console.WriteLine();
                Console.WriteLine("You entered the invalid input.");
                return;
            }

            Console.Write("Enter the Second number:");
            if (!long.TryParse(Console.ReadLine(), out long b))
            {
                Console.WriteLine();
                Console.WriteLine("You entered the invalid input.");

                return;
            }

            if (a == b)
            {
                Console.WriteLine();
                Console.WriteLine("The two numbers are equal.");


            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("The two numbers are not equal.");


            }
        }





        static void CheckSignofNumber()
        {
            Console.WriteLine("To check the sign of the number");
            Console.Write("Enter the number:");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine();
                Console.WriteLine("You entered the invalid input.");

            }
            else
            {
                if (a > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The number is Positive.");

                }
                else if (a < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The number is Negative.");


                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("The number is Zero.");


                }
            }
        }




        static void ArithmeticOperations()
        {

            string op;
            Console.WriteLine("To perform Arithmetic Operations");
            Console.WriteLine("The Operation available are : +,-,*,/");
            Console.Write("Enter the operation:");
            op = Console.ReadLine();
            if (op == "+" || op == "-" || op == "*" || op == "/")
            {
                Console.Write("Enter the First number:");
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine();
                    Console.WriteLine("You entered the invalid input.");

                    return;
                }

                Console.Write("Enter the Second number:");
                if (!double.TryParse(Console.ReadLine(), out double b))
                {
                    Console.WriteLine();
                    Console.WriteLine("You entered the invalid input.");

                    return;
                }

                switch (op)
                {
                    case "+":
                        Console.WriteLine();
                        Console.WriteLine("Addition is: " + (a + b));
                        break;
                    case "-":
                        Console.WriteLine();
                        Console.WriteLine("Subtraction is: " + (a - b));
                        break;
                    case "*":
                        Console.WriteLine();
                        Console.WriteLine("Multiplication is: " + (a * b));
                        break;
                    case "/":
                        if (b != 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Division is: " + (a / b));
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Division by zero is Undefined.");
                        }
                        break;

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You entered invalid operation");

                return;
            }

        }



        static void MultiplicationTables()
        {
            Console.WriteLine("To Create Multiplication tables");
            Console.Write("Enter the Table number:");

            if (!long.TryParse(Console.ReadLine(), out long a))
            {
                Console.WriteLine();
                Console.WriteLine("You entered invalid input.");
            }
            else
            {
                Console.WriteLine();
                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine($"{a} * {i} = {a * i}");
                }


            }
        }





        static void SumofInt()
        {

            Console.WriteLine("To perform Sum of Integers ");
            Console.Write("Enter the First number:");
            if (!long.TryParse(Console.ReadLine(), out long a))
            {
                Console.WriteLine();
                Console.WriteLine("You entered the invalid input.");
                return;
            }

            Console.Write("Enter the Second number:");
            if (!long.TryParse(Console.ReadLine(), out long b))
            {
                Console.WriteLine();
                Console.WriteLine("You entered the invalid input.");
                return;
            }
            long sum = a + b;
            if (a == b)
            {
                Console.WriteLine();
                Console.WriteLine("The two numbers are same.");
                Console.WriteLine();
                Console.WriteLine("The triple of their sum is {0}", 3 * sum);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("The two numbers are different.");
                Console.WriteLine();
                Console.WriteLine("The sum of the number is {0}", sum);

            }
        }
    }
}
