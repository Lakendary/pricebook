using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainUI.Category;
using MainUI.Product;
using MainUI.ProductLink;
using MainUI.Store;
using MainUI.Invoice;
using PriceBookClassLibrary;
using MainUI.InvoiceProduct;

namespace MainUI
{
    public partial class MainUI : Form
    {
        //********************************************************************************************//
        //************************************INDEX***************************************************//
        //********************************************************************************************//
        // 1. Form Global Variables
        // 2. Initial Component Method
        // 3. Form Load Method
        // 4. Seed Database
        // 5. Read Main Function Objects [CRUD]
        //
        //
        //
        //
        //
        //********************************************************************************************//
        
        //Form Global variables
        DataGridViewRow row;
        public string mode { get; set; }

        //Initial Component Method
        public MainUI()
        {
            InitializeComponent();
        }
        //Form Load Method
        private void MainUI_Load(object sender, EventArgs e)
        {
            modeStripStatusLabel.Text = "DEFAULT MODE";
            toggleAllButtons(false);
            barCodeSearchPanel.Visible = false;
        }
        
        //EVENTS
        //SEED DATABASE - DOUBLE CLICK PICTURE BOX EVENT
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

        //LOAD MODELS - DOUBLE CLICK PICTURE BOX EVENT
        //TODO: Remove Id columns and other unwanted columns from each objects get all function.
        //1. Category
        private void categoryPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all categories from the database to the main data grid view.
            modeStripStatusLabel.Text = "CATEGORY MODE";
            mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
            mainDataGridView.AutoResizeColumns();
            toggleAllButtons(true);
            toggleClickFirstButtons(false);
        }
        //2. Store
        private void storePictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all stores from the database to the main data grid view.
            modeStripStatusLabel.Text = "STORE MODE";
            mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
            mainDataGridView.AutoResizeColumns();
            toggleAllButtons(true);
            toggleClickFirstButtons(false);
        }
        //3. Product
        private void productPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all products from the database to the main data grid view.
            modeStripStatusLabel.Text = "PRODUCT MODE";
            mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
            mainDataGridView.AutoResizeColumns();
            toggleAllButtons(true);
            toggleClickFirstButtons(false);
        }
        //4. Product link 
        private void productLinkPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all product links from the database to the main data grid view.
            modeStripStatusLabel.Text = "PRODUCT LINK MODE";
            mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
            mainDataGridView.AutoResizeColumns();
            toggleAllButtons(true);
            toggleClickFirstButtons(false);
        }
        //5. Invoice
        private void invoicePictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all invoices from the database to the main data grid view.
            modeStripStatusLabel.Text = "INVOICE MODE";
            mainDataGridView.DataSource = SqliteDAInvoice.GetAllInvoices();
            mainDataGridView.AutoResizeColumns();
            toggleAllButtons(true);
            toggleClickFirstButtons(false);
        }

        //LOAD MODELS - CLICK VIEW BUTTON EVENT
        //1. Invoice Product
        private void viewButton_Click(object sender, EventArgs e)
        {
            //Load all invoice products by invoice id from the database to the main data grid view.
            //There is no invoice product icon to double click on. 
            //If the user wants to get all invoice products, the user will have to run a report from the reports function.
            //Exception handling - if the user doesn't select a cell before clicking view, an argument error is thrown.
            //Error is logged and message shown. Invoice are reloaded again, because if the user clicks on the current data grid view and then on
            //the view button, the error message is thrown again.
            //TODO: Add reports functionality
            //TODO: Add view all invoice products report
            modeStripStatusLabel.Text = "INVOICE PRODUCT MODE";
            try
            {
                mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(Convert.ToInt32(row.Cells["Id"].Value));
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show("Please select a cell before clicking view", "Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                General.LogError(aex);
                mainDataGridView.DataSource = SqliteDAInvoice.GetAllInvoices();
                mainDataGridView.AutoResizeColumns();

            } catch (Exception ex)
            {
                General.LogError(ex);
            }
            mainDataGridView.AutoResizeColumns();
        }

        //SAVE MODELS - CLICK NEW BUTTON EVENT
        //There is just one click new button event method. Check in which mode the app is in to determine
        //which object to act on.
        private void newButton_Click(object sender, EventArgs e)
        {
            //1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                CategoryNewOrEdit categoryForm = new CategoryNewOrEdit();
                categoryForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
                mainDataGridView.AutoResizeColumns();
            }
            //2. Store
            else if (modeStripStatusLabel.Text == "STORE MODE")
            {
                StoreNewOrEdit storeForm = new StoreNewOrEdit();
                storeForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
                mainDataGridView.AutoResizeColumns();
            }
            //3. Product Link
            else if (modeStripStatusLabel.Text == "PRODUCT LINK MODE")
            {
                ProductLinkNewOrEdit productLinkForm = new ProductLinkNewOrEdit();
                productLinkForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
                mainDataGridView.AutoResizeColumns();
            }
            //4. Product
            else if (modeStripStatusLabel.Text == "PRODUCT MODE")
            {
                ProductNewOrEdit productForm = new ProductNewOrEdit();
                productForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
                mainDataGridView.AutoResizeColumns();
            }
            //5. Invoice
            else if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
                InvoiceNewOrEdit invoiceForm = new InvoiceNewOrEdit();
                invoiceForm.ShowDialog();
                barCodeSearchPanel.Visible = true;
                this.ActiveControl = barcodeTextBox;
                invoiceNumberStripStatusLabel.Text = invoiceForm.invoiceId.ToString();
                mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(invoiceForm.invoiceId);
            }
        }
        //SAVE MODELS - BARCODE PRESS ENTER IN TEXT BOX EVENT
        //Add invoice products to the invoice by either searching for the product by barcode, or by using the product search form.
        private void barcodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductModel product = new ProductModel();
                //1. Does the user have a barcode? 
                //NO? - Press Enter on empty text box
                if (barcodeTextBox.Text == "")
                {
                    product = searchForProduct();
                }
                //YES? - Enter barcode and press enter to search for product
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
                product = SqliteDAProduct.GetProductById(product.Id);
                //Add Invoice Product Details
                InvoiceProductNewOrEdit invoiceProductForm = new InvoiceProductNewOrEdit(product, Convert.ToInt32(invoiceNumberStripStatusLabel.Text));
                invoiceProductForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAInvoiceProduct.GetAllInvoiceProductsByInvoiceId(Convert.ToInt32(invoiceNumberStripStatusLabel.Text));
                barcodeTextBox.ResetText();
                this.ActiveControl = barcodeTextBox;
            }
        }
        //EDIT MODELS - CLICK EDIT BUTTON EVENT
        private void editButton_Click(object sender, EventArgs e)
        {
            //The user first has to select an item from the data grid view, click the edit button and then the edit form for the respective object should open.
            //All the object properties are collected from the selected datagridview row and sent to the edit form. There the user will edit the object properties and update the database.
            //The datagridview reloads and gets all objects and turns off the view/edit/delete buttons.
            //1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                //Create object
                CategoryModel category = new CategoryModel();
                category.Id = Convert.ToInt32(row.Cells["Id"].Value);
                category.MainCategory = row.Cells["MainCategory"].Value.ToString();
                category.Name = row.Cells["Name"].Value.ToString();
                //Send to edit form
                CategoryNewOrEdit categoryForm = new CategoryNewOrEdit(category);
                categoryForm.ShowDialog();
                //Reload data grid view
                mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
                mainDataGridView.AutoResizeColumns();
                toggleClickFirstButtons(false);
            }
            //2. Store
            else if (modeStripStatusLabel.Text == "STORE MODE")
            {
                StoreModel store = new StoreModel();
                store.Id = Convert.ToInt32(row.Cells["Id"].Value);
                store.Location = row.Cells["Location"].Value.ToString();
                store.Name = row.Cells["Name"].Value.ToString();
                StoreNewOrEdit storeForm = new StoreNewOrEdit(store);
                storeForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
                mainDataGridView.AutoResizeColumns();
                toggleClickFirstButtons(false);
            }
            //3. Product Link
            else if (modeStripStatusLabel.Text == "PRODUCT LINK MODE")
            {
                ProductLinkModel productLink = new ProductLinkModel();
                productLink.CategoryId = Convert.ToInt32(row.Cells["CategoryId"].Value);
                productLink.CategoryName = row.Cells["CategoryName"].Value.ToString();
                productLink.Id = Convert.ToInt32(row.Cells["Id"].Value);
                productLink.MeasurementRate = Convert.ToInt32(row.Cells["MeasurementRate"].Value);
                productLink.Name = row.Cells["Name"].Value.ToString();
                productLink.UoM = row.Cells["UoM"].Value.ToString();
                productLink.Weighted = row.Cells["Weighted"].Value.ToString();
                ProductLinkNewOrEdit productLinkForm = new ProductLinkNewOrEdit(productLink);
                productLinkForm.ShowDialog();
                mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
                mainDataGridView.AutoResizeColumns();
                toggleClickFirstButtons(false);
            }
        }
        //TODO: Add a deleted column to each object table and set a deleted object to inactive/deleted
        //DELETE MODELS - CLICK DELETE BUTTON EVENT
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //1. Category
            if (modeStripStatusLabel.Text == "CATEGORY MODE")
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete this category?" +
                    "\nCategory Name: {0}\nMain Category: {1}", row.Cells["Name"].Value.ToString(), row.Cells["MainCategory"].Value.ToString()),
                    "Delete Category", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    bool result = SqliteDACategory.DeleteCategoryById(Convert.ToInt32(row.Cells["Id"].Value));
                    if(result == true)
                    {
                        DialogResult dialog = MessageBox.Show("Category was successfully deleted.", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainDataGridView.DataSource = SqliteDACategory.GetAllCategories();
                        mainDataGridView.AutoResizeColumns();
                        toggleClickFirstButtons(false);
                    } else
                    {
                        DialogResult dialog = MessageBox.Show("Something went wrong. Category could not be deleted.", "Delete Category Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else if(dialogResult == DialogResult.No)
                {
                    toggleClickFirstButtons(false);
                } 
            }
            //2. Store
            else if(modeStripStatusLabel.Text == "STORE MODE")
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
            else if(modeStripStatusLabel.Text == "PRODUCT LINK MODE")
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
        }
        //USE CELL CLICK DATA FROM DATA GRID VIEW - CELL MOUSE CLICK on DATA GRID VIEW
        //1. Invoice Product
        private void mainDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toggleClickFirstButtons(true);
            //if (modeStripStatusLabel.Text == "INVOICE MODE")
            //{
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        row = this.mainDataGridView.Rows[e.RowIndex];
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
        }
        //OTHER EVENTS
        //Clicking the search button - needs to be customized per object
        private void searchButton_Click(object sender, EventArgs e)
        {
            ProductSearch productSearchForm = new ProductSearch();
            productSearchForm.ShowDialog();
        }
        //Changing global mode variable to mode in status strip label
        private void modeStripStatusLabel_TextChanged(object sender, EventArgs e)
        {
            mode = modeStripStatusLabel.Text;
        }
        //OTHER METHODS
        //Enable/disable all main buttons
        private void toggleAllButtons(bool input)
        {
            newButton.Enabled = input;
            searchButton.Enabled = input;
            importButton.Enabled = input;
            exportButton.Enabled = input;
            editButton.Enabled = input;
            viewButton.Enabled = input;
            deleteButton.Enabled = input;
        }
        //Enable/disable all click first main buttons
        private void toggleClickFirstButtons(bool input)
        {
            //The user first needs to click on the data grid view to select a cell. An instance must be selected first,
            //before a function is action on said selected instance.
            //This helps prevent the argument exception.
            editButton.Enabled = input;
            viewButton.Enabled = input;
            deleteButton.Enabled = input;
        }

        //Open Search form and get data back
        private ProductModel searchForProduct()
        {
            ProductModel product = new ProductModel();
            ProductSearch productSearchForm = new ProductSearch(barcodeTextBox.Text);
            productSearchForm.ShowDialog();
            //Does the user want to add a new product with/without the barcode in the textbox?
            //YES?
            if (productSearchForm.openNewProductForm)
            {
                ProductNewOrEdit productForm = new ProductNewOrEdit(barcodeTextBox.Text);
                productForm.ShowDialog();
                product.Id = productForm.productId;
            }
            //NO?
            else
            {
                product.Id = productSearchForm.productId;
            }
            return product;
        }
    }
}
