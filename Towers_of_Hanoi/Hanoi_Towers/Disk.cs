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
    class Disk
    {
        public ControlCollection control;
        public int diskHeight = 21;
        public int diskWidth = 170;
        public Panel disk;
        public bool huh = true;
        public Sticks previous;
        static Sticks[] sticksFromDisk = new Sticks[3];
        Visible visible;
        //Movement movement;

        public Disk(ref ControlCollection Control, ref Sticks[] sticks)
        {
            this.control = Control;
            Disk.sticksFromDisk = sticks;
            this.previous = sticks[0]; 
        }
        public void Add(int i)
        {
            disk = new Panel();
            disk.Location = new Point(340 + (i * 10), 400 - ((i + 1) * diskHeight));
            disk.BorderStyle = BorderStyle.FixedSingle;
            disk.Size = new Size(diskWidth - (i * 20), diskHeight);
            disk.BackColor = Color.FromArgb(200 - i * 15, 255 - i * 20, 255 - i * 25);
            this.control.Add(disk);
            sticksFromDisk[0].disksOnStick.Push(disk);
            Visible.restartClicked = false;
        }
        Point current;
        private void DiskMouseDown(object sender, MouseEventArgs e)
        {
            if (Visible.solveButton.Enabled != false)
            {
                if (previous.disksOnStick.Peek().Size == disk.Size)
                {

                    if (e.Button == MouseButtons.Left)
                    {
                        current = new Point(e.X, e.Y);
                    }
                }
                else
                {
                    huh = huh && false;
                }
            }
        }

        public void DiskMouseMove(object sender, MouseEventArgs e)
        {
            if (Visible.solveButton.Enabled != false)
            {
                if (previous.disksOnStick.Peek().Size == disk.Size)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Point newlocation = disk.Location;
                        newlocation.X += e.X - current.X;
                        newlocation.Y += e.Y - current.Y;
                        disk.Location = newlocation;
                    }
                }
                else
                    huh = huh && false;
            }
        }

        private void DiskMouseUp(object sender, MouseEventArgs e)
        {
            int delta = 70;
            Panel disk = sender as Panel;
            if (Visible.solveButton.Enabled != false)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (previous.disksOnStick.Peek().Size == disk.Size)
                    {
                        if (disk.Location.X <= sticksFromDisk[i].stick.Location.X + delta && disk.Location.X >= sticksFromDisk[i].stick.Location.X - delta)
                        {
                            if (sticksFromDisk[i].disksOnStick.Count == 0 || sticksFromDisk[i].disksOnStick.Peek().Width > disk.Width)
                            {
                                if (sticksFromDisk[i].disksOnStick.Count == 0)
                                {
                                    previous.disksOnStick.Peek().Location = new Point(sticksFromDisk[i].stick.Location.X - disk.Width / 2 + 3, sticksFromDisk[i].stick.Location.Y + sticksFromDisk[i].stick.Height - disk.Height);
                                    previous.disksOnStick.Pop();
                                    sticksFromDisk[i].disksOnStick.Push(disk);
                                    this.previous = sticksFromDisk[i];
                                }

                                else
                                {
                                    previous.disksOnStick.Peek().Location = new Point(sticksFromDisk[i].stick.Location.X - disk.Width / 2 + 3, sticksFromDisk[i].stick.Location.Y + sticksFromDisk[i].stick.Height - disk.Height * (sticksFromDisk[i].disksOnStick.Count + 1));
                                    previous.disksOnStick.Pop();
                                    sticksFromDisk[i].disksOnStick.Push(disk);
                                    this.previous = sticksFromDisk[i];
                                }
                            }
                            else
                            {
                                previous.disksOnStick.Peek().Location = new Point(previous.stick.Location.X - disk.Width / 2 + 3, previous.stick.Location.Y + sticksFromDisk[i].stick.Height - disk.Height * (previous.disksOnStick.Count));
                            }
                        }
                    }
                }
            }
        }

        public void MoveDisk(bool isAnime)
        {
            if (!(sticksFromDisk[1].disksOnStick.Count() == Visible.GetterSumOfDisk() || sticksFromDisk[2].disksOnStick.Count() == Visible.GetterSumOfDisk()))
            {
                if (huh || Visible.restartClicked == false)
                {
                    disk.MouseClick += new MouseEventHandler(DiskMouseDown);
                    disk.MouseMove += new MouseEventHandler(DiskMouseMove);
                    disk.MouseUp += new MouseEventHandler(DiskMouseUp);

                }
                else
                    MessageBox.Show("Нельзя_1");
            }
            else
                MessageBox.Show("Игра закончена");
        }
        public static void Solver(int num_disc, int start, int end, int temp)
        {
            if (Visible.putButton.Enabled == false)
            {
                if (!gameOver(Visible.GetterSumOfDisk()))
                {
                    if (num_disc > 1)
                        Solver(num_disc - 1, start, temp, end);


                    Movement.moveUp(sticksFromDisk[start].disksOnStick.Peek(), 50);

                    if (sticksFromDisk[start].disksOnStick.Peek().Location.X < sticksFromDisk[end].stick.Location.X)
                        Movement.moveRight(sticksFromDisk[start].disksOnStick.Peek(), sticksFromDisk[end].stick.Location.X - (sticksFromDisk[start].disksOnStick.Peek().Width / 2) + 3); //+3
                    else
                        Movement.moveLeft(sticksFromDisk[start].disksOnStick.Peek(), sticksFromDisk[end].stick.Location.X - (sticksFromDisk[start].disksOnStick.Peek().Width / 2) + 6); // +3

                    Movement.moveDown(sticksFromDisk[start].disksOnStick.Peek(), 390 - (sticksFromDisk[end].disksOnStick.Count + 1) * 21);


                    sticksFromDisk[end].disksOnStick.Push(sticksFromDisk[start].disksOnStick.Pop());

                    if (num_disc > 1)
                        Solver(num_disc - 1, temp, end, start);

                }
                else
                    MessageBox.Show("Верните начальное положение дисков");
            }
            else
                MessageBox.Show("Задайте кол-во дисков!");
        }
        public static bool gameOver(int num_disc)
        {
            if (sticksFromDisk[1].disksOnStick.Count() == num_disc || sticksFromDisk[2].disksOnStick.Count() == num_disc)
            {
                return true;
            }
            else
            {
                //MessageBox.Show(sticksFromDisk[1].disksOnStick.Count().ToString());
                return false;
            }
        }
    }
}
