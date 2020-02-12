using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.MsTest
{
    [TestClass]
    public class BankSpecs
    {
        Bank bank;
        String name = "Some Name";
        String correctPassword = "password";
        double balance = 20000;
        int totalInitialAccounts;
        [TestInitialize]
        public void Setup()
        {
            bank = new Bank();
            for (int i = 1; i <= 5; i++)
                bank.OpenAccount("Name" + i, correctPassword, balance);

            totalInitialAccounts = bank.TotalAccounts;
        }

        //[TestMethod]
        //public void BankShouldHaveAName()
        //{
        //    const string bankName = "ICICI";
        //    const double rate = 12;
        //    Bank bank = new Bank(bankName, rate);

        //    Assert.AreEqual(bankName, bank.Name);
        //}

        [TestMethod]
        public void OpenAccountReturnsAccountaNumber()
        {
            var accountNumber = bank.OpenAccount(name,correctPassword, balance);
            Assert.IsInstanceOfType(accountNumber, typeof(int));
        }

        [TestMethod]
        public void OpenAccountReturnsIncrementingAccountaNumber()
        {
            var account1 = bank.OpenAccount(name, correctPassword, balance);
            var account2 = bank.OpenAccount(name, correctPassword, balance);

            Assert.AreEqual(account1 + 1, account2);
        }

        [TestMethod]
        public void OpenAccountIncreasesTotalAccounts()
        {
            int max = 10;
            for(int i = 0; i < max; i++)
            {
                bank.OpenAccount("Name" + i, "pass" + i, 1000);
            }

            Assert.AreEqual(totalInitialAccounts+ max, bank.TotalAccounts);

        }
        
        [TestMethod]
        public void CloseAccountFailsForInvalidAccountNumber()
        {
            var accountNumber = bank.OpenAccount(name, correctPassword, 20000);
            Assert.IsFalse(bank.CloseAccount(accountNumber+1,correctPassword));

        }

        [TestMethod]
        public void CloseAccountFailsForInvalidPassword()
        {
            var accountNumber = bank.OpenAccount(name, correctPassword, 20000);
            Assert.IsFalse(bank.CloseAccount(accountNumber, "not" + correctPassword));
        }
       [TestMethod]
        public void CloseAccountClosesValidAccountWithValidPassword()
        {
            var accountNumber=bank.OpenAccount(name, correctPassword, 20000);
            var result=bank.CloseAccount(accountNumber, correctPassword);
            Assert.IsTrue(result);
            
        }
        [TestMethod]
        public void CloseAccountReducesTotalAccounts()
        {
            bank.OpenAccount("account1", "pass", 10000);
            var toClose = bank.OpenAccount("account1", "pass", 10000);
            bank.OpenAccount("account1", "pass", 10000);
            var totalAccounts = bank.TotalAccounts;
            bank.CloseAccount(toClose, "pass");

            Assert.AreEqual(totalAccounts - 1, bank.TotalAccounts);



        }

        [TestMethod]
        public void GetAccountReturnsValidAccountWithCorrectAccountNumberAndPassword()
        {
            var account = bank.GetAccount(5, correctPassword);
            Assert.AreEqual("Name5", account.Name);
        }

        [TestMethod]
        public void CantGetClosedAccount()
        {
            int accountToClose = 3;

            bank.CloseAccount(accountToClose, correctPassword);

            var account = bank.GetAccount(accountToClose, correctPassword);

            Assert.IsNull(account);

        }

        [TestMethod]
        public void CanGetNotClosedAccount()
        {
            //close an old account
            bank.CloseAccount(1, correctPassword);
            //open a new account
            bank.OpenAccount("New Account", correctPassword, balance);
            //access an old existing account
            var account = bank.GetAccount(5, correctPassword);

            Assert.AreEqual("Name5" , account.Name);


        }

        [TestMethod]
        [Ignore]
        public void TransferFailsForInvalidSourceAccount()
        {
            
        }

        [TestMethod]
        [Ignore]
        public void TransferFailsForInvalidTargetAccount()
        {

        }

        [TestMethod]
        [Ignore]
        public void TransferFailsForInvalidSourceAccountPassword()
        {

        }

        [TestMethod]
        [Ignore]
        public void TransferFailsForInsufficientBalanceInSource()
        {

        }

        [TestMethod]
        [Ignore]
        public void TransferTransferFundInHappyCase()
        {

        }

    }
}
