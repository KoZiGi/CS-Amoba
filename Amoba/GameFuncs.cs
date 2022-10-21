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
            return Horizontal() || Vertical() || Diagonal() || Diagonal2();
        }
        private static bool Horizontal()
        {
            for (int oszlop = 0; oszlop < 20; oszlop++)
            {
                for (int sor = 0; sor < 20; sor++)
                {
                    try
                    {
                        if (data.GameField[sor, oszlop] != "")
                        {
                            int ok = 0;
                            for (int i = 1; i < 5; i++)
                            {
                                if (data.GameField[sor, oszlop] == data.GameField[sor+i, oszlop])
                                {
                                    ok++;
                                }
                            }
                            if (ok >= 4) return true;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return false;
        }
        private static bool Vertical()
        {
            
            for (int sor = 0; sor < 20; sor++)
            {
                for (int oszlop = 0; oszlop < 20; oszlop++)
                {
                    try
                    {
                        if (data.GameField[sor, oszlop] != "")
                        {
                            int ok = 0;
                            for (int i = 1; i < 5; i++)
                            {
                                if (data.GameField[sor, oszlop] == data.GameField[sor, oszlop + i])
                                {
                                    ok++;
                                }
                            }
                            if (ok >= 4) return true;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return false;

        }
        // [0,0]=>[20,20]

        private static bool Diagonal()
        {
            for (int sor = 0; sor < 20; sor++)
            {
                for (int oszlop = 0; oszlop < 20; oszlop++)
                {
                    try
                    {
                        if (data.GameField[sor, oszlop] != "")
                        {
                            int ok = 0;
                            for (int i = 1; i < 5; i++)
                            {
                                if (data.GameField[sor, oszlop] == data.GameField[sor + i, oszlop + i])
                                {
                                    ok++;
                                }
                            }
                            if (ok >= 4) return true;
                        }
                    }
                    catch (Exception)
                    {

                        break;
                    }
                    
                }
            }
            return false;
        }
        // [0,20]=>[20,0]
        private static bool Diagonal2()
        {
            for (int sor = 0; sor < 20; sor++)
            {
                for (int oszlop = 0; oszlop < 20; oszlop++)
                {
                    try
                    {
                        if (data.GameField[sor, oszlop] != "")
                        {
                            int ok = 0;
                            for (int i = 1; i < 5; i++)
                            {
                                if (data.GameField[sor, oszlop] == data.GameField[sor - i, oszlop + i])
                                {
                                    ok++;
                                }
                            }
                            if (ok >= 4) return true;
                        }
                    }
                    catch (Exception)
                    {

                        break;
                    }

                }
            }
            return false;
        }
    }
}
