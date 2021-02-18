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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(firstNameTxtBox) && Validator.IsPresent(lastNameTxtBox)
                && Validator.IsPresent(addressTxtBox) && Validator.IsPresent(cityTxtBox)
                && Validator.IsPresent(stateTxtBox) && Validator.IsInt(zipCodeTxtBox.Text))
            {
                Customer customer = new Customer()
                {
                    Business = businessTxtBox.Text,
                    ContactFirstName = firstNameTxtBox.Text,
                    ContactLastName = lastNameTxtBox.Text,
                    Address = addressTxtBox.Text,
                    City = cityTxtBox.Text,
                    State = stateTxtBox.Text,
                    ZipCode = Convert.ToInt32(zipCodeTxtBox.Text)
                };
                try
                {
                    ProductDb.AddCustomer(customer);
                    messageLbl.Text = $"{customer.ContactFirstName} {customer.ContactLastName} was added successfully.";
                }
                catch (SqlException)
                {
                    messageLbl.Text = "Failed to add customer.";
                }
            }
            else
            {
                MessageBox.Show("All fields are required except business.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
