using System;

namespace Assignment_5
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
    class BankingSystem
    {
        private double balance=0;
        
        public void DepositMoney(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount}");
            }
            else
            {
                throw new ArgumentException("Amount must be Greater than zero..");
            }
        }

        public void WithdrawMoney(double amount)
        {
            if (amount > 0)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Withdrawn: {amount}");
                }
                else
                {
                    throw new InsufficientFundsException("Insufficient funds.");
                }
            }
            else
            {
                throw new ArgumentException("Amount must be Greater than zero..");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {balance}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankingSystem bank = new BankingSystem();
            
            try
            {
                int n = 0;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Banking Services");
                    Console.WriteLine("1. Deposit Money");
                    Console.WriteLine("2. Withdraw Money");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter the service: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    double Amount;
                    switch (n)
                    {
                        case 1:
                            Console.Write("Enter the amount: " );
                            Amount = Convert.ToDouble(Console.ReadLine());
                            bank.DepositMoney(Amount);

                            break;
                        case 2:
                            Console.Write("Enter the amount: ");
                            Amount = Convert.ToDouble(Console.ReadLine());
                            bank.WithdrawMoney(Amount);
                            break;
                        case 3:
                            bank.CheckBalance();
                            break;
                        case 4:
                            Console.WriteLine("Exited....");
                            break;
                        default:
                            Console.WriteLine("Invalid input...");
                            break;
                    }
                } while (n != 4);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
