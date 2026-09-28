using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Represents a charge in the billing system, which is a type of billing record that has a specific category and an amount. The signed amount for a charge is equal to its amount.
    /// </summary>
    public class Charge : BillingRecord
    {
        /// <summary>
        /// Gets or sets the category of the charge, represented by the ChargeCategory enum. This property allows for specifying the type of charge, such as room, dining, room service, etc.
        /// </summary>
        public ChargeCategory Category { get; set; } = ChargeCategory.Miscellaneous;
        /// <summary>
        /// Gets the signed amount associated with the charge record. For charges, this value is equal to the amount, indicating an increase in the total amount owed by the guest.
        /// </summary>
        public override decimal SignedAmount => Amount;

    }
}
