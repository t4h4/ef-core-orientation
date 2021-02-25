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
            AddProducts();
        }

        static void AddProducts()
        {
            using (var db = new ShopContext()) //using içerisine alırsak işimiz bittiğinde bellekten silinir.
            {
                var products = new List<Product>()
                {
                    new Product { Name = "Nokia 6600", Price = 300 },
                    new Product { Name = "Xiaomi Mi A1", Price = 3000 },
                    new Product { Name = "Xiaomi Mi A2", Price = 3000 },
                    new Product { Name = "Xiaomi Mi A3", Price = 3000 },
                    new Product { Name = "Xiaomi Redmi Note", Price = 3000 }

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
                var products = context
                .Products
                .Select(p => new { p.Name, p.Price }) //istediğimiz kolonları filtreleyebiliyoruz.
                .ToList(); // Gelen koleksiyonu listeye çeviriyoruz. veritabanına bu sayede select sorgusu gitmiş oluyor.

                foreach (var item in products)
                {
                    Console.WriteLine($"name: {item.Name} price: {item.Price}");
                }
            }
        }

        static void GetProductById(int id)
        {
            using (var context = new ShopContext())
            {
                var result = context
                    .Products
                    .Where(p => p.ProductId == id)
                    .Select(p => new { p.Name, p.Price }) //istediğimiz kolonları filtreleyebiliyoruz.
                    .FirstOrDefault(); // bunun sayesinde ilgili kayıt bulunamaz ise null değer gönderir.


                Console.WriteLine($"name: {result.Name} price: {result.Price}");

            }
        }

        static void GetProductByName(string name)
        {
            using (var context = new ShopContext())
            {
                var result = context
                    .Products
                    .Where(p => p.Name.ToLower().Contains(name.ToLower())) //contains içeriyormu? büyük küçük harf hassasiyetine dikkat et.
                    .Select(p => new { p.Name, p.Price }) //istediğimiz kolonları filtreleyebiliyoruz.
                    .ToList();

                foreach (var item in result)
                {
                    Console.WriteLine($"name: {item.Name} price: {item.Price}");
                }

            }
        }

        static void UpdateProduct()
        {
            using (var db = new ShopContext())
            {
                var p = db.Products.Where(i => i.ProductId == 14).FirstOrDefault();
                if (p != null)
                {
                    p.Price = 154300;
                    //updaterange ile listeyi güncelleyebilirdik.
                    db.Products.Update(p); //objeyi olduğu gibi update fonksiyonuna gönderdiğimiz için bütün alanlar güncellenir aynı
                    //olsa bile. Bu da veritabanını yorar. Aşağıdaki diğer yaklaşımları kullanmak daha mantıklı. 
                    db.SaveChanges();
                }
            }

            //select olmadan, sadece attach ile verilen entity için takip başlatılıyor.
            // using (var db = new ShopContext())
            // {
            //     var entity = new Product() {ProductId=14};
            //     db.Products.Attach(entity);
            //     entity.Price = 8000;
            //     db.SaveChanges();
            // }
            // using (var db = new ShopContext())
            // {
            //     //entity'nin change tracking özelliği sayesinde yaparız. eğer .AsNoTracking() dersek güncelleme yapılmazdı(aşağıdaki noktalı yerlere ek olarak).
            //     //EF takip etmediği objeyi SaveChanges yapamaz!
            //     var p = db.Products.Where(i=>i.ProductId==14).FirstOrDefault(); //first all diyerek tek kayıt geliyor. eğer kayıt yoksa null geliyor.
            //     if(p!=null)
            //     {
            //         p.Price *=1.2m; //fiyat üzerinde %20'lik artış
            //         db.SaveChanges();

            //         Console.WriteLine("Güncelleme yapıldı.");
            //     }
            // }
        }

        static void DeleteProduct(int id)
        {
            using (var db = new ShopContext())
            {
                var p = new Product() { ProductId = id }; //select olmuyor.
                db.Products.Remove(p);
                db.SaveChanges();

                //     var p = db.Products.FirstOrDefault(i => i.ProductId == id); //Bunda select oluyor.

                //     if (p!=null)
                //     {
                //         db.Products.Remove(p);
                //         db.SaveChanges();

                //         Console.WriteLine("Veri silindi.");
                //     }
            }
        }
    }
}
