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
                for (int i = 0; i < p.Category.Count; i++)
                {
                    context.Categories.Attach(p.Category[i]);
                }
                context.SaveChanges();
                return p;
            }
        }

        /// <summary>
        /// Adds an invoice to the database.
        /// </summary>
        /// <param name="i">The invoice to be added.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds customer to database.
        /// </summary>
        /// <param name="c">The customer to be added.</param>
        /// <returns></returns>
        public static Customer AddCustomer(Customer c)
        {
            using (LumberContext context = new LumberContext())
            {
                context.Customers.Add(c);
                context.SaveChanges();
                return c;
            }
        }

        /// <summary>
        /// Grabs all customers from database.
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetAllCustomers()
        {
            using(LumberContext context = new LumberContext())
            {
                List< Customer> customers = (from c in context.Customers
                                     select c).ToList();
                return customers;
            }
        }

        /// <summary>
        /// Grabs a single customer from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all the Invoices.
        /// </summary>
        /// <returns></returns>
        public static List<Invoice> GetAllInvoices()
        {
            using(LumberContext context = new LumberContext())
            {
                List<Invoice> invoices = (from i in context.Invoices
                                          select i).Include(c => c.Customers).ToList();
                return invoices;
            }
        }

        /// <summary>
        /// Adds an invoice line item to the database.
        /// </summary>
        /// <param name="invoiceLineItems">Invoice line item to be added.</param>
        public static void AddInvoiceLineItem(InvoiceLineItems invoiceLineItems)
        {
            using(LumberContext context = new LumberContext())
            {
                context.InvoiceLineItems.Add(invoiceLineItems);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks to see if product already exists in database.
        /// </summary>
        /// <param name="p">The product to be checked.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Grabs the product from an invoice.
        /// </summary>
        /// <param name="id">The product to show.</param>
        /// <returns></returns>
        public static List<Product> GetInvoiceProducts(int id)
        {
            using(LumberContext context = new LumberContext())
            {
                List<Product> products = (from p in context.Products
                                          join i in context.InvoiceLineItems on p.ProductID equals i.ProductID
                                          where i.InvoiceID == id
                                          select p).Include(c => c.Category).ToList();
                return products;
            }
        }

        /// <summary>
        /// Gets all of the invoice line items.
        /// </summary>
        /// <param name="id">invoice line items to show.</param>
        /// <returns></returns>
        public static List<InvoiceLineItems> GetInvoiceQuantities(int id)
        {
            using(LumberContext context = new LumberContext())
            {
                List<InvoiceLineItems> invoiceLineItems = (from i in context.InvoiceLineItems
                                                           where i.InvoiceID == id
                                                           select i).ToList();
                return invoiceLineItems;
            }
        }

        /// <summary>
        /// Updates the invoice.
        /// </summary>
        /// <param name="i">Invoice to be updated.</param>
        public static void Update(Invoice i)
        {
            using (LumberContext context = new LumberContext())
            {
                context.Entry(i).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
