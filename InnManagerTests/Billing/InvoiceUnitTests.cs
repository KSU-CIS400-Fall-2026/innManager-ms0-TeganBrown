using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Billing
{
    /// <summary>
    /// Runs tests for the Invoice class in InnManager
    /// </summary>
    public class InvoiceUnitTests
    {
        /// <summary>
        /// Ensures that default values are correct
        /// </summary>
        [Fact]
        public void InvoiceDefaultValuesTests()
        {
            Invoice invoice = new Invoice();
            Assert.Equal(invoice.GuestName, string.Empty);
            Assert.Equal(invoice.RoomNumber, string.Empty);
            Assert.Equal(invoice.BillingRecords.Count, 0);
            Assert.Equal(invoice.TotalCharges, 0);
            Assert.Equal(invoice.TotalPayments, 0);
            Assert.Equal(invoice.BalanceDue, 0);
            Assert.Equal(invoice.Status, "Paid");
        }
        /// <summary>
        /// Checks if the invoice is properly calculated
        /// </summary>
        /// <param name="charge">Amount being charged</param>
        /// <param name="pay">Amount paid</param>
        /// <param name="exBal">The expected balance</param>
        /// <param name="exStatus">The expected status of the invoice</param>
        [Theory]
        [InlineData(500, 0, 500, "Unpaid")]
        [InlineData(500, 100, 400, "Unpaid")]
        [InlineData(500, 250, 250, "Unpaid")]
        [InlineData(500, 499, 1, "Unpaid")]
        [InlineData(500, 500, 0, "Paid")]
        [InlineData(500, 550, -50, "Paid")]
        [InlineData(1000, 250, 750, "Unpaid")]
        [InlineData(1000, 1200, -200, "Paid")]
        public void InvoiceIsChargeMinusPayment(decimal charge, decimal pay, decimal exBal, string exStatus)
        {
            Invoice invoice = new Invoice();
            Charge c = new Charge();
            c.IsProcessed = true;
            c.Amount = charge;
            Payment payment = new Payment();
            payment.IsProcessed = true;
            payment.Amount = pay;
            invoice.BillingRecords.Add(c);
            invoice.BillingRecords.Add(payment);
            Assert.Equal(invoice.BalanceDue, exBal);
            Assert.Equal(invoice.Status, exStatus);

        }
    }
}
