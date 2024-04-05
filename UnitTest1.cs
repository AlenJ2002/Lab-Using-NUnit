using NUnit.Framework;
using BankAccountNS;
using System;

namespace BankAccountTests
{
    [TestFixture]
    public class BankAccountTests // Rename the class to BankAccountTests
    {
        private BankAccount account; // Rename the variable to account

        [SetUp]
        public void Setup() // Rename the method to Setup
        {
            // Setup runs before each test to ensure a fresh environment
            account = new BankAccount("Test User", 1000.0);
        }

        [Test]
        public void Credit_WithValidAmount_UpdatesBalanceCorrectly() // Renaming the method
        {
            // Arrange
            double initialBalance = account.Balance; // Renaming the variable
            double creditAmount = 200.0; // Renaming the variable

            // Act
            account.Credit(creditAmount); // Renaming the method

            // Assert
            Assert.AreEqual(initialBalance + creditAmount, account.Balance, "The credited amount was not correctly added to the balance.");
        }

        [Test]
        public void Debit_WithValidAmount_UpdatesBalanceCorrectly()
        {
            // Arrange
            double initialBalance = account.Balance; 
            double debitAmount = 200.0;

            // Act
            account.Debit(debitAmount);

            // Assert
            Assert.AreEqual(initialBalance - debitAmount, account.Balance, "The debited amount was not correctly subtracted from the balance.");
        }

        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double debitAmount = account.Balance + 1;

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount)); // Renaming the method
            Assert.That(ex.Message, Does.Contain(BankAccount.DebitAmountExceedsBalanceMessage));
        }

        [Test]
        public void Debit_WhenAmountIsLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double debitAmount = -1;

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount)); //
            Assert.That(ex.Message, Does.Contain(BankAccount.DebitAmountLessThanZeroMessage));
        }

        [Test]
        public void Credit_WhenAmountIsLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double creditAmount = -1; // Renaming the variable

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
            Assert.That(ex.Message, Does.Contain("amount")); // Renaming the variable
        }
    }
}
