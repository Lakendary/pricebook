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
    public partial class AddBarcode : Form
    {
        public int productId;
        public AddBarcode(int productId)
        {
            InitializeComponent();
            this.productId = productId;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            barcodeTextBox.ResetText();       
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            BarcodeModel barcode = new BarcodeModel();
            barcode.Barcode = barcodeTextBox.Text;
            barcode.ProductId = this.productId;
            bool result = SqliteDataAccessBarcode.SaveBarcode(barcode);
            if (result == true)
            {
                DialogResult dialogResult = MessageBox.Show("New Barcode created successfully", "New Barcode",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (result == false)
            {
                MessageBox.Show("Something went wrong. New barcode could not be saved.", "New Category Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
