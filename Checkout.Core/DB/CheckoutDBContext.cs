using Checkout.Core.Models.Account;
using Checkout.Core.Models.Common;
using Checkout.Core.Models.Payment;
using Checkout.Core.Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Checkout.Core.DB
{
    public class CheckoutDBContext : DbContext
    {
        private readonly string _connectionString;
        public CheckoutDBContext(DbContextOptions options) : base(options)
        {
             
        }
         
        public CheckoutDBContext(string connectionString)
        {
            _connectionString = connectionString; 
        }
        private CheckoutDBContext()
        {
             
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                //optionsBuilder.UseSqlServer("Server=.;initial catalog=CheckoutDB;User Id=sa;Password=");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<CardTransaction> CardTransaction { get; set; }
        public DbSet<TransactionBase> TransactionBase { get; set; }
        public DbSet<TemporaryTransaction> TemporaryTransaction { get; set; }
        public DbSet<MerchantProfile> MerchantProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configure primary key
            modelBuilder.Entity<Merchant>().HasKey(e => e.Id);
            modelBuilder.Entity<TransactionBase>().HasKey(e => e.Id);
            modelBuilder.Entity<TemporaryTransaction>().HasKey(e => e.Id);
            modelBuilder.Entity<MerchantProfile>().HasKey(e => e.Id);
            modelBuilder.Entity<PaymentMethod>().HasKey(e => e.Id);
            modelBuilder.Entity<MerchantProfilesPaymentMethods>().HasKey(e => e.Id);

            modelBuilder.Entity<CardTransaction>().ToTable("tbl_CardTransaction");
            modelBuilder.Entity<Merchant>().ToTable("tbl_Merchant");
            modelBuilder.Entity<TransactionBase>().ToTable("tbl_TransactionBase");
            modelBuilder.Entity<MerchantProfile>().ToTable("tbl_MerchantProfile");
            modelBuilder.Entity<TemporaryTransaction>().ToTable("tbl_TemporaryTransaction");
            modelBuilder.Entity<PaymentMethod>().ToTable("tbl_PaymentMethod");
            modelBuilder.Entity<MerchantProfilesPaymentMethods>().ToTable("tbl_MerchantProfilesPaymentMethods");

            modelBuilder.Entity<MerchantProfile>(entity =>
            {
                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey("MerchantId");
            });

            //modelBuilder.Entity<MerchantProfile>()
            //    .HasMany(mp => mp.PaymentMethods)
            //    .WithMany(p => p.MerchantProfiles)
            //    .UsingEntity(j => j.ToTable("tbl_MerchantProfilesPaymentMethods"));

            modelBuilder.Owned<Amount>();
 
            modelBuilder.Seed();
        }
       
    }
}
