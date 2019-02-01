﻿using System;
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
using PriceBookClassLibrary;

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

            }
        }
        //USE CELL CLICK DATA FROM DATA GRID VIEW - CELL MOUSE CLICK on DATA GRID VIEW
        //1. Invoice Product
        private void mainDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toggleClickFirstButtons(true);
            if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
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
            }
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

        
    }
}
