﻿using FluentValidation.Results;
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
        //  5. Other Methods
        //******************************************************************************************************
        //Global variables
        //******************************************************************************************************
        public ProductModel product { get; set; }  = new ProductModel();
        ProductModel existingProduct = new ProductModel();
        bool newProduct = true;

        //Methods
        //Events - Initialize
        //******************************************************************************************************
        public ProductNewOrEdit()
        {
            InitializeComponent();
        }

        //Initiated when the user clicks edit on the main ui and passes a product to edit.
        public ProductNewOrEdit(int productId)
        {
            InitializeComponent();
            formTitleLabel.Text = "Edit Product";
            saveButton.Text = "Edit";
            this.existingProduct = SqliteDAProduct.GetProductById(productId);
            newProduct = false;
            addBarcodeButton.Enabled = true;
            deleteBarcodeButton.Enabled = true;
        }

        //  TODO: Find out when this method is called.
        public ProductNewOrEdit(string barcode)
        {
            InitializeComponent();
            barcodeComboBox.Text = barcode;
        }

        //Events - Form Load
        //******************************************************************************************************
        private void ProductNewOrEdit_Load(object sender, EventArgs e)
        {
            loadProductLinkComboBox();
            loadBarcodeComboBox();
            if (!this.newProduct)
            {
                SetProductToDefaultValues();
            }
        }

        //Events - Button Clicks
        //******************************************************************************************************
        //1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetProductInformation();
            if (ValidateProductInformation())
            {
                if (this.newProduct)
                {
                    saveNewProductInformationToDb();
                }
                else if (!this.newProduct)
                {
                    saveExistingProductInformationToDb();
                } 
            }
        }

        //2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (this.newProduct)
            {
                ClearProductToBlankValues();
            }
            else if (!this.newProduct)
            {
                SetProductToDefaultValues();
            }
        }

        //3. Add Product Link Button Click
        private void addProductLinkButton_Click(object sender, EventArgs e)
        {
            ProductLinkNewOrEdit productLinkForm = new ProductLinkNewOrEdit();
            productLinkForm.ShowDialog();
            loadProductLinkComboBox();
        }

        //4. Add Barcode Button Click
        private void addBarcodeButton_Click(object sender, EventArgs e)
        {
            //Open the add new barcode form.
            AddBarcode addBarcodeForm = new AddBarcode(this.existingProduct.Id);
            addBarcodeForm.ShowDialog();
            loadBarcodeComboBox();
        }

        //5. Delete Barcode Button Click
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

        //Other Event Methods
        //******************************************************************************************************
        //Change Unit of measure label according to product link selected
        private void productLinkComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //look for a product link object by the combobox's value
            ProductLinkModel productLink = new ProductLinkModel();

            if (Int32.TryParse(productLinkComboBox.SelectedValue.ToString(), out int number))
            {
                productLink = SqliteDAProductLink.GetProductLinkById(number);
                //change the uom label text value to product link object's uom
                uomLabel.Text = productLink.UoM.ToString();
            }
            else
            {
                uomLabel.Text = "";
            }
        }

        //Other Methods
        //******************************************************************************************************
        private void loadBarcodeComboBox()
        {
            barcodeComboBox.DataSource = SqliteDataAccessBarcode.GetBarcodesByProductId(this.existingProduct.Id);
            barcodeComboBox.DisplayMember = "Barcode";
            barcodeComboBox.ValueMember = "Id";
        }

        private void loadProductLinkComboBox()
        {
            productLinkComboBox.DataSource = SqliteDAProductLink.GetAllProductLinks();
            productLinkComboBox.ValueMember = "Id";
            productLinkComboBox.DisplayMember = "Name";
        }

        private void SetProductToDefaultValues()
        {
            productDescriptionTextBox.Text = this.existingProduct.Description;
            brandNameTextBox.Text = this.existingProduct.BrandName;
            packSizeTextBox.Text = this.existingProduct.PackSize.ToString();
            productLinkComboBox.SelectedIndex = productLinkComboBox.FindStringExact(this.existingProduct.ProductLinkName);
            loadBarcodeComboBox();
        }

        private void ClearProductToBlankValues()
        {
            brandNameTextBox.ResetText();
            packSizeTextBox.ResetText();
            productDescriptionTextBox.ResetText();
            productLinkComboBox.SelectedIndex = 0;
        }

        private void SetProductInformation()
        {
            this.product.BrandName = brandNameTextBox.Text;
            this.product.Description = productDescriptionTextBox.Text;
            if (int.TryParse(packSizeTextBox.Text, out int result))
            {
                this.product.PackSize = result;
            }
            this.product.ProductLinkId = Convert.ToInt32(productLinkComboBox.SelectedValue);
            if (!newProduct)
            {
                this.product.Id = this.existingProduct.Id;
            }
        }

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
