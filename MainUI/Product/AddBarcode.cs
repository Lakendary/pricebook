using FluentValidation.Results;
using PriceBookClassLibrary;
using PriceBookClassLibrary.Validators;
using System;
using System.Windows.Forms;

namespace MainUI.Product
{
    public partial class AddBarcode : Form
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

        //  Global variables
        //******************************************************************************************************
        public int productId;
        BarcodeModel barcode = new BarcodeModel();

        //  Methods
        //  Events - Initialize
        //******************************************************************************************************
        //  1. New Barcode Initialize
        public AddBarcode(int productId)
        {
            InitializeComponent();
            this.productId = productId;
        }

        //  Events - Button Clicks
        //******************************************************************************************************
        //  1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetBarcodeInformation();
            if (ValidateBarcodeInformation())
            {
                saveNewBarcodeInformationToDb();
            }
        }
        //  2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            ClearBarcodeToBlankValues();
        }

        //  Other Methods
        //******************************************************************************************************
        //  Clear to blank form
        private void ClearBarcodeToBlankValues()
        {
            barcodeTextBox.ResetText();
        }
        //  Store user input into the barcode object.
        private void SetBarcodeInformation()
        {
            this.barcode.Barcode = barcodeTextBox.Text;
            this.barcode.ProductId = this.productId;
        }
        //  Verify that barcode object has valid information before committing to the database.
        private bool ValidateBarcodeInformation()
        {
            // Validate my data and save in the results variable
            BarcodeValidator barcodeValidator = new BarcodeValidator();
            var results = barcodeValidator.Validate(this.barcode);

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
        //  Commit to database - new barcode
        private void saveNewBarcodeInformationToDb()
        {
            if (SqliteDataAccessBarcode.SaveBarcode(barcode))
            {
                DialogResult dialogResult = MessageBox.Show("New Barcode created successfully", "New Barcode",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. New barcode could not be saved.", "New Category Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
