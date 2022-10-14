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
    public partial class Game : Form
    {
        DisplayFuncs df = new DisplayFuncs();
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            foreach (Label field in DisplayFuncs.GenFields())
            {
                Controls.Add(field);
            }
            Width = 23 * 20;
        }
    }
}
