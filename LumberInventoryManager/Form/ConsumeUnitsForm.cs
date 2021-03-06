﻿using System;
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
    public partial class ConsumeUnitsForm : Form
    {
        /// <summary>
        /// Form that consumes units into smaller units.
        /// </summary>
        public ConsumeUnitsForm()
        {
            InitializeComponent();
        }

        private void ConsumeUnitsForm_Load(object sender, EventArgs e)
        {
            List<Product> products = ProductDb.GetAllProducts();
            consumeProductBox.DataSource = products;
        }

        /// <summary>
        /// Once product is selected, changes list of that products. 
        /// In addition changes list of larger products being consumed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsumeProductBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product product = (Product)consumeProductBox.SelectedItem;
            List<Product> products = ProductDb.GetProductsInRange(product.ProductID, product.Height, product.Width, product.Length);
            produceProductBox.DataSource = products.ToList();
        }

        /// <summary>
        /// The button that initiates consumption of products.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsumeBtn_Click(object sender, EventArgs e)
        {
            Product consumedProduct = (Product)consumeProductBox.SelectedItem;
            Product producedProduct = (Product)produceProductBox.SelectedItem;
            if (Validator.IsByte(consumeNumber.Text) && Validator.IsByte(produceUnits.Text))
            {
                byte numberToConsume = Convert.ToByte(consumeNumber.Text);
                byte numberToProduce = Convert.ToByte(produceUnits.Text);
                if (consumedProduct.OnHand < numberToConsume)
                {
                    MessageBox.Show("There is not enough units to consume");
                    return;
                }
                consumedProduct.OnHand -= numberToConsume;
                producedProduct.OnHand += numberToProduce;
                ProductDb.Update(consumedProduct);
                ProductDb.Update(producedProduct);
                Close();
            }
        }

        /// <summary>
        /// Closes form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
