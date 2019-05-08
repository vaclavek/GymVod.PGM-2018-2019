using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericUpDown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Číslo: " + numericUpDown1.Value);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            MessageBox.Show(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RekurzivniFunkce(Convert.ToInt32(numericUpDown1.Value)).ToString());
        }

        int RekurzivniFunkce(int cislo)
        {
            if (cislo < 1)
            {
                MessageBox.Show("Není definováno pro čísla menší než 1", "Rekurze", MessageBoxButtons.OK);
                return 0;
            }
            if (cislo == 1)
            {
                return 1;
            }
            if (cislo == 2)
            {
                return 1;
            }
            if (cislo % 2 != 0)
            {
                return cislo;
            }

            return 2 * RekurzivniFunkce(cislo - 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var trida = new Trida();
            trida.Metoda();
        }
    }

}
