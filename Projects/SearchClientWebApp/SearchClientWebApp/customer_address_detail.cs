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
    
    public partial class customer_address_detail
    {
        public int CUSTOMER_ADDRESS_ID { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        public Nullable<short> LOCALE_ID { get; set; }
        public string ADDRESS_NAME { get; set; }
        public string LINE_1 { get; set; }
        public string LINE_2 { get; set; }
        public string LINE_3 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string ZIP { get; set; }
        public Nullable<short> ADDRESS_STATUS { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string phone_number_stripped { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
