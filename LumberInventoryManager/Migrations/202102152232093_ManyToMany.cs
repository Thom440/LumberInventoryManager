namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID_CategoryID" });
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
            
            DropColumn("dbo.Products", "CategoryID_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryID_CategoryID", c => c.Int());
            DropForeignKey("dbo.ProductCategories", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_CategoryID" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductID" });
            DropTable("dbo.ProductCategories");
            CreateIndex("dbo.Products", "CategoryID_CategoryID");
            AddForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
