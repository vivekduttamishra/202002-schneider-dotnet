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
            account1.Deposit(-1);

            account1.Deposit(20000);
            account1.Withdraw(35000,"p@ss");
            account1.Withdraw(30000, "wrong-p@ss");
            account1.Withdraw(-1, "wrong-p@ss");
            account1.Withdraw(25000, "p@ss");

            Transfer(account1, 100000, "p@ss", account2);

        }

        static void Transfer(BankAccount src, int amount, String password, BankAccount target )
        {
            src.Withdraw(amount, password);
            target.Deposit(amount);
        }
    }
}
