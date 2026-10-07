using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests.Billing
{
    /// <summary>
    /// Runs tests for the BillingSummary class in InnManager
    /// </summary>
    public class BillingSummaryUnitTests
    {
        /// <summary>
        /// Ensures that default values are correct
        /// </summary>
        [Fact]
        public void BillingSummaryDefaultValuesTests()
        {
            BillingSummary billings = new([]);
            Assert.Equal(billings.TotalCharges, 0);
            Assert.Equal(billings.TotalPayments, 0);
            Assert.Equal(billings.NetBalance, 0);
        }
        
        [Theory]
        [InlineData(false, false, false, false, 0, 0, 0)]
        public void OnlyProcessedBillingsApply(bool charProc1, bool charProc2, bool payProc1, bool payProc2, decimal exCharge, decimal exPay, decimal exBal)
        {
            List<BillingRecord> records = new();
            BillingSummary billings = new BillingSummary(records);
            Charge charge1 = new Charge();
            charge1.Amount = 50;
            charge1.IsProcessed = charProc1;
            records.Add(charge1);


        }
        
    }
}
