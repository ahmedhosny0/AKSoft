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
    
        public virtual DbSet<GroupCode> GroupCode { get; set; }
        public virtual DbSet<HSales> HSales { get; set; }
        public virtual DbSet<ItemCode> ItemCode { get; set; }
        public virtual DbSet<StoreCode> StoreCode { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UnitCode> UnitCode { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<HPurchase> HPurchase { get; set; }
    }
}
