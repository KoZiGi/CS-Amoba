using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Amoba
{
    class DisplayFuncs
    {





        public static List<Label> GenFields()
        {
            List<Label> fields = new List<Label>();

            for (int i = 1; i < 21; i++)
            {
                for (int g = 1; g < 21; g++)
                {
                    fields.Add(GenField(i, g));
                }
            }

            return fields;
        }
        private static Label GenField(int x, int y)
        {
            return new Label()
            {
                Name = $"FieldItem{x}{y}",
                Top = 20 * y,
                Left = 20 * x,
                AutoSize = false,
                Size = new Size(20, 20),
                BorderStyle = BorderStyle.FixedSingle
            };



        }
    }
}
