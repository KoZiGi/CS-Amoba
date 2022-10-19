using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
namespace Amoba
{
    class IO
    {
        public string Filename;
        public IO(string filename)
        {
            list_of_moves = new List<string>();
            Filename = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\CS-Amoba\\" + filename;
        }
        public List<string> list_of_moves;
        public void WriteFile()
        {
            try
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\CS-Amoba\\");
            }
            catch (Exception) { }
            try
            {
                StreamWriter w = new StreamWriter(Filename);
                foreach (string line in list_of_moves)
                    w.WriteLine(line);
                w.Close();
            }
            catch (Exception e)
            {}
        }

        public void OpenFile()
        {
            try
            { Process.Start(Filename); }
            catch (Exception)
            {}
        }
    }
}
