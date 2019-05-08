using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;
using System.Threading;

namespace PsaniDesetiPrsty
{
    public partial class Form1 : Form
    {

        Obrazovka AktualniObrazovka = Obrazovka.Menu;
        StavPsani AktualniLekce = null;
        Uzivatel AktualniUzivatel = null;
        SpravceHudby Prehravac = null;

        public Form1()
        {
            InitializeComponent();
        }

        static Stopwatch sw = new Stopwatch();

        private void Aktualizuj()
        {
            if (AktualniObrazovka == Obrazovka.Psani)
            {
                if (AktualniLekce != null)
                {
                    if (AktualniLekce.Dokonceno)
                    {
                        AktualniLekce = null;
                        AktualniObrazovka = Obrazovka.Menu;
                    }
                }
            }
            // zobrazeni textboxu
            if (AktualniObrazovka == Obrazovka.Psani && !textBox1.Visible)
            {
                textBox1.Visible = true;
            }
            if (AktualniObrazovka != Obrazovka.Psani && textBox1.Visible)
            {
                textBox1.Visible = false;
            }
            // uvodni animace - przatim nepouzito
            if (AktualniObrazovka == Obrazovka.Intro && !sw.IsRunning)
            {
                sw.Reset();
                sw.Start();
            }
            else if (AktualniObrazovka == Obrazovka.Intro && sw.ElapsedMilliseconds > 2000)
            {
                sw.Stop();
                sw.Reset();
                AktualniObrazovka = Obrazovka.Psani;
                Invalidate();
            }
            else if (AktualniObrazovka == Obrazovka.Intro)
            {
                Invalidate();
            }
            // spolecne pro menu
            else if (AktualniObrazovka == Obrazovka.Menu || AktualniObrazovka == Obrazovka.VyberLekce || AktualniObrazovka == Obrazovka.Uzivatel)
            {
                Point P = PointToClient(MousePosition);
                AktualizujPoziciMysi(P.X, P.Y);
            }
            // vyber v menu
            if (kliknutoY != -1)
            {
                if (AktualniObrazovka == Obrazovka.Menu)
                {
                    if (kliknutoY == 0) AktualniObrazovka = Obrazovka.VyberLekce;
                    if (kliknutoY == 1) AktualniObrazovka = Obrazovka.Uzivatel;
                    if (kliknutoY == 3) Application.Exit();
                }
                else if (AktualniObrazovka == Obrazovka.VyberLekce)
                {
                    if (kliknutoY == 0) AktualniObrazovka = Obrazovka.Menu;
                    if (kliknutoY == 1)
                    {
                        SpustLekci(new DebugLekce());
                    }
                    if (kliknutoY == 2)
                    {
                        SpustLekci(new TextovaLekce());
                    }
                    if (kliknutoY == 3)
                    {
                        /*AktualniLekce = new StavPsani();
                        AktualniLekce.Inicializuj(new DebugLekce());
                        AktualniObrazovka = Obrazovka.Psani;*/
                    }
                }
                else if (AktualniObrazovka == Obrazovka.Uzivatel)
                {
                    if (kliknutoY == 0) AktualniObrazovka = Obrazovka.Menu;
                    if (kliknutoY == 1) AktualniObrazovka = Obrazovka.Menu;
                }

                kliknutoY = -1;
            }
        }

        //psani v lekci
        bool nezpracuj = false;
        private void textBox1_TextChanged(object sender, EventArgs e)

        {
              if (!nezpracuj) ZpracujVstup();
            nezpracuj = true;
            textBox1.Text = "";
            nezpracuj = false;
        }
        private void ZpracujVstup()
        {
            long ms = sw.ElapsedMilliseconds;

            // back space
            AktualniLekce.ZpracujVstup((int)ms, textBox1.Text[textBox1.Text.Length - 1]);

            sw.Stop();
            sw.Reset();
            sw.Start();

            Invalidate();
        }
        
