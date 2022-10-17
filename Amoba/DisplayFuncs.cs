﻿using System;
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

            for (int i = 0; i < GameFuncs.data.GameField.GetLength(0) - 1; i++)
            {
                for (int g = 0; g < GameFuncs.data.GameField.GetLength(1) - 1; g++)
                {
                    Label l = game.Controls.Find($"_{i}-{g}", true)[0] as Label;
                    l.Text = GameFuncs.data.GameField[i, g];
                    if (l.Text == "X") l.ForeColor = Color.HotPink;
                    else l.ForeColor = Color.Black;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }
        public static List<Label> GenFields()
        {
            List<Label> fields = new List<Label>();

            for (int i = 1; i < 21; i++)
            {
                for (int g = 1; g < 21; g++)
                {
                    fields.Add(GenField(i, g));
                }
            }

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
        private static Label GenField(int x, int y)
        {
            Label lbl = new Label()
            {
                Name = $"_{x}-{y}",
                Top = 20 * y,
                Left = 20 * x,
                AutoSize = false,
                Size = new Size(20, 20),
                BorderStyle = BorderStyle.FixedSingle
            };
            lbl.Click += GameFuncs.Add;
            return lbl;
        }
    }
}
