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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (Validator.IsByte(heightTxtBox.Text) && Validator.IsByte(widthTxtBox.Text) && 
                Validator.IsByte(lengthTxtBox.Text))
            {
                Product product = new Product()
                {
                    Height = Convert.ToByte(heightTxtBox.Text),
                    Width = Convert.ToByte(widthTxtBox.Text),
                    Length = Convert.ToByte(lengthTxtBox.Text)
                };

                ProductDb.Add(product);
                ClearTxtBox();
            }
            else
            {
                MessageBox.Show("All fields must be numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void ClearTxtBox()
        {
            heightTxtBox.Text = "";
            widthTxtBox.Text = "";
            lengthTxtBox.Text = "";
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
