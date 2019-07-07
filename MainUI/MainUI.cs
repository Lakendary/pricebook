using System;
using System.Windows.Forms;
using MainUI.Category;
using MainUI.Product;
using MainUI.ProductLink;
using MainUI.Store;
using MainUI.Invoice;
using PriceBookClassLibrary;
using MainUI.InvoiceProduct;
using System.Threading.Tasks;
using Squirrel;
using System.Diagnostics;
using MainUI.Report;

namespace MainUI
{
    public partial class MainUI : Form
    {
        //********************************************************************************************//
        //  Index
        //********************************************************************************************//
        //  1. Form Global Variables
        //  2. Initial Component Method
        //  3. Form Load Method
        //  4. Seed Database
        //  5. Read Main Function Objects [CRUD]
        //********************************************************************************************//

        //********************************************************************************************//
        //  Form Global variables
        //********************************************************************************************//
        DataGridViewRow row;
        public string mode { get; set; }

        //********************************************************************************************//
        //  Initial Component Method
        //********************************************************************************************//
        public MainUI()
        {
            InitializeComponent();
        }

        //********************************************************************************************//
        //  Form Load Method
        //********************************************************************************************//
        private void MainUI_Load(object sender, EventArgs e)
        {
            modeStripStatusLabel.Text = "DEFAULT MODE";
            toggleAllButtons(false);
            barCodeSearchPanel.Visible = false;
        }

