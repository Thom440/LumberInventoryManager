﻿
namespace LumberInventoryManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addBtn = new System.Windows.Forms.Button();
            this.productListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.consumeBtn = new System.Windows.Forms.Button();
            this.addCustomerBtn = new System.Windows.Forms.Button();
            this.createInvoiceBtn = new System.Windows.Forms.Button();
            this.updateInvoiceBtn = new System.Windows.Forms.Button();
            this.viewInvoiceBtn = new System.Windows.Forms.Button();
            this.invoiceListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 162);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(120, 33);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Add Product";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // productListBox
            // 
            this.productListBox.FormattingEnabled = true;
            this.productListBox.Location = new System.Drawing.Point(12, 42);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(236, 95);
            this.productListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inventory";
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(138, 162);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(110, 32);
            this.updateBtn.TabIndex = 4;
            this.updateBtn.Text = "Update Inventory";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(12, 201);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 35);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete Product";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // consumeBtn
            // 
            this.consumeBtn.Location = new System.Drawing.Point(138, 202);
            this.consumeBtn.Name = "consumeBtn";
            this.consumeBtn.Size = new System.Drawing.Size(110, 34);
            this.consumeBtn.TabIndex = 6;
            this.consumeBtn.Text = "Consume Product";
            this.consumeBtn.UseVisualStyleBackColor = true;
            this.consumeBtn.Click += new System.EventHandler(this.ConsumeBtn_Click);
            // 
            // addCustomerBtn
            // 
            this.addCustomerBtn.Location = new System.Drawing.Point(397, 201);
            this.addCustomerBtn.Name = "addCustomerBtn";
            this.addCustomerBtn.Size = new System.Drawing.Size(119, 34);
            this.addCustomerBtn.TabIndex = 7;
            this.addCustomerBtn.Text = "Add Customer";
            this.addCustomerBtn.UseVisualStyleBackColor = true;
            this.addCustomerBtn.Click += new System.EventHandler(this.AddCustomerBtn_Click);
            // 
            // createInvoiceBtn
            // 
            this.createInvoiceBtn.Location = new System.Drawing.Point(280, 161);
            this.createInvoiceBtn.Name = "createInvoiceBtn";
            this.createInvoiceBtn.Size = new System.Drawing.Size(110, 33);
            this.createInvoiceBtn.TabIndex = 8;
            this.createInvoiceBtn.Text = "Create Invoice";
            this.createInvoiceBtn.UseVisualStyleBackColor = true;
            this.createInvoiceBtn.Click += new System.EventHandler(this.CreateInvoiceBtn_Click);
            // 
            // updateInvoiceBtn
            // 
            this.updateInvoiceBtn.Location = new System.Drawing.Point(397, 162);
            this.updateInvoiceBtn.Name = "updateInvoiceBtn";
            this.updateInvoiceBtn.Size = new System.Drawing.Size(119, 32);
            this.updateInvoiceBtn.TabIndex = 9;
            this.updateInvoiceBtn.Text = "Update Invoice";
            this.updateInvoiceBtn.UseVisualStyleBackColor = true;
            this.updateInvoiceBtn.Click += new System.EventHandler(this.UpdateInvoiceBtn_Click);
            // 
            // viewInvoiceBtn
            // 
            this.viewInvoiceBtn.Location = new System.Drawing.Point(280, 201);
            this.viewInvoiceBtn.Name = "viewInvoiceBtn";
            this.viewInvoiceBtn.Size = new System.Drawing.Size(110, 34);
            this.viewInvoiceBtn.TabIndex = 10;
            this.viewInvoiceBtn.Text = "View Invoice";
            this.viewInvoiceBtn.UseVisualStyleBackColor = true;
            this.viewInvoiceBtn.Click += new System.EventHandler(this.ViewInvoiceBtn_Click);
            // 
            // invoiceListBox
            // 
            this.invoiceListBox.FormattingEnabled = true;
            this.invoiceListBox.Location = new System.Drawing.Point(280, 42);
            this.invoiceListBox.Name = "invoiceListBox";
            this.invoiceListBox.Size = new System.Drawing.Size(236, 95);
            this.invoiceListBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Invoices";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 248);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invoiceListBox);
            this.Controls.Add(this.viewInvoiceBtn);
            this.Controls.Add(this.updateInvoiceBtn);
            this.Controls.Add(this.createInvoiceBtn);
            this.Controls.Add(this.addCustomerBtn);
            this.Controls.Add(this.consumeBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productListBox);
            this.Controls.Add(this.addBtn);
            this.Name = "Form1";
            this.Text = "Lumber Inventory Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ListBox productListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button consumeBtn;
        private System.Windows.Forms.Button addCustomerBtn;
        private System.Windows.Forms.Button createInvoiceBtn;
        private System.Windows.Forms.Button updateInvoiceBtn;
        private System.Windows.Forms.Button viewInvoiceBtn;
        private System.Windows.Forms.ListBox invoiceListBox;
        private System.Windows.Forms.Label label2;
    }
}

