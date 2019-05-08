using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snenulak
{
    public partial class Form1 : Form
    {
        int pocitadlo = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            switch (pocitadlo)
            {
                case 0:
                    g.DrawEllipse(Pens.Black, 40, 40, 40, 40);
                    g.DrawEllipse(Pens.Black, 40, 80, 60, 60);
                    g.DrawEllipse(Pens.Black, 40, 140, 80, 80);
                    pocitadlo = 1;
                    break;
                case 1:
                    g.DrawEllipse(Pens.Black, 60, 40, 40, 40);
                    g.DrawEllipse(Pens.Black, 50, 80, 60, 60);
                    g.DrawEllipse(Pens.Black, 40, 140, 80, 80);
                    pocitadlo = 2;
                    break;
                case 2:
                    g.DrawEllipse(Pens.Black, 80, 40, 40, 40);
                    g.DrawEllipse(Pens.Black, 60, 80, 60, 60);
                    g.DrawEllipse(Pens.Black, 40, 140, 80, 80);
                    pocitadlo = 3;
                    break;
                case 3:
                    g.DrawEllipse(Pens.Black, 60, 40, 40, 40);
                    g.DrawEllipse(Pens.Black, 50, 80, 60, 60);
                    g.DrawEllipse(Pens.Black, 40, 140, 80, 80);
                    pocitadlo = 0;
                    break;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
