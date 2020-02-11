using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDemo01
{
    class BankAccount
    {
        private int accountNumber;
        private String name;
        private String password;
        private double balance;
        private double interestRate;

        public BankAccount(int accountNumber, String name, String password, double balance, double interestRate)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = balance;
            this.password = password;
            this.interestRate = interestRate;
        }

        //public void  OpenAccount(int accountNumber, String name, String password, double balance, double interestRate)
        //{
        //    this.accountNumber = accountNumber;
        //    this.name = name;
        //    this.balance = balance;
        //    this.password = password;
        //    this.interestRate = interestRate;
        //}

        public void Show()
        {
            Console.WriteLine("Account Number: {0}",accountNumber);
            Console.WriteLine("Name: {0}", name);
            //Console.WriteLine("Password: {0}", password);
            Console.WriteLine("Balance: {0}", balance);
            Console.WriteLine("Interest Rate: {0}", interestRate);
            Console.WriteLine();
        }


        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                
                balance += amount;
                Console.WriteLine("Amount Deposited " + amount + "\total balance " + balance);
            }
            else
            {
                Console.WriteLine("Deposit Failed");
            }
        }


        public void Withdraw(double amount, String password)
        {
            if (amount < 0)
            {
                Console.WriteLine("Negative Withdraw Not allowed");
            }
            else if(amount>balance)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else if(password!=this.password)
            {
                Console.WriteLine("Invalid credentials");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdraw successful. "+amount+" Balance :"+balance);
            }
        }

        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
        }








    }
}
