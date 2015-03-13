using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace LifeProgress
{
    class FormWorker
    {
        //---------------------------------------------------------------------------
        public static void addControls(IEnumerable<Control> arr, Control contaner)
        {
            contaner.Controls.Clear();
            int yPos = 0;
            foreach (UserControl cont in arr)
            {
                cont.Location = new Point(0, yPos);
                yPos += cont.Size.Height;
                cont.Size = new Size(contaner.Size.Width - 20, cont.Size.Height);
                cont.Visible = true;                
                contaner.Controls.Add(cont);
            }
        }

        //---------------------------------------------------------------------------
        internal static Panel createPanelInside(Control control)
        {
            control.Controls.Clear();
            Panel pan = new Panel();
            int offset = 13;
            pan.Location = new Point(offset, offset);
            pan.Size = new Size(control.Size.Width - 2 * offset, control.Size.Height - 2 * offset);
            pan.AutoScroll = true;
            pan.Visible = true;
            control.Controls.Add(pan);
            return pan;
        }

        //---------------------------------------------------------------------------
        internal static void addControlDefault(Control item, Control contaner)
        {
            item.Size = new Size(1, 1);
            item.Location = new Point(0, 0);
            contaner.Controls.Add(item);
        }

        //---------------------------------------------------------------------------
        internal static Label createLabel(string text)
        {
            Label res = new Label();
            res.Text = text;
            res.AutoSize = true;
            return res;
        }
    }
}
