﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TopSoft : DbContext
    {
        public TopSoft()
            : base("name=TopSoft")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BranchCode> BranchCode { get; set; }
        public virtual DbSet<CountryCode> CountryCode { get; set; }
        public virtual DbSet<CustomerCode> CustomerCode { get; set; }
        public virtual DbSet<DealerCode> DealerCode { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<GroupCode> GroupCode { get; set; }
        public virtual DbSet<HPurchase> HPurchase { get; set; }
        public virtual DbSet<HSales> HSales { get; set; }
        public virtual DbSet<ItemCode> ItemCode { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SectorCode> SectorCode { get; set; }
        public virtual DbSet<StoreCode> StoreCode { get; set; }
        public virtual DbSet<SupplierCode> SupplierCode { get; set; }
        public virtual DbSet<TownCode> TownCode { get; set; }
        public virtual DbSet<UnitCode> UnitCode { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
    }
}
