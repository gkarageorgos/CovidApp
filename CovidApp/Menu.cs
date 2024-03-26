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
    public partial class Menu : Form
    {
        private int picturesIndex = 0;
        private string[] pictures = new string[4];
        public Menu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"..\..\pictures\" + pictures[picturesIndex];
            picturesIndex = (picturesIndex + 1) % 4;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            pictures[0] = "picture1.png";
            pictures[1] = "picture2.jpg";
            pictures[2] = "picture3.png";
            pictures[3] = "picture4.png";
            pictureBox1.ImageLocation = @"..\..\pictures\" + pictures[picturesIndex];
            picturesIndex++;
        }

        private void preventiveMeasuresButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Prevention(this).Show();
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Statistics(this).Show();
        }

        private void SymptomsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Symptoms(this).Show();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Karageorgos Ioannis AM:ΜΠΠΛ21023");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
