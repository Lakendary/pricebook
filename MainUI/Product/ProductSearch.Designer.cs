namespace MainUI.Product
{
    partial class ProductSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSearch));
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.productSearchDataGridView = new System.Windows.Forms.DataGridView();
            this.productLinkNameTextBox = new System.Windows.Forms.TextBox();
            this.packSizeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.brandNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.productDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.weightedLabel = new System.Windows.Forms.Label();
            this.weightedComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.addProductToInvoiceButton = new System.Windows.Forms.Button();
            this.addProductPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.productSearchDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addProductPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(162, 30);
            this.formTitleLabel.TabIndex = 6;
            this.formTitleLabel.Text = "Search Product";
            // 
            // productSearchDataGridView
            // 
            this.productSearchDataGridView.AllowUserToAddRows = false;
            this.productSearchDataGridView.AllowUserToDeleteRows = false;
            this.productSearchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productSearchDataGridView.Location = new System.Drawing.Point(12, 161);
            this.productSearchDataGridView.MultiSelect = false;
            this.productSearchDataGridView.Name = "productSearchDataGridView";
            this.productSearchDataGridView.ReadOnly = true;
            this.productSearchDataGridView.RowHeadersVisible = false;
            this.productSearchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productSearchDataGridView.Size = new System.Drawing.Size(600, 390);
            this.productSearchDataGridView.TabIndex = 7;
            this.productSearchDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productSearchDataGridView_CellMouseClick);
            this.productSearchDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productSearchDataGridView_KeyDown);
            // 
            // productLinkNameTextBox
            // 
            this.productLinkNameTextBox.Location = new System.Drawing.Point(12, 80);
            this.productLinkNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productLinkNameTextBox.Name = "productLinkNameTextBox";
            this.productLinkNameTextBox.Size = new System.Drawing.Size(192, 25);
            this.productLinkNameTextBox.TabIndex = 1;
            this.productLinkNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productLinkNameTextBox_KeyDown);
            // 
            // packSizeLabel
            // 
            this.packSizeLabel.AutoSize = true;
            this.packSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packSizeLabel.Location = new System.Drawing.Point(12, 59);
            this.packSizeLabel.Name = "packSizeLabel";
            this.packSizeLabel.Size = new System.Drawing.Size(126, 17);
            this.packSizeLabel.TabIndex = 35;
            this.packSizeLabel.Text = "Product Link Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Product Description";
            // 
            // brandNameTextBox
            // 
            this.brandNameTextBox.Location = new System.Drawing.Point(213, 80);
            this.brandNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brandNameTextBox.Name = "brandNameTextBox";
            this.brandNameTextBox.Size = new System.Drawing.Size(192, 25);
            this.brandNameTextBox.TabIndex = 2;
            this.brandNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.brandNameTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Brand Name";
            // 
            // productDescriptionTextBox
            // 
            this.productDescriptionTextBox.Location = new System.Drawing.Point(213, 129);
            this.productDescriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productDescriptionTextBox.Name = "productDescriptionTextBox";
            this.productDescriptionTextBox.Size = new System.Drawing.Size(192, 25);
            this.productDescriptionTextBox.TabIndex = 5;
            this.productDescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productDescriptionTextBox_KeyDown);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(12, 129);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(192, 25);
            this.categoryComboBox.TabIndex = 4;
            this.categoryComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoryComboBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Category";
            // 
            // weightedLabel
            // 
            this.weightedLabel.AutoSize = true;
            this.weightedLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightedLabel.Location = new System.Drawing.Point(408, 60);
            this.weightedLabel.Name = "weightedLabel";
            this.weightedLabel.Size = new System.Drawing.Size(68, 17);
            this.weightedLabel.TabIndex = 35;
            this.weightedLabel.Text = "Weighted";
            // 
            // weightedComboBox
            // 
            this.weightedComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.weightedComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.weightedComboBox.FormattingEnabled = true;
            this.weightedComboBox.Items.AddRange(new object[] {
            "<ALL>",
            "Weighted",
            "Pre-Packaged"});
            this.weightedComboBox.Location = new System.Drawing.Point(411, 80);
            this.weightedComboBox.Name = "weightedComboBox";
            this.weightedComboBox.Size = new System.Drawing.Size(201, 25);
            this.weightedComboBox.TabIndex = 3;
            this.weightedComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.weightedComboBox_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(516, 124);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(96, 30);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(411, 125);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(96, 30);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addProductToInvoiceButton
            // 
            this.addProductToInvoiceButton.Enabled = false;
            this.addProductToInvoiceButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductToInvoiceButton.Location = new System.Drawing.Point(420, 558);
            this.addProductToInvoiceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addProductToInvoiceButton.Name = "addProductToInvoiceButton";
            this.addProductToInvoiceButton.Size = new System.Drawing.Size(192, 30);
            this.addProductToInvoiceButton.TabIndex = 8;
            this.addProductToInvoiceButton.Text = "Add Product To Invoice";
            this.addProductToInvoiceButton.UseVisualStyleBackColor = true;
            this.addProductToInvoiceButton.Click += new System.EventHandler(this.addProductToInvoiceButton_Click);
            // 
            // addProductPictureBox
            // 
            this.addProductPictureBox.Image = global::PriceBook.Properties.Resources.productAdd;
            this.addProductPictureBox.Location = new System.Drawing.Point(562, 9);
            this.addProductPictureBox.Name = "addProductPictureBox";
            this.addProductPictureBox.Size = new System.Drawing.Size(50, 50);
            this.addProductPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addProductPictureBox.TabIndex = 48;
            this.addProductPictureBox.TabStop = false;
            this.addProductPictureBox.Click += new System.EventHandler(this.addProductPictureBox_Click);
            // 
            // ProductSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 601);
            this.Controls.Add(this.addProductPictureBox);
            this.Controls.Add(this.addProductToInvoiceButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.weightedComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.productDescriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.weightedLabel);
            this.Controls.Add(this.brandNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productLinkNameTextBox);
            this.Controls.Add(this.packSizeLabel);
            this.Controls.Add(this.productSearchDataGridView);
            this.Controls.Add(this.formTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Search";
            this.Load += new System.EventHandler(this.ProductSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productSearchDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addProductPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.DataGridView productSearchDataGridView;
        private System.Windows.Forms.TextBox productLinkNameTextBox;
        private System.Windows.Forms.Label packSizeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox brandNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox productDescriptionTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label weightedLabel;
        private System.Windows.Forms.ComboBox weightedComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.PictureBox addProductPictureBox;
        private System.Windows.Forms.Button addProductToInvoiceButton;
    }
}