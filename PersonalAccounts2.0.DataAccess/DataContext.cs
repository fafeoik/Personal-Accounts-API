using Microsoft.EntityFrameworkCore;
using PersonalAccounts.Core.Models;
using PersonalAccounts2._0.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounts2._0.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<ResidentModel> Residents {  get; set; }
        public DbSet<AccountResidentModel> AccountsResidents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Accounts.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().HasAlternateKey(entity => entity.AccountNumber);
            modelBuilder.Entity<AccountModel>()
            .ToTable(t => t.HasCheckConstraint("valid date", "StartDate < EndDate"));

            modelBuilder.Entity<AccountResidentModel>()
           .HasOne(sc => sc.Account)
           .WithMany(s => s.AccountResidents)
           .HasForeignKey(sc => sc.AccountId);

            modelBuilder.Entity<AccountResidentModel>()
                .HasOne(sc => sc.Resident)
                .WithMany(c => c.AccountResidents)
                .HasForeignKey(sc => sc.ResidentId);
        }
    }
}
