using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\CS-Amoba\\"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\CS-Amoba\\");
                }
                StreamWriter w = new StreamWriter(Filename);
                foreach (string line in list_of_moves)
                    w.WriteLine(line);
                w.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }

        public void OpenFile()
        {
            try
            { Process.Start("notepad.exe", Filename); }
            catch (Exception)
            {}
        }
    }
}
