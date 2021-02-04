namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTable : DbMigration
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
            
            AddColumn("dbo.Products", "CategoryID_CategoryID", c => c.Int());
            CreateIndex("dbo.Products", "CategoryID_CategoryID");
            AddForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID_CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID_CategoryID" });
            DropColumn("dbo.Products", "CategoryID_CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