        //Vykresleni
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (AktualniObrazovka == Obrazovka.Psani) AktualniLekce.Vykreslit(e.Graphics);
            else if (AktualniObrazovka == Obrazovka.Intro) VykresliIntro(e.Graphics);
            else if (AktualniObrazovka == Obrazovka.Menu) VykresliMenuZakl(e.Graphics);
            else if (AktualniObrazovka == Obrazovka.VyberLekce) VykresliMenuLeckce(e.Graphics);
            else if (AktualniObrazovka == Obrazovka.Uzivatel) VykresliMenuUzivatele(e.Graphics);
        }
        private void VykresliIntro(Graphics g)
        {
            int ms = (int)sw.ElapsedMilliseconds;
            g.DrawString("Intro - " + sw.ElapsedMilliseconds, new Font("Arial", 20), Brushes.Cyan, new PointF(0, 25));

            if (ms < 1000) g.DrawString("DESETI PRSTY", new Font("IMPACT", 40), Brushes.Cyan, new PointF(ms * 400 / 1000, 25));
            else if (ms >= 1000 && ms <= 1300) g.DrawString("DESETI PRSTY", new Font("IMPACT", 40), Brushes.Cyan, new PointF(400, 25));
            else if (ms >= 1300 && ms <= 1600) g.DrawString("DESETI PRSTY", new Font("IMPACT", 50), Brushes.Cyan, new PointF(400, 25));
            else if (ms >= 1600 && ms <= 1900) g.DrawString("DESETI PRSTY", new Font("IMPACT", 70), Brushes.Cyan, new PointF(400, 25));
            else if (ms >= 1900 && ms <= 2200) g.DrawString("DESETI PRSTY", new Font("IMPACT", 100), Brushes.Cyan, new PointF(400, 25));
        }
        private void VykresliMenuZakl(Graphics g)
        {
            VykresliMenuUniverzalni(g, new string[] { "LEKCE", "UZIVATEL", "STATISTIKA", "UKONCIT" });
        }
        private void VykresliMenuLeckce(Graphics g)
        {
            VykresliMenuUniverzalni(g, new string[] { "ZPET","DEBUG", "SOUBOR", "GENERATOR VET" });
        }
        private void VykresliMenuUzivatele(Graphics g)
        {
            VykresliMenuUniverzalni(g, new string[] { "NIC TADY", "JDI ZPET" });
        }

        bool lekceSeSpousti = false;
        private void SpustLekci(ILekce l)
        {
            if (lekceSeSpousti) return;
            lekceSeSpousti = true;
            AktualniLekce = new StavPsani();
            AktualniLekce.Inicializuj(l);
            lekceSeSpousti = false;
            AktualniObrazovka = Obrazovka.Psani;
        }


