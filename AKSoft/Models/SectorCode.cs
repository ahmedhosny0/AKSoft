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
    
    public partial class SectorCode
    {
        public int Serial { get; set; }
        public Nullable<int> Code { get; set; }
        public string ArabicName { get; set; }
        public string Notes { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}
