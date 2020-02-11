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
            BankAccount account1 = new BankAccount(1, "Vivek Mishra", "p@ss", 20000, 12);
            BankAccount account2 = new BankAccount(1, "Prabhat Singh", "p@ss", 20000, 14);

            account1.Show();
            account2.Show();


        }

        static void Show(BankAccount account)
        {
            //Console.WriteLine("Account Number :" + account.GetAccountNumber()); 
            Console.WriteLine("Account Number :" + account.AccountNumber);
            Console.WriteLine("Name:"+account.Name);
            Console.WriteLine("Balance:"+account.Balance);
            Console.WriteLine("Interest Rate:"+account.InterestRate);
            Console.WriteLine();

        }

    }
}
