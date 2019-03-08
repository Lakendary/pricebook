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
        InvoiceProductModel invoiceProduct = new InvoiceProductModel();


        public InvoiceProductNewOrEdit(ProductModel product, int id)
        {
            InitializeComponent();
            this.product = product;
            invoiceId = id;
        }

        public InvoiceProductNewOrEdit(int invoiceProductId)
        {
            InitializeComponent();
            this.invoiceProduct = SqliteDAInvoiceProduct.GetInvoiceProductById(invoiceProductId);
            formTitleLabel.Text = "Edit Invoice Product";
            saveButton.Text = "Edit";
        }

        private void InvoiceProductNewOrEdit_Load(object sender, EventArgs e)
        {
            if (formTitleLabel.Text == "New Invoice Product")
            {
                productFullNameLabel.Text = string.Format("{0} {1}", product.BrandName, product.Description);
                uomLabel.Text = product.UoM;
                if (product.Weighted == "Weighted")
                {
                    weightTextBox.Enabled = true;
                }
                else if (product.Weighted == "Pre-Packaged")
                {
                    weightTextBox.Enabled = false;
                }
            } else if (formTitleLabel.Text == "Edit Invoice Product")
            {
                SetInvoiceProductDefaultValues();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            InvoiceProductModel invoiceProduct = new InvoiceProductModel();
            invoiceProduct.InvoiceId = invoiceId;
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
            if (formTitleLabel.Text == "New Invoice Product")
            {
                invoiceProduct.ProductId = product.Id;
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
                    MessageBox.Show("Something went wrong. New invoice product could not be saved.", "New Invoice Product Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (formTitleLabel.Text == "Edit Invoice Product")
            {
                invoiceProduct.ProductId = this.invoiceProduct.ProductId;
                invoiceProduct.Id = this.invoiceProduct.Id;
                bool result = SqliteDAInvoiceProduct.UpdateInvoiceProductById(invoiceProduct);
                if (result == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Invoice product updated successfully", "Edit Invoice Product",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else if (result == false)
                {
                    MessageBox.Show("Something went wrong. Invoice product update could not be saved.", "Edit Invoice Product Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if(formTitleLabel.Text == "New Invoice Product")
            {
                quantityTextBox.ResetText();
                totalPriceTextBox.ResetText();
                weightTextBox.ResetText();
                saleCheckBox.Checked = false;
            } else if (formTitleLabel.Text == "Edit Invoice Product")
            {
                SetInvoiceProductDefaultValues();
            }
        }

        private void SetInvoiceProductDefaultValues()
        {
            productFullNameLabel.Text = invoiceProduct.ProductName;
            quantityTextBox.Text = invoiceProduct.Quantity.ToString();
            //Make sure only weighted products can be edited and show no weight for pre-packaged products (0 throws an error)
            if(invoiceProduct.Weighted == "Pre-Packaged")
            {
                weightTextBox.Text = "";
                weightTextBox.Enabled = false;
            } else
            {
                weightTextBox.Text = invoiceProduct.Weight.ToString();
            }
            totalPriceTextBox.Text = invoiceProduct.TotalPrice.ToString();
            uomLabel.Text = invoiceProduct.UoM;
            if(invoiceProduct.Sale == "Sale")
            {
                saleCheckBox.Checked = true;
            } else if (invoiceProduct.Sale == "Regular")
            {
                saleCheckBox.Checked = false;
            }
        }
    }
}
