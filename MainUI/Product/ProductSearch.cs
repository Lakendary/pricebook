using PriceBookClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainUI.Product
{
    public partial class ProductSearch : Form
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
        public string barcode = "";
        public int productId { get; set; }
        DataGridViewRow row;
        public bool openNewProductForm { get; set; }
        public string mode;
        ProductModel product = new ProductModel();
        public List<ProductModel> products = new List<ProductModel>();

        //  Methods
        //  Events - Initialize
        //******************************************************************************************************
        //  1. Product Mode Initialize
        public ProductSearch(string mode)
        {
            InitializeComponent();
            this.mode = mode;
        }
        //  2. Invoice Product Mode Initialize
        public ProductSearch(string barcode, string mode)
        {
            InitializeComponent();
            this.barcode = barcode;
            this.mode = mode;
        }

        //  Events - Form Load
        //******************************************************************************************************
        private void ProductSearch_Load(object sender, EventArgs e)
        {
            loadCategoryComboBox();
        }

        //  Events - Button Clicks
        //******************************************************************************************************
        //  1. Search Button Click
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForProducts();
        }
        //  2. Search Button Click
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearProductSearchToBlankValues();
        }
        //  3. Add Product To Invoice Button Click
        private void addProductToInvoiceButton_Click(object sender, EventArgs e)
        {

            AddProductToInvoice();
            
        }
        
        //  Other Event Methods
        //******************************************************************************************************
        //  Click the Add Product Picture Box to open a new product form to add a product that doesn't exist in
        //  the database.
        private void addProductPictureBox_Click(object sender, EventArgs e)
        {
            openNewProductForm = true;
            this.Close();
        }
        //  Click the data grid view to select a product and activate the Add To Invoice button if required.
        private void productSearchDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (productSearchDataGridView.SelectedRows != null && 
                    productSearchDataGridView.SelectedRows.Count > 0 && mode == "INVOICE PRODUCT MODE")
                {
                    addProductToInvoiceButton.Enabled = true;
                }

                if (e.RowIndex >= 0)
                {
                    row = this.productSearchDataGridView.Rows[e.RowIndex];
                }
            }
            catch (System.Exception ex)
            {
                General.LogError(ex);
                MessageBox.Show("Something went wrong.\nCheck the error log for more information.", 
                    "Data Grid View Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  Other Methods
        //******************************************************************************************************
        //  Wire up the category combo box with a list of categories from the database.
        private void loadCategoryComboBox()
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
            categoryComboBox.DataSource = categories;
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DisplayMember = "Name";

            //Default Selected Index
            categoryComboBox.SelectedIndex = 0;
            weightedComboBox.SelectedIndex = 0;
        }
        //  Clear to blank search
        private void ClearProductSearchToBlankValues()
        {
            productLinkNameTextBox.ResetText();
            brandNameTextBox.ResetText();
            productDescriptionTextBox.ResetText();
            categoryComboBox.SelectedIndex = 0;
            weightedComboBox.SelectedIndex = 0;
            this.ActiveControl = productLinkNameTextBox;
        }
        //  Store user input into the product object
        private void SetProductInformation()
        {
            this.product.ProductLinkName = productLinkNameTextBox.Text;
            this.product.CategoryName = categoryComboBox.Text;
            this.product.BrandName = brandNameTextBox.Text;
            this.product.Description = productDescriptionTextBox.Text;
            this.product.Weighted = weightedComboBox.Text;
        }
        //  Search for all products based on the parameters set by the user
        private void SearchForProducts()
        {
            SetProductInformation();
            this.products = SqliteDAProduct.GetAllProducts(this.product);
            if (mode == "INVOICE PRODUCT MODE")
            {
                PopulateDGVWithSearchResults();
                this.ActiveControl = productSearchDataGridView;
                if(this.products.Count > 0)
                {
                    productSearchDataGridView.Rows[0].Selected = true;
                    addProductToInvoiceButton.Enabled = true;
                }
            }
            else if (mode == "PRODUCT MODE")
            {
                this.Close();
            }
        }
        //  Wire up the data grid view with the results from the search query
        private void PopulateDGVWithSearchResults()
        {
            productSearchDataGridView.DataSource = this.products;
            productSearchDataGridView.AutoResizeColumns();
            productSearchDataGridView.Columns["ProductLinkId"].Visible = false;
            productSearchDataGridView.Columns["Id"].Visible = false;
            productSearchDataGridView.Columns["Deleted"].Visible = false;
        }

        private void productLinkNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForProducts();
            }
        }

        private void brandNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForProducts();
            }
        }

        private void weightedComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForProducts();
            }
        }

        private void categoryComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForProducts();
            }
        }

        private void productDescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForProducts();
            }
            
        }

        private void productSearchDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                row = this.productSearchDataGridView.CurrentRow;
                AddProductToInvoice();
            }
            else if (e.KeyCode == Keys.Back)
            {
                ClearProductSearchToBlankValues();
            }
        }

        private void AddProductToInvoice()
        {
            productId = Convert.ToInt32(row.Cells["Id"].Value);
            if (barcode != "")
            {
                BarcodeModel barcode = new BarcodeModel();
                barcode.Barcode = this.barcode;
                barcode.ProductId = productId;
                SqliteDataAccessBarcode.SaveBarcode(barcode);
            }
            this.Close();
        }
    }
}
