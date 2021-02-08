namespace LumberInventoryManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LumberInventoryManager.LumberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LumberInventoryManager.LumberContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(x => x.CategoryID,
                new Category() { CategoryID = 1, CategoryName = "WW" },
                new Category() { CategoryID = 2, CategoryName = "ACQ" },
                new Category() { CategoryID = 3, CategoryName = "CCA" },
                new Category() { CategoryID = 4, CategoryName = ".25" },
                new Category() { CategoryID = 5, CategoryName = ".40" },
                new Category() { CategoryID = 6, CategoryName = ".60" }
                );
        }
    }
}
