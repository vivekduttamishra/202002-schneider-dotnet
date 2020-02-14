using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    [Serializable]
    public class OverdraftAccount : BankAccount
    {
        //new property
        public double OdLimit { get; private set; }


        public OverdraftAccount(int accountNumber, string name, string password, double balance) 
            : base(accountNumber, name, password, balance)
        {
            _AdjustOdLimit();
        }

        private void _AdjustOdLimit()
        {
            if(OdLimit< Balance/10)
                OdLimit = Balance / 10;
        }

        public override void Deposit(double amount)
        {
            base.Deposit(amount);
            _AdjustOdLimit();
            
        }

        public override void CreditInterest(double interestRate)
        {
            base.CreditInterest(interestRate);
            _AdjustOdLimit();
        }

        public override double MaxWithdrawableAmount
        {
            get { return Balance + OdLimit; }
        }

        public override void Withdraw(double amount, string password)
        {
            base.Withdraw(amount, password);
            if(balance < 0)
                balance += (balance / 100);

        }

    }
}
