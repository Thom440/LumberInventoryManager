namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID_CategoryID" });
            AddColumn("dbo.Categories", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.Categories", "Product_ProductID");
            AddForeignKey("dbo.Categories", "Product_ProductID", "dbo.Products", "ProductID");
            DropColumn("dbo.Products", "CategoryID_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryID_CategoryID", c => c.Int());
            DropForeignKey("dbo.Categories", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Categories", new[] { "Product_ProductID" });
            DropColumn("dbo.Categories", "Product_ProductID");
            CreateIndex("dbo.Products", "CategoryID_CategoryID");
            AddForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
