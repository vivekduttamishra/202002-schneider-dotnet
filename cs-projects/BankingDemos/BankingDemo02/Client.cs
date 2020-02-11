using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDemo01
{
    class Client
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(1, "Vivek", "p@ss", 20000, 12);

            BankAccount account2 = new BankAccount(2, "Sanjay", "1234",50000, 12);

            account1.Show();

            DoDeposit(account1, -1);
            DoDeposit(account1, 1000);

            DoWithdraw(account1, -1, "p@ss");
            DoWithdraw(account1, 1, "wrongpass");
            DoWithdraw(account1, 100000, "p@ss");
            DoWithdraw(account1, 1000, "p@ss");



            Console.WriteLine("Before Transfer Test");
            account1.Show();
            account2.Show();

            DoTransfer(account1, 100000, "p@ss", account2);

            DoTransfer(account1, 1000, "p@ss", account2);

            Console.WriteLine("After Transfer");
            Show(account1);
            Show(account2);

        }

        static void Show(BankAccount account)
        {
            Console.WriteLine("Account Number:"+account.GetAccountNumber());
            Console.WriteLine("Name:" + account.GetName());
            Console.WriteLine("Balance:" + account.GetBalance());

        }

        static void DoDeposit(BankAccount account, double amount)
        {
            if(account.Deposit(amount))
                Console.WriteLine("Deposit Success");
            else
                Console.WriteLine("Deposit Failed");
        }

        static void DoWithdraw(BankAccount account, double amount,String password)
        {
            if (account.Withdraw(amount,password))
                Console.WriteLine("Withdraw Success");
            else
                Console.WriteLine("Withdraw Failed");
        }

        static void DoTransfer(BankAccount src, int amount, String password, BankAccount target )
        {
           if( src.Withdraw(amount, password))
            {
                target.Deposit(amount);
                Console.WriteLine("Tranfer completed");
            } else
            {
                Console.WriteLine("Transfer Failed");
            }
            
        }
    }
}
