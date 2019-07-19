using FluentValidation.Results;
using MainUI.ProductLink;
using PriceBookClassLibrary;
using PriceBookClassLibrary.Validators;
using System;
using System.Windows.Forms;

namespace MainUI.Product
{
    public partial class ProductNewOrEdit : Form
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
        public ProductModel product { get; set; }  = new ProductModel();
        ProductModel existingProduct = new ProductModel();
        bool isNewProduct = true;

        //  Methods
        //  Events - Initialize
        //******************************************************************************************************
        //  1. New Product Initialize
        public ProductNewOrEdit()
        {
            InitializeComponent();
        }
        //  2. Existing Product Initialize
        //  Initiated when the user clicks edit on the main ui and passes a product to edit.
        public ProductNewOrEdit(int productId)
        {
            InitializeComponent();
            formTitleLabel.Text = "Edit Product";
            saveButton.Text = "Edit";
            this.existingProduct = SqliteDAProduct.GetProductById(productId);
            isNewProduct = false;
            addBarcodeButton.Enabled = true;
            deleteBarcodeButton.Enabled = true;
        }
        //  3. Existing Product Initialize (From Product Search Form)
        public ProductNewOrEdit(string barcode)
        {
            InitializeComponent();
            barcodeComboBox.Text = barcode;
        }

        //  Events - Form Load
        //******************************************************************************************************
        private void ProductNewOrEdit_Load(object sender, EventArgs e)
        {
            loadProductLinkComboBox();
            loadBarcodeComboBox();
            if (!this.isNewProduct)
            {
                SetProductToDefaultValues();
            }
        }

        //  Events - Button Clicks
        //******************************************************************************************************
        //  1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetProductInformation();
            if (ValidateProductInformation())
            {
                if (this.isNewProduct)
                {
                    saveNewProductInformationToDb();
                }
                else if (!this.isNewProduct)
                {
                    saveExistingProductInformationToDb();
                } 
            }
        }
        //  2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (this.isNewProduct)
            {
                ClearProductToBlankValues();
            }
            else if (!this.isNewProduct)
            {
                SetProductToDefaultValues();
            }
        }
        //  3. Add Product Link Button Click
        private void addProductLinkButton_Click(object sender, EventArgs e)
        {
            ProductLinkNewOrEdit productLinkForm = new ProductLinkNewOrEdit();
            productLinkForm.ShowDialog();
            loadProductLinkComboBox();
        }
        //  4. Add Barcode Button Click
        private void addBarcodeButton_Click(object sender, EventArgs e)
        {
            //Open the add new barcode form.
            AddBarcode addBarcodeForm = new AddBarcode(this.existingProduct.Id);
            addBarcodeForm.ShowDialog();
            loadBarcodeComboBox();
        }
        //  5. Delete Barcode Button Click
        private void deleteBarcodeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this barcode?",
                    "Delete Barcode", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (SqliteDataAccessBarcode.DeleteBarcodeById(Convert.ToInt32(barcodeComboBox.SelectedValue)))
                {
                    DialogResult dialog = MessageBox.Show("Barcode was successfully deleted.", "Delete Barcode", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBarcodeComboBox();
                    barcodeComboBox.ResetText();
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Something went wrong. Barcode could not be deleted.\nCheck the error log for more information.",
                        "Delete Barcode Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //  Other Event Methods
        //******************************************************************************************************
        //  Change Unit of measure label according to the selected product link's uom value.
        private void productLinkComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //look for a product link object by the combobox's value
            if(productLinkComboBox.Items.Count > 0)
            {
                if (Int32.TryParse(productLinkComboBox.SelectedValue.ToString(), out int number))
                {
                    ProductLinkModel productLink = new ProductLinkModel();
                    productLink = SqliteDAProductLink.GetProductLinkById(number);
                    //change the uom label text value to product link object's uom
                    uomLabel.Text = productLink.UoM.ToString();
                }
                else
                {
                    uomLabel.Text = "";
                }
            }
        }

        //  Other Methods
        //******************************************************************************************************
        //  Wire up the barcode combo box with a list of barcodes for this product from the database.
        private void loadBarcodeComboBox()
        {
            barcodeComboBox.DataSource = SqliteDataAccessBarcode.GetBarcodesByProductId(this.existingProduct.Id);
            barcodeComboBox.DisplayMember = "Barcode";
            barcodeComboBox.ValueMember = "Id";
        }
        //  Wire up the product link combo box with a list of all active product links from the database.
        private void loadProductLinkComboBox()
        {
            productLinkComboBox.DataSource = SqliteDAProductLink.GetAllProductLinks();
            productLinkComboBox.ValueMember = "Id";
            productLinkComboBox.DisplayMember = "Name";
        }
        //  Reset to default values (existing product)
        private void SetProductToDefaultValues()
        {
            productDescriptionTextBox.Text = this.existingProduct.Description;
            brandNameTextBox.Text = this.existingProduct.BrandName;
            packSizeTextBox.Text = this.existingProduct.PackSize.ToString();
            productLinkComboBox.SelectedIndex = productLinkComboBox.FindStringExact(this.existingProduct.ProductLinkName);
            loadBarcodeComboBox();
        }
        //  Clear to blank form
        private void ClearProductToBlankValues()
        {
            brandNameTextBox.ResetText();
            packSizeTextBox.ResetText();
            productDescriptionTextBox.ResetText();
            productLinkComboBox.SelectedIndex = 0;
        }
        //  Store user input into the product object.
        private void SetProductInformation()
        {
            this.product.BrandName = brandNameTextBox.Text;
            this.product.Description = productDescriptionTextBox.Text;
            if (int.TryParse(packSizeTextBox.Text, out int result))
            {
                this.product.PackSize = result;
            }
            this.product.ProductLinkId = Convert.ToInt32(productLinkComboBox.SelectedValue);
            if (!isNewProduct)
            {
                this.product.Id = this.existingProduct.Id;
            }
        }
        //  Verify that product object has valid information before committing to the database.
        private bool ValidateProductInformation()
        {
            // Validate my data and save in the results variable
            ProductValidator productValidator = new ProductValidator();
            var results = productValidator.Validate(this.product);

            // Check if the validator found any validation errors. 
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show($"{ failure.ErrorMessage }", "Product Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        //  Commit to database - new product
        private void saveNewProductInformationToDb()
        {
            //Save the product that was just created. Check whether the product saved correctly.
            int id = SqliteDAProduct.SaveProductAndGetId(this.product);
            if (id != 0)
            {
                DialogResult dialogResult = MessageBox.Show("New product created successfully", "New Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    //Set the product id variable equal to the product id saved to the database. The forms product id can be accessed by other forms that need it.
                    this.product.Id = id;
                    if (barcodeComboBox.Text != "")
                    {
                        BarcodeModel barcode = new BarcodeModel();
                        barcode.Barcode = barcodeComboBox.Text;
                        barcode.ProductId = id;
                        SqliteDataAccessBarcode.SaveBarcode(barcode);
                    }
                    this.Close();
                }
            }
            else if (id == 0)
            {
                MessageBox.Show("Something went wrong. New product could not be saved.\nCheck the error log for more information.", "New Product Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Commit to databse - existing product
        private void saveExistingProductInformationToDb()
        {
            if (SqliteDAProduct.UpdateProductById(product))
            {
                DialogResult dialogResult = MessageBox.Show("Product updated successfully.", "Edit Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. Product could not be updated.\nCheck the error log for more information.", "Edit Product Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
