using System;
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
                for (int i = 0; i < p.Category.Count; i++)
                {
                    context.Categories.Attach(p.Category[i]);
                }
                context.SaveChanges();
                return p;
            }
        }

        public static Invoice Add(Invoice i)
        {
            using(LumberContext context = new LumberContext())
            {
                context.Invoices.Add(i);
                context.Customers.Attach(i.Customers[0]);
                context.SaveChanges();
                return i;
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
                     select p).Include(nameof(Product.Category)).ToList();

                allProducts = allProducts.OrderBy(p => p.Height)
                    .ThenBy(p => p.Width)
                    .ThenBy(p => p.Length)
                    .ThenBy(p => p.Category[0].CategoryName).ToList();

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
      
        /// <summary>
        /// Grabs a single category
        /// </summary>
        /// <param name="id">The Id for the category</param>
        /// <returns></returns>
        public static Category GetCategory(int id)
        {
            using (LumberContext context = new LumberContext())
            {
                Category category =
                    (from c in context.Categories
                     where c.CategoryID == id
                     select c).Single();

                return category;
            }
        }

        public static Customer AddCustomer(Customer c)
        {
            using (LumberContext context = new LumberContext())
            {
                context.Customers.Add(c);
                context.SaveChanges();
                return c;
            }
        }

        public static List<Customer> GetAllCustomers()
        {
            using(LumberContext context = new LumberContext())
            {
                List< Customer> customers = (from c in context.Customers
                                     select c).ToList();
                return customers;
            }
        }

        public static Customer GetCustomer(int id)
        {
            using(LumberContext context = new LumberContext())
            {
                Customer customer = (from c in context.Customers
                                     where c.CustomerID == id
                                     select c).Single();
                return customer;
            }
        }

        public static List<Invoice> GetAllInvoices()
        {
            using(LumberContext context = new LumberContext())
            {
                List<Invoice> invoices = (from i in context.Invoices
                                          select i).ToList();
                return invoices;
            }
        }

        public static void AddInvoiceLineItem(InvoiceLineItems invoiceLineItems, Invoice invoice, Product product)
        {
            using(LumberContext context = new LumberContext())
            {
                context.InvoiceLineItems.Add(invoiceLineItems);
                //context.Products.Attach(invoiceLineItems.Product);
                //context.Invoices.Attach(invoiceLineItems.Invoice);
                context.SaveChanges();
            }
        }

        public static bool CheckForExistingProduct(Product p)
        {
            using(LumberContext context = new LumberContext())
            {
                List<Product> product = (from prod in context.Products
                               where prod.Height == p.Height && prod.Width == p.Width
                               && prod.Length == p.Length
                               select prod).Include(c => c.Category).ToList();
                for (int i = 0; i < product.Count; i++)
                {
                    for (int j = 0; j < p.Category.Count && product[i].Category.Count == p.Category.Count; j++)
                    {
                        if (product[i].Category[j].CategoryID == p.Category[j].CategoryID)
                        {
                            return true;
                        }
                    }   
                }
                return false;
            }
        }
    }
}
