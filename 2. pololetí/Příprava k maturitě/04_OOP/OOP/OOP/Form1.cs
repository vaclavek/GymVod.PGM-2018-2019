using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            List<ITvar> tvary = new List<ITvar>();

            for (int i = 0; i < 1000; i++)
            {
                var cislo = random.Next(0, 3);
                var velikost = random.Next(20, 40);
                var velikost2 = random.Next(20, 40);

                ITvar tvar;
                if (cislo == 0)
                {
                    tvar = new Ctverec(velikost);
                }
                else if (cislo == 1)
                {
                    tvar = new Kruh(velikost);
                }
                else
                {
                    tvar = new Obdelnik(velikost, velikost2);
                }

                tvary.Add(tvar);
            }

            foreach (ITvar tvar in tvary)
            {
                listBox1.Items.Add(tvar.VratInformace() + ", obsah: " + tvar.VypoctiObsah());
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            e.
        }

        private void ČervenáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zvlenaBarva = Color.Red;
        }

        Color zvlenaBarva = Color.Black;
    }
}
