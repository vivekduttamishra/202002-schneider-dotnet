using System;

namespace ConceptArchitect.Finance
{
    public class Bank
    {
        int accountCount = 0;
        int lastId;
        BankAccount[] accounts = new BankAccount[100];

        public double InterestRate { get; set; }

        public int TotalAccounts
        {
            get { return accountCount; }
        }
        

        public int OpenAccount(string name, string password, double balance)
        {
            accountCount++;
            lastId++;
            int accountNumber = lastId;

            BankAccount account = new SavingsAccount(accountNumber,name, password, balance);

            accounts[accountNumber] = account;

            return accountNumber;
        }

        public bool CloseAccount(int accountNumber, string password)
        {
            //return false;
            if (accountNumber < 1 || accountNumber > accountCount)
                return false;

            var account = accounts[accountNumber];

            if (account.Authenticate(password))
            {
                //shift other accounts by one place
                accounts[accountNumber] = null;

                accountCount--;
                return true;
            }
            else
                return false;
            
        }

        public BankAccount GetAccount(int accountNumber, string password)
        {
            if (accountNumber < 1 || accountNumber > accountCount)
                return null;
            BankAccount account = accounts[accountNumber];
            
            if (account!=null && !account.Authenticate(password))
                return null;
            return account;
        }
    }
}