using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
   public abstract  class BankAccount
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

        protected double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
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


        //static int accountCount = 0;

        //TODO: make this internal
        public  BankAccount(int accountNumber, String name, String password, double balance)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = balance;
            this.password = password;
            //this.interestRate = interestRate;
            //InterestRate = interestRate;
        }

       
        public void Show()
        {
            Console.WriteLine("Account Number: {0}",accountNumber);
            Console.WriteLine("Name: {0}", name);
            //Console.WriteLine("Password: {0}", password);
            Console.WriteLine("Balance: {0}", balance);
            //Console.WriteLine("Interest Rate: {0}", InterestRate);
            Console.WriteLine();
        }


        public virtual bool Deposit(double amount)
        {
            //if (amount > 0)
            //{
            //    balance += amount;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
                
            else
                return false;
        }

        public abstract double MaxWithdrawableAmount { get; }
            
        public virtual bool Withdraw(double amount, String password)
        {
            if (amount < 0)
                return false;
            if (amount > MaxWithdrawableAmount)
                return false;

            else if (!Authenticate(password))
                return false;
            else
            {
                balance -= amount;
                return true;
            }
        }

        private double MaxWithdrableAmount()
        {
            return balance;
        }

        public virtual void CreditInterest(double interestRate)
        {
            //can access both static and non-static field
            balance += balance * interestRate / 1200;
        }



        public static bool Transfer(BankAccount source, String password, double amount, BankAccount target)
        {
            if (source.Withdraw(amount, password))
                return target.Deposit(amount);
            else
                return false;
        }




    }
}
