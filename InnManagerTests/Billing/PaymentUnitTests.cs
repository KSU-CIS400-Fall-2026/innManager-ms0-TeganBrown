using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InnManagerTests.Billing
{
    /// <summary>
    /// Runs tests for the Payment class in InnManager
    /// </summary>
    public class PaymentUnitTests
    {
        /// <summary>
        /// Ensures default values are correct
        /// </summary>
        [Fact]
        public void PaymentDefualtValuesTests()
        {
            Payment payment = new Payment();
            Assert.Equal(payment.Amount, decimal.Zero);
            Assert.Equal(payment.date.Date, DateTime.Now.Date);
            Assert.Equal(payment.Description, string.Empty);
            Assert.False(payment.IsProcessed);
            Assert.Equal(payment.PaymentMethod, PaymentMethod.Cash);
            Assert.Equal(payment.SignedAmount, decimal.Zero);
        }
        /// <summary>
        ///  checks that the signed amount equals the negative of the amount assigned
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(25, -25)]
        [InlineData(50, -50)]
        [InlineData(100, -100)]
        [InlineData(250, -250)]
        [InlineData(600, -600)]
        [InlineData(1250, -1250)]
        [InlineData(5000, -5000)]
        public void SignedAmountIsEqualToNegativeAmount(decimal amount, decimal expected)
        {
            Payment payment = new Payment();
            payment.Amount = amount;
            Assert.Equal(payment.SignedAmount, expected);
        }
        /// <summary>
        /// Ensures payment inherits and interfaces from the correct classes
        /// </summary>
        [Fact]
        public void ShowPaymentInheritanceAndInterface()
        {
            Payment payment = new Payment();
            Assert.IsAssignableFrom<BillingRecord>(payment);
            Assert.IsAssignableFrom<IBillingRecord>(payment);
        }

    }
}
