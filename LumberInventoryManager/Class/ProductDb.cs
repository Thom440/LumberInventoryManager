﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    /// <summary>
    /// The Product Database.
    /// </summary>
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

        /// <summary>
        /// Selects all products from the product table.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProducts()
        {
            using(LumberContext context = new LumberContext())
            {
                List<Product> allProducts =
                    (from p in context.Products
                     orderby p.Height, p.Width, p.Length
                     select p).Include(nameof(Product.Category)).ToList();

                return allProducts;
            }
        }

        /// <summary>
        /// Updates an individual unit of lumber.
        /// </summary>
        /// <param name="p">The product.</param>
        public static Product Update(Product p)
        {
            using (LumberContext context = new LumberContext())
            {
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
                return p;
            }
        }

        /// <summary>
        /// Deletes a unit of lumber.
        /// </summary>
        /// <param name="id">id of the product.</param>
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

        /// <summary>
        /// Grabs all products that are <= to the current product. 
        /// </summary>
        /// <param name="height">Height of the board</param>
        /// <param name="width">Width of the board</param>
        /// <param name="length">Length of the board</param>
        public static List<Product> GetProductsInRange(int id, int height, int width, int length)
        {
            using (LumberContext context = new LumberContext())
            {
                List<Product> allProducts =
                    (from p in context.Products
                     where p.Height <= height && p.Width <= width && p.Length <= length && p.ProductID != id
                     orderby p.Height, p.Width, p.Length
                     select p).ToList();
                return allProducts;
            }
        }

        public static List<Category> GetCategory(int id)
        {
            using (LumberContext context = new LumberContext())
            {
                List<Category> category =
                    (from c in context.Categories
                     where c.CategoryID == id
                     select c).ToList();

                return category;
            }
        }
    }
}
