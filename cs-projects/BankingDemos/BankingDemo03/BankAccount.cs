using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDemo01
{
    class BankAccount
    {
        
        
        private String password;
        
        

        private String name;        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(LastName(this.name)==LastName(value))
                    this.name = value;
            }
        }

        private String LastName(string name)
        {
            int index = name.LastIndexOf(' ');
            if (index == -1)
                return "";
            else
                return name.Substring(index + 1);
        }

        private int accountNumber;
        public int AccountNumber
        {
            get { return accountNumber; }
        }

        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        //account Number can't be re Set

        //private double interestRate;

        //public double InterestRate
        //{
        //    get { return interestRate; }
        //    set { interestRate = value; }
        //}

        //public double InterestRate { get; set; } //create a field and add default get/set logic

        public double InterestRate { get; set; }


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
            //this.interestRate = interestRate;
            InterestRate = interestRate;
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
            Console.WriteLine("Interest Rate: {0}", InterestRate);
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
            balance += balance * InterestRate / 1200;
        }








    }
}
