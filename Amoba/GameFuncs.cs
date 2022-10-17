using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
    class GameFuncs
    {

        public static void Surrender(object sender, EventArgs e)
        {

        }

        public static void Reset(object sender, EventArgs e)
        {

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
