﻿namespace MainUI.Product
{
    partial class ProductNewOrEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductNewOrEdit));
            this.productLinkComboBox = new System.Windows.Forms.ComboBox();
            this.productLinkLabel = new System.Windows.Forms.Label();
            this.brandNameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.packSizeTextBox = new System.Windows.Forms.TextBox();
            this.productDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.packSizeLabel = new System.Windows.Forms.Label();
            this.productDescriptionLabel = new System.Windows.Forms.Label();
            this.brandNameTextBox = new System.Windows.Forms.TextBox();
            this.barcodeLabel = new System.Windows.Forms.Label();
            this.addProductLinkButton = new System.Windows.Forms.Button();
            this.barcodeComboBox = new System.Windows.Forms.ComboBox();
            this.deleteBarcodeButton = new System.Windows.Forms.Button();
            this.addBarcodeButton = new System.Windows.Forms.Button();
            this.uomLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productLinkComboBox
            // 
            this.productLinkComboBox.FormattingEnabled = true;
            this.productLinkComboBox.Location = new System.Drawing.Point(149, 147);
            this.productLinkComboBox.Name = "productLinkComboBox";
            this.productLinkComboBox.Size = new System.Drawing.Size(192, 25);
            this.productLinkComboBox.TabIndex = 4;
            this.productLinkComboBox.SelectedValueChanged += new System.EventHandler(this.productLinkComboBox_SelectedValueChanged);
            // 
            // productLinkLabel
            // 
            this.productLinkLabel.AutoSize = true;
            this.productLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLinkLabel.Location = new System.Drawing.Point(12, 155);
            this.productLinkLabel.Name = "productLinkLabel";
            this.productLinkLabel.Size = new System.Drawing.Size(86, 17);
            this.productLinkLabel.TabIndex = 33;
            this.productLinkLabel.Text = "Product Link";
            // 
            // brandNameLabel
            // 
            this.brandNameLabel.AutoSize = true;
            this.brandNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandNameLabel.Location = new System.Drawing.Point(12, 92);
            this.brandNameLabel.Name = "brandNameLabel";
            this.brandNameLabel.Size = new System.Drawing.Size(84, 17);
            this.brandNameLabel.TabIndex = 34;
            this.brandNameLabel.Text = "Brand Name";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(285, 237);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 30);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(17, 237);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(87, 30);
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(142, 30);
            this.formTitleLabel.TabIndex = 30;
            this.formTitleLabel.Text = "New Product";
            // 
            // packSizeTextBox
            // 
            this.packSizeTextBox.Location = new System.Drawing.Point(149, 117);
            this.packSizeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.packSizeTextBox.Name = "packSizeTextBox";
            this.packSizeTextBox.Size = new System.Drawing.Size(161, 25);
            this.packSizeTextBox.TabIndex = 3;
            // 
            // productDescriptionTextBox
            // 
            this.productDescriptionTextBox.Location = new System.Drawing.Point(149, 51);
            this.productDescriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productDescriptionTextBox.Name = "productDescriptionTextBox";
            this.productDescriptionTextBox.Size = new System.Drawing.Size(223, 25);
            this.productDescriptionTextBox.TabIndex = 1;
            // 
            // packSizeLabel
            // 
            this.packSizeLabel.AutoSize = true;
            this.packSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packSizeLabel.Location = new System.Drawing.Point(12, 123);
            this.packSizeLabel.Name = "packSizeLabel";
            this.packSizeLabel.Size = new System.Drawing.Size(64, 17);
            this.packSizeLabel.TabIndex = 26;
            this.packSizeLabel.Text = "Pack Size";
            // 
            // productDescriptionLabel
            // 
            this.productDescriptionLabel.AutoSize = true;
            this.productDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productDescriptionLabel.Location = new System.Drawing.Point(12, 59);
            this.productDescriptionLabel.Name = "productDescriptionLabel";
            this.productDescriptionLabel.Size = new System.Drawing.Size(131, 17);
            this.productDescriptionLabel.TabIndex = 27;
            this.productDescriptionLabel.Text = "Product Description";
            // 
            // brandNameTextBox
            // 
            this.brandNameTextBox.Location = new System.Drawing.Point(149, 84);
            this.brandNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brandNameTextBox.Name = "brandNameTextBox";
            this.brandNameTextBox.Size = new System.Drawing.Size(223, 25);
            this.brandNameTextBox.TabIndex = 2;
            // 
            // barcodeLabel
            // 
            this.barcodeLabel.AutoSize = true;
            this.barcodeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeLabel.Location = new System.Drawing.Point(12, 187);
            this.barcodeLabel.Name = "barcodeLabel";
            this.barcodeLabel.Size = new System.Drawing.Size(57, 17);
            this.barcodeLabel.TabIndex = 26;
            this.barcodeLabel.Text = "Barcode";
            // 
            // addProductLinkButton
            // 
            this.addProductLinkButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductLinkButton.Location = new System.Drawing.Point(347, 147);
            this.addProductLinkButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addProductLinkButton.Name = "addProductLinkButton";
            this.addProductLinkButton.Size = new System.Drawing.Size(25, 25);
            this.addProductLinkButton.TabIndex = 5;
            this.addProductLinkButton.Text = "+";
            this.addProductLinkButton.UseVisualStyleBackColor = true;
            this.addProductLinkButton.Click += new System.EventHandler(this.addProductLinkButton_Click);
            // 
            // barcodeComboBox
            // 
            this.barcodeComboBox.FormattingEnabled = true;
            this.barcodeComboBox.Location = new System.Drawing.Point(149, 178);
            this.barcodeComboBox.Name = "barcodeComboBox";
            this.barcodeComboBox.Size = new System.Drawing.Size(161, 25);
            this.barcodeComboBox.TabIndex = 6;
            // 
            // deleteBarcodeButton
            // 
            this.deleteBarcodeButton.Enabled = false;
            this.deleteBarcodeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBarcodeButton.Location = new System.Drawing.Point(316, 178);
            this.deleteBarcodeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteBarcodeButton.Name = "deleteBarcodeButton";
            this.deleteBarcodeButton.Size = new System.Drawing.Size(25, 25);
            this.deleteBarcodeButton.TabIndex = 7;
            this.deleteBarcodeButton.Text = "-";
            this.deleteBarcodeButton.UseVisualStyleBackColor = true;
            this.deleteBarcodeButton.Click += new System.EventHandler(this.deleteBarcodeButton_Click);
            // 
            // addBarcodeButton
            // 
            this.addBarcodeButton.Enabled = false;
            this.addBarcodeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBarcodeButton.Location = new System.Drawing.Point(347, 178);
            this.addBarcodeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addBarcodeButton.Name = "addBarcodeButton";
            this.addBarcodeButton.Size = new System.Drawing.Size(25, 25);
            this.addBarcodeButton.TabIndex = 8;
            this.addBarcodeButton.Text = "+";
            this.addBarcodeButton.UseVisualStyleBackColor = true;
            this.addBarcodeButton.Click += new System.EventHandler(this.addBarcodeButton_Click);
            // 
            // uomLabel
            // 
            this.uomLabel.AutoSize = true;
            this.uomLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uomLabel.Location = new System.Drawing.Point(313, 123);
            this.uomLabel.Name = "uomLabel";
            this.uomLabel.Size = new System.Drawing.Size(36, 17);
            this.uomLabel.TabIndex = 26;
            this.uomLabel.Text = "uom";
            // 
            // ProductNewOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.barcodeComboBox);
            this.Controls.Add(this.productLinkComboBox);
            this.Controls.Add(this.productLinkLabel);
            this.Controls.Add(this.brandNameLabel);
            this.Controls.Add(this.addBarcodeButton);
            this.Controls.Add(this.deleteBarcodeButton);
            this.Controls.Add(this.addProductLinkButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.formTitleLabel);
            this.Controls.Add(this.brandNameTextBox);
            this.Controls.Add(this.packSizeTextBox);
            this.Controls.Add(this.productDescriptionTextBox);
            this.Controls.Add(this.barcodeLabel);
            this.Controls.Add(this.uomLabel);
            this.Controls.Add(this.packSizeLabel);
            this.Controls.Add(this.productDescriptionLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductNewOrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Or Edit Product";
            this.Load += new System.EventHandler(this.ProductNewOrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox productLinkComboBox;
        private System.Windows.Forms.Label productLinkLabel;
        private System.Windows.Forms.Label brandNameLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.TextBox packSizeTextBox;
        private System.Windows.Forms.TextBox productDescriptionTextBox;
        private System.Windows.Forms.Label packSizeLabel;
        private System.Windows.Forms.Label productDescriptionLabel;
        private System.Windows.Forms.TextBox brandNameTextBox;
        private System.Windows.Forms.Label barcodeLabel;
        private System.Windows.Forms.Button addProductLinkButton;
        private System.Windows.Forms.ComboBox barcodeComboBox;
        private System.Windows.Forms.Button deleteBarcodeButton;
        private System.Windows.Forms.Button addBarcodeButton;
        private System.Windows.Forms.Label uomLabel;
    }
}