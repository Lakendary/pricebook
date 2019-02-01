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
        public ProductLinkNewOrEdit()
        {
            InitializeComponent();
        }

        private void ProductLinkNewOrEdit_Load(object sender, EventArgs e)
        {
            LoadCategoryComboBox();
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
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            productLinkNameTextBox.ResetText();
            weightedCheckBox.Checked = false;
            measurementRateTextBox.ResetText();
            categoryComboBox.SelectedIndex = 0;
            uomComboBox.SelectedIndex = 0;
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryNewOrEdit categoryForm = new CategoryNewOrEdit();
            categoryForm.ShowDialog();
            LoadCategoryComboBox();
        }
    }
}