        //Univerzalni menu
        private void VykresliMenuUniverzalni(Graphics g, string[] slova)
        {
            for (int i = 0; i < slova.Length; i++)
            {
                int x = Width / 2 - menu_sirkaPole / 2;
                int y = menu_yPole + i * menu_vyskaPole;
                int w = menu_sirkaPole;
                int h = menu_vyskaPole;
                if (poziceY != i)
                {
                    g.DrawRectangle(Pens.White, new Rectangle(x, y, w, h));
                    g.DrawString(slova[i], menu_font, Brushes.Cyan, new RectangleF(x, y, w, h), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    g.FillRectangle(Brushes.DarkCyan, new Rectangle(x, y, w, h));
                    g.DrawRectangle(Pens.White, new Rectangle(x, y, w, h));
                    g.DrawString(slova[i], menu_font, Brushes.White, new RectangleF(x, y, w, h), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }
        }
        private void AktualizujPoziciMysi(int x,int y)
        {
            if (x > Width / 2 - menu_sirkaPole / 2 && x < Width / 2 + menu_sirkaPole / 2)
            {
                if (y > menu_yPole)
                {
                    poziceY = (y - menu_yPole) / menu_vyskaPole;
                }
                else poziceY = -1;
            }
            else poziceY = -1;
        }

        //Pro Vykresleni a vyber v univerzalnim menu
        int poziceY = -1;
        int kliknutoY = -1;
        //Nekonstanty, mohly by se měnit za běhu. (Kazde menu nemusi byt stejne)
        int menu_sirkaPole = 400;
        int menu_vyskaPole = 100;
        int menu_yPole = 100;
        Font menu_font = new Font("Arial Black", 40);

        private void timer1_Tick(object sender, EventArgs e)
        {
            Aktualizuj();
            Invalidate();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            kliknutoY = poziceY;
            Aktualizuj();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
    }

    public interface ILekce
    {
        void AktualizujLekci(StavPsani sp);
        void ZahajLekci(StavPsani sp);
    }
    public class StavPsani
    {
        bool dokonceno = false;
        public bool Dokonceno { get => dokonceno; }

        private ILekce lekce;
        string radek = "";
        public List<string> dalsiRadky = new List<string>();

        int poziceVRadku = 0;
        StavRychlosti rychlost = new StavRychlosti();

        public void Inicializuj(ILekce lekce)
        {
            this.lekce = lekce;

            lekce.ZahajLekci(this);
            lekce.AktualizujLekci(this);

            if (dalsiRadky.Count == 0) ; //ukonceni


                radek = "";
                while (radek == "")
                {
                    if (dalsiRadky.Count > 0)
                    {
                        radek = dalsiRadky[0];
                        dalsiRadky.RemoveAt(0);
                        poziceVRadku = 0;
                    }
                    else
                    {
                        // KONEC LEKCE
                    }
                }
                
            
        }
        public void ZpracujVstup(int ms, char znak)
        {
            if (ms > 3000) rychlost.Nahlas(3000, znak, radek[poziceVRadku]);
            else rychlost.Nahlas(ms, znak, radek[poziceVRadku]);

            if (znak == radek[poziceVRadku]) poziceVRadku++;
            if (poziceVRadku == radek.Length)
            {                
                radek = "";
                if (!dokonceno) while (radek == "")
                {
                    if (dalsiRadky.Count > 0)
                    {
                        radek = dalsiRadky[0];
                        dalsiRadky.RemoveAt(0);
                        poziceVRadku = 0;
                    }
                    else
                    {
                        MessageBox.Show("Konec lekce!\n[Sem vložit vyhodnocení]");
                        dokonceno = true;
                        break;
                    }
                }
                if (!dokonceno) lekce.AktualizujLekci(this);
            }
        }
        public void Aktualizovat()
        {
            rychlost.Aktualizovat();
        }
        public void Vykreslit(Graphics g)
        {
            if (radek.Length > 0)
            {
                g.DrawString(radek, new Font("Consolas", 20), Brushes.White, new PointF(0, 0));
                g.DrawString(radek.Remove(poziceVRadku), new Font("Consolas", 20), Brushes.Cyan, new PointF(0, 25));

                for (int i = 0; i < 5;i++)
                {
                    if (i < dalsiRadky.Count) g.DrawString(dalsiRadky[i], new Font("Consolas", 20), Brushes.Gray, new PointF(0, 50 + i * 25));
                }

                rychlost.Vykreslit(g);
            }
        }
    }
    public class StavRychlosti
    {
        public long totalMs = 0;
        public long totalZnaku = 0;
        public long pocetChyb = 0;

        public void Nahlas(int ms, char znak, char ocekavany)
        {
            if (ocekavany == znak)
            {
                totalMs += ms;
                totalZnaku++;
            }
            else
            {
                totalMs += ms;
                pocetChyb++;
            }
        }
        public void Aktualizovat()
        {

        }
        public void Vykreslit(Graphics g)
        {
            g.DrawString("Čas (na výpočty): " + totalMs.ToString(), new Font("Arial", 20), Brushes.White, new PointF(100, 200));
            g.DrawString("Znaky: " + totalZnaku.ToString(), new Font("Arial", 20), Brushes.White, new PointF(100, 225));

            g.DrawString("Rychlost: " + (totalZnaku / (totalMs / 60000f)).ToString("0.0") + "BPM", new Font("Arial", 20), Brushes.White, new PointF(100, 250));
            g.DrawString("Chyby: " + pocetChyb.ToString(), new Font("Arial", 20), Brushes.Red, new PointF(100, 275));
            g.DrawString("Chybovost: " + (100f * pocetChyb / totalZnaku).ToString("0.0") + "%", new Font("Arial", 20), Brushes.Red, new PointF(100, 300));
        }
    }
    public class SpravceHudby
    {
        Hudba AktualniHudba;
        void PrehrajZvuk(Zvuk z)
        {
        }
        void PrehrajZvukNapitchovany(Zvuk z)
        {
        }
    }
    public class Zvuk
    {
        float[] samply;
        float frekvence;
    }
    public class Hudba
    {
        string soubor;
        int BPM;
    }
    public class SeznamZnaku
    {
        List<List<char>> stupne;
        bool pridatVseNaKonci;
    }
    public class StavZnaku
    {
        List<char> aktualni;

        // vyfiltruje znaky/slova co neumis a nahradi dvojite mezery
        public string Vyfiltruj(string radek, FiltrovaciMoznosti fm)
        {
            string[] ss = radek.Split();
            List<string> sl = ss.ToList();

            

            if (fm == FiltrovaciMoznosti.Znak)
            {
                for (int i = 0; i < sl.Count; i++)
                {
                    List<int> odstranit = new List<int>();
                    int j = 0;
                    foreach (char c in sl[i]) if (!aktualni.Contains(c))
                        {
                            odstranit.Add(j);
                            j++;
                        }
                    odstranit.Reverse();
                    foreach (int k in odstranit) sl[i].Remove(k, 1);
                }
                while (sl.Contains("")) sl.Remove("");
            }
            if (fm == FiltrovaciMoznosti.Slovo)
            {
                while (sl.Contains("")) sl.Remove("");
                List<int> odstranit = new List<int>();
                for(int i = 0; i < sl.Count; i++)
                {
                    foreach (char c in sl[i]) if (!aktualni.Contains(c))
                        {
                            odstranit.Add(i);
                            break;
                        }
                }
                odstranit.Reverse();
                foreach (int i in odstranit) sl.RemoveAt(i);
                
            }
            string ret = "";
            foreach (string str in sl)
            {
                ret += str + " ";
            }
            if (ret != "") ret.Remove(ret.Length - 1);
            return ret;
        }
    }
    public enum FiltrovaciMoznosti { Znak, Slovo }
    public enum Obrazovka { Intro, Menu, Uzivatel, Psani, VyberLekce };

    public class Statistika
    {

    }

    public class Uzivatel
    {
        List<Hudba> uzivatelskaHudba;
        SeznamZnaku pouzivanaAbeceda;
        Statistika uzivatelskaStatistika;
    }

    public class TextovaLekce : ILekce
    {
        System.IO.StreamReader sr;
        bool konec = false;

        public void ZahajLekci(StavPsani sp)
        {
            bool vybrano = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileOk += (s, e) => { sr = new StreamReader(ofd.FileName); vybrano = true; };
            ofd.ShowDialog();

            
            while (!vybrano) { Thread.Sleep(500); }
            NactiRadky(sp);
        }
        public void AktualizujLekci(StavPsani sp)
        {
            NactiRadky(sp);
        }
        void NactiRadky(StavPsani sp)
        {
            while (sp.dalsiRadky.Count < 6 && !konec)
            {
                string s = sr.ReadLine();
                if (s != null) sp.dalsiRadky.Add(s);
                else konec = true;
            }
        }
    }
    public class DebugLekce : ILekce
    {
        string s1 = "Napiš toto ------ a neudělej chybu!!1!";
        int indexRadku = 0;
        Random RNG = new Random();

        public void ZahajLekci(StavPsani sp)
        {
            NactiRadky(sp);
        }
        public void AktualizujLekci(StavPsani sp)
        {
            NactiRadky(sp);
        }
        void NactiRadky(StavPsani sp)
        {
            while (sp.dalsiRadky.Count < 6)
            {
                if (indexRadku < 7) sp.dalsiRadky.Add(s1.Remove(indexRadku * 3 + 1));
                else
                {
                    string s = "";
                    for (int i = 0; i < 20; i++)
                    {
                        s += (char)RNG.Next(97, 123);
                    }
                    sp.dalsiRadky.Add(s);
                }
                indexRadku++;
            }
        }
    }
    public class LekceVyberuVet : ILekce
    {
        System.IO.StreamReader sr;
        bool konec = false;



        public void ZahajLekci(StavPsani sp)
        {
            bool vybrano = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileOk += (s, e) => { sr = new StreamReader(ofd.FileName); vybrano = true; };
            ofd.ShowDialog();


            while (!vybrano) { Thread.Sleep(500); }
            NactiRadky(sp);
        }
        public void AktualizujLekci(StavPsani sp)
        {
            NactiRadky(sp);
        }
        void NactiRadky(StavPsani sp)
        {
            while (sp.dalsiRadky.Count < 6 || !konec)
            {
                string s = sr.ReadLine();
                if (s != null) sp.dalsiRadky.Add(s);
                else konec = true;
            }
        }
    }
}
