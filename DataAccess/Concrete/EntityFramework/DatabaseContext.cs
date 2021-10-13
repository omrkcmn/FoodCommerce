using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;database=YemekSepeti;Trusted_connection=true");
        }

        public DbSet<Food> Yemekler { get; set; }
        public DbSet<Restourant> Restoranlar { get; set; }
        public DbSet<FoodImage> YemekResim { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Yorumlar { get; set; }
        public DbSet<Cart> Sepet { get; set; }
        public DbSet<Order> Siparisler { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
