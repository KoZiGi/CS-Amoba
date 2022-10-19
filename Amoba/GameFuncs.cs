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
        public static void Surrender(object sender, EventArgs e)
        {
            MessageBox.Show($"{(data.IsItX?"X":"O")} feladta a játékot...\n{(data.IsItX ? "O" : "X")} nyert!","Feladás");
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

        public bool WinCheck()
        {
            bool isWin = rowSelect(data.GameField, data.IsItX?"X":"O");
            return isWin;
        }

        private bool rowSelect(string[,] gameField, string userSymbol)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                if (colSelect(i, gameField, userSymbol)) return true; 
            }
            return false;
        }

        private bool colSelect(int row, string[,] gameField, string userSymbol)
        {
            for (int col = 0; col < gameField.GetLength(1); col++)
            {
                if (gameField[row, col] == userSymbol) return AllWayChecker(row, col, userSymbol, gameField);
            }
            return false;
        }

        private bool AllWayChecker(int row, int col, string userSymbol, string[,] gameField)
        {
            if (Check_Vert(row, col, userSymbol, gameField)) return true;
            if (Check_Hori(row, col, userSymbol, gameField)) return true;
            if (Check_Diag(row, col, userSymbol, gameField)) return true;
            return false;
        }

        private bool Check_Diag(int row, int col, string userSymbol, string[,] gameField)
        {
            if (Diag_upLeft_downRight(row, col, userSymbol, gameField)) return true; //left up, right down check
            if (Diag_upRight_downLeft(row, col, userSymbol, gameField)) return true; //right up, left down check
            return false;
        }

        private bool Diag_upRight_downLeft(int row, int col, string userSymbol, string[,] gameField)
        {
            bool isStillGood = true;
            int Row = row;
            for (int i = col + 1; i < 3; i++)    //check the field Diagonal up right start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol) isStillGood = false;
                Row--;
            }
            if (isStillGood) return true;
            Row = row;
            for (int i = col - 1; i < 3; i--)    //check the field Diagonal left down start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol) isStillGood = false;
                Row++;
            }
            return isStillGood;
        }

        private bool Diag_upLeft_downRight(int row, int col, string userSymbol, string[,] gameField)
        {
            bool isStillGood = true;
            int Row = row;
            for (int i = col-1; i < 3; i--)    //check the field Diagonal up left start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol) isStillGood = false;
                Row--;
            }
            if (isStillGood) return true;
            Row = row;
            for (int i = col + 1; i < 3; i++)    //check the field Diagonal right down start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol) isStillGood = false;
                Row++;
            }
            return isStillGood;
        }

        private bool Check_Hori(int row, int col, string userSymbol, string[,] gameField)   //checks the field horizontaly starting at rowIndex;colIndex
        {
            bool stillGood = true;
            for (int i = col + 1; i < 3; i++) if (gameField[row, i] != userSymbol) stillGood = false; //checking forward
            if (stillGood) return true;
            for (int i = col - 1; i < 3; i--) if (gameField[row, i] != userSymbol) stillGood = false; //checking backward
            return stillGood;
        }

        private bool Check_Vert(int row, int col, string userSymbol, string[,] gameField)   //checks the field verticaly starting at rowIndex;colIndex
        {
            bool stillGood = true;
            for (int i = row+1; i < 3; i++) if (gameField[i, col] != userSymbol) stillGood = false; //checking upwards
            if (stillGood) return true;
            for (int i = row-1; i < 3; i--) if (gameField[i, col] != userSymbol) stillGood = false; //checking downwards
            return stillGood;
        }
    }
}
