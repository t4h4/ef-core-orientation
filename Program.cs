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
        public CustomerDemo()
        {
            Orders = new List<OrderDemo>();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public List<OrderDemo> Orders { get; set; }
    }

    public class OrderDemo
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                // Müşterinin sipariş sayıyısını ekrana getirme + her siparişin ayrı ayrı toplam fiyatını getirme
                var customers = db.Customers
                    .Where(i => i.Orders.Any())
                    .Select(i => new CustomerDemo
                    {
                        CustomerId = i.Id,
                        Name = i.FirstName,
                        OrderCount = i.Orders.Count(),
                        Orders = i.Orders.Select(a => new OrderDemo
                        {
                            OrderId = a.Id,
                            Total = (decimal)a.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)
                        }).ToList()
                    })
                    .OrderBy(i => i.OrderCount)
                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"id: {customer.CustomerId} name: {customer.Name} count: {customer.OrderCount}");
                    foreach (var order in customer.Orders)
                    {
                        Console.WriteLine($"order id: {order.OrderId} total: {order.Total}");
                    }
                }
            }
        }
    }
}