        //********************************************************************************************//
        //  EVENTS
        //********************************************************************************************//
        //  SEED DATABASE - DOUBLE CLICK PICTURE BOX EVENT
        private void infoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Seed the database with sample data. 
            if (SqliteDataAccessGeneral.SeedDatabase())
            {
                MessageBox.Show("The database was successfully seeded with sample data.", "PriceBook Database Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong. The database seeding failed.", "PriceBook Database Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //********************************************************************************************//
        //  LOAD MODELS - DOUBLE CLICK PICTURE BOX EVENT
        //********************************************************************************************//
        //  TODO: Remove unwanted columns from each objects get all function.
        //  1. Category
        private void categoryPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all categories from the database to the main data grid view.
            modeStripStatusLabel.Text = "CATEGORY MODE";
            mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
            SetDefaultLoadParameters();
            mainDataGridView.Columns["Id"].Visible = false;
        }
        //  2. Store
        private void storePictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all stores from the database to the main data grid view.
            modeStripStatusLabel.Text = "STORE MODE";
            mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
            SetDefaultLoadParameters();
            mainDataGridView.Columns["Id"].Visible = false;
        }
        //  3. Product
        private void productPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all products from the database to the main data grid view.
            modeStripStatusLabel.Text = "PRODUCT MODE";
            mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
            SetDefaultLoadParameters();
            mainDataGridView.Columns["Id"].Visible = false;
            mainDataGridView.Columns["ProductLinkId"].Visible = false;
            searchButton.Enabled = true;
        }
        //  4. Product link 
        private void productLinkPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all product links from the database to the main data grid view.
            modeStripStatusLabel.Text = "PRODUCT LINK MODE";
            mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
            SetDefaultLoadParameters();
            mainDataGridView.Columns["Id"].Visible = false;
            mainDataGridView.Columns["CategoryId"].Visible = false;
        }
        //  5. Invoice
        private void invoicePictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all invoices from the database to the main data grid view.
            modeStripStatusLabel.Text = "INVOICE MODE";
            mainDataGridView.DataSource = SqliteDAInvoice.GetAllCurrentActiveInvoices();
            SetDefaultLoadParameters();
            mainDataGridView.Columns["StoreId"].Visible = false;
            mainDataGridView.Columns["InvoiceAmount"].DefaultCellStyle.Format = "0.00##";
        }
        //  6. Reports
        private void reportPictureBox_DoubleClick(object sender, EventArgs e)
        {
            modeStripStatusLabel.Text = "REPORT MODE";
            Reports reportForm = new Reports();
            reportForm.ShowDialog();
        }

        //********************************************************************************************//
        //  LOAD MODELS - CLICK VIEW BUTTON EVENT
        //********************************************************************************************//
        private void viewButton_Click(object sender, EventArgs e)
        {
            
            //1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                //TODO: Add View Function for categories - FREE VERSION V1.1
                MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //2. Store
            else if (modeStripStatusLabel.Text == "STORE MODE")
            {
                //TODO: Add View Function for stores - FREE VERSION V1.1
                MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //3. Product Link
            else if (modeStripStatusLabel.Text == "PRODUCT LINK MODE")
            {
                //TODO: Add View Function for product links - FREE VERSION V1.1
                MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //4. Product
            else if (modeStripStatusLabel.Text == "PRODUCT MODE")
            {
                //TODO: Add View Function for products - FREE VERSION V1.1
                MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //5. Invoice
            else if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
                //************************************************************************************************************************************
                //Load all invoice products by invoice id from the database to the main data grid view.
                //There is no invoice product icon to double click on. 
                //If the user wants to get all invoice products, the user will have to run a report from the reports function.
                //Exception handling - if the user doesn't select a cell before clicking view, an argument error is thrown.
                //Error is logged and message shown. Invoice are reloaded again, because if the user clicks on the current data grid view and then on
                //the view button, the error message is thrown again.
                //************************************************************************************************************************************

                modeStripStatusLabel.Text = "INVOICE PRODUCT MODE";
                try
                {
                    invoiceNumberStripStatusLabel.Text = row.Cells["Id"].Value.ToString();
                    mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(Convert.ToInt32(row.Cells["Id"].Value));
                    mainDataGridView.AutoResizeColumns();
                    mainDataGridView.Columns["InvoiceId"].Visible = false;
                    mainDataGridView.Columns["ProductId"].Visible = false;
                    toggleClickFirstButtons(false);
                }
                catch (ArgumentException aex)
                {
                    MessageBox.Show("Please select a cell before clicking view", "Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    General.LogError(aex);
                    mainDataGridView.DataSource = SqliteDAInvoice.GetAllInvoices();
                    mainDataGridView.AutoResizeColumns();
                }
                catch (Exception ex)
                {
                    General.LogError(ex);
                }
                mainDataGridView.AutoResizeColumns();
            }
            //6. Invoice Product
            else if(modeStripStatusLabel.Text == "INVOICE PRODUCT MODE")
            {
                //TODO: Add View Function for invoice products - FREE VERSION V1.1
                MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //********************************************************************************************//
        //  SAVE MODELS - CLICK NEW BUTTON EVENT
        //********************************************************************************************//
        //  There is just one click new button event method. Check in which mode the app is in to 
        //  determine which class to act on.
        private void newButton_Click(object sender, EventArgs e)
        {
            //1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                CategoryNewOrEdit categoryForm = new CategoryNewOrEdit();
                categoryForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
                SetDefaultLoadParameters();
            }
            //2. Store
            else if (modeStripStatusLabel.Text == "STORE MODE")
            {
                StoreNewOrEdit storeForm = new StoreNewOrEdit();
                storeForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
                SetDefaultLoadParameters();
            }
            //3. Product Link
            else if (modeStripStatusLabel.Text == "PRODUCT LINK MODE")
            {
                ProductLinkNewOrEdit productLinkForm = new ProductLinkNewOrEdit();
                productLinkForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
                SetDefaultLoadParameters();
            }
            //4. Product
            else if (modeStripStatusLabel.Text == "PRODUCT MODE")
            {
                ProductNewOrEdit productForm = new ProductNewOrEdit();
                productForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
                SetDefaultLoadParameters();
            }
            //5. Invoice
            else if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
                InvoiceNewOrEdit invoiceForm = new InvoiceNewOrEdit();
                invoiceForm.ShowDialog();
                //  Check if user clicked the save button.
                //  TODO: What happens if the user doesn't click the save button in the next form?
                if (invoiceForm.userClickedSaveButton)
                {
                    SetDefaultLoadParametersForInvoiceBarcodeMode(invoiceForm.invoice);
                }
            }
        }


        //********************************************************************************************//
        //  SAVE MODELS - BARCODE PANEL CONTROLS
        //********************************************************************************************//
        //  SAVE MODELS - BARCODE PRESS ENTER IN TEXT BOX EVENT
        //  Add invoice products to the invoice by either searching for the product by barcode, 
        //  or by using the product search form.
        private void barcodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductModel product = new ProductModel();
                //1. Does the user have a barcode to scan or type in? 
                //1.1 NO - Press Enter on empty text box
                if (barcodeTextBox.Text == "")
                {
                    //Get back a product from the product search form. 
                    //If product search form is closed without selecting a product, e.g. closing the form
                    //Then exit process and wait for the user to type/scan a barcode or try to search again.
                    product = searchForProduct();
                }
                //1.2 YES - Enter barcode and press enter to search for product
                else
                {
                    //Search for product with barcode provided by the user
                    product = SqliteDAProduct.GetProductByBarcode(barcodeTextBox.Text);

                    //2. Did the search return a product that matches the barcode?
                    //NO?
                    if (product == null)
                    {
                        DialogResult result = MessageBox.Show("Barcode not found.\nAdd it to a new or existing product.", "Barcode Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            product = searchForProduct();
                        }
                    }
                }
                //Find Full Product Details with product Id
                //Check whether the user selected a product in the product search form
                if (product.Id != 0)
                {
                    product = SqliteDAProduct.GetProductById(product.Id);
                    //Add Invoice Product Details
                    InvoiceProductNewOrEdit invoiceProductForm = new InvoiceProductNewOrEdit(product, Convert.ToInt32(invoiceNumberStripStatusLabel.Text));
                    invoiceProductForm.ShowDialog();
                    mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(Convert.ToInt32(invoiceNumberStripStatusLabel.Text));
                    mainDataGridView.AutoResizeColumns();
                    barCodeSearchPanel.Visible = true;
                    mainDataGridView.Columns["ProductId"].Visible = false;
                    mainDataGridView.Columns["InvoiceId"].Visible = false;
                    calculateInvoiceTotals(SqliteDAInvoice.GetInvoiceById(Convert.ToInt32(invoiceNumberStripStatusLabel.Text)));
                    barcodeTextBox.ResetText();
                    this.ActiveControl = barcodeTextBox;
                }
            }
        }
        //  SAVE MODELS - CLICK SAVE INVOICE BUTTON EVENT
        //  Change status of invoice if the captured invoice price equals to the sum of invoice product's 
        //  total price.
        private void saveInvoiceButton_Click(object sender, EventArgs e)
        {
            if (SqliteDAInvoice.UpdateInvoiceById(Convert.ToInt32(invoiceNumberStripStatusLabel.Text)))
            {
                DialogResult result = MessageBox.Show("Successfully marked this invoice as saved.", "Save Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    saveInvoiceButton.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. Could not save invoice.", "Save Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //********************************************************************************************//
        //  EDIT MODELS - CLICK EDIT BUTTON EVENT
        //********************************************************************************************//
        private void editButton_Click(object sender, EventArgs e)
        {
            //  The user first has to select an item from the data grid view, click the edit button and 
            //  then the edit form for the respective object should open.
            //  All the object properties are collected from the selected datagridview row and sent to 
            //  the edit form. There the user will edit the object properties and update the database.
            //  The datagridview reloads and gets all objects and turns off the view/edit/delete buttons.
            //  1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                //Create object
                int categoryId = Convert.ToInt32(row.Cells["Id"].Value);
                //Send to edit form
                CategoryNewOrEdit categoryForm = new CategoryNewOrEdit(categoryId);
                categoryForm.ShowDialog();
                //Reload data grid view
                mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
                SetDefaultLoadParameters();
            }
            //  2. Store
            else if (modeStripStatusLabel.Text == "STORE MODE")
            {
                int storeId = Convert.ToInt32(row.Cells["Id"].Value);
                StoreNewOrEdit storeForm = new StoreNewOrEdit(storeId);
                storeForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
                SetDefaultLoadParameters();
            }
            //  3. Product Link
            else if (modeStripStatusLabel.Text == "PRODUCT LINK MODE")
            {
                int productLinkId = Convert.ToInt32(row.Cells["Id"].Value);
                ProductLinkNewOrEdit productLinkForm = new ProductLinkNewOrEdit(productLinkId);
                productLinkForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
                SetDefaultLoadParameters();
            }
            //  4. Product
            else if (modeStripStatusLabel.Text == "PRODUCT MODE")
            {
                int productId = Convert.ToInt32(row.Cells["Id"].Value);
                ProductNewOrEdit productForm = new ProductNewOrEdit(productId);
                productForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
                SetDefaultLoadParameters();
            }
            //  5. Invoice
            else if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
                int invoiceId = Convert.ToInt32(row.Cells["Id"].Value);
                InvoiceNewOrEdit invoiceForm = new InvoiceNewOrEdit(invoiceId);
                invoiceForm.ShowDialog();
                SetDefaultLoadParametersForInvoiceBarcodeMode(invoiceForm.invoice);
            }
            //  6. Invoice Product
            else if (modeStripStatusLabel.Text == "INVOICE PRODUCT MODE")
            {
                int invoiceProductId = Convert.ToInt32(row.Cells["Id"].Value);
                InvoiceProductNewOrEdit invoiceProductForm = new InvoiceProductNewOrEdit(invoiceProductId);
                invoiceProductForm.ShowDialog();
                barCodeSearchPanel.Visible = true;
                this.ActiveControl = barcodeTextBox;
                mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(Convert.ToInt32(invoiceNumberStripStatusLabel.Text));
                mainDataGridView.AutoResizeColumns();
                mainDataGridView.ClearSelection();
                mainDataGridView.Columns["ProductId"].Visible = false;
                mainDataGridView.Columns["InvoiceId"].Visible = false;
                mainDataGridView.Columns["TotalPrice"].DefaultCellStyle.Format = "0.00##";

                calculateInvoiceTotals(SqliteDAInvoice.GetInvoiceById(Convert.ToInt32(invoiceNumberStripStatusLabel.Text)));
            }
        }
        
        //********************************************************************************************//
        //  DELETE MODELS - CLICK DELETE BUTTON EVENT
        //********************************************************************************************//
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this category?" +
                    "\nCategory Name: {0}\nMain Category: {1}", row.Cells["Name"].Value.ToString(), row.Cells["MainCategory"].Value.ToString()),
                    "Delete Category", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = SqliteDACategory.DeleteCategoryById(Convert.ToInt32(row.Cells["Id"].Value));
                    if (result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Category was successfully deleted.", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
                        mainDataGridView.AutoResizeColumns();
                        toggleClickFirstButtons(false);
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Category could not be deleted.", "Delete Category Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                }
            }
            //2. Store
            else if (modeStripStatusLabel.Text == "STORE MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this store?" +
                    "\nStore Name: {0}\nLocation: {1}", row.Cells["Name"].Value.ToString(), row.Cells["Location"].Value.ToString()),
                    "Delete Store", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = SqliteDAStore.DeleteStoreById(Convert.ToInt32(row.Cells["Id"].Value));
                    if (result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Store was successfully deleted.", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
                        mainDataGridView.AutoResizeColumns();
                        toggleClickFirstButtons(false);
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Store could not be deleted.", "Delete Store Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                }
            }
            //3. Product Link
            else if (modeStripStatusLabel.Text == "PRODUCT LINK MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this product link?" +
                    "\nProduct Link Name: {0}\nCategory Name: {1}", row.Cells["Name"].Value.ToString(), row.Cells["CategoryName"].Value.ToString()),
                    "Delete Product Link", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = SqliteDAProductLink.DeleteProductLinkById(Convert.ToInt32(row.Cells["Id"].Value));
                    if (result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Product Link was successfully deleted.", "Delete Product Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
                        mainDataGridView.AutoResizeColumns();
                        toggleClickFirstButtons(false);
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Product Link could not be deleted.", "Delete Product Link Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                }
            }
            //4. Product
            else if (modeStripStatusLabel.Text == "PRODUCT MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this product?" +
                    "\nBrand Name: {0}\nProduct Description: {1}", row.Cells["BrandName"].Value.ToString(), row.Cells["Description"].Value.ToString()),
                    "Delete Product", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = SqliteDAProduct.DeleteProductById(Convert.ToInt32(row.Cells["Id"].Value));
                    if (result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Product was successfully deleted.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
                        mainDataGridView.AutoResizeColumns();
                        toggleClickFirstButtons(false);
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Product could not be deleted.", "Delete Product Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                }
            }
            //5. Invoice
            else if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this invoice?" +
                    "\nInvoice Date: {0}\nInvoice Number: {1}", row.Cells["Date"].Value.ToString(), row.Cells["InvoiceNumber"].Value.ToString()),
                    "Delete Invoice", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = false;
                    if (row.Cells["Saved"].Value.ToString() == "Open")
                    {
                        //Invoices marked as open will be permanently deleted from the database
                        result = SqliteDAInvoice.DeleteOpenInvoiceById(Convert.ToInt32(row.Cells["Id"].Value));
                    }
                    else if (row.Cells["Saved"].Value.ToString() == "Saved")
                    {
                        //Invoices marked as saved will be archived (marked as deleted, but still kept in the database).
                        result = SqliteDAInvoice.DeleteSavedInvoiceById(Convert.ToInt32(row.Cells["Id"].Value));
                    }

                    if (result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Invoice was successfully deleted.", "Delete Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDAInvoice.GetAllInvoices();
                        mainDataGridView.AutoResizeColumns();
                        toggleClickFirstButtons(false);
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Invoice could not be deleted.", "Delete Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                }
            }
            //6. Invoice Product
            else if (modeStripStatusLabel.Text == "INVOICE PRODUCT MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this product from the invoice?" +
                    "\nProduct Name: {0}", row.Cells["ProductName"].Value.ToString()),
                    "Delete Invoice Product", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = SqliteDAInvoiceProduct.DeleteInvoiceProductById(Convert.ToInt32(row.Cells["Id"].Value));
                    if (result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Product was successfully deleted from invoice.", "Delete Invoice Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(Convert.ToInt32(invoiceNumberStripStatusLabel.Text));
                        mainDataGridView.AutoResizeColumns();
                        mainDataGridView.Columns["ProductId"].Visible = false;
                        mainDataGridView.Columns["InvoiceId"].Visible = false;
                        toggleClickFirstButtons(false);
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Product could not be deleted from invoice.", "Delete Invoice Product Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                }
            }
        }

        //********************************************************************************************//
        //  FUTURE FUNCTIONS
        //********************************************************************************************//
        //  Create filters and sorting functions for each object (invoice, product, store etc.)
        private void searchButton_Click(object sender, EventArgs e)
        {
            if(modeStripStatusLabel.Text == "PRODUCT MODE")
            {
                ProductSearch productSearchForm = new ProductSearch(modeStripStatusLabel.Text);
                productSearchForm.ShowDialog();
                mainDataGridView.DataSource = productSearchForm.products;
                mainDataGridView.AutoResizeColumns();
            }
            else
            {
                //TODO: Add Search Function - FREE VERSION V1.1
                MessageBox.Show("Function will be available in a future release version.", "Future Version",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }         
        }
        //  Pro version: import objects from csv file
        private void importButton_Click(object sender, EventArgs e)
        {
            //TODO: Add Import Function - FREE VERSION V1.1
            MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //  Export data grid view to csv
        private void exportButton_Click(object sender, EventArgs e)
        {
            //TODO: Add Export Function - FREE VERSION V1.1
            MessageBox.Show("Function will be available in a future release version.", "Future Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //  Update application to latest version
        private void updateButton_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        //********************************************************************************************//
        //  OTHER EVENTS
        //********************************************************************************************//
        //  USE CELL CLICK DATA FROM DATA GRID VIEW - CELL MOUSE CLICK on DATA GRID VIEW
        //********************************************************************************************//
        private void mainDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toggleClickFirstButtons(true);
            try
            {
                if (e.RowIndex >= 0)
                {
                    row = this.mainDataGridView.Rows[e.RowIndex];
                    //  1. Invoice Product
                    if (modeStripStatusLabel.Text == "INVOICE MODE" &&
                        row.Cells["Saved"].Value.ToString() == "Saved")
                    {
                        deleteButton.Enabled = false;
                        editButton.Enabled = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  Changing global mode variable to mode in status strip label
        private void modeStripStatusLabel_TextChanged(object sender, EventArgs e)
        {
            mode = modeStripStatusLabel.Text;
        }

        //********************************************************************************************//
        //  OTHER METHODS
        //********************************************************************************************//
        //  Enable/disable all main buttons
        private void toggleAllButtons(bool input)
        {
            newButton.Enabled = input;
            editButton.Enabled = input;
            viewButton.Enabled = input;
            deleteButton.Enabled = input;
            //  Future buttons
            //searchButton.Enabled = input;
            //importButton.Enabled = input;
            //exportButton.Enabled = input;
        }
        //  Enable/disable all click first main buttons
        private void toggleClickFirstButtons(bool input)
        {
            //The user first needs to click on the data grid view to select a cell. An instance must be selected first,
            //before a function is action on said selected instance.
            //This helps prevent the argument exception.
            editButton.Enabled = input;
            viewButton.Enabled = input;
            deleteButton.Enabled = input;
        }
        //  Set default parameters when you load an object
        private void SetDefaultLoadParameters()
        {
            mainDataGridView.AutoResizeColumns();
            toggleAllButtons(true);
            toggleClickFirstButtons(false);
            mainDataGridView.ClearSelection();
            barCodeSearchPanel.Visible = false;
        }
        //  Open Search form and get data back
        private ProductModel searchForProduct()
        {
            ProductModel product = new ProductModel();
            ProductSearch productSearchForm = new ProductSearch(barcodeTextBox.Text, modeStripStatusLabel.Text);
            productSearchForm.ShowDialog();
            //Does the user want to add a new product with/without the barcode in the textbox?
            //YES?
            if (productSearchForm.openNewProductForm == true)
            {
                //  ProductNewOrEdit productForm = new ProductNewOrEdit(barcodeTextBox.Text);
                ProductAndProductLinkNewOrEdit addNewProductForm = new ProductAndProductLinkNewOrEdit();
                addNewProductForm.ShowDialog();
                product.Id = addNewProductForm.product.Id;
            }
            //NO?
            else
            {
                product.Id = productSearchForm.productId;
            }
            //TODO: What would happen if no id is returned from the form? Will it ever be NULL?
            return product;
        }
        //  Display the captured invoice total and also calculate the sum of the total price for 
        //  all invoice products
        private void calculateInvoiceTotals(InvoiceModel invoiceModel)
        {
            capturedInvoiceTotalAmountLabel.Text = string.Format("${0:#,0.00}", invoiceModel.InvoiceAmount);
            InvoiceProductModel invoiceProduct = new InvoiceProductModel();
            invoiceProduct = SqliteDAInvoiceProduct.GetInvoiceTotalById(Convert.ToInt32(invoiceModel.Id));
            sumOfProductPricesAmountLabel.Text = string.Format("${0:#,0.00}", invoiceProduct.TotalPrice);
            //Show save button if captured invoice total and sum of invoice products are equal
            if (invoiceModel.InvoiceAmount == invoiceProduct.TotalPrice)
            {
                saveInvoiceButton.Enabled = true;
            }
            else
            {
                saveInvoiceButton.Enabled = false;
            }
        }
        //  Check for updates
        private async Task CheckForUpdates()
        {
            //  TODO: Create a network path/web server or github to host new releases
            using (var manager = new UpdateManager(@"C:\Temp\Releases"))
            {
                await manager.UpdateApp();
            }
        }
        //  Return version number of current version.
        private string AddVersionNumber()
        {
            //  TODO: Create an about section to display the current version number
            string version = "";
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            version = $"v.{versionInfo.FileVersion}";
            return version;
        }
        //  Set default parameters when you a new invoice
        private void SetDefaultLoadParametersForInvoiceBarcodeMode(InvoiceModel invoice)
        {
            toggleAllButtons(false);
            barCodeSearchPanel.Visible = true;
            calculateInvoiceTotals(invoice);
            this.ActiveControl = barcodeTextBox;
            invoiceNumberStripStatusLabel.Text = invoice.Id.ToString();
            mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(invoice.Id);
            mainDataGridView.AutoResizeColumns();
            mainDataGridView.ClearSelection();
            mainDataGridView.Columns["ProductId"].Visible = false;
            mainDataGridView.Columns["InvoiceId"].Visible = false;
            mainDataGridView.Columns["TotalPrice"].DefaultCellStyle.Format = "0.00##";
            modeStripStatusLabel.Text = "INVOICE PRODUCT MODE";
        }

    }
}
