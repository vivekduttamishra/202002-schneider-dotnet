using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    public class SavingsAccount : BankAccount   //SavingsAccount is a type of BankAccount
    {
        public SavingsAccount(int accountNumber, string name, string password, double balance)
                : base(accountNumber, name, password, balance)
        {
            MinimumBalance = 5000;
        }
        public int MinimumBalance { get; set; }//= 5000;

        public override double MaxWithdrawableAmount
        {
            get { return Balance - MinimumBalance; }
        }
        //public override bool Withdraw(double amount, string password)
        //{
        //    if (amount > Balance - MinimumBalance)
        //        return false;

        //    else
        //        return base.Withdraw(amount, password);
            
        //}

        
    }
}
