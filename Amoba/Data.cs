﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
    class Data
    {
        public string[,] GameField = new string[20, 20];
        public string X, O;
        public bool IsItX;
        public Data(string[,] gf)
        {
            GameField = gf;
            IsItX = true;
        }

    }
}
