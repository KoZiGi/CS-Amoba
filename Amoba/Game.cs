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
        private static string p1, p2;
        private static GameFuncs GameFuncs;
        public Game(string player1, string player2)
        {
            GameFuncs = new GameFuncs(this);
            p1 = player1;
            p2 = player2;
            InitializeComponent();
        }
        public void Display()
        {
            
        }
        private void Game_Load(object sender, EventArgs e)
        {
            AddControls();
        }
        private void AddControls()
        {
            AddItems();
            SetSizes();
        }
        private void ShowFields()
        {
            foreach (Label field in DisplayFuncs.GenFields())
                Controls.Add(field);
        }
        private void ShowButtons()
        {
            Controls.Add(DisplayFuncs.GenButton(GameFuncs.Surrender, "SurrBtn",  "Feladás", 20, (20 * 22) - 15));
            Controls.Add(DisplayFuncs.GenButton(GameFuncs.Surrender, "RemakeBtn", "Újrakezdés", Controls.Find("_19-19", true)[0].Left - 40, (20 * 22) - 15));
        }
        private void ShowLabels()
        {
            Controls.Add(DisplayFuncs.GenLabel(p1, "p1Lbl", 20 + GetControl("SurrBtn").Left + GetControl("SurrBtn").Width + 10, (20 * 22) - 15));
            Controls.Add(DisplayFuncs.GenLabel(p2, "p2Lbl", 20 + GetControl("RemakeBtn").Left - GetControl("RemakeBtn").Width - 10, (20 * 22) - 15));
        }
        private Control GetControl(string name)
        {
            return Controls.Find(name, true)[0];
        }
        private void AddItems()
        {
            ShowFields();
            ShowButtons();
            ShowLabels();
        }

        private void SetSizes()
        {
            Width = 23 * 20;
            MaximumSize = new Size(Width, Height);
            MinimumSize = new Size(Width, Height);
        }
    }
}
