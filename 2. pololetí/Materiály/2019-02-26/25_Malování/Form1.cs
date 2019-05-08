using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationMalováníMatorutníOtázkaSyrovátka
{
    public partial class Form1 : Form
    {
        int sirka = 10;
        List<Bod> body = new List<Bod>();

        Brush brush = Brushes.Red;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < body.Count; i++)
            {
                var bod = body[i];
                g.FillEllipse(bod.Brush, bod.Souradnice.X, bod.Souradnice.Y, bod.Sirka, bod.Sirka);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                Bod x = new Bod();
                x.Souradnice = new Point(e.X, e.Y);
                x.Sirka = sirka;
                x.Brush = brush;
                body.Add(x);
                Refresh();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string barva = comboBox1.SelectedItem.ToString();

            switch (barva)
            {

                case "Red":
                    brush = Brushes.Red;
                    break;
                case "Green":
                    brush = Brushes.Green;
                    break;
                case "Blue":
                    brush = Brushes.Blue;
                    break;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            sirka = Convert.ToInt32(((RadioButton)sender).Text);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sirka = Convert.ToInt32(((RadioButton)sender).Text);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sirka = Convert.ToInt32(((RadioButton)sender).Text);

        }
    }
}
