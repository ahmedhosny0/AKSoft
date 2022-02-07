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
    
    public partial class HPurchase
    {
        public int Serial { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> BranchCode { get; set; }
        public Nullable<int> Code { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> CurrencyCode { get; set; }
        public Nullable<double> Factor { get; set; }
        public Nullable<int> StoreSerial { get; set; }
        public Nullable<int> DealerCode { get; set; }
        public Nullable<int> RegionCode { get; set; }
        public Nullable<int> ItemSerial { get; set; }
        public Nullable<int> UnitSerial { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> Tax { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> TotalAfterDisc { get; set; }
        public Nullable<double> DiscValue { get; set; }
        public Nullable<int> GroupSerial { get; set; }
    
        public virtual GroupCode GroupCode { get; set; }
        public virtual ItemCode ItemCode { get; set; }
        public virtual StoreCode StoreCode { get; set; }
        public virtual UnitCode UnitCode { get; set; }
    }