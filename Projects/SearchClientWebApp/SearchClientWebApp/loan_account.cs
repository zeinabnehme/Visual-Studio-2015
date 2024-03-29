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
    
    public partial class loan_account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loan_account()
        {
            this.loan_account1 = new HashSet<loan_account>();
        }
    
        public int ACCOUNT_ID { get; set; }
        public Nullable<int> BUSINESS_ACTIVITIES_ID { get; set; }
        public Nullable<int> COLLATERAL_TYPE_ID { get; set; }
        public short GRACE_PERIOD_TYPE_ID { get; set; }
        public Nullable<short> GROUP_FLAG { get; set; }
        public Nullable<decimal> LOAN_AMOUNT { get; set; }
        public Nullable<short> LOAN_AMOUNT_CURRENCY_ID { get; set; }
        public Nullable<decimal> LOAN_BALANCE { get; set; }
        public Nullable<short> LOAN_BALANCE_CURRENCY_ID { get; set; }
        public Nullable<short> INTEREST_TYPE_ID { get; set; }
        public Nullable<decimal> INTEREST_RATE { get; set; }
        public Nullable<short> FUND_ID { get; set; }
        public Nullable<int> MEETING_ID { get; set; }
        public Nullable<short> CURRENCY_ID { get; set; }
        public short NO_OF_INSTALLMENTS { get; set; }
        public Nullable<System.DateTime> DISBURSEMENT_DATE { get; set; }
        public string collateral_note { get; set; }
        public Nullable<short> GRACE_PERIOD_DURATION { get; set; }
        public Nullable<short> INTEREST_AT_DISB { get; set; }
        public Nullable<short> GRACE_PERIOD_PENALTY { get; set; }
        public Nullable<short> PRD_OFFERING_ID { get; set; }
        public short REDONE { get; set; }
        public Nullable<int> PARENT_ACCOUNT_ID { get; set; }
        public Nullable<short> MONTH_RANK { get; set; }
        public Nullable<short> MONTH_WEEK { get; set; }
        public Nullable<short> RECUR_MONTH { get; set; }
    
        public virtual account account { get; set; }
        public virtual account account1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan_account> loan_account1 { get; set; }
        public virtual loan_account loan_account2 { get; set; }
        public virtual lookup_value lookup_value { get; set; }
        public virtual lookup_value lookup_value1 { get; set; }
        public virtual prd_offering prd_offering { get; set; }
    }
}
