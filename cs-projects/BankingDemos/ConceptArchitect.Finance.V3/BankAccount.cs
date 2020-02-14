using ConceptArchitect.Finance.V3;
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
        public void Authenticate(string password)
        {
            if (this.password != password)
                throw new InvalidCredentialsException(accountNumber);
            
            
        }
        public void ChangePassword(string oldPassword, string newPassword)
        {
            Authenticate(oldPassword);
            password = newPassword;
        }
        public abstract double MaxWithdrawableAmount { get; }
        public virtual void Withdraw(double amount, String password)
        {
            ValidateDenomination(amount);
            if (amount > MaxWithdrawableAmount)
                throw new InsufficientBalanceException(accountNumber, amount - MaxWithdrawableAmount);

            Authenticate(password);
            balance -= amount;

        }

        private void ValidateDenomination(double amount)
        {
            if (amount < 0)
                //return false;
                throw new InvalidDenominationException(accountNumber);
        }



        //static int accountCount = 0;

        //TODO: make this internal
        public BankAccount(int accountNumber, String name, String password, double balance)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = balance;
            this.password = password;
            //this.interestRate = interestRate;
            //InterestRate = interestRate;
        }

       
       

        public virtual void Deposit(double amount)
        {

            ValidateDenomination(amount);
            balance += amount;
            
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



      

        public override string ToString()
        {
            return string.Format("{0} {1}\t{2}\t{3}", GetType().Name, accountNumber, balance, name);
        }



    }
}
