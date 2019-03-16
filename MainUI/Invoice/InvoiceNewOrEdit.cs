using FluentValidation.Results;
using MainUI.Store;
using PriceBookClassLibrary;
using PriceBookClassLibrary.Validators;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace MainUI.Invoice
{
    public partial class InvoiceNewOrEdit : Form
    {
        //******************************************************************************************************
        //  Index
        //******************************************************************************************************
        //  1. Global variables
        //  2. Events Initialize methods
        //  3. Form Load Event
        //  4. Mouse Button Clicks
        //  5. Other Methods
        //******************************************************************************************************
        //Global variables
        //******************************************************************************************************
        public bool userClickedSaveButton { get; set; } = false;//To check if user unexpectately closed the form
        public InvoiceModel invoice { get; set; } = new InvoiceModel();
        InvoiceModel existingInvoice = new InvoiceModel();
        bool newInvoice = true;

        //Methods
        //Events - Initialize
        //******************************************************************************************************
        public InvoiceNewOrEdit()
        {
            InitializeComponent();
        }

        public InvoiceNewOrEdit(int invoiceId)
        {
            InitializeComponent();
            this.existingInvoice = SqliteDAInvoice.GetInvoiceById(invoiceId);
            formTitleLabel.Text = "Edit Invoice";
            saveButton.Text = "Edit";
            this.newInvoice = false;
        }

        //Events - Form Load
        //******************************************************************************************************
        private void InvoiceNewAndEdit_Load(object sender, EventArgs e)
        {
            LoadStoreComboBox();
            if (!this.newInvoice)
            {
                SetInvoiceDefaultValues();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SetInvoiceInformation();
            if (ValidateInvoiceInformation())
            {
                if (this.newInvoice)
                {
                    saveNewInvoiceInformationToDb();
                }
                else if (!this.newInvoice)
                {
                    saveExistingInvoiceInformationToDb();
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (this.newInvoice)
            {
                ClearInvoiceToBlankValues();
            }
            else if (!this.newInvoice)
            {
                SetInvoiceDefaultValues();
            }
        }

        private void addStoreButton_Click(object sender, EventArgs e)
        {
            StoreNewOrEdit storeForm = new StoreNewOrEdit();
            storeForm.ShowDialog();
            LoadStoreComboBox();
        }

        private void generateInvoiceNumberButton_Click(object sender, EventArgs e)
        {
            if (invoiceDateTimePicker.Value == null)
            {
                MessageBox.Show("First pick a invoice date.", "Invoice Date Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (storeComboBox.Text == "")
            {
                MessageBox.Show("First pick a store.", "Store Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                invoiceNumberTextBox.Text = GenerateInvoiceNumber();
            }
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

        private void LoadStoreComboBox()
        {
            storeComboBox.DataSource = SqliteDAStore.GetAllStoresForComboBox();
            storeComboBox.DisplayMember = "Name";
            storeComboBox.ValueMember = "Id";
        }

        private void SetInvoiceDefaultValues()
        {
            storeComboBox.SelectedIndex = storeComboBox.FindStringExact(this.existingInvoice.StoreName);
            invoiceDateTimePicker.Value = DateTime.Parse(this.existingInvoice.Date.ToString());
            invoiceAmountTextBox.Text = this.existingInvoice.InvoiceAmount.ToString();
            invoiceNumberTextBox.Text = this.existingInvoice.InvoiceNumber;
        }

        private void ClearInvoiceToBlankValues()
        {
            invoiceAmountTextBox.ResetText();
            invoiceNumberTextBox.ResetText();
            storeComboBox.SelectedIndex = 0;
        }

        private void SetInvoiceInformation()
        {
            this.invoice.InvoiceAmount = ConvertToMoneyAmount(invoiceAmountTextBox.Text);
            this.invoice.Date = invoiceDateTimePicker.Value.ToString("yyyy-MM-dd");
            this.invoice.InvoiceNumber = invoiceNumberTextBox.Text;
            this.invoice.Saved = "Open";
            this.invoice.StoreId = Convert.ToInt32(storeComboBox.SelectedValue);

            if (!this.newInvoice)
            {
                this.invoice.Id = this.existingInvoice.Id;
            }
        }

        private decimal ConvertToMoneyAmount(string input)
        {
            if (!decimal.TryParse(input, out decimal result))
            {
                //This forces a positive number to be saved. It already doesn't allow the user to use a negative, but if they copy paste a negative number,
                //this will convert that negative number into a postive one.
                if (result < 0)
                {
                    result = result * -1;
                }
            }
            result = result + Convert.ToDecimal(0.0001);
            result = Math.Round(result, 2, MidpointRounding.ToEven);

            return result;
        }

        private bool ValidateInvoiceInformation()
        {
            // Validate my data and save in the results variable
            InvoiceValidator invoiceValidator = new InvoiceValidator();
            var results = invoiceValidator.Validate(this.invoice);

            // Check if the validator found any validation errors. 
            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show($"{ failure.ErrorMessage }", "Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private void saveNewInvoiceInformationToDb()
        {
            this.invoice.Id = SqliteDAInvoice.SaveInvoice(invoice);
            if (this.invoice.Id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("New invoice created successfully", "New Invoice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    userClickedSaveButton = true;
                    this.Close();
                }
            }
            else if (this.invoice.Id == 0)
            {
                MessageBox.Show("Something went wrong. New invoice could not be saved." +
                    "\nCheck the error log for more information.", "New Invoice Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveExistingInvoiceInformationToDb()
        {
            invoice.Id = this.invoice.Id;
            if (SqliteDAInvoice.UpdateInvoiceById(invoice))
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
                MessageBox.Show("Something went wrong. Invoice could not be updated." +
                    "\nCheck the error log for more information.", "Edit Invoice Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
