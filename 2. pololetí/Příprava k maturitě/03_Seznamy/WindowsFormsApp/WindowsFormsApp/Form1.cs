using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private List<string> data = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PridejRetezec(textBox1.Text);
        }

        private void PridejRetezec(string retezec)
        {
            data.Add(retezec);
            listBox1.Items.Add(retezec);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (data.Count == 0)
            {
                return;
            }

            int index = listBox1.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            data.RemoveAt(index);
            listBox1.Items.RemoveAt(index);
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var random = new Random();
            string retezec = "";
            int pocetZnaku = random.Next((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            for (int i = 0; i < pocetZnaku; i++)
            {
                int cislo = random.Next(97, 122);
                char znak = (char)cislo;

                retezec += znak;
            }

            PridejRetezec(retezec);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var odpoved = MessageBox.Show("Souhlasí počet prvků: " + data.Count + "?", "Počet prvků", MessageBoxButtons.YesNo);
            if (odpoved == DialogResult.Yes)
            {
                MessageBox.Show("OK!");
            }

            foreach (var item in data)
            {
                data.Remove(item);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int index = data.IndexOf(textBox1.Text);
            if (index < 0)
            {
                MessageBox.Show("Nebylo nalezeno", "Chyba!", MessageBoxButtons.RetryCancel);
            }
            else
            {
                MessageBox.Show("Je to " + index + ". prvek");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                button1.Left += 5;
            }
        }
    }
}
