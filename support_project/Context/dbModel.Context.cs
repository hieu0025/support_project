﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace support_project.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class suppport_hunreEntities : DbContext
    {
        public suppport_hunreEntities()
            : base("name=suppport_hunreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cong_ty> cong_tys { get; set; }
        public virtual DbSet<khoa> khoas { get; set; }
        public virtual DbSet<sach> sachs { get; set; }
        public virtual DbSet<sinh_vien> sinh_viens { get; set; }
    }
}