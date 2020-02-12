
using ConceptArchitect.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingTestApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            double initialAmount = 20000;
            string correctPassword = "p@ss";
            BankAccount account = new BankAccount(1,"Vivek Mishra", correctPassword, initialAmount);

            TestDeposit(account, -1);
            TestDeposit(account, 10000);

            TestWithdraw(account, -1, correctPassword);
            TestWithdraw(account, initialAmount + 1, correctPassword);
            TestWithdraw(account, 1, "wrong-password");
            TestWithdraw(account, initialAmount - 1, correctPassword);
            

        }

        private static void TestWithdraw(BankAccount account, double amount,string password)
        {
            Console.WriteLine("Before withdraw balance " + account.Balance);
            Console.WriteLine("Withdrawing " + amount);
            bool result=account.Withdraw(amount, password);
            Console.WriteLine("After withdraw balance " + account.Balance);
            Console.WriteLine("TEST RESULT "+(result?"SUCCESS":"FAILED"));
        }

        private static void TestDeposit(BankAccount account, double amount)
        {
            Console.WriteLine("Before Deposit: " + account.Balance);
            Console.WriteLine("Trying to deposit " + amount);
            account.Deposit(amount);
            Console.WriteLine("After Deposit:" + account.Balance);
        }
    }
}
