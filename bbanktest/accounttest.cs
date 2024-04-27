using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;


namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }

        //[TestMethod]
        //public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        //{
        //    // Arrange
        //    double beginningBalance = 11.99;
        //    double debitAmount = -100.00;
        //    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        //    // Act and assert
        //    Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
        //    account.Debit(debitAmount));
        //}

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        //[TestMethod]
        //public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        //{
        //    // Arrange
        //    double beginningBalance = 11.99;
        //    double debitAmount = 100.00;
        //    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        //    // Act and assert
        //    Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
        //    account.Debit(debitAmount));
        //}

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.01;
            double expected = 16.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Balance_WithValidAmountLessThanZero_ShouldntThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = -11.99;
            // Act
            try
            {
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.Fail("The expected exception was not thrown.");
            }
        }
    }
}
