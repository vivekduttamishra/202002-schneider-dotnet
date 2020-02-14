using ConceptArchitect.Finance.V3;
using System;

namespace ConceptArchitect.Finance
{
    public class BankV1 : ListAccountStore//ArrayAccountStore
    {
        


        int accountCount = 0;
        int lastId;
        
        
        public BankV1(string name, int rate)
        {
            this.name = name;
            InterestRate = rate;
        }

        private string name;

        public double InterestRate { get; set; }

        public int TotalAccounts
        {
            get { return accountCount; }
        }
        

        public int OpenAccount(string type,string name, string password, double balance)
        {

            accountCount++;
            lastId++;
            int accountNumber = lastId;
            BankAccount account = null;

            if (type == "SavingsAccount")
                account = new SavingsAccount(accountNumber, name, password, balance);
            else if (type == "CurrentAccount")
                account = new CurrentAccount(accountNumber, name, password, balance);
            else
                account = new OverdraftAccount(accountNumber, name, password, balance);
            return AddAccount(accountNumber, account);
        }
        
        public BankAccount GetAccount(int accountNumber, string password)
        {
            var account = GetAccount(accountNumber);
            account.Authenticate(password);
            return account; 
            
        }      

        public double CloseAccount(int accountNumber, string password)
        {
            //return false;
            var account = GetAccount(accountNumber, password);
            if (account.Balance < 0)
                throw new InsufficientBalanceException(accountNumber, -account.Balance, "Please Clear your dues before closing the account");
            
            RemoveAccount(accountNumber);
            accountCount--;
            return account.Balance;

        }

        

        public void Deposit(int accountNumber, double amount)
        {
            var account = GetAccount(accountNumber);
            account.Deposit(amount);
        }

        public void Withdraw(int accountNumber, String password,double amount)
        {
            var account = GetAccount(accountNumber, password);
            
            account.Withdraw(amount, password);
        }

        public void Transfer(int from, string password, double amount, int to)
        {
            var src = GetAccount(from);
            var trgt = GetAccount(to);

            src.Withdraw(amount, password);
            trgt.Deposit(amount);
            
        }

        public void CreditInterests()
        {
            var accounts = GetAllAccounts();
            for (int i = 1; i <= lastId; i++)
                if (accounts[i] != null)
                    accounts[i].CreditInterest(InterestRate);
        }

        public void PrintAccountList()
        {
            var accounts = GetAllAccounts();
            for (int i=1;i<=lastId;i++)
                if(accounts[i]!=null)
                    Console.WriteLine(accounts[i]);
        }

    }
}