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
    public partial class Leiras : Form
    {
        public Form1 dx;
        public Leiras(Form1 d)
        {
            dx = d;
            InitializeComponent();
        }


        private void mainpageBtn_Click(object sender, EventArgs e)
        {
            dx.Show();
            Close();
        }

        private void returnBackBtn(Label des_lbl)
        {
            Button mainpageBtn = new Button()
            {
                Text = "Ready",
                AutoSize = true,
                Top = des_lbl.Size.Height + 20,
                Left = (des_lbl.Size.Width / 2) 
            };
            mainpageBtn.Click += mainpageBtn_Click;
            mainpageBtn.Left -= mainpageBtn.Size.Width / 2;
            Controls.Add(mainpageBtn);
        }

        private void Leiras_Load(object sender, EventArgs e)
        {
            Label des_lbl = new Label()
            {
                Text = fileOperation.desBeolvas("des.txt").Replace(". ", ".\n"),
                AutoSize = true,
                Top = 10,
                Left = 10
            };
            Controls.Add(des_lbl);
            returnBackBtn(des_lbl);
        }
    }
}
