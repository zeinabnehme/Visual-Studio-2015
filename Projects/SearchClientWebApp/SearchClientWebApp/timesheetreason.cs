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
    
    public partial class timesheetreason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public timesheetreason()
        {
            this.timesheetpresents = new HashSet<timesheetpresent>();
        }
    
        public int ReasonId { get; set; }
        public string ReasonName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timesheetpresent> timesheetpresents { get; set; }
    }
}