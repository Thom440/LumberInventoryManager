using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LumberInventoryManager
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Main Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Launches the Add Product form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            UpdateList();
        }

        /// <summary>
        /// Loads main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Product> products = ProductDb.GetAllProducts();
            IEnumerable<Product> distinctProducts = products.Distinct<Product>();
            productListBox.DataSource = distinctProducts.ToList();

            List<Invoice> invoices = ProductDb.GetAllInvoices();
            invoiceListBox.DataSource = invoices.ToList();
        }

        /// <summary>
        /// Launches Update Inventory Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateInventoryForm updateInventory = new UpdateInventoryForm();
            updateInventory.ShowDialog();
            UpdateList();
        }

        /// <summary>
        /// Deletes Product from Database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {   
            Product product = (Product)productListBox.SelectedItem;
            if (product != null)
            {
                ProductDb.Delete(product.ProductID);
                UpdateList();
            }
            else
            {
                MessageBox.Show("There are no products to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the product list.
        /// </summary>
        private void UpdateList()
        {
            productListBox.DataSource = null;
            productListBox.Items.Clear();
            List<Product> products = ProductDb.GetAllProducts();
            IEnumerable<Product> distinctProducts = products.Distinct<Product>();
            productListBox.DataSource = distinctProducts.ToList();
        }

        /// <summary>
        /// Launches the Consume Product form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsumeBtn_Click(object sender, EventArgs e)
        {
            List<Product> product = ProductDb.GetAllProducts();
            if (product.Any())
            {
                ConsumeUnitsForm consumeUnits = new ConsumeUnitsForm();
                consumeUnits.ShowDialog();
                UpdateList();
            }
            else
            {
                MessageBox.Show("There are no products in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Launches the Add Customer Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
        }

        /// <summary>
        /// Launches the Create Invoice form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInvoiceBtn_Click(object sender, EventArgs e)
        {
            CreateInvoiceForm createInvoice = new CreateInvoiceForm();
            createInvoice.ShowDialog();
            UpdateInvoiceList();
        }

        /// <summary>
        /// Updates the invoice list.
        /// </summary>
        private void UpdateInvoiceList()
        {
            invoiceListBox.DataSource = null;
            List<Invoice> invoices = ProductDb.GetAllInvoices();
            invoiceListBox.DataSource = invoices.ToList();
        }

        /// <summary>
        /// Launches the Update Invoice form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInvoiceBtn_Click(object sender, EventArgs e)
        {
            UpdateInvoiceForm updateInvoiceForm = new UpdateInvoiceForm();
            updateInvoiceForm.ShowDialog();
            UpdateList();
            UpdateInvoiceList();
        }

        /// <summary>
        /// Opens Microsoft Excel to view spreadsheet of the invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewInvoiceBtn_Click(object sender, EventArgs e)
        {
            Invoice invoice = (Invoice)invoiceListBox.SelectedItem;
            if (invoice != null)
            {
                Customer customer = ProductDb.GetCustomer(invoice.Customers[0].CustomerID);
                List<Product> products = ProductDb.GetInvoiceProducts(invoice.InvoiceID);
                List<InvoiceLineItems> lineItems = ProductDb.GetInvoiceQuantities(invoice.InvoiceID);

                // Setting up the excel spreadsheet
                object Nothing = System.Reflection.Missing.Value;
                var app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                Workbook workbook = app.Workbooks.Add(Nothing);
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];
                worksheet.Name = "Worksheet";

                // Formats the columns to be bold and font to 20
                worksheet.Cells[1, 1].EntireColumn.Font.Bold = true;
                worksheet.Cells[1, 1].EntireColumn.Font.Size = 20;
                worksheet.Cells[1, 2].EntireColumn.Font.Bold = true;
                worksheet.Cells[1, 2].EntireColumn.Font.Size = 20;
                worksheet.Cells[1, 3].EntireColumn.Font.Bold = true;
                worksheet.Cells[1, 3].EntireColumn.Font.Size = 20;

                // Fills in the cells with the invoice number and customer information
                worksheet.Cells[1, 1] = "Invoice number: " + invoice.InvoiceID;
                worksheet.Cells[3, 1] = customer.Business;
                worksheet.Cells[4, 1] = customer.ContactFirstName + " " + customer.ContactLastName;
                worksheet.Cells[5, 1] = customer.Address;
                worksheet.Cells[6, 1] = customer.City + ", " + customer.State + " " + customer.ZipCode;

                worksheet.Cells[7, 2] = "Product";
                worksheet.Cells[7, 3] = "Quantity";

                // Goes through a loop and fills in product information
                int count = 8;
                int column = 2;
                for (int i = 0; i < products.Count; i++)
                {
                    worksheet.Cells[count, column] = products[i].InvoiceDisplayString();
                    worksheet.Cells[count, column + 1] = lineItems[i].Quantity;
                    count++;
                }
                count++;

                worksheet.Cells[count, column] = "Date Shipped:";
                worksheet.Cells[count + 1, column] = invoice.ShipDate;

                // Adjusts all the cells size to fit the text
                worksheet.Columns.AutoFit();
            }
            else
            {
                MessageBox.Show("There are no invoices to display", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
