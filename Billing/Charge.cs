using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    public abstract class Charge : BillingRecord
    {
        public ChargeCategory Category { get; set; } = ChargeCategory.Miscellaneous;

        public override decimal SignedAmount => Amount;

    }
}
