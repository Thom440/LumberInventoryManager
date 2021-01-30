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
    public partial class UpdateInventoryForm : Form
    {
        public UpdateInventoryForm()
        {
            InitializeComponent();
        }

        private void UpdateInventoryForm_Load(object sender, EventArgs e)
        {
            List<Product> products = ProductDb.GetAllProducts();
            productListBox.DataSource = products;
            productListBox.DisplayMember = nameof(Product.ToString);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (Validator.IsShort(unitTxtBox.Text))
            {
                Product product = (Product)productListBox.SelectedItem;
                short units = Convert.ToInt16(unitTxtBox.Text);
                product.OnHand += units;
                ProductDb.Update(product);
                Close();
            }
            else
            {
                MessageBox.Show("Must put in a valid number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
