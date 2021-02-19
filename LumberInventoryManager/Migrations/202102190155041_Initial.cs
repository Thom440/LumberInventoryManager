namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Height = c.Byte(nullable: false),
                        Width = c.Byte(nullable: false),
                        Length = c.Byte(nullable: false),
                        OnHand = c.Short(nullable: false),
                        Sold = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.InvoiceLineItems",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceID, t.ProductID })
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ShipDate = c.DateTime(storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Business = c.String(),
                        ContactFirstName = c.String(nullable: false),
                        ContactLastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_ProductID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductID, t.Category_CategoryID })
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID, cascadeDelete: true)
                .Index(t => t.Product_ProductID)
                .Index(t => t.Category_CategoryID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLineItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceLineItems", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.CustomerInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.CustomerInvoices", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ProductCategories", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.CustomerInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.CustomerInvoices", new[] { "Customer_CustomerID" });
            DropIndex("dbo.ProductCategories", new[] { "Category_CategoryID" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductID" });
            DropIndex("dbo.InvoiceLineItems", new[] { "ProductID" });
            DropIndex("dbo.InvoiceLineItems", new[] { "InvoiceID" });
            DropTable("dbo.CustomerInvoices");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Customers");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceLineItems");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
