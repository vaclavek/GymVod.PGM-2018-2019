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
    public partial class Obrazce : Form
    {
        int l = 0;
        Graphics g;
        Pen pen;

        public Obrazce()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            g.DrawEllipse(pen, l, 10, 20, 20);
            l += 10;
        }

        private void Obrazce_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            pen = new Pen(Color.Red);

            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();

            for (int x = 1; x < 300; x++)
            {
                var y = 6 * x * x + 3 * x + 6;
                g.DrawRectangle(pen, x, y, 10, 10);
            }
        }
    }
}
