using MainUI.Category;
using PriceBookClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainUI.ProductLink
{
    public partial class ProductLinkNewOrEdit : Form
    {
        ProductLinkModel productLink = new ProductLinkModel();
        public ProductLinkNewOrEdit()
        {
            InitializeComponent();
        }

        public ProductLinkNewOrEdit(int productLinkId)
        {
            InitializeComponent();
            this.productLink = SqliteDAProductLink.GetProductLinkById(productLinkId);
            formTitleLabel.Text = "Edit Product Link";
            saveButton.Text = "Edit";
        }

        private void ProductLinkNewOrEdit_Load(object sender, EventArgs e)
        {
            LoadCategoryComboBox();
            if (formTitleLabel.Text == "Edit Product Link")
            {
                SetProductLinkToDefaultValues();
            }
        }

        private void LoadCategoryComboBox()
        {
            categoryComboBox.DataSource = SqliteDACategory.GetSubcategoryOnly();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProductLinkModel productLink = new ProductLinkModel();
            productLink.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            if (!int.TryParse(measurementRateTextBox.Text, out int number))
            {
                MessageBox.Show("Please enter a number.", "Measurement Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                productLink.MeasurementRate = number;
                productLink.Name = productLinkNameTextBox.Text;
                productLink.UoM = uomComboBox.Text;
                if (weightedCheckBox.CheckState == CheckState.Checked)
                {
                    productLink.Weighted = "Weighted";
                }
                else
                {
                    productLink.Weighted = "Pre-Packaged";
                }
                if(formTitleLabel.Text == "New Product Link")
                {
                    bool result = SqliteDAProductLink.SaveProductLink(productLink);
                    if (result == true)
                    {
                        DialogResult dialogResult = MessageBox.Show("New product link created successfully", "New Product Link",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else if (result == false)
                    {
                        MessageBox.Show("Something went wrong. New product link could not be saved.", "New Product Link Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else if(formTitleLabel.Text == "Edit Product Link")
                {
                    productLink.Id = this.productLink.Id;
                    bool result = SqliteDAProductLink.UpdateProductLinkById(productLink);
                    if (result == true)
                    {
                        DialogResult dialogResult = MessageBox.Show("New product link updated successfully", "Edit Product Link",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else if (result == false)
                    {
                        MessageBox.Show("Something went wrong. Product link could not be updated.", "Edit Product Link Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if(formTitleLabel.Text == "New Product Link")
            {
                productLinkNameTextBox.ResetText();
                weightedCheckBox.Checked = false;
                measurementRateTextBox.ResetText();
                categoryComboBox.SelectedIndex = 0;
                uomComboBox.SelectedIndex = 0;
            } else if (formTitleLabel.Text == "Edit Product Link")
            {
                SetProductLinkToDefaultValues();
            }
            
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryNewOrEdit categoryForm = new CategoryNewOrEdit();
            categoryForm.ShowDialog();
            LoadCategoryComboBox();
        }

        private void SetProductLinkToDefaultValues()
        {
            productLinkNameTextBox.Text = productLink.Name;
            uomComboBox.SelectedIndex = uomComboBox.FindStringExact(productLink.UoM);
            if(productLink.Weighted == "Weighted")
            {
                weightedCheckBox.Checked = true;
            } else if(productLink.Weighted == "Pre-Packaged")
            {
                weightedCheckBox.Checked = false;
            }
            measurementRateTextBox.Text = productLink.MeasurementRate.ToString();
            categoryComboBox.SelectedIndex = categoryComboBox.FindStringExact(productLink.CategoryName);
        }
    }
}
