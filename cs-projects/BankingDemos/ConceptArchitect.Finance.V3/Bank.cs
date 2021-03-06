﻿using ConceptArchitect.Finance.V3;
using System;

namespace ConceptArchitect.Finance
{
    public class Bank
    {
        //ArrayAccountStore store = new ArrayAccountStore();
        IAccountStore store;


        int accountCount = 0;
        int lastId;
        
        
        public Bank(string name, int rate, IAccountStore store)            
        {
            this.name = name;
            InterestRate = rate;
            this.store = store;
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
            return store.AddAccount(accountNumber, account);
        }
        
        public BankAccount GetAccount(int accountNumber, string password)
        {
            var account = store.GetAccount(accountNumber);
            account.Authenticate(password);
            return account; 
            
        }      

        public double CloseAccount(int accountNumber, string password)
        {
            //return false;
            var account = GetAccount(accountNumber, password);
            if (account.Balance < 0)
                throw new InsufficientBalanceException(accountNumber, -account.Balance, "Please Clear your dues before closing the account");
            
            store.RemoveAccount(accountNumber);
            accountCount--;
            return account.Balance;

        }

        

        public void Deposit(int accountNumber, double amount)
        {
            var account = store.GetAccount(accountNumber);
            account.Deposit(amount);
        }

        public void Withdraw(int accountNumber, String password,double amount)
        {
            var account = GetAccount(accountNumber, password);
            
            account.Withdraw(amount, password);
        }

        public void Transfer(int from, string password, double amount, int to)
        {
            var src = store.GetAccount(from);
            var trgt = store.GetAccount(to);

            src.Withdraw(amount, password);
            trgt.Deposit(amount);
            
        }

        public void CreditInterests()
        {
            var accounts =store. GetAllAccounts();
            foreach(var account in accounts)
               
                    account.CreditInterest(InterestRate);
        }

        public void PrintAccountList()
        {
            var accounts =store. GetAllAccounts();
            foreach(var account in accounts)
                
                    Console.WriteLine(account);
        }

    }
}