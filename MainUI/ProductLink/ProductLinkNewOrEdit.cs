﻿using PriceBookClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            categoryComboBox.DataSource = SqliteDACategory.GetSubcategoryOnly();
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProductLinkModel productLink = new ProductLinkModel();
            productLink.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            //TODO: Product Link should not save after error is thrown.
            try
            {
                productLink.MeasurementRate = Convert.ToInt32(measurementRateTextBox.Text);
            } catch (FormatException fe)
            {
                MessageBox.Show(string.Format("Please enter a number.\nException: {0}",fe),"Measurement Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            productLink.Name = productLinkNameTextBox.Text;
            productLink.UoM = uomComboBox.Text;
            if(weightedCheckBox.CheckState == CheckState.Checked)
            {
                productLink.Weighted = "Weighted";
            } else
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

        private void resetButton_Click(object sender, EventArgs e)
        {
            productLinkNameTextBox.ResetText();
            weightedCheckBox.Checked = false;
            measurementRateTextBox.ResetText();
            categoryComboBox.SelectedIndex = 0;
            uomComboBox.SelectedIndex = 0;
        }
    }
}
