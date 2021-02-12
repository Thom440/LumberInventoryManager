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
                if (wwCheckBox.Checked)
                {
                    AddProductToDatabase(product);
                }
                else if ((twoFiveCheckBox.Checked || fourOCheckBox.Checked || sixOCheckBox.Checked) 
                    && (acqCheckBox.Checked || ccaCheckBox.Checked))
                {
                    int treatmentLevel;
                    int treatmentType;
                    if (twoFiveCheckBox.Checked)
                    {
                        treatmentLevel = 2;
                    }
                    else if (fourOCheckBox.Checked)
                    {
                        treatmentLevel = 3;
                    }
                    else
                    {
                        treatmentLevel = 4;
                    }
                    if (acqCheckBox.Checked)
                    {
                        treatmentType = 5;
                    }
                    else
                    {
                        treatmentType = 6;
                    }
                    AddProductToDatabase(product, treatmentLevel, treatmentType);
                }
                else
                {
                    return;
                } 
            }
            else
            {
                MessageBox.Show("All fields must be numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void AddProductToDatabase(Product product)
        {
            try
            {

                //List<Category> category = ProductDb.GetCategory(1);
                product.Category = ProductDb.GetCategory(1);
                ProductDb.Add(product);
                ClearTxtBox();
                messageLbl.Text = $"{ product.Height} x {product.Width} x {product.Length} added successfully";
            }
            catch
            {
                messageLbl.Text = "Failed to add Product";
            }
        }

        private void AddProductToDatabase(Product p, int treatmentLevel, int treatmentType)
        {

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

        private void wwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (wwCheckBox.Checked)
            {
                twoFiveCheckBox.Enabled = false;
                fourOCheckBox.Enabled = false;
                sixOCheckBox.Enabled = false;
                ccaCheckBox.Enabled = false;
                acqCheckBox.Enabled = false;
            }
            else
            {
                twoFiveCheckBox.Enabled = true;
                fourOCheckBox.Enabled = true;
                sixOCheckBox.Enabled = true;
                ccaCheckBox.Enabled = true;
                acqCheckBox.Enabled = true;
            }
        }

        private void twoFiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (twoFiveCheckBox.Checked)
            {
                wwCheckBox.Enabled = false;
                fourOCheckBox.Checked = false;
                sixOCheckBox.Checked = false;
            }
            else
            {
                CheckIfAllCheckBoxesUnchecked();
            }
        }

        private void fourOCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fourOCheckBox.Checked)
            {
                wwCheckBox.Enabled = false;
                twoFiveCheckBox.Checked = false;
                sixOCheckBox.Checked = false;
            }
            else
            {
                CheckIfAllCheckBoxesUnchecked();
            }
        }

        private void sixOCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sixOCheckBox.Checked)
            {
                wwCheckBox.Enabled = false;
                twoFiveCheckBox.Checked = false;
                fourOCheckBox.Checked = false;
            }
            else
            {
                CheckIfAllCheckBoxesUnchecked();
            }
        }

        private void acqCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (acqCheckBox.Checked)
            {
                wwCheckBox.Enabled = false;
                ccaCheckBox.Checked = false;
            }
            else
            {
                CheckIfAllCheckBoxesUnchecked();
            }
        }

        private void ccaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ccaCheckBox.Checked)
            {
                wwCheckBox.Enabled = false;
                acqCheckBox.Checked = false;
            }
            else
            {
                CheckIfAllCheckBoxesUnchecked();
            }
        }

        private void CheckIfAllCheckBoxesUnchecked()
        {
            if (!twoFiveCheckBox.Checked && !fourOCheckBox.Checked 
                && !sixOCheckBox.Checked && !acqCheckBox.Checked 
                && !ccaCheckBox.Checked)
            {
                wwCheckBox.Enabled = true;
            }
        }
    }
}
