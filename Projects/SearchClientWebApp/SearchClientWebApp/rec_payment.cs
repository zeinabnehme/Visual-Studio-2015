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
    
    public partial class rec_payment
    {
        public int PaymentID { get; set; }
        public int AccountID { get; set; }
        public decimal PaymentAmount { get; set; }
    
        public virtual account account { get; set; }
    }
}