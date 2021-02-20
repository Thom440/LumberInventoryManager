
namespace LumberInventoryManager
{
    partial class CreateInvoiceForm
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
            this.customerComboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createInvoiceBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.messageLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerComboBox1
            // 
            this.customerComboBox1.FormattingEnabled = true;
            this.customerComboBox1.Location = new System.Drawing.Point(75, 21);
            this.customerComboBox1.Name = "customerComboBox1";
            this.customerComboBox1.Size = new System.Drawing.Size(195, 21);
            this.customerComboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customers";
            // 
            // createInvoiceBtn
            // 
            this.createInvoiceBtn.Location = new System.Drawing.Point(16, 62);
            this.createInvoiceBtn.Name = "createInvoiceBtn";
            this.createInvoiceBtn.Size = new System.Drawing.Size(123, 31);
            this.createInvoiceBtn.TabIndex = 2;
            this.createInvoiceBtn.Text = "Create Invoice";
            this.createInvoiceBtn.UseVisualStyleBackColor = true;
            this.createInvoiceBtn.Click += new System.EventHandler(this.CreateInvoiceBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(145, 63);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(125, 30);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Location = new System.Drawing.Point(16, 105);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(0, 13);
            this.messageLbl.TabIndex = 4;
            // 
            // CreateInvoiceForm
            // 
            this.AcceptButton = this.createInvoiceBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 130);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.createInvoiceBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerComboBox1);
            this.Name = "CreateInvoiceForm";
            this.Text = "Create Invoice";
            this.Load += new System.EventHandler(this.CreateInvoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createInvoiceBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label messageLbl;
    }
}