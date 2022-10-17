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
