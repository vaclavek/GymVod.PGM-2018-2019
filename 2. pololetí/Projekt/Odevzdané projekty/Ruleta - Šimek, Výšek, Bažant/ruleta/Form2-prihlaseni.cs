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
    public partial class Prihlaseni : Form
    {
        public static Dictionary<string, int> tabulkaHracu = new Dictionary<string, int>();
        public static string nazevSouboru { get; set;}
        public Prihlaseni()
        {
            InitializeComponent();
            MessageBox.Show("Vyber soubor s hraci");
            openFileDialog1.ShowDialog();
            nazevSouboru = openFileDialog1.FileName;

            using (StreamReader sr = new StreamReader(nazevSouboru))
            {
                string radek;
                while ((radek = sr.ReadLine()) != null)
                {
                    string[] radekRozdeleny = radek.Split(';');
                    tabulkaHracu.Add(radekRozdeleny[0], Convert.ToInt32(radekRozdeleny[1]));
                }
                sr.Close();
            }

            MessageBox.Show("Zadej svůj prihlašovací kód");

        }
        private void Prihlaseni_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonZapniRuletu_Click(object sender, EventArgs e)
        {
            string zadanyPrihlasovaciKod = textBox1.Text;
            if (!tabulkaHracu.ContainsKey(zadanyPrihlasovaciKod))
            {
                MessageBox.Show("Takovy uzivatel neexistuje." + Environment.NewLine + "Zkus to znovu a nebo se pridej do tabulky hracu.");
            }
            else
            {
                Form1.Zustatek = tabulkaHracu[zadanyPrihlasovaciKod].ToString();
                Form1 form1 = new Form1 ();
                form1.Show();
                MessageBox.Show(Form1.Zustatek);
            }
        }
    }
}
