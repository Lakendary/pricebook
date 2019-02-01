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

namespace MainUI.Store
{
    public partial class StoreNewOrEdit : Form
    {
        public StoreNewOrEdit()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StoreModel store = new StoreModel();
            if(storeNameTextBox.Text == "")
            {
                MessageBox.Show("A store must at least have a name.\nEnter a store name.",
                    "Store Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                store.Name = storeNameTextBox.Text;
                store.Location = storeLocationTextBox.Text;
                bool result = SqliteDAStore.SaveStore(store);
                if (result == true)
                {
                    DialogResult dialogResult = MessageBox.Show("New store created successfully", "New Store",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }

                }
                else if (result == false)
                {
                    MessageBox.Show("Something went wrong. New store could not be saved.", "New Store Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            storeNameTextBox.ResetText();
            storeLocationTextBox.ResetText();
        }
    }
}
