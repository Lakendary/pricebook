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

namespace MainUI.Category
{
    public partial class CategoryNewOrEdit : Form
    {
        //Form variables
        List<CategoryModel> mainCategories;
        CategoryModel category = new CategoryModel();

        public CategoryNewOrEdit()
        {
            InitializeComponent();
        }

        public CategoryNewOrEdit(CategoryModel category)
        {
            InitializeComponent();
            formTitleLabel.Text = "Edit Category";
            saveButton.Text = "Edit";
            this.category = category;
        }

        private void CategoryNewOrEdit_Load(object sender, EventArgs e)
        {
            //Add a none category instance to the list of main categories that are loaded to the combo box.
            CategoryModel category = new CategoryModel();
            category.Id = 0;
            category.Name = "<NONE>";
            mainCategories = SqliteDACategory.GetMainCategoryOnly();
            mainCategories.Insert(0, category);
            mainCategoryComboBox.DataSource = mainCategories;
            mainCategoryComboBox.DisplayMember = "Name";
            mainCategoryComboBox.ValueMember = "Id";
            if (formTitleLabel.Text == "Edit Category")
            {
                SetCategoryToDefaultValues();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            CategoryModel category = new CategoryModel();
            category.Name = categoryNameTextBox.Text;
            //Check if <NONE> was selected in the main category combobox 
            if (mainCategoryComboBox.Text == "<NONE>")
            {
                category.MainCategory = "";
            }
            else
            {
                category.MainCategory = mainCategoryComboBox.Text;
            }
            //SAVE NEW CATEGORY
            if (formTitleLabel.Text == "New Category")
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
                    MessageBox.Show("Something went wrong. New category could not be saved.", "New Category Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //EDIT EXISTING CATEGORY
            else if (formTitleLabel.Text == "Edit Category")
            {
                category.Id = this.category.Id;
                bool result = SqliteDACategory.UpdateCategoryById(category);
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
                    MessageBox.Show("Something went wrong. Category update could not be saved.", "Category Edit Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if(formTitleLabel.Text == "New Category")
            {
                categoryNameTextBox.ResetText();
                mainCategoryComboBox.SelectedIndex = 0;
            } else if (formTitleLabel.Text == "Edit Category")
            {
                SetCategoryToDefaultValues();
            }
        }

        private void SetCategoryToDefaultValues()
        {
            categoryNameTextBox.Text = category.Name;
            if(category.MainCategory == "")
            {
                mainCategoryComboBox.SelectedIndex = 0;
            } else
            {
                mainCategoryComboBox.SelectedIndex = mainCategoryComboBox.FindStringExact(category.MainCategory);
            }
        }
    }
}
