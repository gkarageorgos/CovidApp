using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidApp
{
    public partial class viewResults : Form
    {
        private Menu menuInstance;
        private DataTable dataTable;
        private CheckedListBox.CheckedItemCollection[] checkedItemArrays;
        public viewResults(Menu menu, DataTable dataTable, CheckedListBox.CheckedItemCollection[] checkedItemArrays)
        {
            InitializeComponent();
            this.menuInstance = menu;
            this.dataTable = dataTable;
            this.checkedItemArrays = checkedItemArrays;
        }
        private void viewResults_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable;
        }

        private void viewResults_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Statistics(menuInstance, checkedItemArrays).Show();
        }
    }
}
