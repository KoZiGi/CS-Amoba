using System;
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
        public static List<string> PlayerRandomizer(string p1, string p2)
        {
            List<string> players = new List<string>();
            if (new Random().Next(1, 3) == 1)
            {
                players.Add(p1);
                players.Add(p2);
            }
            else
            {
                players.Add(p2);
                players.Add(p1);
            }
            return players;
        }
        public static void Surrender(object sender, EventArgs e)
        {
            MessageBox.Show($"{(data.IsItX ? data.X : data.O)} feladta a játékot...\n{(data.IsItX ? data.O : data.X)} nyert!", "Feladás");
            Application.Exit();
        }
        public static void Add(object sender, EventArgs e)
        {
            Label _this = sender as Label;
            if (_this.Text == "")
            {
                int x = Convert.ToInt32(_this.Name.Split('_')[1].Split('-')[0]), y = Convert.ToInt32(_this.Name.Split('_')[1].Split('-')[1]);
                data.GameField[x, y] = data.IsItX ? "X" : "O";
                data.IsItX = !data.IsItX;
                DisplayFuncs.Display(game);

            }
            else _this.Cursor = Cursors.No;

        }
        public static void Reset(object sender, EventArgs e)
        {
            Application.Restart();
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

        public static bool WinCheck()
        {
            bool isWin = colSelect(data.GameField, data.IsItX ? "X" : "O");
            return isWin;
        }

        private static bool colSelect(string[,] gameField, string userSymbol)
        {
            for (int row = 0; row < gameField.GetLength(0); row++) if (rowSelect(gameField, userSymbol, row)) return true;
            return false;
        }

        private static bool rowSelect(string[,] gameField, string userSymbol, int row)
        {
            for (int col = 0; col < gameField.GetLength(1); col++) if (selectedCheck(gameField, userSymbol, row, col)) return true;
            return false;
        }

        private static bool selectedCheck(string[,] gameField, string userSymbol, int row, int col)
        {
            if (gameField[row, col] == userSymbol)
            {
                if (checkVertical(gameField, userSymbol, row, col)) return true;
                if (checkHorizontal(gameField, userSymbol, row, col)) return true;
                if (checkDiagonalLeft(gameField, userSymbol, row, col)) return true;
                if (checkDiagonalRight(gameField, userSymbol, row, col)) return true;
            }
            return false;
        }

        private static bool checkDiagonalRight(string[,] gameField, string userSymbol, int row, int col)
        {
            try
            {
                int localCol = col + 1;
                for (int i = row + 1; i < row + 4; i++)
                {
                    if (gameField[row, i] != userSymbol) return false;
                    localCol++;
                }
            }
            catch (Exception)
            {
                try
                {
                    int localCol = col + 1;
                    for (int i = row - 1; i < row - 4; i--)
                    {
                        if (gameField[row, i] != userSymbol) return false;
                        localCol++;
                    }
                }
                catch (Exception)
                { }
                return true;
            }
            return true;
        }

        private static bool checkDiagonalLeft(string[,] gameField, string userSymbol, int row, int col)
        {
            try
            {
                int localCol = col+1;
                for (int i = row -1; i < row - 4; i--)
                {
                    if (gameField[row, localCol] != userSymbol) return false;
                    localCol++;
                } 
            }
            catch (Exception)
            {
                try
                {
                    int localCol = col - 1;
                    for (int i = row - 1; i < row - 4; i--)
                    {
                        if (gameField[row, localCol] != userSymbol) return false;
                        localCol--;
                    }
                }
                catch (Exception)
                { }
                return true;
            }
            return true;
        }

        private static bool checkHorizontal(string[,] gameField, string userSymbol, int row, int col)
        {
            try
            {
                for (int i = col + 1; i < col + 4; i++) if (gameField[row, i] != userSymbol) return false;
            }
            catch (Exception)
            {
                try
                {
                    for (int i = col - 1; i < col - 4; i--) if (gameField[row, i] != userSymbol) return false;
                }
                catch (Exception)
                { }
                return true;
            }
            return true;
        }

        private static bool checkVertical(string[,] gameField, string userSymbol, int row, int col)
        {
            try
            {
                for (int i = row + 1; i < row + 4; i++) if (gameField[i, col] != userSymbol) return false;
            }
            catch (Exception)
            {
                try
                {
                    for (int i = row - 1; i < row - 4; i--) if (gameField[i, col] != userSymbol) return false;
                }
                catch (Exception)
                {}
                return true;
            }
            return true;
        }
    }
}

