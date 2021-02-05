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
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
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
                        InvoiceNumber = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ShipDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
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
                        CategoryID_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID_CategoryID)
                .Index(t => t.CategoryID_CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLineItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.InvoiceLineItems", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "CategoryID_CategoryID" });
            DropIndex("dbo.InvoiceLineItems", new[] { "ProductID" });
            DropIndex("dbo.InvoiceLineItems", new[] { "InvoiceID" });
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceLineItems");
            DropTable("dbo.Categories");
        }
    }
}
