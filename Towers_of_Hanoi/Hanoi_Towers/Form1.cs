using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanoi_Towers
{
    public partial class Form1 : Form
    {
        Sticks[] sticks = new Sticks[3];
        List<Disk> disks = new List<Disk>();
        static ControlCollection Control;
        public static bool restartClicked = false;
        public static bool solveClicked = false;
        Visible visible;
        Disk disk;
        public Form1()
        {
            InitializeComponent();
            Control = (ControlCollection)this.Controls;
            CreateForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void CreateForm()
        {
            this.Width = 1100;
            this.Height = 600;
            visible = new Visible(ref Control);
            visible.AddDesk();
            visible.AddAllButtons();
            visible.AddBox();
            Hanoi_Towers.Visible.putButton.Click += new EventHandler(AddDisksOnForm);
            Hanoi_Towers.Visible.restartButton.Click += new EventHandler(Rerun);
            for (int i = 0; i < 3; i++)
            {
                sticks[i] = new Sticks(ref Control);
                sticks[i].Add(i);
            }
        }
        public void Rerun(object sender, EventArgs e)
        {
            int disknum = Convert.ToInt32(Hanoi_Towers.Visible.numOfDisks.SelectedItem);
            Hanoi_Towers.Visible.restartClicked = true;
            for (int i = 0; i < 3; i++)
            {
                while (sticks[i].disksOnStick.Count != 0)
                {
                    sticks[i].disksOnStick.Peek().Dispose();
                    sticks[i].disksOnStick.Pop();
                }
            }
            for (int i = 0; i < disknum; i++)
                disks.Add(disk = new Disk(ref Control, ref sticks));
            for(int i = 0; i< disknum; i++)
            {
                disks[i].Add(i);
                disks[i].MoveDisk(disks[i].huh);
                disks[i].previous = sticks[0];
            }
        }
        public void AddDisksOnForm(object sender, EventArgs e)
        {
            int disknum = Convert.ToInt32(Hanoi_Towers.Visible.numOfDisks.SelectedItem);
            for(int i = 0; i < disknum; i++)
                disks.Add(disk = new Disk(ref Control, ref sticks));
            for(int i = 0; i < disknum; i++)
            {
                disks[i].Add(i);
                disks[i].MoveDisk(disks[i].huh);
            }
            if (disknum > 0)
            {
                Hanoi_Towers.Visible.putButton.Enabled = false;
                Hanoi_Towers.Visible.putButton.BackColor = Color.White;
                Hanoi_Towers.Visible.numOfDisks.Enabled = false;
            }
            else
                MessageBox.Show("Вы не выбрали количество дисков");
        }
    }
}
