//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    
    public partial class UnitCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnitCode()
        {
            this.HSales = new HashSet<HSales>();
            this.ItemCode = new HashSet<ItemCode>();
        }
    
        public int Serial { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> Code { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string DescName { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HSales> HSales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemCode> ItemCode { get; set; }
    }