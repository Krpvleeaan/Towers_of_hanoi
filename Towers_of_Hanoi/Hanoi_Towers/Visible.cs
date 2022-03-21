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
    public class Visible
    {
        public ControlCollection control;
        public static Panel desk;
        public static Button putButton;
        public static ComboBox numOfDisks;
        public Label choose;
        public static Button restartButton;
        public static Button solveButton;
        public static bool restartClicked = false;
        public static bool solveClicked = false;
        public Visible(ref ControlCollection Control)
        {
            this.control = Control;
        }
        public void AddDesk()
        {
            desk = new Panel();
            desk.Size = new Size(650, 20);
            desk.Location = new Point(320, 400);
            desk.BackColor = Color.Chocolate;
            this.control.Add(desk);
        }
        public void AddBox()
        {
            numOfDisks = new ComboBox();
            for (int i = 0, k = 3; i < 6; k++, i++)
                numOfDisks.Items.Add(k);
            numOfDisks.Size = new Size(60, 50);
            numOfDisks.Location = new Point(100, 55);
            numOfDisks.SelectedItem = 3;
            this.control.Add(numOfDisks);

            choose = new Label();
            choose.Text = "Выберите кол-во дисков";
            choose.Size = new Size(190, 15);
            choose.Location = new Point(30, 20);
            choose.Font = new Font("Consolas", 10, FontStyle.Regular);
            this.control.Add(choose);
        }
        public void AddAllButtons()
        {
            putButton = new Button();
            putButton.Size = new Size(70, 50);
            putButton.Location = new Point(170, 50);
            putButton.Text = "Поставить";
            this.control.Add(putButton);

            restartButton = new Button();
            restartButton.Text = "Начать заново";
            restartButton.Font = new Font("Consolas", 10, FontStyle.Regular);
            restartButton.Location = new Point(50, 270);
            restartButton.Size = new Size(150, 50);
            this.control.Add(restartButton);

            solveButton = new Button();
            solveButton.Text = "Решить автоматически";
            solveButton.Font = new Font("Consolas", 10, FontStyle.Regular);
            solveButton.Location = new Point(50, 400);
            solveButton.Size = new Size(150, 50);
            this.control.Add(solveButton);
            solveButton.Click += new EventHandler(Solve);

        }
        public static int GetterSumOfDisk()
        {
            return Convert.ToInt32(numOfDisks.SelectedItem);
        }
        public void Solve(object sender, EventArgs e)
        {
            Disk.Solver(GetterSumOfDisk(), 0, 2, 1);
            solveButton.Enabled = false;
            MessageBox.Show("Игра закончена");

        }
    }
}
