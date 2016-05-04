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
    
    public partial class personnel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personnel()
        {
            this.accounts = new HashSet<account>();
            this.customer_flag_detail = new HashSet<customer_flag_detail>();
            this.customer_note = new HashSet<customer_note>();
            this.personnel1 = new HashSet<personnel>();
            this.personnel11 = new HashSet<personnel>();
            this.customers = new HashSet<customer>();
            this.customers1 = new HashSet<customer>();
        }
    
        public short PERSONNEL_ID { get; set; }
        public short LEVEL_ID { get; set; }
        public string GLOBAL_PERSONNEL_NUM { get; set; }
        public Nullable<short> OFFICE_ID { get; set; }
        public Nullable<int> TITLE { get; set; }
        public Nullable<short> PERSONNEL_STATUS { get; set; }
        public Nullable<short> PREFERRED_LOCALE { get; set; }
        public Nullable<short> site_preference { get; set; }
        public string SEARCH_ID { get; set; }
        public Nullable<int> MAX_CHILD_COUNT { get; set; }
        public byte[] PASSWORD { get; set; }
        public string LOGIN_NAME { get; set; }
        public string EMAIL_ID { get; set; }
        public short PASSWORD_CHANGED { get; set; }
        public string DISPLAY_NAME { get; set; }
        public short CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<short> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN { get; set; }
        public short LOCKED { get; set; }
        public short NO_OF_TRIES { get; set; }
        public int VERSION_NO { get; set; }
        public Nullable<System.DateTime> password_expiration_date { get; set; }
        public Nullable<int> p_Code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_flag_detail> customer_flag_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_note> customer_note { get; set; }
        public virtual lookup_value lookup_value { get; set; }
        public virtual office office { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personnel> personnel1 { get; set; }
        public virtual personnel personnel2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personnel> personnel11 { get; set; }
        public virtual personnel personnel3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers1 { get; set; }
    }
}