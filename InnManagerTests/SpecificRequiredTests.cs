using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests
{
    /// <summary>
    /// Runs specific required tests for InnManager
    /// </summary>
    public class SpecificRequiredTests
    {
        /// <summary>
        /// Ensures charge stores values correctly
        /// </summary>
        [Fact]
        public void ProcessedRoomCharge()
        {
            Charge charge = new Charge();
            charge.Amount = 600;
            charge.Category = ChargeCategory.Room;
            charge.IsProcessed = true;
            Assert.Equal(600, charge.Amount);
            Assert.Equal(600, charge.SignedAmount);
            Assert.Equal(ChargeCategory.Room, charge.Category);
            Assert.True(charge.IsProcessed);
            Assert.IsAssignableFrom<BillingRecord>(charge);
            Assert.IsAssignableFrom<IBillingRecord>(charge);
        }
        /// <summary>
        /// Ensures payment stores values correctly
        /// </summary>
        [Fact]
        public void ProcessedCreditCardPayment()
        {
            Payment payment = new Payment();
            payment.Amount = 500;
            payment.PaymentMethod = PaymentMethod.CreditCard;
            payment.IsProcessed = true;
            Assert.Equal(500, payment.Amount);
            Assert.Equal(-500, payment.SignedAmount);
            Assert.Equal(PaymentMethod.CreditCard, payment.PaymentMethod);
            Assert.True(payment.IsProcessed);
            Assert.IsAssignableFrom<BillingRecord>(payment);
            Assert.IsAssignableFrom<IBillingRecord>(payment);
        }
        /// <summary>
        /// Ensures invoice stores values correctly when partially paid
        /// </summary>
        [Fact]
        public void PartiallyPaidInvoice()
        {
            Invoice invoice = new Invoice();
            Charge roomCharge = new Charge();
            roomCharge.Amount = 600;
            roomCharge.Category = ChargeCategory.Room;
            roomCharge.IsProcessed = true;
            invoice.BillingRecords.Add(roomCharge);
            Charge laundryCharge = new Charge();
            laundryCharge.Amount = 40;
            laundryCharge.Category = ChargeCategory.Laundry;
            laundryCharge.IsProcessed = true;
            invoice.BillingRecords.Add(laundryCharge);
            Payment payment = new Payment();
            payment.Amount = 250;
            payment.PaymentMethod = PaymentMethod.CreditCard;
            payment.IsProcessed = true;
            invoice.BillingRecords.Add(payment);
            Assert.Equal(640, invoice.TotalCharges);
            Assert.Equal(250, invoice.TotalPayments);
            Assert.Equal(390, invoice.BalanceDue);
            Assert.Equal("Unpaid", invoice.Status);
        }

        /// <summary>
        /// Ensures invoice stores values correctly when fully paid
        /// </summary>
        [Fact]
        public void FullyPaidInvoice()
        {
            Invoice invoice = new Invoice();
            Charge roomCharge = new Charge();
            roomCharge.Amount = 600;
            roomCharge.Category = ChargeCategory.Room;
            roomCharge.IsProcessed = true;
            invoice.BillingRecords.Add(roomCharge);
            Charge laundryCharge = new Charge();
            laundryCharge.Amount = 40;
            laundryCharge.Category = ChargeCategory.Laundry;
            laundryCharge.IsProcessed = true;
            invoice.BillingRecords.Add(laundryCharge);
            Payment payment = new Payment();
            payment.Amount = 640;
            payment.PaymentMethod = PaymentMethod.CreditCard;
            payment.IsProcessed = true;
            invoice.BillingRecords.Add(payment);
            Assert.Equal(640, invoice.TotalCharges);
            Assert.Equal(640, invoice.TotalPayments);
            Assert.Equal(0, invoice.BalanceDue);
            Assert.Equal("Paid", invoice.Status);
        }
        /// <summary>
        /// Ensures unprocessed billing records are ignored
        /// </summary>
        [Fact]
        public void IgnoreUnprocessedBillingRecords()
        {
            Invoice invoice = new Invoice();
            Charge rCharge = new Charge();
            rCharge.Amount = 700;
            rCharge.IsProcessed = true;
            Charge sCharge = new Charge();
            sCharge.Amount = 150;
            sCharge.IsProcessed = false;
            Payment pay1 = new Payment();
            pay1.Amount = 200;
            pay1.IsProcessed = true;
            Payment pay2 = new Payment();
            pay2.Amount = 300;
            pay2.IsProcessed = false;
            invoice.BillingRecords.Add(rCharge);
            invoice.BillingRecords.Add(sCharge);
            invoice.BillingRecords.Add(pay1);
            invoice.BillingRecords.Add(pay2);
            Assert.Equal(700, invoice.TotalCharges);
            Assert.Equal(200, invoice.TotalPayments);
            Assert.Equal(500, invoice.BalanceDue);
            Assert.Equal("Unpaid", invoice.Status);
        }
        /// <summary>
        /// Ensures BillingSummary store values correctly
        /// </summary>
        [Fact]
        public void BillingSummaryWithMixedRecords()
        {
            List<BillingRecord> records = new List<BillingRecord>();
            BillingSummary billings = new BillingSummary(records);
            Charge rChar = new Charge();
            rChar.Amount = 1200;
            rChar.IsProcessed = true;
            records.Add(rChar);
            Charge dChar = new Charge();
            dChar.Amount = 300;
            dChar.IsProcessed = true;
            records.Add(dChar);
            Charge lChar = new Charge();
            lChar.Amount = 100;
            lChar.IsProcessed = true;
            records.Add(lChar);
            Charge sChar = new Charge();
            sChar.Amount = 400;
            sChar.IsProcessed = false;
            records.Add(sChar);
            
            Payment pay1 = new Payment();
            pay1.Amount = 800;
            pay1.IsProcessed = true;
            records.Add(pay1);
            
            Payment pay2 = new Payment();
            pay2.Amount = 250;
            pay2.IsProcessed = true;
            records.Add(pay2);
            
            Payment pay3 = new Payment();
            pay3.Amount = 500;
            pay3.IsProcessed = false;
            records.Add(pay3);
            
            Assert.Equal(1600, billings.TotalCharges);
            Assert.Equal(1050, billings.TotalPayments);
            Assert.Equal(550, billings.NetBalance);
        }
        /// <summary>
        /// Ensures Hotel stores values correctly
        /// </summary>
        [Fact]
        public void HotelRoomStatusCounts()
        {
            Hotel hotel = new Hotel("Grandview Hotel", HotelType.Business);
            Room room101 = new Room();
            room101.Status = RoomStatus.Available;
            hotel.Rooms.Add(room101);
            Room room102 = new Room();
            room102.Status = RoomStatus.Available;
            hotel.Rooms.Add(room102);
            Room room103 = new Room();
            room103.Status = RoomStatus.Occupied;
            hotel.Rooms.Add(room103);
            Room room104 = new Room();
            room104.Status = RoomStatus.Reserved;
            hotel.Rooms.Add(room104);
            Room room201 = new Room();
            room201.Status = RoomStatus.Maintenance;
            hotel.Rooms.Add(room201);
            Room room202 = new Room();
            room202.Status = RoomStatus.Occupied;
            hotel.Rooms.Add(room202);
            Room room203 = new Room();
            room203.Status = RoomStatus.Maintenance;
            hotel.Rooms.Add(room203);
            Room room204 = new Room();
            room204.Status = RoomStatus.Available;
            hotel.Rooms.Add(room204);
            Assert.Equal(8, hotel.Rooms.Count);
            Assert.Equal(3, hotel.AvailableRoomCount);
            Assert.Equal(2, hotel.OccupiedRoomCount);
        }
        /// <summary>
        /// Ensures HoukeepingTask returns the correct status
        /// </summary>
        [Fact]
        public void HousekeepingStatus()
        {
            HousekeepingTask task = new HousekeepingTask();
            task.RoomNumber = "204";
            task.Description = "Clean and prepare room";
            task.IsCompleted = false;
            Assert.Equal("Not Completed", task.Status);
            task.IsCompleted = true;
            Assert.Equal("Completed", task.Status);
        }
    }
}
