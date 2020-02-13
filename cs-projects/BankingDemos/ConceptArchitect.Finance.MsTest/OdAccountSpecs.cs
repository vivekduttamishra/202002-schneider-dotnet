using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.MsTest
{

    [TestClass]
    public class OdAccountSpecs
    {
        OverdraftAccount account;
        String correctPassword = "password";
        double balance = 20000;

        [TestInitialize]
        public void Setup()
        {
            account = new OverdraftAccount(1, "Someone", correctPassword, balance);
        }

        [TestMethod]
        public void OdLimitIs10PercentOfInitialDeposit()
        {
            Assert.AreEqual(balance / 10, account.OdLimit);
        }

        [TestMethod]
        public void DepositIncreasesOdLimit()
        {
            var amount = 30000;
            account.Deposit(amount);
            Assert.AreEqual(account.Balance / 10, account.OdLimit);

        }

        [TestMethod]
        public void creditInterestIncreasedOdLimit()
        {
            account.CreditInterest(10);
            Assert.AreEqual(account.Balance / 10, account.OdLimit);
        }

        [TestMethod]
        public void WithdrawDoesnotReduceOdLimit()
        {
            var odLimitBeforeWithdraw = account.OdLimit;
            account.Withdraw(balance, correctPassword);
            Assert.AreEqual(odLimitBeforeWithdraw, account.OdLimit);
        }

        [TestMethod]
        public void DepoistLessThanMaxHistoricBalanceDoesntReduceOdLimit()
        {
            //Arrange ---> Arrange
            account.Deposit(20000); //Historic max balance
            var odLimitAtHistoricMaxBalance = account.OdLimit;

            //take out some money
            account.Withdraw(20000,correctPassword); //now i am less than historic max balance


            //A ---> ACT
            account.Deposit(5000); //deposit is not upto historic max balance


            //Arrange ---> Arrange
            Assert.AreEqual(odLimitAtHistoricMaxBalance, account.OdLimit);
        }

        [TestMethod]
        public void WithdrawCanWithdrawUpToBalance()
        {
            account.Withdraw(balance, correctPassword);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void WithdrawCanWithdrawUpToBlancePlusOdLimit()
        {
            var result=account.Withdraw(balance + account.OdLimit, correctPassword);

            Assert.IsTrue(result);
            Assert.IsTrue(account.Balance < 0);

        }

        [TestMethod]
        public void WithdrawFailsForOverdrawnAccount()
        {
            //A--->Arrange
            bool result = account.Withdraw(balance + account.OdLimit, correctPassword);
            Assert.IsTrue(result, "Failed At Assumption");
            
            //A --> Act
            result = account.Withdraw(1, correctPassword);

            //A ---> Assert
            Assert.IsFalse(result,"Failed At Assertion");
        }

        [TestMethod]
        public void OverWithdrawChargesOdFee()
        {
            account.Withdraw(balance + account.OdLimit, correctPassword);

            var odFee = account.OdLimit / 100;

            var finalBalance = -account.OdLimit - odFee;

            Assert.AreEqual(finalBalance, account.Balance);
        }




    }
}
