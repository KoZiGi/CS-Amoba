using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
    class GameFuncs
    {
        public static Data data = new Data(GenField());
        
        public static void Surrender(object sender, EventArgs e)
        {

        }
        //a
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


        public static List<string> PlayerRandomizer(string p1,string p2)
        {
            List<string> players = new List<string>();
            if (new Random().Next(1,3)==1)
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
    }
}
