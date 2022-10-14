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
    public partial class amobaDes : Form
    {
        Form1 dx;
        public amobaDes(Form1 d)
        {
            dx = d;
            InitializeComponent();
        }

        private void amobaDes_Load(object sender, EventArgs e)
        {
            desLblGen();
        }

        private void mainpageBtn_Click(object sender, EventArgs e)
        {
            dx.Show();
            Close();
        }

        private void driveBackBtn(Label des_lbl)
        {
            Button mainpageBtn = new Button()
            {
                Text = "Ready",
                AutoSize = true,
                Top = des_lbl.Height + 20,
                Left = (des_lbl.Width / 2) + 10
            };
            mainpageBtn.Click += mainpageBtn_Click;
            Controls.Add(mainpageBtn);
        }

        private void desLblGen()
        {
            Label des_lbl = new Label()
            {
                Text = makeItPrety(fileOperations.readDes("des.txt")),
                AutoSize = true,
                Top = 10,
                Left = 10
            };
            Controls.Add(des_lbl);
            driveBackBtn(des_lbl);
        }
            
        private string makeItPrety(string v)
        {
            return v.Replace(".", ".\n");
        }
    }
}
