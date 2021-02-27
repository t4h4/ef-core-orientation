using Microsoft.EntityFrameworkCore;

namespace ef_core_st.Data.EfCore
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public int OrderCount { get; set; }
    }
    public class CustomNorthwindContext : NorthwindContext
    {
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public CustomNorthwindContext()
        {

        }

        public CustomNorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //base demek ilk başta miras alınan sınıfın fonksiyonu çalışsın demek.

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.CustomerId).HasColumnName("id");
                entity.Property(e => e.OrderCount).HasColumnName("count");
            });

        }
    }
}