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
    
    public partial class customer_state_flag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer_state_flag()
        {
            this.customer_flag_detail = new HashSet<customer_flag_detail>();
        }
    
        public short FLAG_ID { get; set; }
        public int FLAG_LOOKUP_ID { get; set; }
        public short STATUS_ID { get; set; }
        public string FLAG_DESCRIPTION { get; set; }
        public Nullable<short> ISBLACKLISTED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_flag_detail> customer_flag_detail { get; set; }
        public virtual lookup_value lookup_value { get; set; }
        public virtual customer_state customer_state { get; set; }
    }
}
