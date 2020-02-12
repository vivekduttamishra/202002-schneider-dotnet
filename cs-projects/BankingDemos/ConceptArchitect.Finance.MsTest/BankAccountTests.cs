
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
            Assert.AreEqual(originalBalance+1000, account.Balance);
        }
        [TestMethod]
        public void DepositFailsForNegativeAmount()
        {
            //ACT
            bool result = account.Deposit(-1000);

            //ASSERT
            Assert.IsFalse(result);
            Assert.AreEqual(originalBalance, account.Balance);
        }

        [TestMethod]
        public void WithdrawFailsWithIncorrectPassword()
        {
            bool result = account.Withdraw(1, "not"+correctPassword);
            Assert.IsFalse(result);

            Assert.AreEqual(originalBalance, account.Balance);
        }

        [TestMethod]
        [Ignore]
        public void WithdrawFailsForInsufficientBalance()
        {

        }
        [TestMethod]
        [Ignore]
        public void WithdrawFailsForNegativeAmount()
        {

        }

        [TestMethod]
        [Ignore]
        public void WithdrawHappyPath()
        {

        }

        [TestMethod]
        [Ignore]
        public void NameChangeNotPermittedForDifferentLastName()
        {

        }

        [TestMethod]
        [Ignore]
        public void NameChangePermittedForSameLastName()
        {

        }

        [TestMethod]
        [Ignore]
        public void AuthenticationFailsForWrongPassword()
        {

        }

        [TestMethod]
        [Ignore]
        public void PasswordChangeFailsForWrongCurrentPassword()
        {

        }

        [TestMethod]
        [Ignore]
        public void PasswordSucceedsWithCorrectCurrentPassword()
        {

        }


    }
}
