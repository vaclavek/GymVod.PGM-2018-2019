using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Files
{
    public partial class Form1 : Form
    {
        private const string NazevSouboru = "mujsoubor.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUloz_Click(object sender, EventArgs e)
        {
            System.IO.File.AppendAllText(NazevSouboru, txtVstup.Text + "\r\n");
            txtVstup.Text = "";
            NactiData();
        }

        private void btnNacti_Click(object sender, EventArgs e)
        {
            NactiData();
        }

        private void NactiData()
        {
            txtText.Text = System.IO.File.ReadAllText(NazevSouboru);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
            pictureBox1.Image = Image.FromStream(new MemoryStream(data));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter(NazevSouboru))
            {
                sw.WriteLine(txtVstup.Text);
                sw.Close();
            }
        }

        private void PoleList()
        {
            List<int> a = new List<int>();

            // později
            a.Add(5);
            a.Add(6);

            int[] b = a.ToArray();
        }


    }
}