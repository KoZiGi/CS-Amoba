﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Amoba
{
    class GameFuncs
    {
        public static Data data;
        public static Game game;
        public GameFuncs(Game g)
        {
            data = new Data(GenField());
            game = g;
        }
        public static void Surrender(object sender, EventArgs e)
        {

        }
        public static void Add(object sender, EventArgs e)
        {
            Label _this = sender as Label;
            if (_this.Text == "")
            {
                int x = Convert.ToInt32(_this.Name.Split('_')[1].Split('-')[0]), y = Convert.ToInt32(_this.Name.Split('_')[1].Split('-')[1]);
                data.GameField[x, y] = data.IsItX ? "X" : "O";
                DisplayFuncs.Display(game);
            }
            else _this.Cursor = Cursors.No;
            
        }
        public static void Reset(object sender, EventArgs e)
        {

        }

        private static string[,] GenField()
        {
            string[,] f = new string[20, 20];
            for (int i = 0; i < f.GetLength(0); i++)
            {
                for (int g = 0; g < f.GetLength(1); g++)
                {
                    f[i, g] = "";
                }
            }
            return f;
        }


    }
}
