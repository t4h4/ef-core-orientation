using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ef_core_st.Data.EfCore
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePrivilege> EmployeePrivileges { get; set; }
        public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual DbSet<InventoryTransactionType> InventoryTransactionTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailsStatus> OrderDetailsStatuses { get; set; }
        public virtual DbSet<OrdersStatus> OrdersStatuses { get; set; }
        public virtual DbSet<OrdersTaxStatus> OrdersTaxStatuses { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderStatus> PurchaseOrderStatuses { get; set; }
        public virtual DbSet<SalesReport> SalesReports { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<String> Strings { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=northwind;user=root", x => x.ServerVersion("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.City, "city");

                entity.HasIndex(e => e.Company, "company");

                entity.HasIndex(e => e.FirstName, "first_name");

                entity.HasIndex(e => e.LastName, "last_name");

                entity.HasIndex(e => e.StateProvince, "state_province");

                entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("longtext")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("business_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("company")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("country_region")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("fax_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("home_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("job_title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("mobile_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("state_province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnType("longtext")
                    .HasColumnName("web_page")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("zip_postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.City, "city");

                entity.HasIndex(e => e.Company, "company");

                entity.HasIndex(e => e.FirstName, "first_name");

                entity.HasIndex(e => e.LastName, "last_name");

                entity.HasIndex(e => e.StateProvince, "state_province");

                entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("longtext")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("business_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("company")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("country_region")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("fax_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("home_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("job_title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("mobile_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("state_province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnType("longtext")
                    .HasColumnName("web_page")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("zip_postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<EmployeePrivilege>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.PrivilegeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("employee_privileges");

                entity.HasIndex(e => e.EmployeeId, "employee_id");

                entity.HasIndex(e => e.PrivilegeId, "privilege_id");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.PrivilegeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("privilege_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePrivileges)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_privileges_employees1");

                entity.HasOne(d => d.Privilege)
                    .WithMany(p => p.EmployeePrivileges)
                    .HasForeignKey(d => d.PrivilegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_privileges_privileges1");
            });

            modelBuilder.Entity<InventoryTransaction>(entity =>
            {
                entity.ToTable("inventory_transactions");

                entity.HasIndex(e => e.CustomerOrderId, "customer_order_id");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id");

                entity.HasIndex(e => e.TransactionType, "transaction_type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Comments)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("comments")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerOrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_order_id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("purchase_order_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.TransactionCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_created_date");

                entity.Property(e => e.TransactionModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_modified_date");

                entity.Property(e => e.TransactionType)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("transaction_type");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("fk_inventory_transactions_orders1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_transactions_products1");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("fk_inventory_transactions_purchase_orders1");

                entity.HasOne(d => d.TransactionTypeNavigation)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.TransactionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_transactions_inventory_transaction_types1");
            });

            modelBuilder.Entity<InventoryTransactionType>(entity =>
            {
                entity.ToTable("inventory_transaction_types");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("type_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoices");

                entity.HasIndex(e => e.OrderId, "fk_invoices_orders1_idx");

                entity.HasIndex(e => e.Id, "id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AmountDue)
                    .HasPrecision(19, 4)
                    .HasColumnName("amount_due")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("due_date");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("invoice_date");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_id");

                entity.Property(e => e.Shipping)
                    .HasPrecision(19, 4)
                    .HasColumnName("shipping")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Tax)
                    .HasPrecision(19, 4)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_invoices_orders1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.EmployeeId, "employee_id");

                entity.HasIndex(e => e.StatusId, "fk_orders_orders_status1");

                entity.HasIndex(e => e.Id, "id");

                entity.HasIndex(e => e.ShipZipPostalCode, "ship_zip_postal_code");

                entity.HasIndex(e => e.ShipperId, "shipper_id");

                entity.HasIndex(e => e.TaxStatusId, "tax_status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paid_date");

                entity.Property(e => e.PaymentType)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("payment_type")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipAddress)
                    .HasColumnType("longtext")
                    .HasColumnName("ship_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipCity)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("ship_city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipCountryRegion)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("ship_country_region")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("ship_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipStateProvince)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("ship_state_province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipZipPostalCode)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("ship_zip_postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shipped_date");

                entity.Property(e => e.ShipperId)
                    .HasColumnType("int(11)")
                    .HasColumnName("shipper_id");

                entity.Property(e => e.ShippingFee)
                    .HasPrecision(19, 4)
                    .HasColumnName("shipping_fee")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.StatusId)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TaxStatusId)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tax_status_id");

                entity.Property(e => e.Taxes)
                    .HasPrecision(19, 4)
                    .HasColumnName("taxes")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_orders_employees1");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("fk_orders_shippers1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_orders_orders_status1");

                entity.HasOne(d => d.TaxStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TaxStatusId)
                    .HasConstraintName("fk_orders_orders_tax_status1");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details");

                entity.HasIndex(e => e.StatusId, "fk_order_details_order_details_status1_idx");

                entity.HasIndex(e => e.OrderId, "fk_order_details_orders1_idx");

                entity.HasIndex(e => e.Id, "id");

                entity.HasIndex(e => e.InventoryId, "inventory_id");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateAllocated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_allocated");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.InventoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_id");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("purchase_order_id");

                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 4)
                    .HasColumnName("quantity");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("status_id");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(19, 4)
                    .HasColumnName("unit_price")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_order_details_products1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_order_details_order_details_status1");
            });

            modelBuilder.Entity<OrderDetailsStatus>(entity =>
            {
                entity.ToTable("order_details_status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("status_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OrdersStatus>(entity =>
            {
                entity.ToTable("orders_status");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("status_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OrdersTaxStatus>(entity =>
            {
                entity.ToTable("orders_tax_status");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TaxStatusName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("tax_status_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.ToTable("privileges");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PrivilegeName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("privilege_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.ProductCode, "product_code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.Category)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("category")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    .HasColumnName("description")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.ListPrice)
                    .HasPrecision(19, 4)
                    .HasColumnName("list_price");

                entity.Property(e => e.MinimumReorderQuantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("minimum_reorder_quantity");

                entity.Property(e => e.ProductCode)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("product_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("product_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuantityPerUnit)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("quantity_per_unit")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("reorder_level");

                entity.Property(e => e.StandardCost)
                    .HasPrecision(19, 4)
                    .HasColumnName("standard_cost")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.SupplierIds)
                    .HasColumnType("longtext")
                    .HasColumnName("supplier_ids")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TargetLevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("target_level");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("purchase_orders");

                entity.HasIndex(e => e.CreatedBy, "created_by");

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.HasIndex(e => e.StatusId, "status_id");

                entity.HasIndex(e => e.SupplierId, "supplier_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("approved_by");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approved_date");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ExpectedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expected_date");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentAmount)
                    .HasPrecision(19, 4)
                    .HasColumnName("payment_amount")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("payment_method")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingFee)
                    .HasPrecision(19, 4)
                    .HasColumnName("shipping_fee");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SubmittedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("submitted_by");

                entity.Property(e => e.SubmittedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("submitted_date");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("int(11)")
                    .HasColumnName("supplier_id");

                entity.Property(e => e.Taxes)
                    .HasPrecision(19, 4)
                    .HasColumnName("taxes");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_purchase_orders_employees1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_purchase_orders_purchase_order_status1");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("fk_purchase_orders_suppliers1");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.ToTable("purchase_order_details");

                entity.HasIndex(e => e.Id, "id");

                entity.HasIndex(e => e.InventoryId, "inventory_id");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateReceived)
                    .HasColumnType("datetime")
                    .HasColumnName("date_received");

                entity.Property(e => e.InventoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_id");

                entity.Property(e => e.PostedToInventory).HasColumnName("posted_to_inventory");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("purchase_order_id");

                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 4)
                    .HasColumnName("quantity");

                entity.Property(e => e.UnitCost)
                    .HasPrecision(19, 4)
                    .HasColumnName("unit_cost");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("fk_purchase_order_details_inventory_transactions1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_purchase_order_details_products1");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_order_details_purchase_orders1");
            });

            modelBuilder.Entity<PurchaseOrderStatus>(entity =>
            {
                entity.ToTable("purchase_order_status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SalesReport>(entity =>
            {
                entity.HasKey(e => e.GroupBy)
                    .HasName("PRIMARY");

                entity.ToTable("sales_reports");

                entity.Property(e => e.GroupBy)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("group_by")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Default).HasColumnName("default");

                entity.Property(e => e.Display)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("display")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FilterRowSource)
                    .HasColumnType("longtext")
                    .HasColumnName("filter_row_source")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("shippers");

                entity.HasIndex(e => e.City, "city");

                entity.HasIndex(e => e.Company, "company");

                entity.HasIndex(e => e.FirstName, "first_name");

                entity.HasIndex(e => e.LastName, "last_name");

                entity.HasIndex(e => e.StateProvince, "state_province");

                entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("longtext")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("business_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("company")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("country_region")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("fax_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("home_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("job_title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("mobile_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("state_province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnType("longtext")
                    .HasColumnName("web_page")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("zip_postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<String>(entity =>
            {
                entity.ToTable("strings");

                entity.Property(e => e.StringId)
                    .HasColumnType("int(11)")
                    .HasColumnName("string_id");

                entity.Property(e => e.StringData)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("string_data")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.HasIndex(e => e.City, "city");

                entity.HasIndex(e => e.Company, "company");

                entity.HasIndex(e => e.FirstName, "first_name");

                entity.HasIndex(e => e.LastName, "last_name");

                entity.HasIndex(e => e.StateProvince, "state_province");

                entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("longtext")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("business_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("company")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("country_region")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("email_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("fax_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("home_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("job_title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("mobile_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("state_province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnType("longtext")
                    .HasColumnName("web_page")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("zip_postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
