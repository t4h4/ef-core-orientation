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

                var customers = db.Customers.Select(c=>new {
                      c.FirstName,
                      c.LastName  
                });

                foreach (var item in customers)
                {
                    Console.WriteLine(item.FirstName +" "+ item.LastName);
                }
                ////////////////////////////////
            }
        }
    }
}
