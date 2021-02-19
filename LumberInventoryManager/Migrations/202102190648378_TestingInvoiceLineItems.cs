namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingInvoiceLineItems : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InvoiceCustomers", newName: "CustomerInvoices");
            DropPrimaryKey("dbo.CustomerInvoices");
            AddPrimaryKey("dbo.CustomerInvoices", new[] { "Customer_CustomerID", "Invoice_InvoiceID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustomerInvoices");
            AddPrimaryKey("dbo.CustomerInvoices", new[] { "Invoice_InvoiceID", "Customer_CustomerID" });
            RenameTable(name: "dbo.CustomerInvoices", newName: "InvoiceCustomers");
        }
    }
}
