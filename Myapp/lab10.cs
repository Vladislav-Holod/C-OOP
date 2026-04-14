using System;
using System.Windows.Forms;

namespace LabForms
{
    public class MainForm : Form
    {
        TextBox tbQ = new TextBox();
        TextBox tbS = new TextBox();
        TextBox tbG = new TextBox();

        TextBox tbE = new TextBox(); // mouse X (readonly)
        TextBox tbY = new TextBox(); // mouse Y (readonly)

        TextBox tbSum = new TextBox();

        public MainForm()
        {
            Text = "Лабораторная работа (MouseMove)";
            Width = 500;
            Height = 300;

            Label l1 = new Label() { Text = "q", Top = 20, Left = 20 };
            Label l2 = new Label() { Text = "s", Top = 60, Left = 20 };
            Label l3 = new Label() { Text = "g", Top = 100, Left = 20 };

            tbQ.SetBounds(60, 20, 100, 20);
            tbS.SetBounds(60, 60, 100, 20);
            tbG.SetBounds(60, 100, 100, 20);

            Label le = new Label() { Text = "e (X)", Top = 150, Left = 20 };
            Label ly = new Label() { Text = "y (Y)", Top = 190, Left = 20 };

            tbE.SetBounds(60, 150, 100, 20);
            tbY.SetBounds(60, 190, 100, 20);

            tbE.ReadOnly = true;
            tbY.ReadOnly = true;

            Label lsum = new Label() { Text = "Sum", Top = 230, Left = 20 };
            tbSum.SetBounds(60, 230, 100, 20);
            tbSum.ReadOnly = true;

            Controls.AddRange(new Control[]
            {
                l1,l2,l3,le,ly,lsum,
                tbQ,tbS,tbG,tbE,tbY,tbSum
            });

            MouseMove += MainForm_MouseMove;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // координаты мыши
                tbE.Text = e.X.ToString();
                tbY.Text = e.Y.ToString();

                Text = $"Координаты: {e.X}, {e.Y}";

                // сумма координат
                tbSum.Text = (e.X + e.Y).ToString();

                // чтение пользовательских данных
                double q = double.Parse(tbQ.Text);
                double s = double.Parse(tbS.Text);
                double g = double.Parse(tbG.Text);

                double E = e.X;
                double Y = e.Y;

                // формула
                double R = q
                           + Math.Pow(Math.Sin(E), 2)
                           + Math.Cos(Y) * Math.Cos(s + g);

                Text = $"R = {R:F4} | Координаты: {e.X}, {e.Y}";
            }
            catch
            {
                Text = "ERROR";
            }
        }
    }
}