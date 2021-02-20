using System;
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
                    //invoiceLineItems.Product = product;
                    //invoiceLineItems.Invoice = invoice;

                    try
                    {
                        ProductDb.AddInvoiceLineItem(invoiceLineItems, invoice, product);
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductShippedBtn_Click(object sender, EventArgs e)
        {
            Invoice invoice = (Invoice)invoiceCmbBox.SelectedItem;
            if (invoice != null)
            {
                invoice.ShipDate = DateTime.Now;
                ProductDb.Update(invoice);
            }
        }
    }
}
