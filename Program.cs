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
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }



        //dotnet add package Microsoft.Extensions.Logging.Console --version 5.0.0
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                //.UseSqlite("Data Source=shop.db");
                //.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDb;Integrated Security=SSPI;");
                //@ işareti ters \'ı stringin parçası yapar.
                //Integrated Security=SSPI demek localde olduğumuz için. kullanıcı adı ve şifreye gerek yok. 
                //Sqlite migrations'u proje dosyamızdan siliyoruz. yeni migrations yapmamız gerekli. dotnet ef migrations add InitialCreate
                //Migrations'ı uygulamak için kulllanacağımız komut dotnet ef database update
                .UseMySql(@"server=localhost;port=3306;database=ShopDb;user=root;");
            //dotnet ef migrations add InitialCreate      
            //dotnet ef database update

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ProductCategory entity yapısının combine key'a sahip olmasını sağladık aşağıda.
            //Bu şekilde yapıldığında tekrarlayan yapılar database tarafından kabul edilmez.
            modelBuilder.Entity<ProductCategory>()
                        .HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                        .HasOne(pc => pc.Product)
                        .WithMany(p => p.ProductCategories)
                        .HasForeignKey(pc => pc.ProductId); //yabancı id

            modelBuilder.Entity<ProductCategory>()
                        .HasOne(pc => pc.Category)
                        .WithMany(c => c.ProductCategories)
                        .HasForeignKey(pc => pc.CategoryId);
        }
    }

    // One to Many
    // One to One
    // Many to Many

    // convention ProductId
    // data annotations [Key]
    // fluent api

    // 1 kullanıcının birden fazla adresi olabilir. One to Many senaryo bu.
    // 1 kullanıcı birden fazla müşteri ya da supplier olması beklenemez. One to One senaryo bu. (aynı anda hem müşteri hem supplier olabilir ama.) 
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Customer Customer { get; set; } // one to one olduğu için tekil. list değil
        public List<Address> Adresses { get; set; } //navigation property one to many olduğu için list
    }

    public class Customer //User ile ilişki sağlandıgından context'e eklemesek bile veritabanına bu kolon gitti. ama aşağıdaki supplier tablosu gitmedi. çünkü user ile ilişkisi yok.
    //Ama veritabanına ekleme falan yaparken lazım olur diye gene de context'e bu kolonu ekliyoruz. 
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }

    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User User { get; set; } //navigation property
        public int UserId { get; set; }
        // public int? UserId { get; set; } 
        // soru işareti sayesinde address bilgileri girilirken UserId girilmese bile olur. otomatikman null diye geçer.
    }

    //bir product birden fazla kategoride olabilir. 
    public class Product
    {
        // primary key (Id, <type_name>Id)
        //[Key] diyerek de belirtebilirdik üzerinde.
        public int ProductId { get; set; } // yukarıdaki yorum satırındaki yapı gibi oldugundan primary key oldu.
        // [MaxLength(100)]
        // [Required]
        public string Name { get; set; }
        public decimal Price { get; set; } //decimal alan normalde zorunlu alan ama sonuna decimal? yaparsak null alabilen olur. Şimdiki haliyle mutlaka fiyat bilgisi gerekli
        //  public int CategoryId { get; set; } // yeni kolon. migratons güncelle. dotnet ef migrations add addColumnProductCategoryId 
        //  dotnet ef database update  
        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }

    //Context'e eklemek gerekmiyor.
    //ManyToMany Relation ise bir ürün birden fazla kategoride olabilir, bir kategoride birden fazla ürün içerebilir.
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShopContext())
            {
                var products = new List<Product>()
                {
                    new Product() {Name="Nokia 3310",Price=6000},
                    new Product() {Name="Nokia 3210",Price=5000},
                    new Product() {Name="Nokia N8",Price=7000},
                    new Product() {Name="Nokia 6230i",Price=5500},
                };


                var categories = new List<Category>()
                {
                    new Category() {Name="Telefon"},
                    new Category() {Name="Elektronik"},
                    new Category() {Name="Bilgisayar"},
                };
                // ****************
                //aşağısı 1 numaralı ürünün yani nokia 3310 telefonunun kategorisini hem telefon hem de elektronik
                //olarak kaydediyor ProductCategory entity yapısına.
                // ****************
                int[] ids = new int[2] { 1, 2 };
                var p = db.Products.Find(1);
                //select ile foreach gibi dolanabiliyoruz.
                p.ProductCategories = ids.Select(cid => new ProductCategory() //1. ve 2. kategoriler için uygulanıyor, ama sadece 1. product için.
                {
                    CategoryId = cid,
                    ProductId = p.ProductId
                }).ToList();

                db.SaveChanges();
            }

        }

        static void InsertUsers()
        {
            var users = new List<User>(){
                new User(){Username="Taha", Email="taha@taha.com"},
                new User(){Username="Elfin", Email="elfin@elfin.com"},
                new User(){Username="Ali", Email="ali@ali.com"},
                new User(){Username="Veli", Email="veli@veli.com"},
            };

            using (var db = new ShopContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        static void InsertAddresses()
        {
            var addresses = new List<Address>(){
                new Address(){Fullname="Taha Erkan", Title="Ev", Body="Ankara", UserId=1},
                new Address(){Fullname="Taha Erkan", Title="İş", Body="Ankara", UserId=1},
                new Address(){Fullname="Elfin Yılmaz", Title="Ev", Body="Ankara", UserId=2},
                new Address(){Fullname="Elfin Yılmaz", Title="İş", Body="Ankara", UserId=2},
                new Address(){Fullname="Ali Erkan", Title="İş", Body="Ankara", UserId=3},
                new Address(){Fullname="Veli Erkan", Title="İş", Body="Ankara", UserId=4},

            };

            using (var db = new ShopContext())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }
    }
}
