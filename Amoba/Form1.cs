using System;
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
            Leiras des= new Leiras(this);
            des.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p1 = textBox1.Text;
            string p2 = textBox2.Text;
            if (p1 == p2)
                MessageBox.Show("Nem egyezhet a két játékos neve","Hibás nevek",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                if (p1 == "" || p2 == "") MessageBox.Show("Á játékosok neve nem lehet üres!", "Hibás nevek", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else InitGame(p1, p2);
            }
        }
        private void InitGame(string p1, string p2)
        {
            Game jatek = new Game(p1, p2);
            jatek.Show();
            Hide();
        }
    }
}
