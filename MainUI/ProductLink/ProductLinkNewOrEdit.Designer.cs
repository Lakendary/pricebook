namespace MainUI.ProductLink
{
    partial class ProductLinkNewOrEdit
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
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.measurementRateTextBox = new System.Windows.Forms.TextBox();
            this.productLinkNameTextBox = new System.Windows.Forms.TextBox();
            this.measurementRateLabel = new System.Windows.Forms.Label();
            this.productLinkNameLabel = new System.Windows.Forms.Label();
            this.uomComboBox = new System.Windows.Forms.ComboBox();
            this.uomLabel = new System.Windows.Forms.Label();
            this.weightedCheckBox = new System.Windows.Forms.CheckBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(285, 205);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 30);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(12, 205);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(87, 30);
            this.resetButton.TabIndex = 7;
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
            this.formTitleLabel.Size = new System.Drawing.Size(190, 30);
            this.formTitleLabel.TabIndex = 20;
            this.formTitleLabel.Text = "New Product Link";
            // 
            // measurementRateTextBox
            // 
            this.measurementRateTextBox.Location = new System.Drawing.Point(140, 115);
            this.measurementRateTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.measurementRateTextBox.Name = "measurementRateTextBox";
            this.measurementRateTextBox.Size = new System.Drawing.Size(232, 25);
            this.measurementRateTextBox.TabIndex = 4;
            this.measurementRateTextBox.Leave += new System.EventHandler(this.measurementRateTextBox_Leave);
            // 
            // productLinkNameTextBox
            // 
            this.productLinkNameTextBox.Location = new System.Drawing.Point(140, 51);
            this.productLinkNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productLinkNameTextBox.Name = "productLinkNameTextBox";
            this.productLinkNameTextBox.Size = new System.Drawing.Size(232, 25);
            this.productLinkNameTextBox.TabIndex = 1;
            // 
            // measurementRateLabel
            // 
            this.measurementRateLabel.AutoSize = true;
            this.measurementRateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measurementRateLabel.Location = new System.Drawing.Point(12, 123);
            this.measurementRateLabel.Name = "measurementRateLabel";
            this.measurementRateLabel.Size = new System.Drawing.Size(123, 17);
            this.measurementRateLabel.TabIndex = 16;
            this.measurementRateLabel.Text = "Measurement Rate";
            // 
            // productLinkNameLabel
            // 
            this.productLinkNameLabel.AutoSize = true;
            this.productLinkNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLinkNameLabel.Location = new System.Drawing.Point(12, 59);
            this.productLinkNameLabel.Name = "productLinkNameLabel";
            this.productLinkNameLabel.Size = new System.Drawing.Size(126, 17);
            this.productLinkNameLabel.TabIndex = 17;
            this.productLinkNameLabel.Text = "Product Link Name";
            // 
            // uomComboBox
            // 
            this.uomComboBox.FormattingEnabled = true;
            this.uomComboBox.Items.AddRange(new object[] {
            "g",
            "ml",
            "ea",
            "cm"});
            this.uomComboBox.Location = new System.Drawing.Point(140, 83);
            this.uomComboBox.Name = "uomComboBox";
            this.uomComboBox.Size = new System.Drawing.Size(129, 25);
            this.uomComboBox.TabIndex = 2;
            // 
            // uomLabel
            // 
            this.uomLabel.AutoSize = true;
            this.uomLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uomLabel.Location = new System.Drawing.Point(12, 91);
            this.uomLabel.Name = "uomLabel";
            this.uomLabel.Size = new System.Drawing.Size(107, 17);
            this.uomLabel.TabIndex = 23;
            this.uomLabel.Text = "Unit of Measure";
            // 
            // weightedCheckBox
            // 
            this.weightedCheckBox.AutoSize = true;
            this.weightedCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightedCheckBox.Location = new System.Drawing.Point(275, 87);
            this.weightedCheckBox.Name = "weightedCheckBox";
            this.weightedCheckBox.Size = new System.Drawing.Size(97, 21);
            this.weightedCheckBox.TabIndex = 3;
            this.weightedCheckBox.Text = "Weighted ?";
            this.weightedCheckBox.UseVisualStyleBackColor = true;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(12, 155);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(64, 17);
            this.categoryLabel.TabIndex = 23;
            this.categoryLabel.Text = "Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(140, 147);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(201, 25);
            this.categoryComboBox.TabIndex = 5;
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategoryButton.Location = new System.Drawing.Point(347, 147);
            this.addCategoryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(25, 25);
            this.addCategoryButton.TabIndex = 6;
            this.addCategoryButton.Text = "+";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            // 
            // ProductLinkNewOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.weightedCheckBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.uomComboBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.uomLabel);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.formTitleLabel);
            this.Controls.Add(this.measurementRateTextBox);
            this.Controls.Add(this.productLinkNameTextBox);
            this.Controls.Add(this.measurementRateLabel);
            this.Controls.Add(this.productLinkNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductLinkNewOrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Or Edit Product Link";
            this.Load += new System.EventHandler(this.ProductLinkNewOrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.TextBox measurementRateTextBox;
        private System.Windows.Forms.TextBox productLinkNameTextBox;
        private System.Windows.Forms.Label measurementRateLabel;
        private System.Windows.Forms.Label productLinkNameLabel;
        private System.Windows.Forms.ComboBox uomComboBox;
        private System.Windows.Forms.Label uomLabel;
        private System.Windows.Forms.CheckBox weightedCheckBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button addCategoryButton;
    }
}