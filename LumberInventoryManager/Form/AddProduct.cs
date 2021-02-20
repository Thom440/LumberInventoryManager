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
    /// <summary>
    /// Adds a product to the database.
    /// </summary>
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

        /// <summary>
        /// Button to add a product to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Adds a product with the category White Wood.
        /// </summary>
        /// <param name="product"></param>
        private void AddProductToDatabase(Product product)
        {
            try
            {
                product.Category.Add(ProductDb.GetCategory(WhiteWood));
                if (!ProductDb.CheckForExistingProduct(product))
                {
                    ProductDb.Add(product);
                    ClearTxtBoxesAndCheckBoxes();
                    messageLbl.Text = $"{product.Height} x {product.Width} x {product.Length} added successfully";
                }
                else
                {
                    messageLbl.Text = "Product already exists in database";
                }
            }
            catch (SqlException)
            {
                messageLbl.Text = "Failed to add Product";
            }
        }

        /// <summary>
        /// Adds a product with multiple categories.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="treatmentLevel"></param>
        /// <param name="treatmentType"></param>
        private void AddProductToDatabase(Product p, int treatmentLevel, int treatmentType)
        {
            try
            {
                
                p.Category.Add(ProductDb.GetCategory(treatmentLevel));
                p.Category.Add(ProductDb.GetCategory(treatmentType));
                if (!ProductDb.CheckForExistingProduct(p))
                {
                    ProductDb.Add(p);
                    ClearTxtBoxesAndCheckBoxes();
                    messageLbl.Text = $"{p.Height} x {p.Width} x {p.Length} added successfully";
                }
                else
                {
                    messageLbl.Text = "Product already exists in database";
                }   
            }
            catch (SqlException)
            {
                messageLbl.Text = "Failed to add Product";
            }
        }

        /// <summary>
        /// Clears Textboxes and Checkboxes once form is submitted.
        /// </summary>
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

        /// <summary>
        /// Closes Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Unchecks certain categories once White Wood is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Unchecks certain categories once .25 is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Unchecks certain categories once .40 is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Unchecks certain categories once .60 is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Unchecks CCA (If checked) if ACQ gets checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Unchecks ACQ (If checked) if CCA gets checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Checks for required checkboxes to be checked.
        /// </summary>
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
