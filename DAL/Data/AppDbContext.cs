using DAL.Entities;
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


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product ve Brand ilişkisi
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand) // Her ürünün bir markası var
                .WithMany(b => b.Products) // Her markanın birden fazla ürünü olabilir
                .HasForeignKey(p => p.BrandId) // Yabancı anahtar
                .OnDelete(DeleteBehavior.Cascade); // İlişkili ürün silindiğinde markayı da sil

            // Product ve Category ilişkisi
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // Her ürünün bir kategorisi var
                .WithMany(c => c.Products) // Her kategorinin birden fazla ürünü olabilir
                .HasForeignKey(p => p.CategoryId) // Yabancı anahtar
                .OnDelete(DeleteBehavior.Cascade); // İlişkili ürün silindiğinde kategoriyi de sil

            modelBuilder.Entity<Product>()
       .Property(p => p.Price)
       .HasColumnType("decimal(18, 2)"); // 18 basamak toplam, 2 basamak ondalık
        }


    }




}
