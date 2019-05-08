using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obrazek.Properties;

namespace Obrazek
{
    public partial class Form1 : Form
    {

        private SmerEnum Smer { get; set; } = Form1.SmerEnum.R;
        private Random Random { get; set; } = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // pictureBox1.Load("slecna.jpg");
            // pictureBox1.Image = Resources.slecna;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            const int step = 10;
            switch (Smer)
            {
                case SmerEnum.L:
                    pictureBox1.Left -= step;
                    break;

                case SmerEnum.R:
                    pictureBox1.Left += step;
                    break;

                case SmerEnum.U:
                    pictureBox1.Top -= step;
                    break;

                case SmerEnum.D:
                    pictureBox1.Top += step;
                    break;
            }

            if(pictureBox1.Top < 0)
            {
                pictureBox1.Top = 0;
            }

            if(pictureBox1.Left < 0)
            {
                pictureBox1.Left = 0;
            }

            if (pictureBox1.Left + pictureBox1.Width > this.Width)
            {
                pictureBox1.Left = this.Width - pictureBox1.Width;
            }
            if (pictureBox1.Top + pictureBox1.Height > this.Height)
            {
                pictureBox1.Top = this.Height - pictureBox1.Height;
            }

            Smer = (SmerEnum)Random.Next(0, 4);
        }

        private enum SmerEnum
        {
            L,
            R,
            U,
            D
        }
    }
}
