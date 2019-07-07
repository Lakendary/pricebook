using PriceBookClassLibrary;
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
    public partial class ProductAndProductLinkNewOrEdit : Form
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
        public ProductLinkModel productLink = new ProductLinkModel();
        public List<ProductLinkModel> searchResultProductLinks = new List<ProductLinkModel>();
        //  ProductModel existingProduct = new ProductModel();
        //  bool isNewProduct = true;

        public ProductAndProductLinkNewOrEdit()
        {
            InitializeComponent();
            SetDefaultFormLayout();
        }

        private void SetDefaultFormLayout()
        {
            productGroupBox.Enabled = false;
            productLinkTabControl.SelectedTab = findTabPage;
            ActiveControl = findProductLinkNameTextBox;
        }

        private void findProductLinkNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  Search for product links
                SearchForProductLinks();
            }
        }

        private void findCategoryComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //  Search for product links
                SearchForProductLinks();
            }
        }

        private void findWeightedCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  Search for product links
                SearchForProductLinks();
            }
        }

        private void findSearchButton_Click(object sender, EventArgs e)
        {
            SearchForProductLinks();
        }

        private void SearchForProductLinks()
        {
            SetProductLinkSearchTerm();
            GetListOfProductLinks();
            PopulateDGVWithSearchResults();
        }

        private void SetProductLinkSearchTerm()
        {
            this.productLink.Name = findProductLinkNameTextBox.Text;
            this.productLink.CategoryName = findCategoryComboBox.Text;
            if(findWeightedCheckBox.CheckState == CheckState.Checked)
            {
                this.productLink.Weighted = "Weighted";
            } else if(findWeightedCheckBox.CheckState == CheckState.Unchecked)
            {
                this.productLink.Weighted = "Pre-Packaged";
            }
        }

        private void GetListOfProductLinks()
        {
            searchResultProductLinks = SqliteDAProductLink.GetAllProductLinks(productLink);
        }

        private void PopulateDGVWithSearchResults()
        {
            findProductLinkDataGridView.DataSource = this.searchResultProductLinks;
            findProductLinkDataGridView.AutoResizeColumns();
            findProductLinkDataGridView.Columns["Id"].Visible = false;
            findProductLinkDataGridView.Columns["CategoryId"].Visible = false;
            findProductLinkDataGridView.Columns["Deleted"].Visible = false;
        }

        

        //  The user clicks add new product on the product search form. This form loads
        //  TODO: Update click event in the product search form to show the new product and product link page

        //  TODO: The product group box should be disabled until a product link is selected
        //  TODO: Show the user the product link search controls in the product link find tab page

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
