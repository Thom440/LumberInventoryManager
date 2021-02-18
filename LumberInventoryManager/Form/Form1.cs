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
    }
}
