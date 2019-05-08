using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Graf : Form
    {
        private double a = 0.0004;
        private double b = 0.0002;
        private double c = 0.01;
        private double d = 2.0;

        private PointF[] p = new PointF[200];

        public Graf()
        {
            InitializeComponent();

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

            Calc();
        }

        private void Calc()
        {
            for (int x = -100; x < 100; x++)
            {
                double res = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;
                p[x + 100] = new PointF(x, (float)res);

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(150, 150);
            e.Graphics.ScaleTransform(1, 0.25F);
            e.Graphics.DrawLines(Pens.Blue, p);
        }
    }
}