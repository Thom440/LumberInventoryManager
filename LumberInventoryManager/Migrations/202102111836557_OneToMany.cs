namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Categories", new[] { "Product_ProductID" });
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
            
            DropColumn("dbo.Categories", "Product_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Product_ProductID", c => c.Int());
            DropForeignKey("dbo.ProductCategories", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_CategoryID" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductID" });
            DropTable("dbo.ProductCategories");
            CreateIndex("dbo.Categories", "Product_ProductID");
            AddForeignKey("dbo.Categories", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
