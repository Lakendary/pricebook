namespace MainUI.Invoice
{
    partial class InvoiceNewOrEdit
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
            this.storeNameLabel = new System.Windows.Forms.Label();
            this.invoiceAmountTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.invoiceNumberTextBox = new System.Windows.Forms.TextBox();
            this.invoiceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.invoiceAmountLabel = new System.Windows.Forms.Label();
            this.invoiceNumberLabel = new System.Windows.Forms.Label();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.generateInvoiceNumberButton = new System.Windows.Forms.Button();
            this.addStoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // storeNameLabel
            // 
            this.storeNameLabel.AutoSize = true;
            this.storeNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeNameLabel.Location = new System.Drawing.Point(12, 59);
            this.storeNameLabel.Name = "storeNameLabel";
            this.storeNameLabel.Size = new System.Drawing.Size(80, 17);
            this.storeNameLabel.TabIndex = 0;
            this.storeNameLabel.Text = "Store Name";
            // 
            // invoiceAmountTextBox
            // 
            this.invoiceAmountTextBox.Location = new System.Drawing.Point(135, 113);
            this.invoiceAmountTextBox.Name = "invoiceAmountTextBox";
            this.invoiceAmountTextBox.Size = new System.Drawing.Size(237, 25);
            this.invoiceAmountTextBox.TabIndex = 3;
            this.invoiceAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoiceAmountTextBox_KeyPress);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(12, 90);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(85, 17);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Invoice Date";
            // 
            // invoiceNumberTextBox
            // 
            this.invoiceNumberTextBox.Location = new System.Drawing.Point(135, 144);
            this.invoiceNumberTextBox.Name = "invoiceNumberTextBox";
            this.invoiceNumberTextBox.Size = new System.Drawing.Size(206, 25);
            this.invoiceNumberTextBox.TabIndex = 4;
            // 
            // invoiceDateTimePicker
            // 
            this.invoiceDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.invoiceDateTimePicker.Location = new System.Drawing.Point(135, 82);
            this.invoiceDateTimePicker.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.invoiceDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.invoiceDateTimePicker.Name = "invoiceDateTimePicker";
            this.invoiceDateTimePicker.Size = new System.Drawing.Size(237, 25);
            this.invoiceDateTimePicker.TabIndex = 2;
            // 
            // storeComboBox
            // 
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(135, 51);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(206, 25);
            this.storeComboBox.TabIndex = 1;
            // 
            // invoiceAmountLabel
            // 
            this.invoiceAmountLabel.AutoSize = true;
            this.invoiceAmountLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceAmountLabel.Location = new System.Drawing.Point(12, 121);
            this.invoiceAmountLabel.Name = "invoiceAmountLabel";
            this.invoiceAmountLabel.Size = new System.Drawing.Size(106, 17);
            this.invoiceAmountLabel.TabIndex = 0;
            this.invoiceAmountLabel.Text = "Invoice Amount";
            // 
            // invoiceNumberLabel
            // 
            this.invoiceNumberLabel.AutoSize = true;
            this.invoiceNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceNumberLabel.Location = new System.Drawing.Point(12, 152);
            this.invoiceNumberLabel.Name = "invoiceNumberLabel";
            this.invoiceNumberLabel.Size = new System.Drawing.Size(106, 17);
            this.invoiceNumberLabel.TabIndex = 0;
            this.invoiceNumberLabel.Text = "Invoice Number";
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(135, 30);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "New Invoice";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(285, 202);
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
            this.resetButton.Location = new System.Drawing.Point(15, 202);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(87, 30);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // generateInvoiceNumberButton
            // 
            this.generateInvoiceNumberButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateInvoiceNumberButton.Location = new System.Drawing.Point(347, 144);
            this.generateInvoiceNumberButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generateInvoiceNumberButton.Name = "generateInvoiceNumberButton";
            this.generateInvoiceNumberButton.Size = new System.Drawing.Size(25, 25);
            this.generateInvoiceNumberButton.TabIndex = 5;
            this.generateInvoiceNumberButton.Text = "+";
            this.generateInvoiceNumberButton.UseVisualStyleBackColor = true;
            this.generateInvoiceNumberButton.Click += new System.EventHandler(this.generateInvoiceNumberButton_Click);
            // 
            // addStoreButton
            // 
            this.addStoreButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStoreButton.Location = new System.Drawing.Point(347, 51);
            this.addStoreButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addStoreButton.Name = "addStoreButton";
            this.addStoreButton.Size = new System.Drawing.Size(25, 25);
            this.addStoreButton.TabIndex = 5;
            this.addStoreButton.Text = "+";
            this.addStoreButton.UseVisualStyleBackColor = true;
            this.addStoreButton.Click += new System.EventHandler(this.addStoreButton_Click);
            // 
            // InvoiceNewOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.addStoreButton);
            this.Controls.Add(this.generateInvoiceNumberButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.storeComboBox);
            this.Controls.Add(this.invoiceDateTimePicker);
            this.Controls.Add(this.invoiceNumberTextBox);
            this.Controls.Add(this.invoiceAmountTextBox);
            this.Controls.Add(this.invoiceNumberLabel);
            this.Controls.Add(this.invoiceAmountLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.formTitleLabel);
            this.Controls.Add(this.storeNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceNewOrEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Or Edit Invoice";
            this.Load += new System.EventHandler(this.InvoiceNewAndEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label storeNameLabel;
        private System.Windows.Forms.TextBox invoiceAmountTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox invoiceNumberTextBox;
        public System.Windows.Forms.DateTimePicker invoiceDateTimePicker;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.Label invoiceAmountLabel;
        private System.Windows.Forms.Label invoiceNumberLabel;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button generateInvoiceNumberButton;
        private System.Windows.Forms.Button addStoreButton;
    }
}