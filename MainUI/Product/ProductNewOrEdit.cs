using PriceBookClassLibrary;
using System;
using System.Windows.Forms;

namespace MainUI.Product
{
    public partial class ProductNewOrEdit : Form
    {
        string mode = "";
        public int productId { get; set; }
        ProductModel product = new ProductModel();

        public ProductNewOrEdit()
        {
            InitializeComponent();
        }
        //Initiated when the user clicks edit on the main ui and passes a product to edit.
        public ProductNewOrEdit(int productId)
        {
            InitializeComponent();
            this.product = SqliteDAProduct.GetProductById(productId);
            formTitleLabel.Text = "Edit Product";
            saveButton.Text = "Edit";
            SetProductDefaultValues();
            addBarcodeButton.Enabled = true;
            deleteBarcodeButton.Enabled = true;
        }

        public ProductNewOrEdit(string barcode)
        {
            InitializeComponent();
            barcodeComboBox.Text = barcode;
            mode = "INVOICE MODE";
        }

        private void ProductNewOrEdit_Load(object sender, EventArgs e)
        {
            loadProductLinkComboBox();
            loadBarcodeComboBox();
            if (formTitleLabel.Text == "Edit Product")
            {
                SetProductDefaultValues();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Check if the user entered a valid number in the pack size text box.
            if (!int.TryParse(packSizeTextBox.Text, out int number))
            {
                MessageBox.Show("Please enter a number.", "Pack Size Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //TODO: Add comments
                ProductModel product = new ProductModel();
                product.BrandName = brandNameTextBox.Text;
                product.Description = productDescriptionTextBox.Text;
                product.PackSize = number;
                product.ProductLinkId = Convert.ToInt32(productLinkComboBox.SelectedValue);
                if (formTitleLabel.Text == "New Product")
                {
                    //Save the product that was just created. Check whether the product saved correctly.
                    int id = SqliteDAProduct.SaveProductAndGetId(product);
                    if (id != 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("New product created successfully", "New Product",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            //Set the product id variable equal to the product id saved to the database. The forms product id can be accessed by other forms that need it.
                            productId = id;
                            if(barcodeComboBox.Text != "")
                            {
                                BarcodeModel barcode = new BarcodeModel();
                                barcode.Barcode = barcodeComboBox.Text;
                                barcode.ProductId = id;
                                SqliteDataAccessBarcode.SaveBarcode(barcode);
                            }
                            this.Close();
                        }
                    }
                    else if (id == 0)
                    {
                        MessageBox.Show("Something went wrong. New product could not be saved.", "New Product Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else if (formTitleLabel.Text == "Edit Product")
                {
                    product.Id = this.product.Id;
                    bool result = SqliteDAProduct.UpdateProductById(product);
                    if (result == true)
                    {
                        DialogResult dialogResult = MessageBox.Show("Product updated successfully.", "Edit Product",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else if (result == false)
                    {
                        MessageBox.Show("Something went wrong. Product could not be updated.", "Edit Product Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (formTitleLabel.Text == "New Product")
            {
                brandNameTextBox.ResetText();
                packSizeTextBox.ResetText();
                productDescriptionTextBox.ResetText();
                productLinkComboBox.SelectedIndex = 0;
            }
            else if (formTitleLabel.Text == "Edit Product")
            {
                SetProductDefaultValues();
            }
        }

        private void SetProductDefaultValues()
        {
            productDescriptionTextBox.Text = product.Description;
            brandNameTextBox.Text = product.BrandName;
            packSizeTextBox.Text = product.PackSize.ToString();
            productLinkComboBox.SelectedIndex = productLinkComboBox.FindStringExact(product.ProductLinkName);
            loadBarcodeComboBox();
        }

        private void loadBarcodeComboBox()
        {
            barcodeComboBox.DataSource = SqliteDataAccessBarcode.GetBarcodesByProductId(product.Id);
            barcodeComboBox.DisplayMember = "Barcode";
            barcodeComboBox.ValueMember = "Id";
        }

        private void loadProductLinkComboBox()
        {
            productLinkComboBox.DataSource = SqliteDAProductLink.GetAllProductLinks();
            productLinkComboBox.ValueMember = "Id";
            productLinkComboBox.DisplayMember = "Name";
        }

        //Barcode Maintenance (ADD and DELETE) - ONLY IN PRODUCT EDIT MODE
        //1. Add Barcode To Product
        private void addBarcodeButton_Click(object sender, EventArgs e)
        {
            AddBarcode addBarcodeForm = new AddBarcode(product.Id);
            addBarcodeForm.ShowDialog();
            loadBarcodeComboBox();
        }

        //2. Delete Barcode
        private void deleteBarcodeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this barcode?",
                    "Delete Barcode", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = SqliteDataAccessBarcode.DeleteBarcodeById(Convert.ToInt32(barcodeComboBox.SelectedValue));
                if (result == true)
                {
                    DialogResult dialog = MessageBox.Show("Barcode was successfully deleted.", "Delete Barcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBarcodeComboBox();
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Something went wrong. Barcode could not be deleted.", "Delete Barcode Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
