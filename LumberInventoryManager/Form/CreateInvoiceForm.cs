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
    public partial class CreateInvoiceForm : Form
    {
        public CreateInvoiceForm()
        {
            InitializeComponent();
        }

        private void CreateInvoiceForm_Load(object sender, EventArgs e)
        {
            List<Customer> customers = ProductDb.GetAllCustomers();
            customerComboBox1.DataSource = customers.ToList();
        }

        private void CreateInvoiceBtn_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)customerComboBox1.SelectedItem;
            Invoice invoice = new Invoice();
            invoice.Customers.Add(customer);
            try
            {
                ProductDb.Add(invoice);
                messageLbl.Text = "Invoice Created";
            }
            catch (SqlException)
            {
                messageLbl.Text = "Failed to create invoice";
            }
            
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
