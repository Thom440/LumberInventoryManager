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
    public partial class CreateInvoiceForm : Form
    {
        /// <summary>
        /// Form that creates a new Invoice.
        /// </summary>
        public CreateInvoiceForm()
        {
            InitializeComponent();
        }

        private void CreateInvoiceForm_Load(object sender, EventArgs e)
        {
            List<Customer> customers = ProductDb.GetAllCustomers();
            customerComboBox1.DataSource = customers.ToList();
        }

        /// <summary>
        /// Button to create an Invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInvoiceBtn_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)customerComboBox1.SelectedItem;
            if (customer != null)
            {
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
            else
            {
                MessageBox.Show("No customer selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        /// <summary>
        /// Closes Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
