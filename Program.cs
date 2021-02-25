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
    }

    // One to Many
    // One to One
    // Many to Many

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
    public class Product
    {
        // primary key (Id, <type_name>Id)
        public int ProductId { get; set; } // yukarıdaki yorum satırındaki yapı gibi oldugundan primary key oldu.
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; } //decimal alan normalde zorunlu alan ama sonuna decimal? yaparsak null alabilen olur. Şimdiki haliyle mutlaka fiyat bilgisi gerekli
        public int CategoryId { get; set; } // yeni kolon. migratons güncelle. dotnet ef migrations add addColumnProductCategoryId 
        //dotnet ef database update  

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
            // using (var db = new ShopContext())
            // {
            //     var customer = new Customer()
            //     {
            //         IdentityNumber = "16856156",
            //         FirstName = "Taha",
            //         LastName = "Erkan",
            //         UserId = 1
            //         // User = db.Users.FirstOrDefault(i=>i.Id==1)     // bu şekilde de yapabilirdik.
            //     };

            //     db.Customers.Add(customer);
            //     db.SaveChanges();
            // }

            using (var db = new ShopContext())
            {
                var user = new User()
                {
                    Username = "deneme",
                    Email = "deneme@deneme.com",
                    Customer = new Customer()
                    {
                        FirstName = "deneme",
                        LastName = "deneme",
                        IdentityNumber = "12312312"
                    }
                };
                db.Users.Add(user);
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
