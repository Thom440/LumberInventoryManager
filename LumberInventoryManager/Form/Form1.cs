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
        public Form1()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            DialogResult result = addProduct.ShowDialog();
            UpdateList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Product> products = ProductDb.GetAllProducts();
            IEnumerable<Product> distinctProducts = products.Distinct<Product>();
            productListBox.DataSource = distinctProducts.ToList();

            List<Invoice> invoices = ProductDb.GetAllInvoices();
            invoiceListBox.DataSource = invoices.ToList();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateInventoryForm updateInventory = new UpdateInventoryForm();
            DialogResult result = updateInventory.ShowDialog();
            UpdateList();
        }

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

        private void UpdateList()
        {
            productListBox.DataSource = null;
            productListBox.Items.Clear();
            List<Product> products = ProductDb.GetAllProducts();
            IEnumerable<Product> distinctProducts = products.Distinct<Product>();
            productListBox.DataSource = distinctProducts.ToList();
            productListBox.DisplayMember = nameof(Product);
        }

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

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
        }

        private void CreateInvoiceBtn_Click(object sender, EventArgs e)
        {
            CreateInvoiceForm createInvoice = new CreateInvoiceForm();
            createInvoice.ShowDialog();
        }

        private void UpdateInvoiceBtn_Click(object sender, EventArgs e)
        {
            UpdateInvoiceForm updateInvoiceForm = new UpdateInvoiceForm();
            updateInvoiceForm.ShowDialog();
            UpdateList();
        }

        private void ViewInvoiceBtn_Click(object sender, EventArgs e)
        {
            Invoice invoice = (Invoice)invoiceListBox.SelectedItem;
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

            // Formats the columns to be bold
            worksheet.Cells[1, 1].EntireColumn.Font.Bold = true;
            worksheet.Cells[1, 2].EntireColumn.Font.Bold = true;
            worksheet.Cells[1, 3].EntireColumn.Font.Bold = true;

            // Fills in the cells with the invoice number and customer information
            worksheet.Cells[1, 1] = "Invoice number: " + invoice.InvoiceID;
            worksheet.Cells[3, 1] = customer.Business;
            worksheet.Cells[4, 1] = customer.ContactFirstName + " " + customer.ContactLastName;
            worksheet.Cells[5, 1] = customer.Address;
            worksheet.Cells[6, 1] = customer.City + ", " + customer.State + " " + customer.ZipCode;

            worksheet.Cells[7, 2] = "Product";
            worksheet.Cells[7, 3] = "Quanity";

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
            worksheet.Cells[count + 1, column + 1] = invoice.ShipDate;

            // Adjusts all the cells size to fit the text
            worksheet.Columns.AutoFit();
        }
    }
}
