using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Username)
                        .IsUnique();

            modelBuilder.Entity<Product>()
                        .ToTable("Urunler"); // uygulama tarafında bu isimle göreceğiz.

            modelBuilder.Entity<Customer>()
                        .Property(p => p.IdentityNumber)
                        .HasMaxLength(11)
                        .IsRequired();

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

    public static class DataSeeding
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0) //bekleyen migration yoksa bloğa girer.
            {
                if (context is ShopContext)
                {
                    ShopContext _context = context as ShopContext;

                    if (_context.Products.Count() == 0) //Hiç product yoksa ekle
                    {
                        _context.Products.AddRange(Products);
                    }

                    if (_context.Categories.Count() == 0) //Hiç category yoksa ekle
                    {
                        _context.Categories.AddRange(Categories);
                    }
                }

                context.SaveChanges();

            }
        }

        private static Product[] Products = {
            new Product(){Name="Samsun S6",Price=2000},
            new Product(){Name="Samsun S7",Price=3000},
            new Product(){Name="Samsun S8",Price=4000},
            new Product(){Name="Samsun S9",Price=5000}
        };

        private static Category[] Categories = {
            new Category(){Name="Telefon"},
            new Category(){Name="Elektronik"},
            new Category(){Name="Bilgisayar"}
        };
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
        [Required]
        [MinLength(8), MaxLength(15)]
        public string Username { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Email { get; set; }
        public Customer Customer { get; set; } // one to one olduğu için tekil. list değil
        public List<Address> Adresses { get; set; } //navigation property one to many olduğu için list
    }

    public class Customer //User ile ilişki sağlandıgından context'e eklemesek bile veritabanına bu kolon gitti. ama aşağıdaki supplier tablosu gitmedi. çünkü user ile ilişkisi yok.
    //Ama veritabanına ekleme falan yaparken lazım olur diye gene de context'e bu kolonu ekliyoruz. 
    {
        [Column("customer_id")] //uygulama tarafındaki id bilgisi veritabanındaki buraya karşılık gelir.
        public int Id { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped] //bu sayede database'e göndermeyiz. sadece uygulama içerisinde kullanırız.
        public string FullName { get; set; } //database'de istemiyorum.
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
        // [DatabaseGenerated(DatabaseGeneratedOption.None)] //id'yi kendimiz girmemiz lazım. oto arttırımı engelliyor.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } // yukarıdaki yorum satırındaki yapı gibi oldugundan primary key oldu.
        public string Name { get; set; }
        public decimal Price { get; set; } //decimal alan normalde zorunlu alan ama sonuna decimal? yaparsak null alabilen olur. Şimdiki haliyle mutlaka fiyat bilgisi gerekli
        //  public int CategoryId { get; set; } // yeni kolon. migratons güncelle. dotnet ef migrations add addColumnProductCategoryId 
        //  dotnet ef database update  

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // bir kere oluşturuluyor, bi' daha değiştirilmiyor. ilk giriş datasının vaktide mantıken değiştirilmemesi lazım.
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // güncellenebilir, değiştirilebilir alan oluyor.
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;

        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }

    //Context'e eklemek gerekmiyor. Çünkü context'e eklenen product ve category entity yapılarında aşağıdaki entity eleman olarak 
    //yani liste olarak kullanıldı bu yüzden.
    // [NotMapped] diyerek database'de gözükmesini engelleyebiliriz.
    // [Table("UrunKategorileri")] bu şekilde database'de gözükmesini istediğimiz adı belirleyebiliriz. //Fluent api benzeri ise bunun yukarıda var. (modelbuilder'a bak)
    //ManyToMany Relation ise bir ürün birden fazla kategoride olabilir, bir kategoride birden fazla ürün içerebilir.

    [Table("UrunKategorileri")]
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
            DataSeeding.Seed(new ShopContext());
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
