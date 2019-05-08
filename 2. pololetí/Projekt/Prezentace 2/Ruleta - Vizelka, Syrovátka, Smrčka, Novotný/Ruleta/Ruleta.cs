using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruleta
{
    public partial class FormVymazatSázky : Form
    {
        int vylosovaneCislo;
        Random rnd;
        int sazka;
        int konto;

        public FormVymazatSázky()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            konto = 1000;
            textBoxKonto.Text = Convert.ToString(konto);

            //usazení aplikace do fullscreen okna
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //další proměnné
            rnd = new Random();

            //definování šířky a výšky okna
            int width = this.Width;
            int height = this.Height;

            //pozicování buttonExit
            Point buttonExitPosition = new Point(width - buttonExit.Width, 0);
            buttonExit.Location = buttonExitPosition;
            MessageBox.Show("Vitejte v Casinu GymVod");
        }

        public bool zkontroluj(int vstup)
        {
            if (vstup > konto)
            {
                MessageBox.Show("Sázka převyšuje hodnotu vašeho konta");
                return false;
            }
            else
            {
                return true;
            }
        }



        //odsud bych umisťoval pouze buttonclicky

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  //Prihlaseni.showdialog
        }

        private void buttonHrat_Click(object sender, EventArgs e)
        {
            if (true) { };
        }

        private void buttonVymazatVsechnySazky_Click(object sender, EventArgs e)  //vymaže všechny zapsané sázky
        {
            int pocetradku = listViewSazky.Items.Count;

            for (int i = 0 ;i < pocetradku; i++)
            {
                int vratitsazku = Convert.ToInt32(listViewSazky.Items[i].SubItems[1].Text);
                konto += vratitsazku;
                textBoxKonto.Text = Convert.ToString(konto);
            }

            listViewSazky.Items.Clear();

        }

        private void buttonSazkaNa1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string tag = Convert.ToString(button.Tag);
            string[] polozky = tag.Split(new char[] { '_' });
            int vsazeno = Convert.ToInt32(textBoxSazka.Text);
            int pocetPolozek = polozky.Length;

            if (zkontroluj(vsazeno)) //zkontrolována výše sázky
            {
                if (pocetPolozek < 8)
                //sazky na cislo, dvojici, trojici, čtveřici, šestici
                {
                    ListViewItem LVINew = new ListViewItem(polozky[0]);
                    konto -= vsazeno;
                    textBoxKonto.Text = Convert.ToString(konto);
                    LVINew.SubItems.Add(Convert.ToString(vsazeno));
                    string vsazenona = string.Empty; ;
                    for (int i = 1; i <= pocetPolozek - 1; i++)
                    {
                        if (i != pocetPolozek - 1)
                        {
                            vsazenona += polozky[i] + ", ";
                        }
                        else
                        {
                            vsazenona += polozky[i];
                        }
                    }
                    LVINew.SubItems.Add(vsazenona);

                    int nasobitel = 36 / (pocetPolozek - 1);

                    string pravděpodobnost = "1/" + nasobitel;
                    LVINew.SubItems.Add(Convert.ToString(pravděpodobnost));

                    int moznavyhra = nasobitel * vsazeno;

                    LVINew.SubItems.Add(Convert.ToString(moznavyhra));

                    listViewSazky.Items.Add(LVINew);
                }
                else
                {
                    ListViewItem lviNew = new ListViewItem(polozky[0]);
                    konto -= vsazeno;
                    textBoxKonto.Text = Convert.ToString(konto);
                    lviNew.SubItems.Add(Convert.ToString(vsazeno));
                    lviNew.SubItems.Add(polozky[pocetPolozek - 1]);

                    int nasobitel = 36 / (pocetPolozek - 2);
                    string pravděpodobnost = "1/" + nasobitel;
                    lviNew.SubItems.Add(Convert.ToString(pravděpodobnost));
                    int moznavyhra = nasobitel * vsazeno;

                    lviNew.SubItems.Add(Convert.ToString(moznavyhra));

                    listViewSazky.Items.Add(lviNew);
                }
            }
        }
    }
}
