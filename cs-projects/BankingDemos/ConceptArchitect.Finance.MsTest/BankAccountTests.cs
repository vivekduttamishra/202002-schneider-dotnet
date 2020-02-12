
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConceptArchitect.Finance;

namespace ConceptArchitect.Finance.MsTest
{
    [TestClass]
    public class BankAccountTests
    {
        double originalBalance = 20000;
        String correctPassword = "p@ss";
        String lastName = "Mishra";
        String name;
        BankAccount account;

        #region Helper Functions
        private void AssertBalanceUnchanged()
        {
            Assert.AreEqual(originalBalance, account.Balance);
        }

        private void AssertBalanceEquals(double expected)
        {
            Assert.AreEqual(expected, account.Balance);
        }
        #endregion



        [TestInitialize]
        public void Arrange()
        {
            name = "Vivek " + lastName;
            account = new BankAccount(name, correctPassword, originalBalance);
        }

        [TestMethod]
        public void DepositSucceedsForPostiveAmount()
        {

            //A ---> Arrange
            //A ---> Act
            bool result=account.Deposit(1000);

            //A ---> Assert
            Assert.IsTrue(result);
            //Assert.AreEqual(originalBalance+1000, account.Balance);
            AssertBalanceEquals(originalBalance + 1000);
        }
        [TestMethod]
        public void DepositFailsForNegativeAmount()
        {
            //ACT
            bool result = account.Deposit(-1000);

            //ASSERT
            //Assert.IsFalse(result);
            //Assert.AreEqual(originalBalance, account.Balance);
            AssertBalanceUnchanged();
        }

        [TestMethod]
        public void WithdrawFailsWithIncorrectPassword()
        {
            bool result = account.Withdraw(1, "not"+correctPassword);
            Assert.IsFalse(result);

            //Assert.AreEqual(originalBalance, account.Balance);
            AssertBalanceUnchanged();
        }

        [TestMethod]
        public void WithdrawFailsForInsufficientBalance()
        {
            var result = account.Withdraw(originalBalance + 1, correctPassword);
            //Assert.AreEqual(originalBalance, account.Balance);

            AssertBalanceUnchanged();


        }
        [TestMethod]
       // [Ignore]
        public void WithdrawFailsForNegativeAmount()
        {
            account.Withdraw(-1, correctPassword);
            AssertBalanceUnchanged();
        }

       

        [TestMethod]
        //[Ignore]
        public void WithdrawHappyPath()
        {
            account.Withdraw(originalBalance, correctPassword);
            AssertBalanceEquals(0);
        }

        

        [TestMethod]
        //[Ignore]
        public void NameChangeNotPermittedForDifferentLastName()
        {
            var newName = "Something Else";
            account.Name = newName;
            Assert.AreEqual(name, account.Name);
        }

        [TestMethod]
        public void NameChangePermittedForSameLastName()
        {
            var newName = "New " + lastName;
            account.Name = newName;

            Assert.AreEqual(newName, account.Name);
        }

        [TestMethod]
        public void AuthenticationFailsForWrongPassword()
        {
            Assert.IsFalse(account.Authenticate("not" + correctPassword));
        }

        [TestMethod]
        public void PasswordChangeFailsForWrongCurrentPassword()
        {
            String newPassword = "New Password";
            account.ChangePassword("not" + correctPassword, newPassword);

            Assert.IsFalse(account.Authenticate(newPassword));
        }

        [TestMethod]
        public void PasswordSucceedsWithCorrectCurrentPassword()
        {
            String newPassword = "New Password";
            account.ChangePassword( correctPassword, newPassword);

            Assert.IsTrue(account.Authenticate(newPassword));
        }


    }
}
