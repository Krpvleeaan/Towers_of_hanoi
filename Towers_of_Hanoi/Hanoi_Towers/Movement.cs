using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanoi_Towers
{
    class Movement
    {
        public static void moveUp(Panel Disk, int newY)
        {
            // Start moving.
            while (Disk.Location.Y > newY)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X, Disk.Location.Y - 10);
                Thread.Sleep(10);
            }
        }
        public static void moveDown(Panel Disk, int newY)
        {
            // Start moving.
            while (Disk.Location.Y < newY)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X, Disk.Location.Y + 10);
                Thread.Sleep(10);
            }
        }
        public static void moveRight(Panel Disk, int newX)
        {
            // Start moving.
            while (Disk.Location.X < newX)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X + 10, Disk.Location.Y);
                Thread.Sleep(10);
            }

        }
        public static void moveLeft(Panel Disk, int newX)
        {
            // Start moving.
            while (Disk.Location.X > newX)
            {
                Disk.Location = new System.Drawing.Point(Disk.Location.X - 10, Disk.Location.Y);
                Thread.Sleep(10);
            }
        }
    }
}
