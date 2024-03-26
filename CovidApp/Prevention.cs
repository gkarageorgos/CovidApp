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
    public partial class Prevention : Form
    {
        private Menu menuInstance;
        public Prevention(Menu menu)
        {
            InitializeComponent();
            this.menuInstance = menu;
        }

        private void backBbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuInstance.Show();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Prevention_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
