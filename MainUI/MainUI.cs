using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            modeStripStatusLabel.Text = "DEFAULT MODE";
            buttonsPanel.Visible = false;
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
            buttonsPanel.Visible = false;
        }
        //2. Store
        private void storePictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all stores from the database to the main data grid view.
            modeStripStatusLabel.Text = "STORE MODE";
            mainDataGridView.DataSource = SqliteDAStore.GetAllStores();
            mainDataGridView.AutoResizeColumns();
            buttonsPanel.Visible = false;
        }
        //3. Product
        private void productPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all products from the database to the main data grid view.
            modeStripStatusLabel.Text = "PRODUCT MODE";
            mainDataGridView.DataSource = SqliteDAProduct.GetAllProducts();
            mainDataGridView.AutoResizeColumns();
            buttonsPanel.Visible = false;
        }
        //4. Product link 
        private void productLinkPictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all product links from the database to the main data grid view.
            modeStripStatusLabel.Text = "PRODUCT LINK MODE";
            mainDataGridView.DataSource = SqliteDAProductLink.GetAllProductLinks();
            mainDataGridView.AutoResizeColumns();
            buttonsPanel.Visible = false;
        }
        //5. Invoice
        private void invoicePictureBox_DoubleClick(object sender, EventArgs e)
        {
            //Load all invoices from the database to the main data grid view.
            modeStripStatusLabel.Text = "INVOICE MODE";
            mainDataGridView.DataSource = SqliteDAInvoice.GetAllInvoices();
            mainDataGridView.AutoResizeColumns();
            buttonsPanel.Visible = false;
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


        //USE CELL CLICK DATA FROM DATA GRID VIEW - CELL MOUSE CLICK on DATA GRID VIEW
        //1. Invoice Product
        private void mainDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (modeStripStatusLabel.Text == "INVOICE MODE")
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        row = this.mainDataGridView.Rows[e.RowIndex];
                        buttonsPanel.Visible = true;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
