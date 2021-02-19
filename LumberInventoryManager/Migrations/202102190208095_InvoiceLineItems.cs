namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceLineItems : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InvoiceCustomers", newName: "CustomerInvoices");
            DropPrimaryKey("dbo.CustomerInvoices");
            AddPrimaryKey("dbo.CustomerInvoices", new[] { "Customer_CustomerID", "Invoice_InvoiceID" });
            CreateIndex("dbo.InvoiceLineItems", "InvoiceID");
            CreateIndex("dbo.InvoiceLineItems", "ProductID");
            AddForeignKey("dbo.InvoiceLineItems", "InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceLineItems", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLineItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceLineItems", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.InvoiceLineItems", new[] { "ProductID" });
            DropIndex("dbo.InvoiceLineItems", new[] { "InvoiceID" });
            DropPrimaryKey("dbo.CustomerInvoices");
            AddPrimaryKey("dbo.CustomerInvoices", new[] { "Invoice_InvoiceID", "Customer_CustomerID" });
            RenameTable(name: "dbo.CustomerInvoices", newName: "InvoiceCustomers");
        }
    }
}
