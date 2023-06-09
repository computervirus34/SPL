using Microsoft.EntityFrameworkCore;
using SPL.Models;
using System;

namespace SPL.Data
{
    public class SPLDatabaseContext : DbContext
    {
        public SPLDatabaseContext()
        {
        }

        public SPLDatabaseContext(DbContextOptions<SPLDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Prospect> Prospects { get; set; }
        public virtual DbSet<UserAuth> UserAuths { get; set; }
        public virtual DbSet<UPDSGenericReult> UPDSGenericReults { get; set; }
        public virtual DbSet<WaselAddressDetails> WaselAddressDetails { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<PinCodeModel> PinCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Contact>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Shipment>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Prospect>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<UserAuth>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<UPDSGenericReult>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<WaselAddressDetails>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Account>()
               .Property(b => b.Id)
               .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PinCodeModel>()
               .Property(b => b.Id)
               .HasDefaultValueSql("NEWID()");
        }
    }
}
