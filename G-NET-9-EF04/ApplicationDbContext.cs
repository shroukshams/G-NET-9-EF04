using G_NET_9_EF04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_NET_9_EF04

{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=G_NET_9_EF04;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountCustomer>()
                .HasKey(ac => new { ac.AccountId, ac.CustomerId });
            modelBuilder.Entity<AccountCustomer>()
                .HasOne(ac => ac.Account)
                .WithMany(a => a.AccountCustomers)
                .HasForeignKey(ac => ac.AccountId);
            modelBuilder.Entity<AccountCustomer>()
                .HasOne(ac => ac.Customer)
                .WithMany(c => c.AccountCustomers)
                .HasForeignKey(ac => ac.CustomerId);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.BranchAccount)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BranchId);
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.mangerBranch)
                .WithOne(m => m.BranchManger)
                .HasForeignKey<Manger>(m => m.BranchCode);
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.AccountTransaction)
                .WithMany(a => a.TransactionList)
                .HasForeignKey(t => t.AccountId);
      modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .HasConversion<string>();
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .HasMaxLength(50);
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .IsRequired(false);
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasDefaultValue(0);
            modelBuilder.Entity<Account>()
                .Property(a => a.OpenDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();
           modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber);
           
            modelBuilder.Entity<Branch>()
                .HasKey(b => b.Code);
            modelBuilder.Entity<Manger>()
               .HasIndex(m => m.Id)
               .IsUnique();
            modelBuilder.Entity<Transaction>()
               .HasKey(t => t.TransactionNumber);




        }










        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountCustomer> AccountCustomers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manger> Mangers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}

