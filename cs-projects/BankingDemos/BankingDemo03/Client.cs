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

            account1.Show();

            account1.Name = "Vivek Singh";

            account1.Show();

            account1.Name = "Shweta Mishra";
            account1.Show();


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
