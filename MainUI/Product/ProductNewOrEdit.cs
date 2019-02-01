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

namespace MainUI.Product
{
    public partial class ProductNewOrEdit : Form
    {
        public ProductNewOrEdit()
        {
            InitializeComponent();
        }

        private void ProductNewOrEdit_Load(object sender, EventArgs e)
        {
            productLinkComboBox.DataSource = SqliteDAProductLink.GetAllProductLinks();
            productLinkComboBox.ValueMember = "Id";
            productLinkComboBox.DisplayMember = "Name";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(packSizeTextBox.Text, out int number))
            {
                MessageBox.Show("Please enter a number.", "Pack Size Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                ProductModel product = new ProductModel();
                product.BrandName = brandNameTextBox.Text;
                product.Description = productDescriptionTextBox.Text;
                product.PackSize = number;
                product.ProductLinkId = Convert.ToInt32(productLinkComboBox.SelectedValue);
                bool result = SqliteDAProduct.SaveProduct(product);
                if (result == true)
                {
                    DialogResult dialogResult = MessageBox.Show("New product created successfully", "New Product",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }

                }
                else if (result == false)
                {
                    MessageBox.Show("Something went wrong. New product could not be saved.", "New Product Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            barcodeTextBox.ResetText();
            brandNameTextBox.ResetText();
            packSizeTextBox.ResetText();
            productDescriptionTextBox.ResetText();
            productLinkComboBox.SelectedIndex = 0;
        }
    }
}
