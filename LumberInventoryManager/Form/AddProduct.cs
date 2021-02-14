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
        private const int WhiteWood = 1;
        private const int TwoFive = 2;
        private const int FourO = 3;
        private const int SixO = 4;
        private const int Acq = 5;
        private const int Cca = 6;
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
                        treatmentLevel = TwoFive;
                    }
                    else if (fourOCheckBox.Checked)
                    {
                        treatmentLevel = FourO;
                    }
                    else
                    {
                        treatmentLevel = SixO;
                    }
                    if (acqCheckBox.Checked)
                    {
                        treatmentType = Acq;
                    }
                    else
                    {
                        treatmentType = Cca;
                    }
                    AddProductToDatabase(product, treatmentLevel, treatmentType);
                }
                else
                {
                    MessageBox.Show("Appropriate boxes must be checked", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                product.Category.Add(ProductDb.GetCategory(WhiteWood));
                ProductDb.Add(product);
                ClearTxtBoxesAndCheckBoxes();
                messageLbl.Text = $"{product.Height} x {product.Width} x {product.Length} added successfully";
            }
            catch
            {
                messageLbl.Text = "Failed to add Product";
            }
        }

        private void AddProductToDatabase(Product p, int treatmentLevel, int treatmentType)
        {
            p.Category.Add(ProductDb.GetCategory(treatmentLevel));
            p.Category.Add(ProductDb.GetCategory(treatmentType));
            ProductDb.Add(p);
            ClearTxtBoxesAndCheckBoxes();
            messageLbl.Text = $"{p.Height} x {p.Width} x {p.Length} added successfully";
        }

        private void ClearTxtBoxesAndCheckBoxes()
        {
            heightTxtBox.Text = "";
            widthTxtBox.Text = "";
            lengthTxtBox.Text = "";
            wwCheckBox.Checked = false;
            twoFiveCheckBox.Checked = false;
            fourOCheckBox.Checked = false;
            sixOCheckBox.Checked = false;
            acqCheckBox.Checked = false;
            ccaCheckBox.Checked = false;
            wwCheckBox.Enabled = true;
            twoFiveCheckBox.Enabled = true;
            fourOCheckBox.Enabled = true;
            sixOCheckBox.Enabled = true;
            acqCheckBox.Enabled = true;
            ccaCheckBox.Enabled = true;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WwCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void TwoFiveCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void FourOCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void SixOCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void AcqCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void CcaCheckBox_CheckedChanged(object sender, EventArgs e)
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
