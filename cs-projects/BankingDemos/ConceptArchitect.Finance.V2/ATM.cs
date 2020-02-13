using ConceptArchitect.Finance.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    public class ATM
    {
        private Bank bank;
        Input keyboard = new Input();
        private int accountNumber;
        //private string password;

        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        public void Boot()
        {
            while (true)
            {
                accountNumber = keyboard.GetInt("account number? ");

                if (accountNumber == -1 && keyboard.GetString("password ?") == "NIMDA")
                    _ShowAdminMenu();
                else
                    _ShowUserMenu();
            }
        }

        private void _ShowAdminMenu()
        {
            while (true)
            {
                int choice = keyboard.GetInt("1. Print List  2. Open Account  3. Credit Interset 0. Exit ?");
                switch (choice)
                {
                    case 1:
                        bank.PrintAccountList();
                        break;
                    case 2:
                        _DoOpenAccount();
                        break;
                    case 3:
                        bank.CreditInterests();
                        break;
                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Retry");
                        break;


                }
            }
        }

        private void _DoOpenAccount()
        {
            String accountType = keyboard.GetString("Account Type?");
            String name= keyboard.GetString("Name?");
            String password = keyboard.GetString("password?");
            int openingBalance = keyboard.GetInt("Amount?");
            var accountNumber=bank.OpenAccount(accountType, name, password, openingBalance);
            _Display("New Account is Ready. Account number is " + accountNumber);

        }

        private void _ShowUserMenu()
        {
            while (true)
            {
                int choice = keyboard.GetInt("1. Deposit  2. Withdraw 3. Show Balance 4. Transfer 5. Close 0. Exit ?");
                switch(choice)
                {
                    case 1:
                        _DoDeposit();
                        break;
                    case 2:
                        _DoWithdraw();
                        break;
                    case 3:
                        _DoShowBalance();
                        break;
                    case 4:
                        _DoTransfer();
                        break;
                    case 5:
                        _DoClose();
                        break;
                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Retry");
                        break;

                }
            }
        }

        private void _DoClose()
        {
            string password = keyboard.GetString("password?");
            if(keyboard.GetString("TYPE: PLEASE CLOSE MY ACCOUNT")=="PLEASE CLSOE MY ACCOUNT")
            {
                var result=bank.CloseAccount(accountNumber, password);
                if(result)
                    _Display("Your account has been closed");
                else
                    _Display("Failed to close account");
            }

        }

        private void _DoTransfer()
        {
            String password = keyboard.GetString("Password?");
            int amount = keyboard.GetInt("Amount?");
            int to = keyboard.GetInt("to ? ");
            var result = bank.Transfer(accountNumber, password, amount, to);
            if (result)
                _Display("Fund Transferred");
            else
                _Display("Fund Transfer Failed");
        }

        private void _DoShowBalance()
        {
            string password = keyboard.GetString("Passoword");
            var account = bank.GetAccount(accountNumber, password);
            if (account == null)
                _Display("Invalid credentials");
            else
                _Display("Balance is :" + account.Balance);
        }

        private void _DoWithdraw()
        {
            int amount = keyboard.GetInt("Amount?");
            string password = keyboard.GetString("Passoword");
            var result = bank.Withdraw(accountNumber, password, amount);
            if (result)
                _DispenseCash(amount);
            else
                _Display("Withdraw failed");
        }

        private void _DispenseCash(int amount)
        {
            Console.WriteLine("Please collect your cash :"+amount);
        }

        private void _DoDeposit()
        {
            int amount = keyboard.GetInt("Amount ?");
            bool result = bank.Deposit(accountNumber, amount);
            if (result)
                _Display("Amount Deposited");
            else
                _Display("Deposit Failed");
        }

        private void _Display(string v)
        {
            Console.WriteLine(v);
        }
    }

       
}
