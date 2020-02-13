using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
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

        public override bool Deposit(double amount)
        {
            var result=base.Deposit(amount);
            _AdjustOdLimit();
            return result;
        }

        public override void CreditInterest(double interestRate)
        {
            base.CreditInterest(interestRate);
            _AdjustOdLimit();
        }

        public override bool Withdraw(double amount, string password)
        {
            if (amount > Balance + OdLimit)
                return false;
            //var result = base.Withdraw(amount,password);

            if (amount < 0)
                return false;

            if (!Authenticate(password))
                return false;

            balance -= amount;
            if (balance < 0)
                balance += (balance / 100);

            return true;
        }

    }
}
