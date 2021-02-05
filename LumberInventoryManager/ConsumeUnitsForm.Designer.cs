
namespace LumberInventoryManager
{
    partial class ConsumeUnitsForm
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
            this.consumeProductBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.produceProductBox = new System.Windows.Forms.ComboBox();
            this.consumeNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.produceUnits = new System.Windows.Forms.TextBox();
            this.deckingCheckBox = new System.Windows.Forms.CheckBox();
            this.consumeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consumeProductBox
            // 
            this.consumeProductBox.FormattingEnabled = true;
            this.consumeProductBox.Location = new System.Drawing.Point(12, 43);
            this.consumeProductBox.Name = "consumeProductBox";
            this.consumeProductBox.Size = new System.Drawing.Size(236, 21);
            this.consumeProductBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a unit to consume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select a unit to produce";
            // 
            // produceProductBox
            // 
            this.produceProductBox.FormattingEnabled = true;
            this.produceProductBox.Location = new System.Drawing.Point(12, 116);
            this.produceProductBox.Name = "produceProductBox";
            this.produceProductBox.Size = new System.Drawing.Size(236, 21);
            this.produceProductBox.TabIndex = 3;
            // 
            // consumeNumber
            // 
            this.consumeNumber.Location = new System.Drawing.Point(12, 169);
            this.consumeNumber.MaxLength = 2;
            this.consumeNumber.Name = "consumeNumber";
            this.consumeNumber.Size = new System.Drawing.Size(36, 20);
            this.consumeNumber.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Units to consume";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Units to produce";
            // 
            // produceUnits
            // 
            this.produceUnits.Location = new System.Drawing.Point(132, 168);
            this.produceUnits.Name = "produceUnits";
            this.produceUnits.Size = new System.Drawing.Size(42, 20);
            this.produceUnits.TabIndex = 7;
            // 
            // deckingCheckBox
            // 
            this.deckingCheckBox.AutoSize = true;
            this.deckingCheckBox.Location = new System.Drawing.Point(12, 211);
            this.deckingCheckBox.Name = "deckingCheckBox";
            this.deckingCheckBox.Size = new System.Drawing.Size(72, 17);
            this.deckingCheckBox.TabIndex = 9;
            this.deckingCheckBox.Text = "Decking?";
            this.deckingCheckBox.UseVisualStyleBackColor = true;
            // 
            // consumeBtn
            // 
            this.consumeBtn.Location = new System.Drawing.Point(12, 254);
            this.consumeBtn.Name = "consumeBtn";
            this.consumeBtn.Size = new System.Drawing.Size(109, 36);
            this.consumeBtn.TabIndex = 10;
            this.consumeBtn.Text = "Consume Units";
            this.consumeBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(132, 254);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(116, 36);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // ConsumeUnitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 320);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.consumeBtn);
            this.Controls.Add(this.deckingCheckBox);
            this.Controls.Add(this.produceUnits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consumeNumber);
            this.Controls.Add(this.produceProductBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.consumeProductBox);
            this.Name = "ConsumeUnitsForm";
            this.Text = "Consume Units";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox consumeProductBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox produceProductBox;
        private System.Windows.Forms.TextBox consumeNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox produceUnits;
        private System.Windows.Forms.CheckBox deckingCheckBox;
        private System.Windows.Forms.Button consumeBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}