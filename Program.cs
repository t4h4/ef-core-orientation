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
                // miami'de yaşan customer bilgileri gelir.
                var customers = db.Customers
                    .FromSqlRaw("select * from customers where city='Miami'").ToList();

                foreach (var item in customers)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
    }
}
