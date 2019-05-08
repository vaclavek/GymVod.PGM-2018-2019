using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kresleni
{
    public partial class Form1 : Form
    {
        private PointF[] points = new PointF[20];

        public Form1()
        {
            InitializeComponent();
            Calculate();
        }

        private void Calculate()
        {
            for (int x = -10; x < 10; x++)
            {
                var y = 5 * x *  x + 6 * x + 3;
                points[x + 10] = new PointF(x, -y);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.TranslateTransform(200, 200);

            // e.Graphics.ScaleTransform(1, 0.2F);
            // osa X
            e.Graphics.DrawLine(Pens.Black, new Point(-100, 0), new Point(100, 0));

            // osa Y
            e.Graphics.DrawLine(Pens.Black, 0, 100, 0, -100);

            e.Graphics.DrawLines(Pens.Red, points);
        }
    }
}
