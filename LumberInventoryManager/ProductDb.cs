using System;
using System.Collections.Generic;
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
    }
}
