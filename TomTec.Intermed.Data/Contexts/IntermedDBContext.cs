using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Data
{
    public class IntermedDBContext : DbContext
    {
        public DbContext Instance { get => this; }
        protected readonly IConfiguration Configuration;

        public IntermedDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            // construct the DB using the project TomTec.AuthServerAPI as startup
            options.UseSqlServer(Configuration.GetConnectionString("IntermedDB"), b => b.MigrationsAssembly("TomTec.Intermed.API"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => new {
                u.Email,
                u.UserName,
            }).IsUnique();
            modelBuilder.Entity<Claim>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<UserType>().HasIndex(ut => ut.Name).IsUnique();

            modelBuilder.Entity<UsersClaims>()
                .HasKey(uc => new { uc.UserId, uc.ClaimId });
            modelBuilder.Entity<UsersClaims>()
                .HasOne(uc => uc.User)
                .WithMany(b => b.UsersClaims)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UsersClaims>()
                .HasOne(bc => bc.Claim)
                .WithMany(c => c.UsersClaims)
                .HasForeignKey(bc => bc.ClaimId);
            modelBuilder.Entity<HealthProfessional>()
                .HasMany(h => h.CreditCardInfo)
                .WithOne(c => c.HealthProfessional);         
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<UsersClaims> UsersClaims { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<HealthProfessional> HealthProfessionals { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<ContactCard> ContactCards { get; set; }
        public DbSet<CreditCardInfo> CreditCardInfos { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<SignatureType> SignatureTypes { get; set; }
    }
}
