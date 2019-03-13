using FluentValidation.Results;
using PriceBookClassLibrary;
using PriceBookClassLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainUI.Category
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
    public partial class CategoryNewOrEdit : Form
    {
        //Global variables
        //******************************************************************************************************
        List<CategoryModel> mainCategories = new List<CategoryModel>();
        CategoryModel category = new CategoryModel();
        CategoryModel existingCategory = new CategoryModel();
        bool newCategory = true;

        //Methods
        //Events - Initialize
        //******************************************************************************************************
        public CategoryNewOrEdit()
        {
            InitializeComponent();
        }

        public CategoryNewOrEdit(int categoryId)
        {
            InitializeComponent();
            formTitleLabel.Text = "Edit Category";
            saveButton.Text = "Edit";
            this.existingCategory = SqliteDACategory.GetCategoryById(categoryId);
            this.newCategory = false;
        }

        //Events - Form Load
        //******************************************************************************************************
        private void CategoryNewOrEdit_Load(object sender, EventArgs e)
        {
            LoadMainCategoryComboBox();

            if (!this.newCategory)
            {
                SetCategoryToDefaultValues();
            }
        }

        //Events - Button Clicks
        //******************************************************************************************************
        //1. Save Button Click
        private void saveButton_Click(object sender, EventArgs e)
        {
            SetCategoryInformation();
            //Validate category information
            if(ValidateCategoryInformation())
            {
                if(this.newCategory)
                {
                    saveNewCategoryInformationToDb();
                }
                else if(!this.newCategory)
                {
                    saveExistingCategoryInformationToDb();
                }
            }
        }

        //2. Reset Button Click
        private void resetButton_Click(object sender, EventArgs e)
        {
            if(this.newCategory)
            {
                ClearCategoryToBlankValues();
            } 
            else if (!this.newCategory)
            {
                SetCategoryToDefaultValues();
            }
        }

        //Other Methods
        //******************************************************************************************************
        private void LoadMainCategoryComboBox()
        {
            //Add a none category instance to the list of main categories that are loaded to the combo box.
            //Create a category with no main category
            CategoryModel category = new CategoryModel();
            category.Id = 0;
            category.Name = "<NONE>";
            //Get the list of main categories
            this.mainCategories = SqliteDACategory.GetMainCategoryOnly();
            //Add no main category to the start of the list
            this.mainCategories.Insert(0, category);
            //Wire up the main category combobox.
            mainCategoryComboBox.DataSource = this.mainCategories;
            mainCategoryComboBox.DisplayMember = "Name";
            mainCategoryComboBox.ValueMember = "Id";
        }

        private void SetCategoryInformation()
        {
            this.category.Name = categoryNameTextBox.Text;
            //Check if <NONE> was selected in the main category combobox 
            if (mainCategoryComboBox.Text == "<NONE>")
            {
                this.category.MainCategory = "";
            }
            else
            {
                this.category.MainCategory = mainCategoryComboBox.Text;
            }

            if(!newCategory)
            {
                this.category.Id = this.existingCategory.Id;
            }
        }

        private void SetCategoryToDefaultValues()
        {
            categoryNameTextBox.Text = this.existingCategory.Name;
            if(this.existingCategory.MainCategory == "")
            {
                mainCategoryComboBox.SelectedIndex = 0;
            } else
            {
                mainCategoryComboBox.SelectedIndex = mainCategoryComboBox.FindStringExact(this.existingCategory.MainCategory);
            }
        }
        private void ClearCategoryToBlankValues()
        {
            categoryNameTextBox.ResetText();
            mainCategoryComboBox.SelectedIndex = 0;
        }
        private bool ValidateCategoryInformation()
        {
            // Validate my data and save in the results variable
            CategoryValidator categoryValidator = new CategoryValidator();
            var results = categoryValidator.Validate(this.category);

            // Check if the validator found any validation errors. 
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show($"{ failure.ErrorMessage }", "Category Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private void saveNewCategoryInformationToDb()
        {
            bool result = SqliteDACategory.SaveCategory(category);
            if (result == true)
            {
                DialogResult dialogResult = MessageBox.Show("New category created successfully", "New Category",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (result == false)
            {
                MessageBox.Show("Something went wrong. New category could not be saved.\nCheck the error log for more information.", "New Category Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveExistingCategoryInformationToDb()
        {
            bool result = SqliteDACategory.UpdateCategoryById(this.category);
            if (result == true)
            {
                DialogResult dialogResult = MessageBox.Show("Category updated successfully", "Category Edit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (result == false)
            {
                MessageBox.Show("Something went wrong. Category update could not be saved.\nCheck the error log for more information.", "Category Edit Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
