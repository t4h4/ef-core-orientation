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
    public class CustomerDemo
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int OrderCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //Taşıyıcı class kullanarak sipariş sayısı 0'dan büyük müşterileri getirme. + order sayısına göre artan olarak
                var customers = db.Customers
                    .Where(i => i.Orders.Count() > 0)
                    .Select(i => new CustomerDemo
                    {
                        CustomerId = i.Id,
                        Name = i.FirstName,
                        OrderCount = i.Orders.Count()
                    })
                    .OrderBy(i => i.OrderCount)
                    .ToList();

                foreach (var item in customers)
                {
                    Console.WriteLine($"id: {item.CustomerId} name: {item.Name} count: {item.OrderCount}");
                }
            }
        }
    }
}
