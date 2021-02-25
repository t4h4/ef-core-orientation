using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef_core_st
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //dotnet add package Microsoft.Extensions.Logging.Console --version 5.0.0
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlite("Data Source=shop.db");
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
            GetAllProducts();
        }

        static void AddProducts()
        {
            using (var db = new ShopContext()) //using içerisine alırsak işimiz bittiğinde bellekten silinir.
            {
                var products = new List<Product>()
                {
                    new Product { Name = "Xiaomi Mi A1", Price = 3000 },
                    new Product { Name = "Xiaomi Mi A2", Price = 4000 },
                    new Product { Name = "Xiaomi Mi A3", Price = 5000 },
                    new Product { Name = "Xiaomi Redmi Note", Price = 2500 }

                };

                // foreach (var p in products)
                // {
                //     db.Products.Add(p);
                // }

                db.Products.AddRange(products); //yukarıdaki kodlarıda kullanabiliriz bu şekilde koleksiyonuda ekleyebiliriz.
                db.SaveChanges();
                Console.WriteLine("Veriler eklendi");
            }
        }

        static void AddProduct()
        {
            using (var db = new ShopContext()) //using içerisine alırsak işimiz bittiğinde bellekten silinir.
            {
                var p = new Product { Name = "Nokia 6600", Price = 20000 };
                db.Products.Add(p);
                db.SaveChanges();
                Console.WriteLine("Veri eklendi");
            }
        }

        static void GetAllProducts()
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.ToList(); // Gelen koleksiyonu listeye çeviriyoruz.
                //veritabanına bu sayede select sorgusu gitmiş oluyor.

                foreach (var item in products)
                {
                    Console.WriteLine($"name: {item.Name} price: {item.Price}");
                }
            }
        }
    }
}
