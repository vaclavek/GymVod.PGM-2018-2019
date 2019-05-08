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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public static string Zustatek { get; set; }

        private int operace;
        private readonly Random rnd = new Random();
        private int vylosovane;
        private int vyhra = 0;
        private int vklad;
        private int zustatek;
        private readonly int[] black = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        private readonly int[] red = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

        public Form1()
        {
            InitializeComponent();
            textBoxZustatek.Text = Zustatek;
        }

        private void btnCislo(object sender, EventArgs e)
        {
            while (!int.TryParse(textBoxCastka.Text, out vklad))
            {
                MessageBox.Show("Vklad musí být číselný!");
                return;
            }
            if (vklad > Convert.ToInt32(textBoxZustatek.Text))
                MessageBox.Show("Nelze vsadit více, než máte!");
            var button = (Button)sender;
            int operace = Convert.ToInt32(button.Name.Replace("btn", ""));
            textBoxBet.Text = vklad + " na číslo " + operace;
        }


        private void btnSpecial(object sender, EventArgs e)
        {
            while (!int.TryParse(textBoxCastka.Text, out vklad))
            {
                MessageBox.Show("Vklad musí být číselný!");
                return;
            }
            if (vklad > Convert.ToInt32(textBoxZustatek.Text))
                MessageBox.Show("Nelze vsadit více, než máte!");
            var button = (Button)sender;
            string special = button.Name.Replace("btn", "");
            switch (special)
            {
                case "Black":
                    operace = 100;
                    textBoxBet.Text = vklad + " na černou.";
                    break;
                case "Red":
                    operace = 200;
                    textBoxBet.Text = vklad + " na červenou.";
                    break;
                case "Even":
                    operace = 300;
                    textBoxBet.Text = vklad + " na sudé.";
                    break;
                case "Odd":
                    operace = 400;
                    textBoxBet.Text = vklad + " na liché.";
                    break;
                case "1st":
                    operace = 500;
                    textBoxBet.Text = vklad + " na 1st 12.";
                    break;
                case "2nd":
                    operace = 600;
                    textBoxBet.Text = vklad + " na 2nd 12.";
                    break;
                case "3rd":
                    operace = 700;
                    textBoxBet.Text = vklad + " na 3rd 12.";
                    break;
                case "Prvni":
                    operace = 800;
                    textBoxBet.Text = vklad + " na 1. sloupec.";
                    break;
                case "Druhy":
                    operace = 900;
                    textBoxBet.Text = vklad + " na 2. sloupec.";
                    break;
                case "Treti":
                    operace = 1000;
                    textBoxBet.Text = vklad + " na 3. sloupec.";
                    break;
            }
        }

        private void Roztoc(object sender, EventArgs e)
        {
            zustatek = Convert.ToInt32(textBoxZustatek.Text);
            vylosovane = rnd.Next(1, 37);
            Drop.Text = Convert.ToString(vylosovane);
            switch (operace)
            {
                case 100: //sazeno cerna
                    if ((vylosovane != 0) && (black.Contains(vylosovane)))
                        vyhra = vklad * 2;
                    break;
                case 200: //sazeno cervena
                    if ((vylosovane != 0) && (red.Contains(vylosovane)))
                        vyhra = vklad * 2;
                    break;
                case 300: //sazeno sude
                    if ((vylosovane != 0) && (vylosovane % 2 == 0))
                        vyhra = vklad * 2;
                    break;
                case 400: //sazeno liche
                    if ((vylosovane != 0) && (vylosovane % 2 == 1))
                        vyhra = vklad * 2;
                    break;
                case 500: //1st 12
                    if ((0 < vylosovane) && (vylosovane < 13))
                        vyhra = vklad * 3;
                    break;
                case 600: //2nd 12
                    if ((12 < vylosovane) && (vylosovane > 25))
                        vyhra = vklad * 3;
                    break;
                case 700: //3rd 12
                    if (24 < vylosovane)
                        vyhra = vklad * 3;
                    break;
                case 800: //2 to 1
                    if (vylosovane % 3 == 1)
                        vyhra = vklad * 3;
                    break;
                case 900: //2 to 1
                    if (vylosovane % 3 == 2)
                        vyhra = vklad * 3;
                    break;
                case 1000: //2 to 1
                    if ((vylosovane != 0) && (vylosovane % 3 == 0))
                        vyhra = vklad * 3;
                    break;
                default:
                    if (vylosovane == operace)
                        vyhra = vklad * 36;
                    break;
            }
            if (vyhra == 0)
                textBoxZustatek.Text = Convert.ToString(zustatek - vklad);
            else
                textBoxZustatek.Text = Convert.ToString(zustatek + vyhra);

            Refresh();
        }

        private void buttonKonecHry_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(Prihlaseni.nazevSouboru))
            {
                foreach (KeyValuePair<string, int> kvp in Prihlaseni.tabulkaHracu)
                {
                    string radekNaZapis = kvp.Key + ";" + kvp.Value;
                    sw.WriteLine(radekNaZapis);
                }
                sw.Flush();
                sw.Close();
            }

            Application.Exit();
        }
    }
}
