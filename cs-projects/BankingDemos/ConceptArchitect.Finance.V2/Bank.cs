using System;

namespace ConceptArchitect.Finance
{
    public class Bank
    {
        int accountCount = 0;
        int lastId;
        BankAccount[] accounts = new BankAccount[100];
        
        public Bank(string name, int rate)
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

            if(type=="SavingsAccount")
                account=new SavingsAccount(accountNumber,name, password, balance);
            else if(type=="CurrentAccount")
                account = new CurrentAccount(accountNumber, name, password, balance);
            else
                account = new OverdraftAccount(accountNumber, name, password, balance);

            accounts[accountNumber] = account;

            return accountNumber;
        }

        private BankAccount GetAccount(int accountNumber)
        {
            if (accountNumber < 1 || accountNumber > lastId)
                return null;
            return accounts[accountNumber];
        }
        public BankAccount GetAccount(int accountNumber, string password)
        {
            var account = GetAccount(accountNumber);
            if (account != null && account.Authenticate(password))
                return account;
            else
                return null;
            
        }

        public bool CloseAccount(int accountNumber, string password)
        {
            //return false;
            var account = GetAccount(accountNumber, password);
            if (account != null && account.Balance >= 0)
            {
                accounts[accountNumber] = null;
                accountCount--;
                return true;
            }
            else
                return false;

        }

        public bool Deposit(int accountNumber, double amount)
        {
            var account = GetAccount(accountNumber);
            if (account == null)
                return false;
            return account.Deposit(amount);
        }

        public bool Withdraw(int accountNumber, String password,double amount)
        {
            var account = GetAccount(accountNumber, password);
            if (account == null)
                return false;
            return account.Withdraw(amount, password);
        }

        public bool Transfer(int from, string password, double amount, int to)
        {
            var src = GetAccount(from, password);
            var trgt = GetAccount(to);
            if (src == null)
                return false;
            if (trgt == null)
                return false;
            if (src.Withdraw(amount, password))
                return trgt.Deposit(amount);
            else
                return false;
        }

        public void CreditInterests()
        {
            for (int i = 1; i <= lastId; i++)
                if (accounts[i] != null)
                    accounts[i].CreditInterest(InterestRate);
        }

        public void PrintAccountList()
        {
            for(int i=1;i<=lastId;i++)
                if(accounts[i]!=null)
                    Console.WriteLine(accounts[i]);
        }

    }
}