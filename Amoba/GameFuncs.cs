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
        public static IO io;
        public GameFuncs(Game g)
        {
            data = new Data(GenField());
            game = g;
            io = new IO($"{DateTime.UtcNow.ToShortDateString().Replace('.', '-')}{ DateTime.UtcNow.ToLongTimeString().Replace(':', '.')}.txt");
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
            string surrenderer = data.IsItX ? data.X : data.O,
                   winner = data.IsItX ? data.O : data.X,
                   message = $"{ surrenderer} feladta a játékot...\n{ winner} nyert!";

            MessageBox.Show(message, "Feladás");
            io.list_of_moves.Add($"{surrenderer} feladás => {winner} győzött.");
            io.WriteFile();
            if (DisplayFuncs.OpenFile())
            {
                io.OpenFile();
            }
            Application.Exit();
        }
        public static void Add(object sender, EventArgs e)
        {
            Label _this = sender as Label;
            if (_this.Text == "")
            {
                int x = Convert.ToInt32(_this.Name.Split('_')[1].Split('-')[0]), y = Convert.ToInt32(_this.Name.Split('_')[1].Split('-')[1]);
                data.GameField[x, y] = data.IsItX ? "X" : "O";
                io.list_of_moves.Add($"{(data.IsItX ? data.X : data.O)}-(AKA:{(data.IsItX ? "X" : "O")})->X:{x}|Y:{y}");
                data.IsItX = !data.IsItX;
                DisplayFuncs.Display(game);
            }
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


        private static bool rowSelect(string[,] gameField, string userSymbol)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                if (colSelect(i, gameField, userSymbol)) return true; 
            }
            return false;
        }

        private static bool colSelect(int row, string[,] gameField, string userSymbol)
        {
            for (int col = 0; col < gameField.GetLength(1); col++)
            {
                if (gameField[row, col] == userSymbol) return AllWayChecker(row, col, userSymbol, gameField);
            }
            return false;
        }

        private static bool AllWayChecker(int row, int col, string userSymbol, string[,] gameField)
        {
            if (Check_Vert(row, col, userSymbol, gameField)) return true;
            if (Check_Hori(row, col, userSymbol, gameField)) return true;
            if (Check_Diag(row, col, userSymbol, gameField)) return true;
            return false;
        }

        private static bool Check_Diag(int row, int col, string userSymbol, string[,] gameField)
        {   
            if (Diag_upLeft_downRight(row, col, userSymbol, gameField)) return true; //left up, right down check
            if (Diag_upRight_downLeft(row, col, userSymbol, gameField)) return true; //right up, left down check
            return false;
        }

        private static bool Diag_upRight_downLeft(int row, int col, string userSymbol, string[,] gameField)
        {
            bool isStillGood = true;
            int Row = row;
            for (int i = col + 1; i < 3; i++)    //check the field Diagonal up right start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol || gameField[Row, i] == "") isStillGood = false;
                Row--;
            }
            if (isStillGood) return true;
            Row = row;
            for (int i = col - 1; i < 3; i--)    //check the field Diagonal left down start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol || gameField[Row, i] == "") isStillGood = false;
                Row++;
            }
            return isStillGood;
        }

        private static bool Diag_upLeft_downRight(int row, int col, string userSymbol, string[,] gameField)
        {
            bool isStillGood = true;
            int Row = row;
            for (int i = col-1; i < 3; i--)    //check the field Diagonal up left start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol || gameField[Row, i] == "") isStillGood = false;
                Row--;
            }
            if (isStillGood) return true;
            Row = row;
            for (int i = col + 1; i < 3; i++)    //check the field Diagonal right down start at rowIndex,colIndex
            {
                if (gameField[Row, i] != userSymbol || gameField[Row, i] == "") isStillGood = false;
                Row++;
            }
            return isStillGood;
        }

        private static bool Check_Hori(int row, int col, string userSymbol, string[,] gameField)   //checks the field horizontaly starting at rowIndex;colIndex
        {
            bool stillGood = true;
            for (int i = col + 1; i < 3; i++) if (gameField[row, i] != userSymbol || gameField[row, i] == "") stillGood = false; //checking forward
            if (stillGood) return true;
            for (int i = col - 1; i < 3; i--) if (gameField[row, i] != userSymbol || gameField[row, i] == "") stillGood = false; //checking backward
            return stillGood;
        }

        private static bool Check_Vert(int row, int col, string userSymbol, string[,] gameField)   //checks the field verticaly starting at rowIndex;colIndex
        {
            bool stillGood = true;
            for (int i = row+1; i < 3; i++) if (gameField[i, col] != userSymbol || gameField[i, col] == "") stillGood = false; //checking upwards
            if (stillGood) return true;
            for (int i = row-1; i < 3; i--) if (gameField[i, col] != userSymbol || gameField[i,col]=="") stillGood = false; //checking downwards
            return stillGood;
        }
    }
}
