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
        //public int invoiceId { get; set; } //For the main ui status bar
        public bool userClickedSaveButton { get; set; } //To check if user unexpectately closed the form
        public InvoiceModel invoice { get; set; }

        public InvoiceNewOrEdit()
        {
            InitializeComponent();
            this.invoice = new InvoiceModel();
        }

        public InvoiceNewOrEdit(int invoiceId)
        {
            InitializeComponent();
            this.invoice = new InvoiceModel();
            this.invoice = SqliteDAInvoice.GetInvoiceById(invoiceId);
            //this.invoiceId = invoice.Id;
            formTitleLabel.Text = "Edit Invoice";
            saveButton.Text = "Edit";
        }

        private void InvoiceNewAndEdit_Load(object sender, EventArgs e)
        {
            LoadStoreComboBox();
            userClickedSaveButton = false;
            if (formTitleLabel.Text == "Edit Invoice")
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
            
            if (!decimal.TryParse(invoiceAmountTextBox.Text, out decimal invoiceAmount))
            {
                MessageBox.Show("Please enter a positive number.", "Invoice Amount Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                invoice.Date = invoiceDateTimePicker.Value.ToString("yyyy-MM-dd");
                //This forces a positive number to be saved. It already doesn't allow the user to use a negative, but if they copy paste a negative number,
                //this will convert that negative number into a postive one.
                if(invoiceAmount > 0)
                {
                    invoice.InvoiceAmount = Math.Round(invoiceAmount, 2, MidpointRounding.ToEven);
                } else
                {
                    invoiceAmount = invoiceAmount * -1;
                    invoice.InvoiceAmount = Math.Round(invoiceAmount, 2, MidpointRounding.ToEven);
                }
                invoice.InvoiceNumber = invoiceNumberTextBox.Text;
                invoice.Saved = "Open";
                invoice.StoreId = Convert.ToInt32(storeComboBox.SelectedValue);

                //New Invoice
                if (formTitleLabel.Text == "New Invoice")
                {
                    int result = SqliteDAInvoice.SaveInvoice(invoice);
                    this.invoice = SqliteDAInvoice.GetInvoiceById(result);
                    if (result > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("New invoice created successfully", "New Invoice",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            userClickedSaveButton = true;
                            this.Close();
                        }
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Something went wrong. New invoice could not be saved.", "New Invoice Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Edit Invoice
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
                            userClickedSaveButton = true;
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

        private void invoiceAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //private void InvoiceNewOrEdit_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //}


        //public string GetInvoiceNumber()
        //{
        //    return invoiceId;
        //}
    }
}
