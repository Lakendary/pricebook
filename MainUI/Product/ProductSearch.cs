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
    public partial class ProductSearch : Form
    {
        public string barcode = "";
        public int productId { get; set; }
        DataGridViewRow row;
        public bool openNewProductForm { get; set; }
        public string mode;
        //TODO: Select item from data grid view and add invoice product details
        public ProductSearch(string mode)
        {
            InitializeComponent();
            this.mode = mode;
            //TODO: Add Plus picture to add product picture box
        }

        public ProductSearch(string barcode, string mode)
        {
            InitializeComponent();
            this.barcode = barcode;
            this.mode = mode;
        }

        private void ProductSearch_Load(object sender, EventArgs e)
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            //Combo box selection option. If the user wants to search for a product in all categories,
            //<ALL> can be chosen.
            CategoryModel category = new CategoryModel();
            category.Id = 0;
            category.Name = "<ALL>";

            //Load Combo Boxes. Add <ALL> option at the beginning of list.
            categories = SqliteDACategory.GetAllCategories();
            categories.Insert(0, category);
            categoryComboBox.DataSource = categories;
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DisplayMember = "Name";

            //Default Selected Index
            categoryComboBox.SelectedIndex = 0;
            weightedComboBox.SelectedIndex = 0;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ProductModel product = new ProductModel();
            product.ProductLinkName = productLinkNameTextBox.Text;
            product.CategoryName = categoryComboBox.Text;
            product.BrandName = brandNameTextBox.Text;
            product.Description = productDescriptionTextBox.Text;
            product.Weighted = weightedComboBox.Text;
            productSearchDataGridView.DataSource = SqliteDAProduct.GetAllProducts(product);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            productLinkNameTextBox.ResetText();
            brandNameTextBox.ResetText();
            productDescriptionTextBox.ResetText();
            categoryComboBox.SelectedIndex = 0;
            weightedComboBox.SelectedIndex = 0;
        }

        private void addProductPictureBox_Click(object sender, EventArgs e)
        {
            //if(barcode != "")
            //{
            //    ProductNewOrEdit productForm = new ProductNewOrEdit(barcode);
            //    productForm.ShowDialog();
            //} else
            //{
            //    ProductNewOrEdit productForm = new ProductNewOrEdit();
            //    productForm.ShowDialog();
            //}
            openNewProductForm = true;
            this.Close();
        }

        private void productSearchDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (productSearchDataGridView.SelectedRows != null && productSearchDataGridView.SelectedRows.Count > 0 && mode == "INVOICE PRODUCT MODE")
                {
                    addProductToInvoiceButton.Enabled = true;
                }

                if (e.RowIndex >= 0)
                {
                    row = this.productSearchDataGridView.Rows[e.RowIndex];
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProductToInvoiceButton_Click(object sender, EventArgs e)
        {
            productId = Convert.ToInt32(row.Cells["Id"].Value);
            if(barcode != "")
            {
                BarcodeModel barcode = new BarcodeModel();
                barcode.Barcode = this.barcode;
                barcode.ProductId = productId;
                SqliteDataAccessBarcode.SaveBarcode(barcode);
            }
            this.Close();
        }
    }
}
