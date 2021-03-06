﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LumberInventoryManager
{
    public partial class UpdateInvoiceForm : Form
    {
        /// <summary>
        /// Adds products to an invoice.
        /// </summary>
        public UpdateInvoiceForm()
        {
            InitializeComponent();
        }

        private void UpdateInvoiceForm_Load(object sender, EventArgs e)
        {
            List<Invoice> invoices = ProductDb.GetAllInvoices();
            invoiceCmbBox.DataSource = invoices.ToList();

            List<Product> products = ProductDb.GetAllProducts();
            productCmbBox.DataSource = products.ToList();


        }

        /// <summary>
        /// Adds a product to an invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            Invoice invoice = (Invoice)invoiceCmbBox.SelectedItem;
            if (invoice != null)
            {
                Product product = (Product)productCmbBox.SelectedItem;
                if (product == null)
                {
                    MessageBox.Show("No product selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                InvoiceLineItems invoiceLineItems = new InvoiceLineItems();
                invoiceLineItems.ProductID = product.ProductID;
                invoiceLineItems.InvoiceID = invoice.InvoiceID;

                if (Validator.IsShort(quantityTxtBox.Text))
                {
                    short quantity = Convert.ToInt16(quantityTxtBox.Text);
                    invoiceLineItems.Quantity = quantity;

                    try
                    {
                        ProductDb.AddInvoiceLineItem(invoiceLineItems);
                        product.Sold += quantity;
                        ProductDb.Update(product);
                        quantityTxtBox.Text = String.Empty;
                        messageLbl.Text = "Product added successfully";
                    }
                    catch (SqlException)
                    {

                        messageLbl.Text = "Failed to add product";
                    }
                }
            }
            else
            {
                MessageBox.Show("No invoice is selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Closes form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sets a ship date and adjusts in stock quantity and sold quantities.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductShippedBtn_Click(object sender, EventArgs e)
        {
            Invoice invoice = (Invoice)invoiceCmbBox.SelectedItem;
            if (invoice != null)
            {
                invoice.ShipDate = DateTime.Now;
                ProductDb.Update(invoice);

                List<Product> products = ProductDb.GetInvoiceProducts(invoice.InvoiceID);
                List<InvoiceLineItems> lineItems = ProductDb.GetInvoiceQuantities(invoice.InvoiceID);

                for (int i = 0; i < products.Count; i++)
                {
                    products[i].OnHand -= lineItems[i].Quantity;
                    products[i].Sold -= lineItems[i].Quantity;
                    ProductDb.Update(products[i]);
                }
                messageLbl.Text = $"Ship Date set to {DateTime.Now}";
            }
            else
            {
                MessageBox.Show("No invoice selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
