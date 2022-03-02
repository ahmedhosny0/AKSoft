//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AKSoft.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CountryCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CountryCode()
        {
            this.CustomerCode = new HashSet<CustomerCode>();
            this.SupplierCode = new HashSet<SupplierCode>();
            this.DealerCode = new HashSet<DealerCode>();
            this.Employee = new HashSet<Employee>();
            this.StoreCode = new HashSet<StoreCode>();
        }
    
        public int Serial { get; set; }
        public Nullable<int> Code { get; set; }
        public Nullable<int> Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string DescName { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> AddUserDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCode> CustomerCode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierCode> SupplierCode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealerCode> DealerCode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreCode> StoreCode { get; set; }
    }
}
