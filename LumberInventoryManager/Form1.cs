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
            productListBox.DataSource = products;
            productListBox.DisplayMember = nameof(Product.ToString);
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
            ProductDb.Delete(product.ProductID);
            UpdateList();
        }

        private void UpdateList()
        {
            productListBox.DataSource = null;
            productListBox.Items.Clear();
            List<Product> products = ProductDb.GetAllProducts();
            productListBox.DataSource = products;
            productListBox.DisplayMember = nameof(Product.ToString);
        }
    }
}
