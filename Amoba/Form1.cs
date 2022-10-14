﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amoba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            amobaDes des= new amobaDes();
            des.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p1 = textBox1.Text;
            string p2 = textBox2.Text;
            if (p1==p2)
            {
                MessageBox.Show("Nem egyezhet a két játékos neve","Hibás nevek",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Game jatek = new Game(p1,p2);
                jatek.Show();
            }
            amobaDes desForm = new amobaDes(this);
            this.Hide();
            desForm.ShowDialog();
        }
    }
}
