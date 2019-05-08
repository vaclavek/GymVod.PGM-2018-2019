using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private int cislo = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Ahoj !";
            label1.Text = "Můj label";

            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = cislo.ToString();
            cislo++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            // webBrowser1.Url = new Uri("http://www.seznam.cz");
            timer1.Start();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOtevriGraf_Click(object sender, EventArgs e)
        {
            Graf graf = new Graf();
            //graf.Username = textBox1.Text;
            //graf.SetPassword("Tajné heslo");
            //graf.ShowDialog();
            graf.PredejUdajeAZobraz(textBox1.Text, "Moje heslo");
        }
    }
}
