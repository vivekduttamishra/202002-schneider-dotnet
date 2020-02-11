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
            account2.Show();
        }
    }
}
