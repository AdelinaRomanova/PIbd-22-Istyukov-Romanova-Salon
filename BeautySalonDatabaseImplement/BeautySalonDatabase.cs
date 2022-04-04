﻿using BeautySalonDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySalonDatabaseImplement
{
    internal class BeautySalonDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-5SU5L3MT\SQLEXPRESS;Initial Catalog=BeautySalonDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Cosmetic> Cosmetics { set; get; }
        public virtual DbSet<Distribution> Distributions { set; get; }
        public virtual DbSet<DistributionCosmetic> DistributionCosmetics { set; get; }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<Receipt> Receipts { set; get; }
        public virtual DbSet<ReceiptCosmetic> ReceiptCosmetics { set; get; }
        public virtual DbSet<Procedure> Procedures { set; get; }
        public virtual DbSet<Purchase> Purchases { set; get; }
        public virtual DbSet<ProcedurePurchase> ProcedurePurchases { get; set; }
        public virtual DbSet<ProcedureVisit> ProcedureVisits { get; set; }
        public virtual DbSet<Visit> Visits { set; get; }
    }
}
