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


        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            this.name = newName;
        }

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        //account Number can't be re Set

        public double GetBalance()
        {
            return balance;
        }

        // balance changes by Deposit,Withdraw etc

        public double GetInterestRate()
        {
            return interestRate;
        }

        public void SetInterestRate(double rate)
        {
            interestRate = rate;
        }


        /// no regular Get-Set for password
        public bool Authenticate(string password)
        {
            return this.password == password;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (Authenticate(oldPassword))
                password = newPassword;
        }




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


        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Withdraw(double amount, String password)
        {
            if (amount < 0)
                return false;
            if (amount > balance)
                return false;

            else if (! Authenticate(password))
                return false;
            else
            {
                balance -= amount;
                return true;
            }
        }

        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
        }








    }
}
