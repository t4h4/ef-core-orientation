using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ef_core_st
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shop.db");
        }
    }

    public class Product
    {
        // primary key (Id, <type_name>Id)
        public int ProductId { get; set; } // yukarıdaki yorum satırındaki yapı gibi oldugundan primary key oldu.
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; } //decimal alan normalde zorunlu alan ama sonuna decimal? yaparsak null alabilen olur. Şimdiki haliyle mutlaka fiyat bilgisi gerekli

    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
