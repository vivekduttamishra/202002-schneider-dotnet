using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.MsTest
{
    [TestClass]
    public class SavingsAccountSpecs
    {
        double balance = 20000;
        string name = "Test Name";
        string correctPassword = "password";

        int minBalance = 5000;
        SavingsAccount savingsAccount;

        [TestInitialize]
        public void Setup()
        {
            savingsAccount = new SavingsAccount(1, name, correctPassword, balance);
        }

        [TestMethod]
        public void SavingsAccountIsATypeOfBankAccount()
        {
            Assert.IsInstanceOfType(savingsAccount, typeof(BankAccount));
        }

        [TestMethod]
        public void SavingsAccountHasAMinBalance()
        {
            Assert.AreEqual(minBalance, savingsAccount.MinimumBalance);
        }
        [TestMethod]
        public void SavingsAccountWithdrawFailsIfMinBalanceIsNotRemaining()
        {
            var result = savingsAccount.Withdraw(balance, correctPassword);
            AssertBalanceUnchanged();
        }

        private void AssertBalanceUnchanged()
        {
            Assert.AreEqual(balance, savingsAccount.Balance);
        }

        [TestMethod]
        public void SavingsAccountWithdrawSucceedsIfMinBalanceIsRemaining()
        {
            //savingsAccount.
            var result = savingsAccount.Withdraw(balance - minBalance, correctPassword);
            Assert.AreEqual(minBalance, savingsAccount.Balance);
        }

        [TestMethod]
        public void SavingsAccountGetsIneterest()
        {
            double rate = 10;
            savingsAccount.CreditInterest(rate);
            double expectedBalance = balance * rate / 1200 + balance;
            Assert.AreEqual(expectedBalance, savingsAccount.Balance);
        }

    }
}
