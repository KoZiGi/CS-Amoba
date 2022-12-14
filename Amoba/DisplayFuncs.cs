using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Amoba
{
    class DisplayFuncs
    {
        public static void Display(Game game)
        {
            for (int i = 0; i < GameFuncs.data.GameField.GetLength(0); i++)
            {
                for (int g = 0; g < GameFuncs.data.GameField.GetLength(1); g++)
                {
                    Control l = game.Controls.Find($"_{i}-{g}", true)[0];
                    Label x = l as Label;
                    x.Text = GameFuncs.data.GameField[i, g];
                    if (x.Text == "") x.Cursor = Cursors.Hand;
                    else x.Cursor = Cursors.Default;
                    if (x.Text == "X") x.ForeColor = Color.HotPink;
                    else x.ForeColor = Color.Black;
                    x.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }
        public static void ChangePlayerColors()
        {
            GameFuncs.data.p1Label.ForeColor = GameFuncs.data.IsItX ? Color.Red : Color.Black;
            GameFuncs.data.p2Label.ForeColor = GameFuncs.data.IsItX ? Color.Black : Color.Red;
        }
        public static List<Label> GenFields()
        {
            List<Label> fields = new List<Label>();
            for (int i = 0; i < 20; i++)
                for (int g = 0; g < 20; g++)
                    fields.Add(GenField(i, g));
            return fields;
        }
        public static Button GenButton(EventHandler function, string name, string buttontext, int x, int y)
        {
            Button btn = new Button()
            {
                Name = name,
                Text = buttontext,
                Top = y,
                Left = x,
                Width = 60
            };
            btn.Click += function;
            return btn;
        }
        public static Label GenLabel(string text, string name, int x, int y) 
        {
            return new Label()
            {
                Text = text,
                Name = name,
                Left = x,
                Top = y
            };
        }
        public static bool OpenFile()
        {
            DialogResult dialog = MessageBox.Show("Mentettem egy fájlt a játszmáról a dokumentumokba. Szeretnéd megnyitni?", "Játszma vége", MessageBoxButtons.YesNo);
            return dialog == DialogResult.Yes;
        }
        private static Label GenField(int x, int y)
        {
            Label lbl = new Label()
            {
                Name = $"_{x}-{y}",
                BackColor = Color.White,
                Top = 20 * (y + 1),
                Left = 20 * (x + 1),
                AutoSize = false,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(20, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };
            lbl.Click += GameFuncs.Add;
            return lbl;
        }
    }
}
