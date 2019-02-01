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

namespace MainUI.Invoice
{
    public partial class InvoiceNewOrEdit : Form
    {
        public InvoiceNewOrEdit()
        {
            InitializeComponent();
        }

        private void InvoiceNewAndEdit_Load(object sender, EventArgs e)
        {
            //TODO: Show location as well in the store combo box.
            storeComboBox.DataSource = SqliteDAStore.GetAllStores();
            storeComboBox.DisplayMember = "Name";
            storeComboBox.ValueMember = "Id";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            invoiceAmountTextBox.ResetText();
            invoiceNumberTextBox.ResetText();
            storeComboBox.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            InvoiceModel invoice = new InvoiceModel();
            
            if (!decimal.TryParse(invoiceAmountTextBox.Text, out decimal number))
            {
                MessageBox.Show("Please enter a number.", "Invoice Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                invoice.Date = invoiceDateTimePicker.Value.ToString("yyyy-MM-dd");
                invoice.InvoiceAmount = Math.Round(number, 2, MidpointRounding.ToEven);
                invoice.InvoiceNumber = invoiceNumberTextBox.Text;
                invoice.Saved = "Open";
                invoice.StoreId = Convert.ToInt32(storeComboBox.SelectedValue);
                bool result = SqliteDAInvoice.SaveInvoice(invoice);
                if (result == true)
                {
                    DialogResult dialogResult = MessageBox.Show("New invoice created successfully", "New Invoice",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else if (result == false)
                {
                    MessageBox.Show("Something went wrong. New invoice could not be saved.", "New Invoice Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GenerateInvoiceNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000);
            string invoiceNumber = string.Format("{0}{1}{2}", invoiceDateTimePicker.Value.ToString("yyyyMMdd"), 
                storeComboBox.SelectedValue.ToString().PadLeft(3,'0'), 
                randomNumber.ToString().PadLeft(3,'0'));
            return invoiceNumber;
        }

        private void generateInvoiceNumberButton_Click(object sender, EventArgs e)
        {
            if(invoiceDateTimePicker.Value == null)
            {
                MessageBox.Show("First pick a invoice date.", "Invoice Date Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(storeComboBox.Text == "")
            {
                MessageBox.Show("First pick a store.", "Store Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                invoiceNumberTextBox.Text = GenerateInvoiceNumber();
            }
        }
    }
}
