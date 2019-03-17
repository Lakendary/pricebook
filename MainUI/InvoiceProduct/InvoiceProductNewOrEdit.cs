using PriceBookClassLibrary;
using System;
using System.Windows.Forms;
using FluentValidation.Results;
using PriceBookClassLibrary.Validators;

namespace MainUI.InvoiceProduct
{
    public partial class InvoiceProductNewOrEdit : Form
    {
        //******************************************************************************************************
        //  Index
        //******************************************************************************************************
        //  1. Global variables
        //  2. Events Initialize methods
        //  3. Form Load Event
        //  4. Mouse Button Clicks
        //  5. Other Event Methods
        //  6. Other Methods
        //******************************************************************************************************

        //  Global variables
        //******************************************************************************************************
        ProductModel product = new ProductModel();
        int invoiceId = 0;
        InvoiceProductModel invoiceProduct = new InvoiceProductModel();
        InvoiceProductModel existingInvoiceProduct = new InvoiceProductModel();
        bool newInvoiceProduct = true;

        //  Methods
        //  Events - Initialize
        //******************************************************************************************************
        //  1. New Invoice Product Initialize
        public InvoiceProductNewOrEdit(ProductModel product, int invoiceId)
        {
            InitializeComponent();
            this.product = product;
            this.invoiceId = invoiceId;
        }
        //  2. Existing Invoice Product Initialize
        public InvoiceProductNewOrEdit(int invoiceProductId)
        {
            InitializeComponent();
            this.existingInvoiceProduct = SqliteDAInvoiceProduct.GetInvoiceProductById(invoiceProductId);
            //  Required to display the product information on the form when editing an invoice product.
            this.product = SqliteDAProduct.GetProductById(this.existingInvoiceProduct.ProductId);
            this.invoiceId = this.existingInvoiceProduct.InvoiceId;
            formTitleLabel.Text = "Edit Invoice Product";
            saveButton.Text = "Edit";
            this.newInvoiceProduct = false;
        }

        //  Events - Form Load
        //******************************************************************************************************
        private void InvoiceProductNewOrEdit_Load(object sender, EventArgs e)
        {
            LoadProductDetails();
            if (!this.newInvoiceProduct)
            {
                SetInvoiceProductDefaultValues();
            }
        }
        
        //  Events - Button Clicks
        //******************************************************************************************************
        //  1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetInvoiceProductInformation();
            if (ValidateInvoiceProductInformation())
            {
                if (this.newInvoiceProduct)
                {
                    saveNewInvoiceProductInformationToDb();
                }
                else if (!this.newInvoiceProduct)
                {
                    saveExistingInvoiceProductInformationToDb();
                }
            }
        }
        //  2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (this.newInvoiceProduct)
            {
                ClearInvoiceProductToBlankValue();
            }
            else if (!this.newInvoiceProduct)
            {
                SetInvoiceProductDefaultValues();
            }
        }

        //  Other Methods
        //******************************************************************************************************
        //  Wire up the product details labels with the product from the database. 
        private void LoadProductDetails()
        {
            productFullNameLabel.Text = string.Format("{0} {1}", product.BrandName, product.Description);
            uomLabel.Text = product.UoM;
            if (product.Weighted == "Weighted")
            {
                weightTextBox.Enabled = true;
            }
            else if (product.Weighted == "Pre-Packaged")
            {
                weightTextBox.Enabled = false;
            }
        }
        //  Reset to default values (existing invoice)
        private void SetInvoiceProductDefaultValues()
        {
            productFullNameLabel.Text = invoiceProduct.ProductName;
            quantityTextBox.Text = invoiceProduct.Quantity.ToString();
            //Make sure only weighted products can be edited and show no weight for pre-packaged products (0 throws an error)
            if (invoiceProduct.Weighted == "Pre-Packaged")
            {
                weightTextBox.Text = "";
                weightTextBox.Enabled = false;
            }
            else
            {
                weightTextBox.Text = invoiceProduct.Weight.ToString();
            }
            totalPriceTextBox.Text = invoiceProduct.TotalPrice.ToString();
            uomLabel.Text = invoiceProduct.UoM;
            if (invoiceProduct.Sale == "Sale")
            {
                saleCheckBox.Checked = true;
            }
            else if (invoiceProduct.Sale == "Regular")
            {
                saleCheckBox.Checked = false;
            }
        }
        //  Clear to blank form
        private void ClearInvoiceProductToBlankValue()
        {
            quantityTextBox.ResetText();
            totalPriceTextBox.ResetText();
            weightTextBox.ResetText();
            saleCheckBox.Checked = false;
        }
        //  Store user input into the invoice product object.
        private void SetInvoiceProductInformation()
        {
            this.invoiceProduct.InvoiceId = invoiceId;
            this.invoiceProduct.ProductId = product.Id;
            this.invoiceProduct.Quantity = CheckIfQuantityIsANumber();
            this.invoiceProduct.TotalPrice = Convert.ToDecimal(totalPriceTextBox.Text);
            if (weightTextBox.Text != "")
            {
                this.invoiceProduct.Weight = Convert.ToInt32(weightTextBox.Text);
            }
            if (saleCheckBox.Checked == true)
            {
                this.invoiceProduct.Sale = "Sale";
            }
            else if (saleCheckBox.Checked == false)
            {
                this.invoiceProduct.Sale = "Regular";
            }
            if (!this.newInvoiceProduct)
            {
                invoiceProduct.Id = this.existingInvoiceProduct.Id;
            }
        }
        //  Verify that invoice product object has valid information before committing to the database.
        private bool ValidateInvoiceProductInformation()
        {
            // Validate my data and save in the results variable
            InvoiceProductValidator invoiceProductValidator = new InvoiceProductValidator();
            var results = invoiceProductValidator.Validate(this.invoiceProduct);

            // Check if the validator found any validation errors. 
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show($"{ failure.ErrorMessage }", "Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        //  Commit to database - new invoice product
        private void saveNewInvoiceProductInformationToDb()
        {
            if (SqliteDAInvoiceProduct.SaveInvoiceProduct(invoiceProduct))
            {
                DialogResult dialogResult = MessageBox.Show("New invoice product created successfully", "New Invoice Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. New invoice product could not be saved." +
                    "\nCheck the error log for more information.", "New Invoice Product Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //  Commit to databse - existing invoice product
        private void saveExistingInvoiceProductInformationToDb()
        {
            if (SqliteDAInvoiceProduct.UpdateInvoiceProductById(invoiceProduct))
            {
                DialogResult dialogResult = MessageBox.Show("Invoice product updated successfully", "Edit Invoice Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. Invoice product update could not be saved." +
                    "\nCheck the error log for more information.", "Edit Invoice Product Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //  Return a positive number or an error if conversion cannot happen.
        private int CheckIfQuantityIsANumber()
        {
            if (!int.TryParse(quantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Please enter a number.", "Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //  Convert any negative number into a positive one before returning it
            if(quantity < 0)
            {
                quantity = quantity * -1;
            }
            return quantity;
        }
    }
}
