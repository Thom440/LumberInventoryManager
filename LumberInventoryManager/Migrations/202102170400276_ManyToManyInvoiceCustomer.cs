namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyInvoiceCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Customers", new[] { "Invoice_InvoiceID" });
            CreateTable(
                "dbo.CustomerInvoices",
                c => new
                    {
                        Customer_CustomerID = c.Int(nullable: false),
                        Invoice_InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerID, t.Invoice_InvoiceID })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.Invoice_InvoiceID);
            
            DropColumn("dbo.Customers", "Invoice_InvoiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Invoice_InvoiceID", c => c.Int());
            DropForeignKey("dbo.CustomerInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.CustomerInvoices", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.CustomerInvoices", new[] { "Customer_CustomerID" });
            DropTable("dbo.CustomerInvoices");
            CreateIndex("dbo.Customers", "Invoice_InvoiceID");
            AddForeignKey("dbo.Customers", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
        }
    }
}
