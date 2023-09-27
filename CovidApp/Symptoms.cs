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
    public partial class Symptoms : Form
    {
        private Menu menuInstance;
        public Symptoms(Menu menu)
        {
            InitializeComponent();
            this.menuInstance = menu;
        }

        private void backBbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuInstance.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDialopg = new PrintDialog();
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void Symptoms_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
