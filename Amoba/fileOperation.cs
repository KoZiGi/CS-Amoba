using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Amoba
{
    class fileOperation
    {
        public static string desBeolvas(string filename)
        {
            StreamReader read = new StreamReader(filename, Encoding.Default);
            string des = "";
            while (!read.EndOfStream) des += read.ReadLine();
            read.Close();
            return des;
        }
    }
}
