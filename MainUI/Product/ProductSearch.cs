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
        //TODO: Select item from data grid view and add invoice product details
        public ProductSearch()
        {
            InitializeComponent();
            addProductPictureBox.Visible = false;
        }

        public ProductSearch(bool barcodeFound)
        {
            InitializeComponent();
            if (!barcodeFound)
            {
                //TODO: Add Plus picture to add product picture box
                //TODO: Open new product form when clicking on add product picture box
                addProductPictureBox.Visible = true;
            }
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
    }
}
