using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestaurantManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.DataContext
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.Property(_ => _.Id).ValueGeneratedOnAdd();
                u.HasKey(_ => _.Id);
                u.Property(_ => _.Name).IsRequired();
                u.Property(_ => _.Surname).IsRequired();
                u.Property(_ => _.Role).IsRequired();
            });

            modelBuilder.Entity<Order>(u =>
            {
                u.Property(_ => _.Id).ValueGeneratedOnAdd();
                u.HasKey(_ => _.Id);
                u.Property(_ => _.Quantity).IsRequired();
                u.Property(_ => _.ProductId).IsRequired();
               
            });

            modelBuilder.Entity<Order>()
                .HasOne(p => p.User)
                .WithMany(b => b.Orders)
            .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Category>(u =>
            {
                u.Property(_ => _.Id).ValueGeneratedOnAdd();
                u.HasKey(_ => _.Id);
                u.Property(_ => _.Name).IsRequired();

            });
            modelBuilder.Entity<Menu>(u =>
            {
                u.Property(_ => _.Id).ValueGeneratedOnAdd();
                u.HasKey(_ => _.Id);
                u.Property(_ => _.Products)
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<List<string>>(v));
            });
            modelBuilder.Entity<Product>(u =>
            {
                u.Property(_ => _.Id).ValueGeneratedOnAdd();
                u.HasKey(_ => _.Id);
                u.Property(_ => _.Name).IsRequired();
                u.Property(_ => _.CategoryId).IsRequired();
                u.Property(_ => _.Price).IsRequired();

            });
        }
    }
}
