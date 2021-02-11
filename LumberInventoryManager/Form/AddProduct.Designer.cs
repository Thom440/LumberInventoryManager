
namespace LumberInventoryManager
{
    partial class AddProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.heightTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.widthTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lengthTxtBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.messageLbl = new System.Windows.Forms.Label();
            this.wwCheckBox = new System.Windows.Forms.CheckBox();
            this.twoFiveCheckBox = new System.Windows.Forms.CheckBox();
            this.fourOCheckBox = new System.Windows.Forms.CheckBox();
            this.sixOCheckBox = new System.Windows.Forms.CheckBox();
            this.acqCheckBox = new System.Windows.Forms.CheckBox();
            this.ccaCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Height";
            // 
            // heightTxtBox
            // 
            this.heightTxtBox.Location = new System.Drawing.Point(98, 5);
            this.heightTxtBox.MaxLength = 2;
            this.heightTxtBox.Name = "heightTxtBox";
            this.heightTxtBox.Size = new System.Drawing.Size(47, 20);
            this.heightTxtBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Width";
            // 
            // widthTxtBox
            // 
            this.widthTxtBox.Location = new System.Drawing.Point(98, 34);
            this.widthTxtBox.MaxLength = 2;
            this.widthTxtBox.Name = "widthTxtBox";
            this.widthTxtBox.Size = new System.Drawing.Size(47, 20);
            this.widthTxtBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product Length";
            // 
            // lengthTxtBox
            // 
            this.lengthTxtBox.Location = new System.Drawing.Point(98, 65);
            this.lengthTxtBox.MaxLength = 2;
            this.lengthTxtBox.Name = "lengthTxtBox";
            this.lengthTxtBox.Size = new System.Drawing.Size(47, 20);
            this.lengthTxtBox.TabIndex = 5;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 166);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Add Product";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(98, 166);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Location = new System.Drawing.Point(9, 198);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(0, 13);
            this.messageLbl.TabIndex = 8;
            // 
            // wwCheckBox
            // 
            this.wwCheckBox.AutoSize = true;
            this.wwCheckBox.Location = new System.Drawing.Point(12, 97);
            this.wwCheckBox.Name = "wwCheckBox";
            this.wwCheckBox.Size = new System.Drawing.Size(86, 17);
            this.wwCheckBox.TabIndex = 9;
            this.wwCheckBox.Text = "White Wood";
            this.wwCheckBox.UseVisualStyleBackColor = true;
            this.wwCheckBox.CheckedChanged += new System.EventHandler(this.wwCheckBox_CheckedChanged);
            // 
            // twoFiveCheckBox
            // 
            this.twoFiveCheckBox.AutoSize = true;
            this.twoFiveCheckBox.Location = new System.Drawing.Point(12, 120);
            this.twoFiveCheckBox.Name = "twoFiveCheckBox";
            this.twoFiveCheckBox.Size = new System.Drawing.Size(41, 17);
            this.twoFiveCheckBox.TabIndex = 10;
            this.twoFiveCheckBox.Text = ".25";
            this.twoFiveCheckBox.UseVisualStyleBackColor = true;
            this.twoFiveCheckBox.CheckedChanged += new System.EventHandler(this.twoFiveCheckBox_CheckedChanged);
            // 
            // fourOCheckBox
            // 
            this.fourOCheckBox.AutoSize = true;
            this.fourOCheckBox.Location = new System.Drawing.Point(57, 120);
            this.fourOCheckBox.Name = "fourOCheckBox";
            this.fourOCheckBox.Size = new System.Drawing.Size(41, 17);
            this.fourOCheckBox.TabIndex = 11;
            this.fourOCheckBox.Text = ".40";
            this.fourOCheckBox.UseVisualStyleBackColor = true;
            this.fourOCheckBox.CheckedChanged += new System.EventHandler(this.fourOCheckBox_CheckedChanged);
            // 
            // sixOCheckBox
            // 
            this.sixOCheckBox.AutoSize = true;
            this.sixOCheckBox.Location = new System.Drawing.Point(98, 120);
            this.sixOCheckBox.Name = "sixOCheckBox";
            this.sixOCheckBox.Size = new System.Drawing.Size(41, 17);
            this.sixOCheckBox.TabIndex = 12;
            this.sixOCheckBox.Text = ".60";
            this.sixOCheckBox.UseVisualStyleBackColor = true;
            this.sixOCheckBox.CheckedChanged += new System.EventHandler(this.sixOCheckBox_CheckedChanged);
            // 
            // acqCheckBox
            // 
            this.acqCheckBox.AutoSize = true;
            this.acqCheckBox.Location = new System.Drawing.Point(12, 143);
            this.acqCheckBox.Name = "acqCheckBox";
            this.acqCheckBox.Size = new System.Drawing.Size(48, 17);
            this.acqCheckBox.TabIndex = 13;
            this.acqCheckBox.Text = "ACQ";
            this.acqCheckBox.UseVisualStyleBackColor = true;
            this.acqCheckBox.CheckedChanged += new System.EventHandler(this.acqCheckBox_CheckedChanged);
            // 
            // ccaCheckBox
            // 
            this.ccaCheckBox.AutoSize = true;
            this.ccaCheckBox.Location = new System.Drawing.Point(66, 143);
            this.ccaCheckBox.Name = "ccaCheckBox";
            this.ccaCheckBox.Size = new System.Drawing.Size(47, 17);
            this.ccaCheckBox.TabIndex = 14;
            this.ccaCheckBox.Text = "CCA";
            this.ccaCheckBox.UseVisualStyleBackColor = true;
            this.ccaCheckBox.CheckedChanged += new System.EventHandler(this.ccaCheckBox_CheckedChanged);
            // 
            // AddProduct
            // 
            this.AcceptButton = this.addBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 221);
            this.Controls.Add(this.ccaCheckBox);
            this.Controls.Add(this.acqCheckBox);
            this.Controls.Add(this.sixOCheckBox);
            this.Controls.Add(this.fourOCheckBox);
            this.Controls.Add(this.twoFiveCheckBox);
            this.Controls.Add(this.wwCheckBox);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.lengthTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heightTxtBox);
            this.Controls.Add(this.label1);
            this.Name = "AddProduct";
            this.Text = "Add Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox heightTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox widthTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lengthTxtBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label messageLbl;
        private System.Windows.Forms.CheckBox wwCheckBox;
        private System.Windows.Forms.CheckBox twoFiveCheckBox;
        private System.Windows.Forms.CheckBox fourOCheckBox;
        private System.Windows.Forms.CheckBox sixOCheckBox;
        private System.Windows.Forms.CheckBox acqCheckBox;
        private System.Windows.Forms.CheckBox ccaCheckBox;
    }
}