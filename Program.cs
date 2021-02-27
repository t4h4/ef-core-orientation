using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ef_core_st.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef_core_st
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                // Tüm müşteri kayıtlarını getiriniz.

                // var customers = db.Customers.ToList();

                // foreach (var item in customers)
                // {
                //     Console.WriteLine(item.FirstName + " " + item.LastName);
                // }
                ////////////////////////////
                // Tüm müşteri kayıtlarının sadece first_name ve last_name bilgilerini getiriniz.

                // var customers = db.Customers.Select(c=>new {
                //       c.FirstName,
                //       c.LastName  
                // });

                // foreach (var item in customers)
                // {
                //     Console.WriteLine(item.FirstName +" "+ item.LastName);
                // }
                ////////////////////////////////
                // New York' da yaşayan müşterileri isim sırasına göre getiriniz.

                // var customers = db.Customers
                //                 .Where(i=>i.City == "New York")
                //                 .Select(s=> new {s.FirstName,s.LastName})
                //                 .ToList();

                // foreach (var item in customers)
                // {
                //     Console.WriteLine(item.FirstName +" "+ item.LastName);
                // }
                ///////////////////////////////////
                // "Beverages" kategorisine ait ürünlerin isimlerini getiriniz.

                // var productnames = db.Products
                //                 .Where(i=>i.Category=="Beverages")
                //                 .Select(i=>i.ProductName)
                //                 .ToList();

                // foreach (var name in productnames)
                // {
                //     Console.WriteLine(name);
                // }
                ///////////////////////////////////////
                // En son eklenen 5 ürün bilgisini alınız.

                // var products = db.Products.OrderByDescending(i=>i.Id).Take(5);

                // foreach (var p in products)
                // {
                //     Console.WriteLine(p.ProductName);
                // }
                //////////////////////////////////////////
                // Fiyatı 10 ile 30 arasında olan ürünlerin isim, fiyat bilgilerini azalan şekilde getiriniz.

                // var products = db.Products
                //                 .Where(i=> i.ListPrice>=10 && i.ListPrice<=30)
                //                 .Select(i=> new {
                //                      i.ProductName,
                //                      i.ListPrice  
                //                 }).ToList();


                // foreach (var item in products)
                // {
                //     Console.WriteLine(item.ProductName + " - " +item.ListPrice );
                // }
                ///////////////////////////////////////////
                // "Beverages" kategorisindeki ürünlerin ortalama fiyatı nedir?

                // var ortalama = db.Products
                //     .Where(i=>i.Category=="Beverages")
                //     .Average(i=>i.ListPrice);

                // Console.WriteLine("ortalama: {0}", ortalama);
                /////////////////////////////////////////
                // "Beverages" kategorisinde kaç ürün vardır?

                var adet = db.Products.Count(i=>i.Category=="Beverages");
                Console.WriteLine("adet: {0}", adet);
                ///////////////////////////////////////////

            }
        }
    }
}
