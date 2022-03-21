using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Form;

namespace Hanoi_Towers
{
    class Sticks
    {
        public ControlCollection сontrol;
        public Panel stick;
        public Stack<Panel> disksOnStick = new Stack<Panel>();

        public Sticks(ref ControlCollection Control)
        {
            this.сontrol = Control;
        }

        public void Add(int i)
        {
            stick = new Panel();
            int d = 210;
            stick.Size = new Size(10, 200);
            stick.Location = new Point(d * (i + 2), 200);
            stick.BackColor = Color.DarkGoldenrod;
            this.сontrol.Add(stick);
        }
    }
}
