using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Billing
{
    /// <summary>
    /// Runs tests for the Charge class in InnManager
    /// </summary>
    public class ChargeUnitTests
    {
        [Fact]
        public void ChargeDefaultValueTests()
        {
            Charge charge = new Charge();
            Assert.Equal(charge.Amount, decimal.Zero);
            Assert.Equal(charge.date.Date, DateTime.Now.Date);
            Assert.Equal(charge.Description, string.Empty);
            Assert.False(charge.IsProcessed);
            Assert.Equal(charge.Category, ChargeCategory.Miscellaneous);
            Assert.Equal(charge.SignedAmount, decimal.Zero);
        }
        /// <summary>
        /// checks that the signed amount equals the amount assigned
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(25, 25)]
        [InlineData(50, 50)]
        [InlineData(100, 100)]
        [InlineData(250, 250)]
        [InlineData(600, 600)]
        [InlineData(1250, 1250)]
        [InlineData(5000, 5000)]
        public void SignedAmountIsEqualToAmount(decimal amount, decimal expected)
        {
            Charge charge = new Charge();
            charge.Amount = amount;
            Assert.Equal(charge.SignedAmount, expected);
        }
        /// <summary>
        /// Ensures charge inherits and interfaces from the correct classes
        /// </summary>
        [Fact]
        public void ShowChargeInheritanceAndInterface()
        {
            Charge charge = new Charge();
            Assert.IsAssignableFrom<BillingRecord>(charge);
            Assert.IsAssignableFrom<IBillingRecord>(charge);
        }
    }
}
