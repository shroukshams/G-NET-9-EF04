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
            // Branch Entity Configuration
            modelBuilder.Entity<Branch>()
                .HasKey(b => b.Code);

            // Manager Entity Configuration
            modelBuilder.Entity<Manger>()
                .HasKey(m => m.Id);

            // Customer Entity Configuration
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            // Account Entity Configuration
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber);

            // Transaction Entity Configuration
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionNumber);

            // Relationships

            // 1:1 Branch and Manager (Manager manages Branch)
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.mangerBranch)
                .WithOne(m => m.BranchManger)
                .HasForeignKey<Manger>(m => m.Id); // Manager Id is also FK to Branch Code

            // 1:M Branch and Account (Account belongs to Branch)
            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Accounts)
                .WithOne(a => a.BranchAccount)
                .HasForeignKey(a => a.BranchId);

            // M:M Customer and Account (via CustomerAccount join entity)
            modelBuilder.Entity<AccountCustomer>()
                .HasKey(ca => new { ca.CustomerId, ca.AccountId });

            modelBuilder.Entity<AccountCustomer>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.AccountCustomers)
                .HasForeignKey(ca => ca.CustomerId);
                
            modelBuilder.Entity<AccountCustomer>()
                .HasOne(ca => ca.Account)
                .WithMany(a => a.AccountCustomers)
                .HasForeignKey(ca => ca.AccountId);

            // 1:M Account and Transaction (Transaction is related to Account)
            modelBuilder.Entity<Account>()
                .HasMany(a => a.TransactionList)
                .WithOne(t => t.AccountTransaction)
                .HasForeignKey(t => t.AccountId);
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manger> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountCustomer> CustomerAccounts { get; set; }
    }









}
