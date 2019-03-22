namespace MainUI.Report
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.reportTabControl = new System.Windows.Forms.TabControl();
            this.invoiceProductsTabPage = new System.Windows.Forms.TabPage();
            this.consumptionTabPage = new System.Windows.Forms.TabPage();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.deletedCheckBox = new System.Windows.Forms.CheckBox();
            this.savedCheckBox = new System.Windows.Forms.CheckBox();
            this.storeNameComboBox = new System.Windows.Forms.ComboBox();
            this.storeNameLabel = new System.Windows.Forms.Label();
            this.storeLocationLabel = new System.Windows.Forms.Label();
            this.storeLocationComboBox = new System.Windows.Forms.ComboBox();
            this.subcategoryLabel = new System.Windows.Forms.Label();
            this.subcategoryComboBox = new System.Windows.Forms.ComboBox();
            this.productLinkLabel = new System.Windows.Forms.Label();
            this.productLinkComboBox = new System.Windows.Forms.ComboBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.runReportButton = new System.Windows.Forms.Button();
            this.reportTabControl.SuspendLayout();
            this.invoiceProductsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportTabControl
            // 
            this.reportTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.reportTabControl.Controls.Add(this.invoiceProductsTabPage);
            this.reportTabControl.Controls.Add(this.consumptionTabPage);
            this.reportTabControl.Location = new System.Drawing.Point(12, 12);
            this.reportTabControl.Multiline = true;
            this.reportTabControl.Name = "reportTabControl";
            this.reportTabControl.SelectedIndex = 0;
            this.reportTabControl.Size = new System.Drawing.Size(673, 336);
            this.reportTabControl.TabIndex = 0;
            // 
            // invoiceProductsTabPage
            // 
            this.invoiceProductsTabPage.Controls.Add(this.runReportButton);
            this.invoiceProductsTabPage.Controls.Add(this.searchButton);
            this.invoiceProductsTabPage.Controls.Add(this.productTextBox);
            this.invoiceProductsTabPage.Controls.Add(this.storeLocationComboBox);
            this.invoiceProductsTabPage.Controls.Add(this.storeLocationLabel);
            this.invoiceProductsTabPage.Controls.Add(this.productLinkComboBox);
            this.invoiceProductsTabPage.Controls.Add(this.subcategoryComboBox);
            this.invoiceProductsTabPage.Controls.Add(this.storeNameComboBox);
            this.invoiceProductsTabPage.Controls.Add(this.productLinkLabel);
            this.invoiceProductsTabPage.Controls.Add(this.productLabel);
            this.invoiceProductsTabPage.Controls.Add(this.subcategoryLabel);
            this.invoiceProductsTabPage.Controls.Add(this.storeNameLabel);
            this.invoiceProductsTabPage.Controls.Add(this.savedCheckBox);
            this.invoiceProductsTabPage.Controls.Add(this.deletedCheckBox);
            this.invoiceProductsTabPage.Controls.Add(this.toDateTimePicker);
            this.invoiceProductsTabPage.Controls.Add(this.toDateLabel);
            this.invoiceProductsTabPage.Controls.Add(this.fromDateTimePicker);
            this.invoiceProductsTabPage.Controls.Add(this.fromDateLabel);
            this.invoiceProductsTabPage.Location = new System.Drawing.Point(4, 4);
            this.invoiceProductsTabPage.Name = "invoiceProductsTabPage";
            this.invoiceProductsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.invoiceProductsTabPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.invoiceProductsTabPage.Size = new System.Drawing.Size(665, 306);
            this.invoiceProductsTabPage.TabIndex = 0;
            this.invoiceProductsTabPage.Text = "Invoice Products";
            this.invoiceProductsTabPage.UseVisualStyleBackColor = true;
            // 
            // consumptionTabPage
            // 
            this.consumptionTabPage.Location = new System.Drawing.Point(4, 4);
            this.consumptionTabPage.Name = "consumptionTabPage";
            this.consumptionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.consumptionTabPage.Size = new System.Drawing.Size(665, 306);
            this.consumptionTabPage.TabIndex = 1;
            this.consumptionTabPage.Text = "Consumption";
            this.consumptionTabPage.UseVisualStyleBackColor = true;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(97, 10);
            this.fromDateTimePicker.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.fromDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(128, 25);
            this.fromDateTimePicker.TabIndex = 5;
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateLabel.Location = new System.Drawing.Point(8, 16);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(73, 17);
            this.fromDateLabel.TabIndex = 4;
            this.fromDateLabel.Text = "From Date";
            // 
            // toDateLabel
            // 
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateLabel.Location = new System.Drawing.Point(231, 16);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(56, 17);
            this.toDateLabel.TabIndex = 4;
            this.toDateLabel.Text = "To Date";
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(329, 10);
            this.toDateTimePicker.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.toDateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(128, 25);
            this.toDateTimePicker.TabIndex = 5;
            // 
            // deletedCheckBox
            // 
            this.deletedCheckBox.AutoSize = true;
            this.deletedCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletedCheckBox.Location = new System.Drawing.Point(11, 147);
            this.deletedCheckBox.Name = "deletedCheckBox";
            this.deletedCheckBox.Size = new System.Drawing.Size(75, 21);
            this.deletedCheckBox.TabIndex = 6;
            this.deletedCheckBox.Text = "Deleted";
            this.deletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // savedCheckBox
            // 
            this.savedCheckBox.AutoSize = true;
            this.savedCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedCheckBox.Location = new System.Drawing.Point(92, 147);
            this.savedCheckBox.Name = "savedCheckBox";
            this.savedCheckBox.Size = new System.Drawing.Size(63, 21);
            this.savedCheckBox.TabIndex = 6;
            this.savedCheckBox.Text = "Saved";
            this.savedCheckBox.UseVisualStyleBackColor = true;
            // 
            // storeNameComboBox
            // 
            this.storeNameComboBox.FormattingEnabled = true;
            this.storeNameComboBox.Items.AddRange(new object[] {
            "g",
            "ml",
            "ea",
            "cm"});
            this.storeNameComboBox.Location = new System.Drawing.Point(97, 41);
            this.storeNameComboBox.Name = "storeNameComboBox";
            this.storeNameComboBox.Size = new System.Drawing.Size(128, 25);
            this.storeNameComboBox.TabIndex = 24;
            // 
            // storeNameLabel
            // 
            this.storeNameLabel.AutoSize = true;
            this.storeNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeNameLabel.Location = new System.Drawing.Point(6, 44);
            this.storeNameLabel.Name = "storeNameLabel";
            this.storeNameLabel.Size = new System.Drawing.Size(80, 17);
            this.storeNameLabel.TabIndex = 25;
            this.storeNameLabel.Text = "Store Name";
            // 
            // storeLocationLabel
            // 
            this.storeLocationLabel.AutoSize = true;
            this.storeLocationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeLocationLabel.Location = new System.Drawing.Point(231, 44);
            this.storeLocationLabel.Name = "storeLocationLabel";
            this.storeLocationLabel.Size = new System.Drawing.Size(97, 17);
            this.storeLocationLabel.TabIndex = 25;
            this.storeLocationLabel.Text = "Store Location";
            // 
            // storeLocationComboBox
            // 
            this.storeLocationComboBox.FormattingEnabled = true;
            this.storeLocationComboBox.Items.AddRange(new object[] {
            "g",
            "ml",
            "ea",
            "cm"});
            this.storeLocationComboBox.Location = new System.Drawing.Point(329, 41);
            this.storeLocationComboBox.Name = "storeLocationComboBox";
            this.storeLocationComboBox.Size = new System.Drawing.Size(128, 25);
            this.storeLocationComboBox.TabIndex = 24;
            // 
            // subcategoryLabel
            // 
            this.subcategoryLabel.AutoSize = true;
            this.subcategoryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subcategoryLabel.Location = new System.Drawing.Point(6, 86);
            this.subcategoryLabel.Name = "subcategoryLabel";
            this.subcategoryLabel.Size = new System.Drawing.Size(85, 17);
            this.subcategoryLabel.TabIndex = 25;
            this.subcategoryLabel.Text = "Subcategory";
            // 
            // subcategoryComboBox
            // 
            this.subcategoryComboBox.FormattingEnabled = true;
            this.subcategoryComboBox.Items.AddRange(new object[] {
            "g",
            "ml",
            "ea",
            "cm"});
            this.subcategoryComboBox.Location = new System.Drawing.Point(97, 83);
            this.subcategoryComboBox.Name = "subcategoryComboBox";
            this.subcategoryComboBox.Size = new System.Drawing.Size(128, 25);
            this.subcategoryComboBox.TabIndex = 24;
            // 
            // productLinkLabel
            // 
            this.productLinkLabel.AutoSize = true;
            this.productLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLinkLabel.Location = new System.Drawing.Point(231, 86);
            this.productLinkLabel.Name = "productLinkLabel";
            this.productLinkLabel.Size = new System.Drawing.Size(86, 17);
            this.productLinkLabel.TabIndex = 25;
            this.productLinkLabel.Text = "Product Link";
            // 
            // productLinkComboBox
            // 
            this.productLinkComboBox.FormattingEnabled = true;
            this.productLinkComboBox.Items.AddRange(new object[] {
            "g",
            "ml",
            "ea",
            "cm"});
            this.productLinkComboBox.Location = new System.Drawing.Point(329, 83);
            this.productLinkComboBox.Name = "productLinkComboBox";
            this.productLinkComboBox.Size = new System.Drawing.Size(128, 25);
            this.productLinkComboBox.TabIndex = 24;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabel.Location = new System.Drawing.Point(10, 118);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(56, 17);
            this.productLabel.TabIndex = 25;
            this.productLabel.Text = "Product";
            // 
            // productTextBox
            // 
            this.productTextBox.Location = new System.Drawing.Point(97, 115);
            this.productTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.Size = new System.Drawing.Size(220, 25);
            this.productTextBox.TabIndex = 26;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(329, 115);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(128, 25);
            this.searchButton.TabIndex = 27;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // runReportButton
            // 
            this.runReportButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runReportButton.Location = new System.Drawing.Point(535, 274);
            this.runReportButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runReportButton.Name = "runReportButton";
            this.runReportButton.Size = new System.Drawing.Size(124, 25);
            this.runReportButton.TabIndex = 27;
            this.runReportButton.Text = "Run Report";
            this.runReportButton.UseVisualStyleBackColor = true;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 360);
            this.Controls.Add(this.reportTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.reportTabControl.ResumeLayout(false);
            this.invoiceProductsTabPage.ResumeLayout(false);
            this.invoiceProductsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl reportTabControl;
        private System.Windows.Forms.TabPage invoiceProductsTabPage;
        private System.Windows.Forms.TabPage consumptionTabPage;
        public System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Label toDateLabel;
        public System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label fromDateLabel;
        private System.Windows.Forms.CheckBox savedCheckBox;
        private System.Windows.Forms.CheckBox deletedCheckBox;
        private System.Windows.Forms.ComboBox storeNameComboBox;
        private System.Windows.Forms.Label storeNameLabel;
        private System.Windows.Forms.ComboBox storeLocationComboBox;
        private System.Windows.Forms.Label storeLocationLabel;
        private System.Windows.Forms.ComboBox productLinkComboBox;
        private System.Windows.Forms.ComboBox subcategoryComboBox;
        private System.Windows.Forms.Label productLinkLabel;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label subcategoryLabel;
        private System.Windows.Forms.TextBox productTextBox;
        private System.Windows.Forms.Button runReportButton;
        private System.Windows.Forms.Button searchButton;
    }
}