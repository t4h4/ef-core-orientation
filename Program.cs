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
                //Anonymous type kullanarak sipariş sayısı 0'dan büyük müşterileri getirme. 
                var customers = db.Customers
                    .Where(i => i.Orders.Count() > 0)
                    .Select(i => new { i.FirstName })
                    .ToList();

                foreach (var item in customers)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
    }
}
