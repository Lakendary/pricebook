using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainUI.Report
{
    public partial class Reports : Form
    {
        //******************************************************************************************************
        //  Index
        //******************************************************************************************************
        //  1. Global variables
        //  2. Events Initialize methods
        //  3. Form Load Event
        //  4. Mouse Button Clicks
        //  5. Other Event Methods
        //  6. Other Methods
        //******************************************************************************************************

        //  Global variables
        //******************************************************************************************************
        public DataGridView DataGridView { get; set; }
        

        //  Methods
        //  Events - Initialize
        //******************************************************************************************************
        //  1. New Product Initialize
        public Reports()
        {
            InitializeComponent();
        }
    }
}
