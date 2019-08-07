using FluentValidation.Results;
using MainUI.Category;
using PriceBookClassLibrary;
using PriceBookClassLibrary.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainUI.Product
{
    public partial class NewProduct : Form
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
        public ProductModel product { get; set; } = new ProductModel();
        //  ProductModel existingProduct = new ProductModel();
        //  bool isNewProduct = true;

        public NewProduct()
        {
            InitializeComponent();
            SetDefaultFormLayout();
        }

        private void SetDefaultFormLayout()
        {
            productGroupBox.Enabled = false;
            productLinkTabControl.SelectedTab = findTabPage;
            ActiveControl = findProductLinkNameTextBox;
            LoadNewCategoryComboBox();
            LoadFindCategoryComboBox();
        }

        private void LoadNewCategoryComboBox()
        {
            newCategoryComboBox.DataSource = SqliteDACategory.GetSubcategoryOnly();
            newCategoryComboBox.DisplayMember = "Name";
            newCategoryComboBox.ValueMember = "Id";
        }

        private void LoadFindCategoryComboBox()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            //Combo box selection option. If the user wants to search for a product in all categories,
            //<ALL> can be chosen.
            CategoryModel category = new CategoryModel();
            category.Id = 0;
            category.Name = "<ALL>";

            //Load Combo Boxes. Add <ALL> option at the beginning of list.
            categories = SqliteDACategory.GetSubcategoryOnly();
            categories.Insert(0, category);
            findCategoryComboBox.DataSource = categories;
            findCategoryComboBox.ValueMember = "Id";
            findCategoryComboBox.DisplayMember = "Name";

            //Default Selected Index
            findCategoryComboBox.SelectedIndex = 0;
            findCategoryComboBox.SelectedIndex = 0;
        }

        private void findProductLinkNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  Search for product links
                SearchForProductLinks();
            }
            else if (e.KeyCode == Keys.F2)
            {
                AddNewProductLink();
            }
        }

        private void findCategoryComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //  Search for product links
                SearchForProductLinks();
            }
            else if (e.KeyCode == Keys.F2)
            {
                AddNewProductLink();
            }
        }

        private void findWeightedCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  Search for product links
                SearchForProductLinks();
            }
            else if (e.KeyCode == Keys.F2)
            {
                AddNewProductLink();
            }
        }

        private void findSearchButton_Click(object sender, EventArgs e)
        {
            SearchForProductLinks();
        }

        private void AddNewProductLink()
        {
            productLinkTabControl.SelectedTab = newTabPage;
            ActiveControl = newProductLinkNameTextBox;
        }

        private void SearchForProductLinks()
        {
            ProductLinkModel productLink = new ProductLinkModel();
            List<ProductLinkModel> searchResultProductLinks = new List<ProductLinkModel>();

            productLink = SetProductLinkSearchTerm(productLink);
            searchResultProductLinks = GetListOfProductLinks(productLink, searchResultProductLinks);
            PopulateDGVWithSearchResults(searchResultProductLinks);
        }

        private ProductLinkModel SetProductLinkSearchTerm(ProductLinkModel productLink)
        {
            productLink.Name = findProductLinkNameTextBox.Text;
            productLink.CategoryName = findCategoryComboBox.Text;
            if(findWeightedCheckBox.CheckState == CheckState.Checked)
            {
                productLink.Weighted = "Weighted";
            } else if(findWeightedCheckBox.CheckState == CheckState.Unchecked)
            {
                productLink.Weighted = "Pre-Packaged";
            }

            return productLink;
        }

        private List<ProductLinkModel> GetListOfProductLinks(ProductLinkModel productLink, 
            List<ProductLinkModel> searchResultProductLinks)
        {
            searchResultProductLinks = SqliteDAProductLink.GetAllProductLinks(productLink);

            return searchResultProductLinks;
        }

        private void PopulateDGVWithSearchResults(List<ProductLinkModel> searchResultProductLinks)
        {
            findProductLinkDataGridView.DataSource = searchResultProductLinks;
            FormatFindDGVHeaders();
            ActiveControl = findProductLinkDataGridView;
        }

        private void FormatFindDGVHeaders()
        {
            HideColumnsFromDGV();
            ChangeColumnOrderOfDGV();
            ChangeColumnNames();
            findProductLinkDataGridView.AutoResizeColumns();
        }

        private void HideColumnsFromDGV()
        {
            //  Hide columns that shouldn't be displayed in the UI 
            findProductLinkDataGridView.Columns["Id"].Visible = false;
            findProductLinkDataGridView.Columns["CategoryId"].Visible = false;
            findProductLinkDataGridView.Columns["Deleted"].Visible = false;
        }

        private void ChangeColumnOrderOfDGV()
        {
            findProductLinkDataGridView.Columns["Name"].DisplayIndex = 0;
            findProductLinkDataGridView.Columns["Weighted"].DisplayIndex = 1;
            findProductLinkDataGridView.Columns["CategoryName"].DisplayIndex = 2;
            findProductLinkDataGridView.Columns["UoM"].DisplayIndex = 3;
            findProductLinkDataGridView.Columns["MeasurementRate"].DisplayIndex = 4;
        }

        private void ChangeColumnNames()
        {
            findProductLinkDataGridView.Columns["Name"].HeaderText = "Name";
            findProductLinkDataGridView.Columns["Weighted"].HeaderText = "Weighted";
            findProductLinkDataGridView.Columns["CategoryName"].HeaderText = "Category" + Environment.NewLine + "Name";
            findProductLinkDataGridView.Columns["UoM"].HeaderText = "Unit of" + Environment.NewLine + "Measure";
            findProductLinkDataGridView.Columns["MeasurementRate"].HeaderText = "Measurement " + Environment.NewLine + "Rate";
        }

        private void findProductLinkDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetProductLink();
            }
            else if (e.KeyCode == Keys.F2)
            {
                AddNewProductLink();
            }
            else if (e.KeyCode == Keys.Back)
            {
                ClearProductSearchToBlankValues();
            }
        }

        private ProductLinkModel GetProductLink(ProductLinkModel productLink)
        {
            //  Get Product Link Id from selected row in data grid view
            int productLinkId = 0;
            productLinkId = Convert.ToInt32(findProductLinkDataGridView.CurrentRow.Cells["Id"].Value);
            productLink = SqliteDAProductLink.GetProductLinkById(productLinkId);
            return productLink;
        }

        private void DisplaySelectedProductLink(ProductLinkModel productLink)
        {
            detailCategoryLabel2.Text = productLink.CategoryName;
            detailMeasurementRateLabel2.Text = productLink.MeasurementRate.ToString();
            detailProductLinkNameLabel2.Text = productLink.Name;
            detailUnitOfMeasureLabel2.Text = productLink.UoM;
            detailWeightedLabel2.Text = productLink.Weighted;
            detailProductLinkIdLabel2.Text = productLink.Id.ToString();
            uomLabel.Text = productLink.UoM;
            productLinkTabControl.SelectedTab = detailTabPage;
        }

        private void findResetButton_Click(object sender, EventArgs e)
        {
            ClearProductSearchToBlankValues();
        }

        private void ClearProductSearchToBlankValues()
        {
            findCategoryComboBox.SelectedIndex = 0;
            findProductLinkNameTextBox.ResetText();
            findWeightedCheckBox.Checked = false;
            ActiveControl = findProductLinkNameTextBox;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SetProductLink();
        }

        private void SetProductLink()
        {
            
            if (findProductLinkDataGridView.SelectedRows.Count > 0)
            {
                ProductLinkModel productLink = new ProductLinkModel();
                productLink = GetProductLink(productLink);
                DisplaySelectedProductLink(productLink);
                productGroupBox.Enabled = true;
                ActiveControl = productDescriptionTextBox;
            }
            else
            {
                MessageBox.Show("First select a product link in the table below before clicking select",
                    "Price Link Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newSaveButton_Click(object sender, EventArgs e)
        {
            SaveNewProductLinkToDb();
        }

        private void SaveNewProductLinkToDb()
        {
            ProductLinkModel productLink = new ProductLinkModel();
            productLink = SetNewProductLinkInformation(productLink);
            if(ValidateProductLinkInformation(productLink) == true)
            {
               productLink = SaveProductLinkToDb(productLink);
            }
            if(productLink.Id > 0)
            {
                DisplaySelectedProductLink(productLink);
                productGroupBox.Enabled = true;
                ActiveControl = productDescriptionTextBox;
                if(productLink.Weighted == "Weighted")
                {
                    packSizeTextBox.Enabled = false;
                    packSizeTextBox.Text = "1";
                }
            }
        }

        private ProductLinkModel SetNewProductLinkInformation(ProductLinkModel productLink)
        {
            productLink.CategoryId = Convert.ToInt32(newCategoryComboBox.SelectedValue);
            productLink.CategoryName = newCategoryComboBox.Text;
            if (int.TryParse(newMeasurementRateTextBox.Text, out int result))
            {
                productLink.MeasurementRate = result;
            }
            productLink.Name = newProductLinkNameTextBox.Text;
            productLink.UoM = newUomComboBox.Text;
            if (newWeightedCheckBox.CheckState == CheckState.Checked)
            {
                productLink.Weighted = "Weighted";
            }
            else if (newWeightedCheckBox.CheckState == CheckState.Unchecked)
            {
                productLink.Weighted = "Pre-Packaged";
            }

            return productLink;
        }
        //  This checks whether the user's input is valid before committing anything to the database.
        private bool ValidateProductLinkInformation(ProductLinkModel productLink)
        {
            // Validate my data and save in the results variable
            ProductLinkValidator productLinkValidator = new ProductLinkValidator();
            var results = productLinkValidator.Validate(productLink);

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

        private ProductLinkModel SaveProductLinkToDb(ProductLinkModel productLink)
        {
            int productLinkId = SqliteDAProductLink.SaveProductLink(productLink);
            if (productLinkId > 0)
            {
                MessageBox.Show("New product link created successfully", "New Product Link",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                productLink.Id = productLinkId;
            }
            else
            {
                MessageBox.Show("Something went wrong. New product link could not be saved.\nCheck the error log for more information.", "New Product Link Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return productLink;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveNewProductToDb();
        }

        private void SaveNewProductToDb()
        {
            //ProductModel product = new ProductModel();
            this.product = SetNewProductInformation(this.product);
            if(ValidateProductInformation(this.product) == true)
            {
                saveNewProductInformationToDb(this.product);
            }
        }

        private ProductModel SetNewProductInformation(ProductModel product)
        {
            product.BrandName = brandNameTextBox.Text;
            product.Description = productDescriptionTextBox.Text;
            if (int.TryParse(packSizeTextBox.Text, out int result))
            {
                product.PackSize = result;
            }
            product.ProductLinkId = Convert.ToInt32(detailProductLinkIdLabel2.Text);

            return product;
        }

        private bool ValidateProductInformation(ProductModel product)
        {
            // Validate my data and save in the results variable
            ProductValidator productValidator = new ProductValidator();
            var results = productValidator.Validate(product);

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

        private void saveNewProductInformationToDb(ProductModel product)
        {
            //Save the product that was just created. Check whether the product saved correctly.
            int id = SqliteDAProduct.SaveProductAndGetId(product);
            if (id != 0)
            {
                DialogResult dialogResult = MessageBox.Show("New product created successfully", "New Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    //Set the product id variable equal to the product id saved to the database. The forms product id can be accessed by other forms that need it.
                    product.Id = id;
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

        private void newResetButton_Click(object sender, EventArgs e)
        {
            ClearNewProductLinkToBlankValues();
        }

        private void ClearNewProductLinkToBlankValues()
        {
            newProductLinkNameTextBox.ResetText();
            newUomComboBox.SelectedIndex = 0;
            newWeightedCheckBox.Checked = false;
            newMeasurementRateTextBox.ResetText();
            newCategoryComboBox.SelectedIndex = 0;
            ActiveControl = newProductLinkNameTextBox;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ClearNewProductToBlankValues();
        }

        private void ClearNewProductToBlankValues()
        {
            productDescriptionTextBox.ResetText();
            brandNameTextBox.ResetText();
            packSizeTextBox.ResetText();
            barcodeComboBox.ResetText();
            ActiveControl = productDescriptionTextBox;
        }

        private void newAddCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryNewOrEdit categoryForm = new CategoryNewOrEdit();
            categoryForm.ShowDialog();
            LoadNewCategoryComboBox();
        }

        //  The user clicks add new product on the product search form. This form loads

        //  1. User searches for a product link
        //  a. User types in the search term in the product link description text box
        //  b. User selects a category from the product link category combo box
        //  c. User ticks the product link weighted check box if the product link is weighted
        //  d. User presses enter to search or clicks the search button
        //  e. User selects the product link from the list in the data grid view
        //  f. User resets the product link search term information and searches again


        //  2. User creates a new product link
        //  a. User clicks the create product link button or presses F2 on the keyboard
        //  b. Show the user the product link new tab page and its controls
        //  c. User completes the information for the new product link
        //  d. User saves the product link information to the database
        //  e. The product link information is validated
        //  f. User resets the product link information

        //  TODO: Show the product link information in the product link detail tab page
        //  TODO: Activate the product group box

        //  3. User completes information for new product
        //  a. User resets the product information
        //  b. User saves the product information to the database 

        //  TODO: Validate product information before committing the product information to the database
        //  TODO: Close form
    }
}
