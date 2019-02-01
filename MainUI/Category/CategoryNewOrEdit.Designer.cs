namespace MainUI.Category
{
    partial class CategoryNewOrEdit
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
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.categoryNameTextBox = new System.Windows.Forms.TextBox();
            this.invoiceNumberLabel = new System.Windows.Forms.Label();
            this.invoiceAmountLabel = new System.Windows.Forms.Label();
            this.mainCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(153, 30);
            this.formTitleLabel.TabIndex = 18;
            this.formTitleLabel.Text = "New Category";
            // 
            // categoryNameTextBox
            // 
            this.categoryNameTextBox.Location = new System.Drawing.Point(140, 51);
            this.categoryNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.categoryNameTextBox.Name = "categoryNameTextBox";
            this.categoryNameTextBox.Size = new System.Drawing.Size(192, 25);
            this.categoryNameTextBox.TabIndex = 1;
            // 
            // invoiceNumberLabel
            // 
            this.invoiceNumberLabel.AutoSize = true;
            this.invoiceNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceNumberLabel.Location = new System.Drawing.Point(12, 91);
            this.invoiceNumberLabel.Name = "invoiceNumberLabel";
            this.invoiceNumberLabel.Size = new System.Drawing.Size(99, 17);
            this.invoiceNumberLabel.TabIndex = 14;
            this.invoiceNumberLabel.Text = "Main Category";
            // 
            // invoiceAmountLabel
            // 
            this.invoiceAmountLabel.AutoSize = true;
            this.invoiceAmountLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceAmountLabel.Location = new System.Drawing.Point(12, 59);
            this.invoiceAmountLabel.Name = "invoiceAmountLabel";
            this.invoiceAmountLabel.Size = new System.Drawing.Size(104, 17);
            this.invoiceAmountLabel.TabIndex = 15;
            this.invoiceAmountLabel.Text = "Category Name";
            // 
            // mainCategoryComboBox
            // 
            this.mainCategoryComboBox.FormattingEnabled = true;
            this.mainCategoryComboBox.Location = new System.Drawing.Point(140, 83);
            this.mainCategoryComboBox.Name = "mainCategoryComboBox";
            this.mainCategoryComboBox.Size = new System.Drawing.Size(192, 25);
            this.mainCategoryComboBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(245, 141);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 30);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(12, 141);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(87, 30);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // CategoryNewOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 181);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.mainCategoryComboBox);
            this.Controls.Add(this.formTitleLabel);
            this.Controls.Add(this.categoryNameTextBox);
            this.Controls.Add(this.invoiceNumberLabel);
            this.Controls.Add(this.invoiceAmountLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CategoryNewOrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Or Edit Category";
            this.Load += new System.EventHandler(this.CategoryNewOrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.TextBox categoryNameTextBox;
        private System.Windows.Forms.Label invoiceNumberLabel;
        private System.Windows.Forms.Label invoiceAmountLabel;
        private System.Windows.Forms.ComboBox mainCategoryComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
    }
}