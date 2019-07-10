using MainUI.Category;
using PriceBookClassLibrary;
using System;
using PriceBookClassLibrary.Validators;
using FluentValidation.Results;
using System.Windows.Forms;

namespace MainUI.ProductLink
{
    public partial class ProductLinkNewOrEdit : Form
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
        ProductLinkModel productLink = new ProductLinkModel();
        ProductLinkModel existingProductLink = new ProductLinkModel();
        bool newProductLink = true;

        //Methods
        //Events - Initialize
        //******************************************************************************************************
        //  1. New Product Link Initialize
        public ProductLinkNewOrEdit()
        {
            InitializeComponent();
        }
        //  2. Existing Product Link Initialize
        public ProductLinkNewOrEdit(int productLinkId)
        {
            InitializeComponent();
            this.existingProductLink = SqliteDAProductLink.GetProductLinkById(productLinkId);
            formTitleLabel.Text = "Edit Product Link";
            saveButton.Text = "Edit";
            this.newProductLink = false;
        }

        //Events - Form Load
        //******************************************************************************************************
        private void ProductLinkNewOrEdit_Load(object sender, EventArgs e)
        {
            LoadCategoryComboBox();
            if (!this.newProductLink)
            {
                SetProductLinkToDefaultValues();
            }
        }

        //  Events - Button Clicks
        //******************************************************************************************************
        //  1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetProductLinkInformation();
            if (ValidateProductLinkInformation())
            {
                if (this.newProductLink)
                {
                    saveNewProductLinkInformationToDb();
                }
                else if (!this.newProductLink)
                {
                    saveExistingProductLinkInformationToDb();
                }
            }
        }
        //  2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            if(this.newProductLink)
            {
                ClearProductLinkToBlankValues();
            }
            else if (!this.newProductLink)
            {
                SetProductLinkToDefaultValues();
            }
        }
        //  3. Add Category Button Click
        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryNewOrEdit categoryForm = new CategoryNewOrEdit();
            categoryForm.ShowDialog();
            LoadCategoryComboBox();
        }

        //Other Methods
        //******************************************************************************************************
        //  Wire up the combo boxes in the form.
        private void LoadCategoryComboBox()
        {
            categoryComboBox.DataSource = SqliteDACategory.GetSubcategoryOnly();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";
        }
        //  When the user is editing an existing product link, this method helps to return to the original values
        //  at the start of the editing process. This method helps when the user made an error and wishes to return
        //  back to default.
        private void SetProductLinkToDefaultValues()
        {
            productLinkNameTextBox.Text = this.existingProductLink.Name;
            uomComboBox.SelectedIndex = uomComboBox.FindStringExact(this.existingProductLink.UoM);
            if(this.existingProductLink.Weighted == "Weighted")
            {
                weightedCheckBox.Checked = true;
            } else if(this.existingProductLink.Weighted == "Pre-Packaged")
            {
                weightedCheckBox.Checked = false;
            }
            measurementRateTextBox.Text = this.existingProductLink.MeasurementRate.ToString();
            categoryComboBox.SelectedIndex = categoryComboBox.FindStringExact(this.existingProductLink.CategoryName);
        }
        //  When the user is creating a new product link, this method helps to erase all the information in the form's
        //  controls. This method helps the user to clear whatever mistakes were made.
        private void ClearProductLinkToBlankValues()
        {
            productLinkNameTextBox.ResetText();
            weightedCheckBox.Checked = false;
            measurementRateTextBox.ResetText();
            categoryComboBox.SelectedIndex = 0;
            uomComboBox.SelectedIndex = 0;
        }
        //  This method copies all the information from the form's controls (user input) and places it into a product 
        //  link object. 
        private void SetProductLinkInformation()
        {
            if(int.TryParse(measurementRateTextBox.Text, out int result))
            {
                this.productLink.MeasurementRate = result;
            }
            this.productLink.Name = productLinkNameTextBox.Text;
            this.productLink.UoM = uomComboBox.Text;
            if (weightedCheckBox.CheckState == CheckState.Checked)
            {
                this.productLink.Weighted = "Weighted";
            }
            else
            {
                this.productLink.Weighted = "Pre-Packaged";
            }
            this.productLink.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            if (!this.newProductLink)
            {
                this.productLink.Id = this.existingProductLink.Id;
            }
        }
        //  This checks whether the user's input is valid before committing anything to the database.
        private bool ValidateProductLinkInformation()
        {
            // Validate my data and save in the results variable
            ProductLinkValidator productLinkValidator = new ProductLinkValidator();
            var results = productLinkValidator.Validate(this.productLink);

            // Check if the validator found any validation errors. 
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show($"{ failure.ErrorMessage }", "Product Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        //  This method saves the new product link information, which was added by the user, to the database.
        private void saveNewProductLinkInformationToDb()
        {
            if (SqliteDAProductLink.SaveProductLink(this.productLink) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("New product link created successfully", "New Product Link",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. New product link could not be saved.\nCheck the error log for more information.", "New Product Link Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //  This method saves the updated product link information to the database. 
        private void saveExistingProductLinkInformationToDb()
        {
            if (SqliteDAProductLink.UpdateProductLinkById(productLink))
            {
                DialogResult dialogResult = MessageBox.Show("New product link updated successfully", "Edit Product Link",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. Product link could not be updated.\nCheck the error log for more information.", "Edit Product Link Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
