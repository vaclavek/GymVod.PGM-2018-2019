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

    public partial class FormHra : Form
    {
        int vylosovaneCislo;
        Random rnd;
        int sazka;
        int konto;
        float degree;
        public FormHra()
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
                ListViewItem LVINew = new ListViewItem(polozky[0]);
                konto -= vsazeno;
                textBoxKonto.Text = Convert.ToString(konto);
                LVINew.SubItems.Add(Convert.ToString(vsazeno));
                bool doplnenisazky = false;

                if (pocetPolozek < 8)
                //sazky na cislo, dvojici, trojici, čtveřici, šestici
                {
                    int nasobitel = 36 / (pocetPolozek - 1);
                    int moznavyhra;

                    string vsazenona = string.Empty;
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

                    foreach(ListViewItem item in listViewSazky.Items)
                    {
                        if (item.SubItems[2].Text == vsazenona )
                        {
                            vsazeno += Convert.ToInt32(item.SubItems[1].Text);
                            item.SubItems[1].Text = Convert.ToString(vsazeno);
                            moznavyhra = nasobitel * vsazeno;
                            item.SubItems[4].Text = Convert.ToString(moznavyhra);
                            doplnenisazky = true;
                        }
                    }

                    if (!doplnenisazky)
                    {
                        LVINew.SubItems.Add(vsazenona);

                        nasobitel = 36 / (pocetPolozek - 1);

                        string pravděpodobnost = "1/" + nasobitel;
                        LVINew.SubItems.Add(Convert.ToString(pravděpodobnost));

                        moznavyhra = nasobitel * vsazeno;

                        LVINew.SubItems.Add(Convert.ToString(moznavyhra));
                        vsazenona = string.Empty;
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
                        listViewSazky.Items.Add(LVINew);
                    }

                }
                else
                {
                    int nasobitel = 36 / (pocetPolozek - 2);
                    int moznavyhra;
                    foreach (ListViewItem item in listViewSazky.Items)
                    {
                        if(polozky[pocetPolozek - 1] == item.SubItems[2].Text)
                        {
                            vsazeno += Convert.ToInt32(item.SubItems[1].Text);
                            item.SubItems[1].Text = Convert.ToString(vsazeno);
                            moznavyhra = nasobitel * vsazeno;
                            item.SubItems[4].Text = Convert.ToString(moznavyhra);
                            doplnenisazky = true;
                        }
                    }
                    if (!doplnenisazky)
                    {
                        LVINew.SubItems.Add(polozky[pocetPolozek - 1]);

                        string pravděpodobnost = "1/" + nasobitel;
                        LVINew.SubItems.Add(Convert.ToString(pravděpodobnost));
                        moznavyhra = nasobitel * vsazeno;

                        LVINew.SubItems.Add(Convert.ToString(moznavyhra));
                        string vsazenona = string.Empty;
                        for (int i = 1; i <= pocetPolozek - 2; i++)
                        {
                            if (i != pocetPolozek - 1)
                            {
                                vsazenona += polozky[i] + ",";
                            }
                            else
                            {
                                vsazenona += polozky[i];
                            }
                        }
                        LVINew.SubItems.Add(vsazenona);
                        listViewSazky.Items.Add(LVINew);
                    }
                }
            }
        }



        private void buttonZeton1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            sazka = Convert.ToInt32(button.Tag);
            textBoxSazka.Text = Convert.ToString(sazka);
        }


        //Velmi důležitý button
        private void buttonHrat_Click(object sender, EventArgs e)
        {
            if(listViewSazky.Items.Count > 0)
            {
                vylosovaneCislo = rnd.Next(0, 37);
                    int bilance = 0;
                textBoxVylosovaneCislo.Text = Convert.ToString(vylosovaneCislo);
                foreach (ListViewItem item in listViewSazky.Items)
                {
                    string[] cisla = item.SubItems[5].Text.Split(new char[] { ',' });
                    bool vylosovano = false;
                    foreach(string cislo in cisla)
                    {
                        if(cislo == Convert.ToString(vylosovaneCislo))
                        {
                            vylosovano = true;
                        }
                    }
                    if (vylosovano)
                    {
                        int vydelek = Convert.ToInt32(item.SubItems[4].Text);
                        konto += vydelek;
                        bilance = bilance + vydelek - Convert.ToInt32(item.SubItems[1].Text);
                    }
                    else
                    {
                        bilance -= Convert.ToInt32(item.SubItems[1].Text);
                    }
                }

                textBoxKonto.Text = Convert.ToString(konto);
                if(bilance == 0)
                {
                    MessageBox.Show("Vaše konto se nepozměnilo, neprodělal jste, ani nevydělal");
                }
                else
                {
                    if(bilance > 0)
                    {
                        MessageBox.Show("Vydělal jste " + bilance);
                    }
                    else
                    {
                        bilance = bilance * -1;
                        MessageBox.Show("Prodělal jste " + bilance);
                    }
                }
                listViewSazky.Items.Clear();
            }
            else
            {
                MessageBox.Show("Nemáte Vsazeno");
            }

            if (konto == 0)
            {
                MessageBox.Show("Konec hry, došly vám peníze");
                Application.Exit();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
