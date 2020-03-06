using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PsaniDesetiPrsty
{
    public partial class NastaveniZnakuForm : Form
    {
        SeznamZnaku sz;
        public NastaveniZnakuForm(SeznamZnaku sz)
        {
            InitializeComponent();
            this.sz = sz;

            AktualizovatHodnoty();
        }
        string puvodni;
        public void AktualizovatHodnoty()
        {
            textBox1.Text = sz.stupne;
            puvodni = sz.stupne;

            trackBar1.Maximum = sz.stupne.Length;
            trackBar2.Maximum = sz.stupne.Length;
            if (sz.obtiznost > sz.stupne.Length) sz.obtiznost = sz.stupne.Length;
            if (sz.obtiznost < 8) sz.obtiznost = 8;
            trackBar1.Value = sz.obtiznost;
            if (sz.velkaPismena > sz.stupne.Length) sz.velkaPismena = sz.stupne.Length;
            if (sz.velkaPismena < 8) sz.velkaPismena = 8;
            trackBar2.Value = sz.velkaPismena;
            label2.Text = "Obtížnost: " + sz.obtiznost;
            label3.Text = "Velká písmena: " + sz.velkaPismena;

            checkBox1.Checked = sz.pridatVseNaKonci;
            checkBox2.Checked = sz.dynamickeZtezovani;

            if (sz.pocatecniRychlost < 10) sz.pocatecniRychlost = 10;
            if (sz.konecnaRychlost < 10) sz.konecnaRychlost = 10;
            if (sz.pocatecniRychlost > 410) sz.pocatecniRychlost = 410;
            if (sz.konecnaRychlost > 410) sz.konecnaRychlost = 410;

            trackBar3.Value = Math.Min(sz.pocatecniRychlost, sz.konecnaRychlost);
            trackBar4.Value = Math.Max(sz.pocatecniRychlost, sz.konecnaRychlost);

            if (sz.pocatecniChybovost < 0) sz.pocatecniChybovost = 0;
            if (sz.koncovaChybovost < 0) sz.koncovaChybovost = 0;
            if (sz.pocatecniChybovost > 5) sz.pocatecniChybovost = 5;
            if (sz.koncovaChybovost > 5) sz.koncovaChybovost = 5;

            trackBar5.Value = Math.Min((int)(sz.pocatecniChybovost * 10), (int)(sz.koncovaChybovost * 10));
            trackBar6.Value = Math.Max((int)(sz.pocatecniChybovost * 10), (int)(sz.koncovaChybovost * 10));

            label4.Text = "Rozsah Rychlostí: " + Math.Min(sz.pocatecniRychlost, sz.konecnaRychlost) + " - " + Math.Max(sz.pocatecniRychlost, sz.konecnaRychlost);
            int v0 = Math.Max(trackBar5.Value, trackBar6.Value);
            int v1 = Math.Min(trackBar5.Value, trackBar6.Value);
            label5.Text = "Rozsah Chyb.: "+v0 / 10+"."+v0 % 10+" % - " +v1 / 10+"." +v1 % 10+" %";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 9)
            {
                bool mezery = true;
                foreach (char c in textBox1.Text) if (c != ' ') mezery = false;
                if (mezery)
                {
                    MessageBox.Show("Pouze mezery nejsou možné.");
                    textBox1.Text = puvodni;
                }
                else
                {
                    sz.stupne = textBox1.Text;
                    puvodni = textBox1.Text;
                    AktualizovatHodnoty();
                }
            }
            else
            {
                MessageBox.Show("Je třeba nejméně 9 znaků");
                textBox1.Text = puvodni;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sz.obtiznost = trackBar1.Value;
            AktualizovatHodnoty();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            sz.velkaPismena = trackBar2.Value;
            AktualizovatHodnoty();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sz.pridatVseNaKonci = checkBox1.Checked;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            sz.dynamickeZtezovani = checkBox2.Checked;
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            sz.pocatecniRychlost = Math.Min(trackBar3.Value, trackBar4.Value);
            sz.konecnaRychlost = Math.Max(trackBar3.Value, trackBar4.Value);
            AktualizovatHodnoty();
        }
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            sz.pocatecniChybovost = Math.Max(trackBar5.Value / 10f, trackBar6.Value / 10f);
            sz.koncovaChybovost = Math.Min(trackBar5.Value / 10f, trackBar6.Value / 10f);
            AktualizovatHodnoty();
        }
    }
}
