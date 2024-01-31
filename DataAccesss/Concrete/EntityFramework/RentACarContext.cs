using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EMINE;Initial Catalog=RentDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colors>().HasKey(c => c.ColorId);
            modelBuilder.Entity<Brand>().HasKey(b => b.BrandId);
            modelBuilder.Entity<Car>().HasKey(c => c.Id);
            modelBuilder.Entity<Rental>().HasKey(r => r.Id);
            modelBuilder.Entity<Customer>().HasKey(cm => cm.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<CarImage>().HasKey(cı=> cı.Id);
        }
        //Dbset<benim projedeki nesnem>Veritabanındaki nesneme karşılık tablo { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Colors> Colors { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<User> Users { get; set; }

         public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; } 

    }
}
