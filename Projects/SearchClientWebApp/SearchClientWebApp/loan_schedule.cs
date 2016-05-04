//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SearchClientWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class loan_schedule
    {
        public int ID { get; set; }
        public int ACCOUNT_ID { get; set; }
        public int CUSTOMER_ID { get; set; }
        public Nullable<short> CURRENCY_ID { get; set; }
        public Nullable<System.DateTime> ACTION_DATE { get; set; }
        public decimal PRINCIPAL { get; set; }
        public Nullable<short> PRINCIPAL_CURRENCY_ID { get; set; }
        public decimal INTEREST { get; set; }
        public Nullable<short> INTEREST_CURRENCY_ID { get; set; }
        public decimal PENALTY { get; set; }
        public Nullable<short> PENALTY_CURRENCY_ID { get; set; }
        public Nullable<decimal> MISC_FEES { get; set; }
        public Nullable<short> MISC_FEES_CURRENCY_ID { get; set; }
        public Nullable<decimal> MISC_FEES_PAID { get; set; }
        public Nullable<short> MISC_FEES_PAID_CURRENCY_ID { get; set; }
        public Nullable<decimal> MISC_PENALTY { get; set; }
        public Nullable<short> MISC_PENALTY_CURRENCY_ID { get; set; }
        public Nullable<decimal> MISC_PENALTY_PAID { get; set; }
        public Nullable<short> MISC_PENALTY_PAID_CURRENCY_ID { get; set; }
        public Nullable<decimal> PRINCIPAL_PAID { get; set; }
        public Nullable<short> PRINCIPAL_PAID_CURRENCY_ID { get; set; }
        public Nullable<decimal> INTEREST_PAID { get; set; }
        public Nullable<short> INTEREST_PAID_CURRENCY_ID { get; set; }
        public Nullable<decimal> PENALTY_PAID { get; set; }
        public Nullable<short> PENALTY_PAID_CURRENCY_ID { get; set; }
        public short PAYMENT_STATUS { get; set; }
        public short INSTALLMENT_ID { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATE { get; set; }
        public Nullable<short> PARENT_FLAG { get; set; }
        public int VERSION_NO { get; set; }
        public Nullable<decimal> extra_interest { get; set; }
        public Nullable<short> extra_interest_currency_id { get; set; }
        public Nullable<decimal> extra_interest_paid { get; set; }
        public Nullable<short> extra_interest_paid_currency_id { get; set; }
        public System.DateTime last_updated { get; set; }
    
        public virtual account account { get; set; }
        public virtual customer customer { get; set; }
    }
}
