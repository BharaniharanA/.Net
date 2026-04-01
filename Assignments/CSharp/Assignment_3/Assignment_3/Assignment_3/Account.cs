using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    using System;

    class Accounts
    {
        int accNo;
        string custName;
        string accType;
        char transType;
        double amount;
        double balance;

        
        public Accounts(int accNo, string custName, string accType, double balance)
        {
            this.accNo = accNo;
            this.custName = custName;
            this.accType = accType;
            this.balance = balance;
        }

        public void Transaction(char type, double amt)
        {
            transType = type;
            amount = amt;

            if (transType == 'D' || transType == 'd')
                Credit(amount);
            else if (transType == 'W' || transType == 'w')
                Debit(amount);
            else
                Console.WriteLine("Invalid transaction type");
        }

        public void Credit(double amt)
        {
            balance += amt;
            Console.WriteLine("Amount Deposited: " + amt);
        }

        public void Debit(double amt)
        {
            if (amt > balance)
                Console.WriteLine("Insufficient Balance");
            else
            {
                balance -= amt;
                Console.WriteLine("Amount Withdrawn: " + amt);
            }
        }

        public void ShowData()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine("Account No: " + accNo);
            Console.WriteLine("Customer Name: " + custName);
            Console.WriteLine("Account Type: " + accType);
            Console.WriteLine("Balance: " + balance);
        }
    }
}
