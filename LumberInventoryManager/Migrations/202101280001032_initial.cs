namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
