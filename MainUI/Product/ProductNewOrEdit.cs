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
        string mode = "";
        public int productId { get; set; }
        public ProductNewOrEdit()
        {
            InitializeComponent();
        }

        public ProductNewOrEdit(string barcode)
        {
            InitializeComponent();
            barcodeTextBox.Text = barcode;
            mode = "INVOICE MODE";
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
                //TODO: Refactor code and add comments
                //TODO: Remove SaveProduct and replace with SaveProductAndGetId
                ProductModel product = new ProductModel();
                product.BrandName = brandNameTextBox.Text;
                product.Description = productDescriptionTextBox.Text;
                product.PackSize = number;
                product.ProductLinkId = Convert.ToInt32(productLinkComboBox.SelectedValue);
                if (mode == "INVOICE MODE")
                {
                    int id = SqliteDAProduct.SaveProductAndGetId(product);
                    if (id != 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("New product created successfully", "New Product",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            productId = id;
                            BarcodeModel barcode = new BarcodeModel();
                            barcode.Barcode = barcodeTextBox.Text;
                            barcode.ProductId = id;
                            SqliteDataAccessBarcode.SaveBarcode(barcode);
                            this.Close();
                        }

                    }
                    else if (id == 0)
                    {
                        MessageBox.Show("Something went wrong. New product could not be saved.", "New Product Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
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
