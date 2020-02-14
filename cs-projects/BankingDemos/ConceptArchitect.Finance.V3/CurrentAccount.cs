using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    [Serializable]
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(int accountNumber, string name, string password, double balance) 
            : base(accountNumber, name, password, balance)
        {
        }

        public override double MaxWithdrawableAmount
        {
            get{return Balance;}
        }

        public override void CreditInterest(double interestRate)
        {
            //base.CreditInterest(0);   
        }
    }
}
