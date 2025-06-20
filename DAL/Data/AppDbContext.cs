﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductRating> ProductRating { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


                 modelBuilder.Entity<ProductRating>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Ratings)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand) 
                .WithMany(b => b.Products) 
                .HasForeignKey(p => p.BrandId) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) 
                .WithMany(c => c.Products) 
                .HasForeignKey(p => p.CategoryId) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Product>()
       .Property(p => p.Price)
       .HasColumnType("decimal(18, 2)"); 





            modelBuilder.Entity<Comment>()
        .HasOne(c => c.User)
        .WithMany(u => u.Comments)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        
                    modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        

                        modelBuilder.Entity<Basket>()
            .HasOne(f => f.User)
            .WithMany(u => u.Baskets)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                    .HasOne(o => o.User)
                    .WithMany(u => u.Orders) 
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders) 
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany(a => a.Orders) 
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.CreditCard)
                .WithMany(cc => cc.Orders) 
                .HasForeignKey(o => o.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Basket>()
       .Property(b => b.Price)
       .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
.Property(b => b.TotalPrice)
.HasColumnType("decimal(18, 2)");

        }


    }




}
