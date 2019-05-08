using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdpuzovanaKulicka
{
    public partial class Form1 : Form
    {
        Point ball = new Point(120, 100);
        Point kurzor;
        int polomer = 10;
        double gFX, gFY;
        double vX , vY ;
        double time;
        double G = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            kurzor = this.PointToClient(Cursor.Position);
            g.FillEllipse(Brushes.Black, kurzor.X - (polomer / 2), kurzor.Y - (polomer / 2), polomer, polomer);

            
            double vzdalenost = Math.Sqrt(Math.Pow(ball.X - kurzor.X, 2) + Math.Pow(ball.Y - kurzor.Y, 2));
            double uhel;
            if (ball.X == kurzor.X)
            {
                uhel = 90;
            }
            else
            {
                uhel = Math.Atan(Math.Abs(ball.Y - kurzor.Y) / Math.Abs(ball.X - kurzor.X));
            }

            double gF = Convert.ToInt32(G * (100) / Math.Pow(vzdalenost, 2));




            if (ball.X != kurzor.X)
            {
                gFX = Math.Sin(uhel) * gF;

                if (ball.X > kurzor.X)
                {
                    vX = vX + gFX;
                }
                else
                {
                    vX = vX - gFX;
                }
            }

            if (ball.Y != kurzor.Y)
            {
                gFY = Math.Cos(uhel) * gF;

                if (ball.Y > kurzor.Y)
                {
                    vX = vY + gFY;
                }
                else
                {
                    vY = vY - gFY;
                }
            }
            

            ball.X += Convert.ToInt32(vX * time);
            ball.Y += Convert.ToInt32(vY * time);

            if (ball.X < 0)
            {
                ball.X = Math.Abs(ball.X);
                vX = vX * -1;
            }

            if (ball.Y < 0)
            {
                ball.Y = Math.Abs(ball.Y);
                vY = vY * -1;
            }

            if (ball.X + polomer > this.ClientSize.Width)
            {
                vX = vX * -1;
                ball.X = this.ClientSize.Width - polomer;
            }

            if (ball.Y + polomer > this.ClientSize.Height)
            {
                vY = vY * -1;
                ball.Y = this.ClientSize.Height - polomer;
            }


            g.FillEllipse(Brushes.Black, ball.X - (polomer / 2), ball.Y - (polomer / 2), polomer, polomer);

            gFY = 0;
            gFX = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = timer1.Interval / 10;

            MessageBox.Show("Posnažil jsem se, ale bohužel je to dost plné bugů :(");
        }
    }
}
