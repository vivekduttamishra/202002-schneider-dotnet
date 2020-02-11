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

            BankAccount.InterestRate = 20;

            BankAccount account1 = new BankAccount( "Vivek Mishra", "p@ss", 20000);
            BankAccount account2 = new BankAccount( "Prabhat Singh", "p@ss", 20000);


            // account1.InterestRate = 20; //sets interst rate for account1. actually setting for every one
            
            account1.Show();
            account2.Show();

            BankAccount.Transfer(account1, "p@ss", 1000, account2);
            account1.Show();
            account2.Show();


        }

        static void Show(BankAccount account)
        {
            //Console.WriteLine("Account Number :" + account.GetAccountNumber()); 
            Console.WriteLine("Account Number :" + account.AccountNumber);
            Console.WriteLine("Name:"+account.Name);
            Console.WriteLine("Balance:"+account.Balance);
            Console.WriteLine("Interest Rate:"+BankAccount.InterestRate);
            Console.WriteLine();

        }

    }
}
