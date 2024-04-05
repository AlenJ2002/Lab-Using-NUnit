using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS // Renaming the namespace
{
    public class BankAccount // Renaming the class
    {
        private readonly string m_customerName; // Renaming the variable
        private double m_balance;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance"; // Renaming the constant
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero"; // Renaming the constant

        private BankAccount() { }

        public BankAccount(string customerName, double balance) // Renaming the constructor
        {
            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(balance), "Initial balance must be greater than or equal to 0."); // Renaming the variable
            }
            m_customerName = customerName ??  
                throw new ArgumentNullException(nameof(customerName), "Customer name cannot be null."); // Renaming the variable
            m_balance = balance;
        }

        public string CustomerName // Renaming the property
        {
            get { return m_customerName; } // Renaming the variable
        }

        public double Balance // Renaming the property
        {
            get { return m_balance; } // Renaming the variable
        }

        public void Debit(double amount) // Renaming the method
        {
            if (amount > m_balance) // Renaming the variable
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // Corrected to accurately reflect debit action
        }

        public void Credit(double amount) // Renaming the method
        {
            if (amount < 0) // Renaming the variable
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Credit amount must be greater than zero."); // Renaming the variable
            }

            m_balance += amount; // Corrected to accurately reflect credit action
        }

        public static void Main() // Renaming the method
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99); // Renaming the variable

            ba.Credit(5.77); // Renaming the method
            ba.Debit(11.22); // Renaming the method
            Console.WriteLine("Current balance is ${0}", ba.Balance); // Renaming the variable
        }
    }
}

