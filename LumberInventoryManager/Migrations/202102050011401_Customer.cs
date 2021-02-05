namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
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
                        ZipCode = c.Short(nullable: false),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .Index(t => t.Invoice_InvoiceID);
            
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Invoices", "ShipDate", c => c.DateTime(storeType: "smalldatetime"));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Customers", new[] { "Invoice_InvoiceID" });
            AlterColumn("dbo.Invoices", "ShipDate", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            DropTable("dbo.Customers");
        }
    }
}
