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

namespace MainUI.InvoiceProduct
{
    public partial class InvoiceProductNewOrEdit : Form
    {
        //Global variables
        ProductModel product = new ProductModel();
        int invoiceId = 0;
        
        public InvoiceProductNewOrEdit(ProductModel product, int id)
        {
            InitializeComponent();
            this.product = product;
            invoiceId = id;
        }

        private void InvoiceProductNewOrEdit_Load(object sender, EventArgs e)
        {
            //TODO: Fix Error - When Product Search form is closed without doing anything
            productFullNameLabel.Text = string.Format("{0} {1}", product.BrandName, product.Description);
            uomLabel.Text = product.UoM;
            if(product.Weighted == "Weighted")
            {
                weightTextBox.Enabled = true;
            } else if (product.Weighted == "Pre-Packaged")
            {
                weightTextBox.Enabled = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            InvoiceProductModel invoiceProduct = new InvoiceProductModel();
            invoiceProduct.InvoiceId = invoiceId;
            invoiceProduct.ProductId = product.Id;
            //TODO: Validate the text boxes. Check if user entered a number
            invoiceProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
            if(weightTextBox.Text != "")
            {
                invoiceProduct.Weight = Convert.ToInt32(weightTextBox.Text);
            }
            invoiceProduct.TotalPrice = Convert.ToDecimal(totalPriceTextBox.Text);
            if(saleCheckBox.Checked == true)
            {
                invoiceProduct.Sale = "Sale";
            } else if (saleCheckBox.Checked == false)
            {
                invoiceProduct.Sale = "Regular";
            }
            bool result = SqliteDAInvoiceProduct.SaveInvoiceProduct(invoiceProduct);
            if (result == true)
            {
                DialogResult dialogResult = MessageBox.Show("New invoice product created successfully", "New Invoice Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }

            }
            else if (result == false)
            {
                MessageBox.Show("Something went wrong. New invoice product could not be saved.", "New nvoice Product Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            quantityTextBox.ResetText();
            totalPriceTextBox.ResetText();
            weightTextBox.ResetText();
            saleCheckBox.Checked = false;
        }
    }
}
