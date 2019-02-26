using MainUI.Store;
using PriceBookClassLibrary;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace MainUI.Invoice
{
    public partial class InvoiceNewOrEdit : Form
    {
        //TODO: Add comments
        //Global variables
        public int invoiceId { get; set; } //For the main ui status bar
        InvoiceModel invoice = new InvoiceModel();

        public InvoiceNewOrEdit()
        {
            InitializeComponent();
        }

        public InvoiceNewOrEdit(int invoiceId)
        {
            InitializeComponent();
            this.invoice = SqliteDAInvoice.GetInvoiceById(invoiceId);
            this.invoiceId = invoice.Id;
            formTitleLabel.Text = "Edit Invoice";
            saveButton.Text = "Edit";
        }

        private void InvoiceNewAndEdit_Load(object sender, EventArgs e)
        {
            //TODO: Show location as well in the store combo box.
            LoadStoreComboBox();
            if(formTitleLabel.Text == "Edit Invoice")
            {
                SetInvoiceDefaultValues();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if(formTitleLabel.Text == "New Invoice")
            {
                invoiceAmountTextBox.ResetText();
                invoiceNumberTextBox.ResetText();
                storeComboBox.SelectedIndex = 0;
            } else if (formTitleLabel.Text == "Edit Invoice")
            {
                SetInvoiceDefaultValues();
            }
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
                if (formTitleLabel.Text == "New Invoice")
                {
                    invoiceId = SqliteDAInvoice.SaveInvoice(invoice);
                    if (invoiceId > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("New invoice created successfully", "New Invoice",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else if (invoiceId == 0)
                    {
                        MessageBox.Show("Something went wrong. New invoice could not be saved.", "New Invoice Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (formTitleLabel.Text == "Edit Invoice")
                {
                    invoice.Id = this.invoice.Id;
                    bool result = SqliteDAInvoice.UpdateInvoiceById(invoice);
                    if (result)
                    {
                        DialogResult dialogResult = MessageBox.Show("Invoice updated successfully", "Edit Invoice",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Something went wrong. Invoice could not be updated.", "Edit Invoice Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void LoadStoreComboBox()
        {
            storeComboBox.DataSource = SqliteDAStore.GetAllStoresForComboBox();
            storeComboBox.DisplayMember = "Name";
            storeComboBox.ValueMember = "Id";
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

        private void addStoreButton_Click(object sender, EventArgs e)
        {
            StoreNewOrEdit storeForm = new StoreNewOrEdit();
            storeForm.ShowDialog();
            LoadStoreComboBox();
        }

        private void SetInvoiceDefaultValues()
        {
            storeComboBox.SelectedIndex = storeComboBox.FindStringExact(this.invoice.StoreName);
            invoiceDateTimePicker.Value = DateTime.Parse(invoice.Date.ToString());
            invoiceAmountTextBox.Text = invoice.InvoiceAmount.ToString();
            invoiceNumberTextBox.Text = invoice.InvoiceNumber;
        }
        //public string GetInvoiceNumber()
        //{
        //    return invoiceId;
        //}
    }
}
