using FluentValidation.Results;
using PriceBookClassLibrary;
using PriceBookClassLibrary.Validators;
using System;
using System.Windows.Forms;

namespace MainUI.Store
{
    public partial class StoreNewOrEdit : Form
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
        StoreModel store = new StoreModel();
        bool newStore = true;
        StoreModel existingStore = new StoreModel();


        //Methods
        //Events - Initialize
        //******************************************************************************************************
        //1. If a new store is created, this method is initialized.
        public StoreNewOrEdit()
        {
            InitializeComponent();
        }
        //2. However, if a store instance is edited, the store id is passed from the main data grid view 
        //from the main ui.
        public StoreNewOrEdit(int storeId)
        {
            InitializeComponent();
            //Get the rest of the store information the id provided and store in the existing store variable. 
            //When the user presses the reset button, the textbox will default to this value.
            this.existingStore = SqliteDAStore.GetStoreById(storeId);
            //Update the form's information from new(default) to edit
            formTitleLabel.Text = "Edit Store";
            saveButton.Text = "Edit";
            this.newStore = false;
        }

        //Events - Form Load
        //******************************************************************************************************
        private void StoreNewOrEdit_Load(object sender, EventArgs e)
        {
            SetStoreToDefaultValues();
        }

        //Events - Button Clicks
        //******************************************************************************************************
        //1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetStoreInformation();

            if (ValidateStoreInformation())
            {
                if (this.newStore)
                {
                    saveNewStoreInformationToDb();
                }
                else
                {
                    saveExistingStoreInformationToDb();
                }
            }
        }
        //2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (!this.newStore)
            {
                SetStoreToDefaultValues();

            }
            else if (formTitleLabel.Text == "New Store")
            {
                storeNameTextBox.ResetText();
                storeLocationTextBox.ResetText();
            }
        }

        //Other Methods
        //******************************************************************************************************
        private void SetStoreToDefaultValues()
        {
            //Insert the store information passed from the main ui's data gridview.
            storeNameTextBox.Text = this.existingStore.Name;
            storeLocationTextBox.Text = this.existingStore.Location;
        }

        private void SetStoreInformation()
        {
            //Store the current information and store it in the store variable.
            //When the user clicks the save or edit button, 
            this.store.Name = storeNameTextBox.Text;
            this.store.Location = storeLocationTextBox.Text;
            //When its a new store, the id also needs to be saved to the store variable. 
            //This is taken from the existing store variable which has the default values.
            if (!this.newStore)
            {
                this.store.Id = this.existingStore.Id;
            }
        }

        private bool ValidateStoreInformation()
        {
            // Validate my data and save in the results variable
            StoreValidator storeValidator = new StoreValidator();
            var results = storeValidator.Validate(store);

            // Check if the validator found any validation errors. 
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show($"{ failure.ErrorMessage }", "Store Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private void saveNewStoreInformationToDb()
        {
            //This method executes if its a new store that's needs to be commited to the database.
            //Pass store instance to save store method. If the method returns true, the information was successfully committed to the database.
            bool result = SqliteDAStore.SaveStore(this.store);
            if (result == true)
            {
                DialogResult dialogResult = MessageBox.Show("New store created successfully", "New Store",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (result == false)
            {
                MessageBox.Show("Something went wrong. New store could not be saved.\nCheck the error log for more information.", "New Store Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveExistingStoreInformationToDb()
        {
            //This method updates an existing store. 
            //Pass store information to update store method. Check if the update was successfully committed to the database and inform the user. Close
            //this form if the edit was successful.
            bool result = SqliteDAStore.UpdateStoreById(store);
            if (result == true)
            {
                DialogResult dialogResult = MessageBox.Show("Store updated successfully", "Store Edit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (result == false)
            {
                MessageBox.Show("Something went wrong. Store update could not be saved.\nCheck the error log for more information.", "Store Edit Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
