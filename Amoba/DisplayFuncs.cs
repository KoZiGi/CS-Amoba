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





        private List<Label> GenFields()
        {
            List<Label> fields = new List<Label>();

            for (int i = 1; i < 51; i++)
            {
                for (int g = 1; g < 51; g++)
                {
                    fields.Add(GenField(i, g));
                }
            }

            return fields;
        }
        private Label GenField(int x, int y)
        {
            return new Label()
            {
                Name = $"FieldItem{x}{y}",
                Top = 10 * y,
                Left = 10 * x,
                AutoSize = false,
                Size = new Size(10, 10)
            };



        }
    }
}
