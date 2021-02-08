using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    static class ProductDb
    {
        /// <summary>
        /// This method adds the product to the database.
        /// </summary>
        /// <param name="p">The product to be added.</param>
        /// <returns></returns>
        public static Product Add(Product p)
        {
            using (LumberContext context = new LumberContext())
            {
                context.Products.Add(p);
                context.SaveChanges();
                return p;
            }
        }

        public static List<Product> GetAllProducts()
        {
            using(LumberContext context = new LumberContext())
            {
                List<Product> allProducts =
                    (from p in context.Products
                     orderby p.Height, p.Width, p.Length
                     select p).ToList();

                return allProducts;
            }
        }

        public static Product Update(Product p)
        {
            using (LumberContext context = new LumberContext())
            {
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
                return p;
            }
        }

        public static void Delete(int id)
        {
            using (LumberContext context = new LumberContext())
            {
                Product prodToDelete =
                    (from p in context.Products
                     where p.ProductID == id
                     select p).Single();

                context.Entry(prodToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static List<Product> GetProductsInRange(int height, int width, int length)
        {
            using (LumberContext context = new LumberContext())
            {
                List<Product> allProducts =
                    (from p in context.Products
                     where p.Height <= height && p.Width <= width && p.Length <= length
                     orderby p.Height, p.Width, p.Length
                     select p).ToList();
                return allProducts;
            }
        }
    }
}
