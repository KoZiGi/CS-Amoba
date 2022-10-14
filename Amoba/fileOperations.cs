using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Amoba
{
    class fileOperations
    {

        public static string readDes(string filename)
        {
            StreamReader read = new StreamReader(filename, Encoding.Default);
            string des = "";
            try
            {
                while (!read.EndOfStream)
                {
                    des += read.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return des;
        }
    }
}
