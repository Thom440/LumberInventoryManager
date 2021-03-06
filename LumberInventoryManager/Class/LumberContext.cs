using System;
using System.Data.Entity;
using System.Linq;

namespace LumberInventoryManager
{
    public class LumberContext : DbContext
    {
        // Your context has been configured to use a 'LumberContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LumberInventoryManager.LumberContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LumberContext' 
        // connection string in the application configuration file.
        public LumberContext()
            : base("name=LumberContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceLineItems>().HasKey(InvoiceLineItems => new { InvoiceLineItems.InvoiceID, InvoiceLineItems.ProductID });
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLineItems> InvoiceLineItems { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    } 
}