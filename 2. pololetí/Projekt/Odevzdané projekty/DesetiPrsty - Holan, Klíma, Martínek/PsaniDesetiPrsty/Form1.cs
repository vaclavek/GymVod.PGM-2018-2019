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
using static PsaniDesetiPrsty.Form1.Math3D;
using static System.Math;
using System.Drawing.Drawing2D;

namespace PsaniDesetiPrsty
{
    public partial class Form1 : Form
    {

        Obrazovka AktualniObrazovka = Obrazovka.Menu;
        StavPsani AktualniLekce = null;
        Uzivatel AktualniUzivatel = null;
        string JmenoUzivatele = null;
        SpravceHudby Prehravac = null;

        public Form1()
        {
            InitializeComponent();
            InitShape();

            bool pozadovatUzivatele = false;

            if (!File.Exists("Nastaveni.txt"))
            {
                FileStream fs = new FileStream("Nastaveni.txt", FileMode.Create);
                fs.Close();
                fs.Dispose();
                pozadovatUzivatele = true;
            }
            else
            {
                FileStream fs = new FileStream("Nastaveni.txt", FileMode.Open);
                string s = StreamHelper.LoadString(fs);
                fs.Close();
                fs.Dispose();
                if (!File.Exists("U_" + s + ".txt"))
                {
                    pozadovatUzivatele = true;
                }
                else
                {
                    AktualniUzivatel = Uzivatel.ZeSouboru("U_" + s + ".txt");
                    JmenoUzivatele = s;
                }
            }

            /*Prehravac = new SpravceHudby();
            Prehravac.SpustHudbu(new Hudba() { BPM = 140, soubor = @"F://spartaTest.mp3" });
            WasapiOut wo = new WasapiOut(NAudio.CoreAudioApi.AudioClientShareMode.Exclusive, 100);
            wo.Init(Prehravac);
            wo.Play();*/

            if (pozadovatUzivatele)
            {
                AktualniObrazovka = Obrazovka.Uzivatel;
            }
        }

        static Stopwatch sw = new Stopwatch();

        int Hudba_CasPsani;
        int Hudba_PocetStisku = 0;

        private void Aktualizuj()
        {

            // psani BPM
            if (AktualniObrazovka == Obrazovka.Psani)
            {
                Hudba_CasPsani += timer1.Interval;
                if (Hudba_CasPsani > 10000)
                {
                    Hudba_CasPsani -= 10000;
                    //Prehravac.NahlasBPM(Hudba_PocetStisku * 6);
                    Hudba_PocetStisku = 0;

                    if (AktualniUzivatel.pouzivanaAbeceda.dynamickeZtezovani)
                    {
                        Tuple<float, float> t = AktualniLekce.RychlostChybovost();
                        float uroven = AktualniUzivatel.pouzivanaAbeceda.OcekavanaUroven(t.Item1, t.Item2);

                        if (uroven - AktualniUzivatel.pouzivanaAbeceda.obtiznost > 1)
                        {
                            AktualniUzivatel.pouzivanaAbeceda.obtiznost++;
                        }
                        if (uroven - AktualniUzivatel.pouzivanaAbeceda.obtiznost < -1)
                        {
                            AktualniUzivatel.pouzivanaAbeceda.obtiznost--;
                        }
                    }
                }
            }

            if (AktualniObrazovka == Obrazovka.Psani)
            {
                if (AktualniLekce != null)
                {
                    if (AktualniLekce.Dokonceno)
                    {
                        AktualniLekce = null;
                        //Statistika se ulozi
                        AktualniUzivatel.Ulozit();
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
            else if (AktualniObrazovka == Obrazovka.Menu || AktualniObrazovka == Obrazovka.VyberLekce || AktualniObrazovka == Obrazovka.Uzivatel || AktualniObrazovka == Obrazovka.Statistika)
            {
                Point P = PointToClient(MousePosition);
                AktualizujPoziciMysi(P.X, P.Y);
            }
            // vyber v menu
            if (kliknutoY != -1 && kliknuto)
            {
                kliknuto = false;
                if (AktualniObrazovka == Obrazovka.Psani)
                {
                    if (kliknutoY == 0) MessageBox.Show("HAHAHA");
                }
                if (AktualniObrazovka == Obrazovka.Menu)
                {
                    if (kliknutoY == 0) AktualniObrazovka = Obrazovka.VyberLekce;
                    if (kliknutoY == 1) AktualniObrazovka = Obrazovka.Uzivatel;
                    if (kliknutoY == 2) AktualniObrazovka = Obrazovka.Statistika;
                    if (kliknutoY == 3) Application.Exit();
                }
                else if (AktualniObrazovka == Obrazovka.VyberLekce)
                {
                    if (kliknutoY == 0) AktualniObrazovka = Obrazovka.Menu;
                    if (kliknutoY == 3)
                    {
                        SpustLekci(new DebugLekce());
                    }
                    if (kliknutoY == 1)
                    {
                        SpustLekci(new TextovaLekce());
                    }
                    if (kliknutoY == 2)
                    {
                        SpustLekci(new LekceVyberuVet());
                    }
                }
                else if (AktualniObrazovka == Obrazovka.Uzivatel)
                {
                    if (kliknutoY == 0)
                    {
                        if (AktualniUzivatel != null) AktualniObrazovka = Obrazovka.Menu;
                        else MessageBox.Show("Vyberte uživatele", "Upozornění");
                        kliknutoY = -1;
                    }
                    if (kliknutoY == 1)
                    {
                        JmenoUzivateleForm juf = new JmenoUzivateleForm();
                        juf.TextZadan += (s, e) =>
                        {
                            if (File.Exists("U_" + e.text + ".txt"))
                            {
                                MessageBox.Show("Uživatel už existuje. Byl automaticky vybrán.");
                                AktualniUzivatel = Uzivatel.ZeSouboru("U_" + e.text + ".txt");
                                JmenoUzivatele = e.text;

                                FileStream fs = new FileStream("Nastaveni.txt", FileMode.Create);
                                StreamHelper.SaveString(fs, e.text);
                                fs.Close();
                                fs.Dispose();
                            }
                            else
                            {
                                AktualniUzivatel = new Uzivatel("U_" + e.text + ".txt");
                                AktualniUzivatel.Ulozit();
                                JmenoUzivatele = e.text;

                                FileStream fs = new FileStream("Nastaveni.txt", FileMode.Create);
                                StreamHelper.SaveString(fs, e.text);
                                fs.Close();
                                fs.Dispose();
                            }
                            juf.Close();
                        };
                        juf.ShowDialog();
                        kliknutoY = -1;
                    }
                    if (kliknutoY == 2)
                    {
                        VyberUzivateleForm vuf = new VyberUzivateleForm();
                        vuf.TextZadan += (s, e) =>
                        {
                            AktualniUzivatel = Uzivatel.ZeSouboru("U_" + e.text + ".txt");
                            JmenoUzivatele = e.text;
                            vuf.Close();

                            FileStream fs = new FileStream("Nastaveni.txt", FileMode.Create);
                            StreamHelper.SaveString(fs, e.text);
                            fs.Close();
                            fs.Dispose();
                        };
                        vuf.ShowDialog();
                        kliknutoY = -1;
                    }
                    if (kliknutoY == 3 && AktualniUzivatel != null)
                    {
                        NastaveniZnakuForm nzf = new NastaveniZnakuForm(AktualniUzivatel.pouzivanaAbeceda);
                        nzf.ShowDialog();
                        AktualniUzivatel.Ulozit();
                    }
                }
                else if (AktualniObrazovka == Obrazovka.Statistika)
                {
                    if (kliknutoY == 0) AktualniObrazovka = Obrazovka.Menu;
                }

                kliknutoY = -1;

            }
        }

        bool kliknuto = false;

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
            if (AktualniObrazovka == Obrazovka.Psani)
            {
                Hudba_PocetStisku++;

                long ms = sw.ElapsedMilliseconds;

                // back space
                AktualniLekce.ZpracujVstup((int)ms, textBox1.Text[textBox1.Text.Length - 1]);

                sw.Stop();
                sw.Reset();
                sw.Start();

                Invalidate();
            }
        }

        //Vykresleni
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (AktualniObrazovka == Obrazovka.Psani)
            {
                VykresliPozadi(e.Graphics);
                AktualniLekce.Vykreslit(e.Graphics);
            }
            else if (AktualniObrazovka == Obrazovka.Intro) VykresliIntro(e.Graphics);
            else if (AktualniObrazovka == Obrazovka.Menu)
            {
                VykresliPozadi(e.Graphics);
                VykresliMenuZakl(e.Graphics);
                e.Graphics.DrawString("Vítejte, " + JmenoUzivatele, new Font("Arial", 20), Brushes.Cyan, new Point(5, 640));
            }
            else if (AktualniObrazovka == Obrazovka.VyberLekce)
            {
                VykresliPozadi(e.Graphics);
                VykresliMenuLeckce(e.Graphics);
                e.Graphics.DrawString("Vítejte, " + JmenoUzivatele, new Font("Arial", 20), Brushes.Cyan, new Point(5, 640));
            }
            else if (AktualniObrazovka == Obrazovka.Uzivatel)
            {
                VykresliPozadi(e.Graphics);
                VykresliMenuUzivatele(e.Graphics);
                e.Graphics.DrawString("Vítejte, " + JmenoUzivatele, new Font("Arial", 20), Brushes.Cyan, new Point(5, 640));
            }
            else if (AktualniObrazovka == Obrazovka.Statistika) VykresliStatistiku(e.Graphics);
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
            VykresliMenuUniverzalni(g, new string[] { "Lekce", "Uživatel", "Statistika", "Ukončit" });

        }
        private void VykresliMenuLeckce(Graphics g)
        {
            VykresliMenuUniverzalni(g, new string[] { "Zpět", "Soubor", "Mixér", "Debug"});
        }
        private void VykresliMenuUzivatele(Graphics g)
        {
            VykresliMenuUniverzalni(g, new string[] { "Zpět", "Přidat", "Změnit", "Nastavení" });
        }
        private void VykresliStatistiku(Graphics g)
        {
            g.DrawString("Statistika - " + JmenoUzivatele, new Font("Arial", 25), Brushes.White, new Point(5, 5));
            //GRAF
            DateTime dt = DateTime.Now;

            AktualniUzivatel.uzivatelskaStatistika.VykresliGrafDatumVsRychlost(g);
            AktualniUzivatel.uzivatelskaStatistika.VykresliGrafDatumVsChybovost(g);
            AktualniUzivatel.uzivatelskaStatistika.VykresliZbytekStatistik(g);

            //g.DrawRectangle(Pens.White, new Rectangle(1080, 0, 200, 100));
            g.DrawString("Zmáčkněte ESCAPE pro návrat", new Font("Consolas", 8), Brushes.White, new RectangleF(0, 0, 1200, 680), new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far });
        }
        private void VykresliPozadi(Graphics g)
        {
            if (Pozadi_Typ == 0)
            {
                float velikost = 1;
                if (Pozadi_Cas < 10000) velikost = Pozadi_Cas / 10000f;
                if (Pozadi_Cas > 110000) velikost = (120000 - Pozadi_Cas) / 10000f;
                if (Pozadi_Cas > 120000)
                {
                    Pozadi_Cas = 0;
                    Pozadi_Typ++;
                    Pozadi_Typ %= Pozadi_PocetTypu;
                }

                faces = new List<Face>();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            cube.add(ref faces, 1, i - 2, j - 2, k - 2);
                        }
                    }


                }
                Matrix4x3 m = Matrix4x3.CreateFromRotationX(Pozadi_Cas / 300000f) * Matrix4x3.CreateFromRotationY((Pozadi_Cas + 50) / 600000f) * Matrix4x3.CreateFromTranslationX(velikost * (float)Math.Sin(Pozadi_Cas / 60000f)) * Matrix4x3.CreateFromTranslationY(velikost * (float)Math.Sin(Pozadi_Cas / 45000f)) * Matrix4x3.CreateFromTranslationZ(2.5f + velikost * (float)Math.Sin(Pozadi_Cas / 77000f)) * Matrix4x3.CreateFromScaleX(velikost) * Matrix4x3.CreateFromScaleY(velikost) * Matrix4x3.CreateFromScaleZ(velikost);
                foreach (Face f in faces) f.UpdateFace(0.5625f, 1280f, m);
                foreach (Face f in faces) f.Draw(g, new Pen(Color.FromArgb(0, 64, 0), 3));
                foreach (Face f in faces) f.Draw(g, new Pen(Color.FromArgb(0, 128, 0), 1));
            }
        }
        
       

        public List<Face> faces;
        public Object3D cube;
        private void InitShape()
        {
            faces = new List<Face>();
            faces.Add(new Face(new Math3D.Vector3D[]
            {
                new Math3D.Vector3D(-1,1,-1),
            new Math3D.Vector3D(-1,1,1),
            new Math3D.Vector3D(-1,-1,1),
            new Math3D.Vector3D(-1,-1,-1),
        }, Color.Blue));
            faces.Add(new Face(new Math3D.Vector3D[]
            {
                new Math3D.Vector3D(1,1,-1),
            new Math3D.Vector3D(1,1,1),
            new Math3D.Vector3D(1,-1,1),
            new Math3D.Vector3D(1,-1,-1),
        }, Color.Green));
            faces.Add(new Face(new Math3D.Vector3D[]
            {
                new Math3D.Vector3D(-1,1,1),
            new Math3D.Vector3D(1,1,1),
            new Math3D.Vector3D(1,-1,1),
            new Math3D.Vector3D(-1,-1,1),
        }, Color.Red));

            faces.Add(new Face(new Math3D.Vector3D[]
                {
                new Math3D.Vector3D(-1,1,-1),
            new Math3D.Vector3D(1,1,-1),
            new Math3D.Vector3D(1,-1,-1),
            new Math3D.Vector3D(-1,-1,-1),
            }, Color.Yellow));
            faces.Add(new Face(new Math3D.Vector3D[]
            {
                new Math3D.Vector3D(-1,1,1),
            new Math3D.Vector3D(1,1,1),
            new Math3D.Vector3D(1,1,-1),
            new Math3D.Vector3D(-1,1,-1),
        }, Color.Purple));
            faces.Add(new Face(new Math3D.Vector3D[]
            {
                new Math3D.Vector3D(-1,-1,1),
            new Math3D.Vector3D(1,-1,1),
            new Math3D.Vector3D(1,-1,-1),
            new Math3D.Vector3D(-1,-1,-1),
        }, Color.Orange));
            cube = new Object3D(faces, 0.15f);
        }
        public class Math3D
        {
            const double PIOVER180 = Math.PI / 180.0;

            public struct Vector3D
            {
                public float x;
                public float y;
                public float z;

                public Vector3D(int _x, int _y, int _z)
                {
                    x = _x;
                    y = _y;
                    z = _z;
                }

                public Vector3D(double _x, double _y, double _z)
                {
                    x = (float)_x;
                    y = (float)_y;
                    z = (float)_z;
                }

                public Vector3D(float _x, float _y, float _z)
                {
                    x = _x;
                    y = _y;
                    z = _z;
                }

                public override string ToString()
                {
                    return "(" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ")";
                }

            }
            public class Matrix3D
            {
                public float V00;   // 00 10 20 d0
                public float V01;   // 01 11 21 d1
                public float V02;   // 02 12 22 d2

                public float V10;
                public float V11;
                public float V12;

                public float V20;
                public float V21;
                public float V22;

                public float Vd0;
                public float Vd1;
                public float Vd2;

                public Matrix3D(float v00, float v10, float v20, float vd0, float v01, float v11, float v21, float vd1, float v02, float v12, float v22, float vd2)
                {
                    V00 = v00;
                    V01 = v01;
                    V02 = v02;
                    V10 = v10;
                    V11 = v11;
                    V12 = v12;
                    V20 = v20;
                    V21 = v21;
                    V22 = v22;
                    Vd0 = vd0;
                    Vd1 = vd1;
                    Vd2 = vd2;
                }

                public Matrix3D() : this(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0)
                {
                }

                public static Matrix3D operator *(Matrix3D A, Matrix3D B)
                {
                    return new Matrix3D(
                        A.V00 * B.V00 + A.V10 * B.V01 + A.V20 * B.V02,
                        A.V00 * B.V10 + A.V10 * B.V11 + A.V20 * B.V12,
                        A.V00 * B.V20 + A.V10 * B.V21 + A.V20 * B.V22,
                        A.V00 * B.Vd0 + A.V10 * B.Vd1 + A.V20 * B.Vd2 + A.Vd0,

                        A.V01 * B.V00 + A.V11 * B.V01 + A.V21 * B.V02,
                        A.V01 * B.V10 + A.V11 * B.V11 + A.V21 * B.V12,
                        A.V01 * B.V20 + A.V11 * B.V21 + A.V21 * B.V22,
                        A.V01 * B.Vd0 + A.V11 * B.Vd1 + A.V21 * B.Vd2 + A.Vd1,

                        A.V02 * B.V00 + A.V12 * B.V01 + A.V22 * B.V02,
                        A.V02 * B.V10 + A.V12 * B.V11 + A.V22 * B.V12,
                        A.V02 * B.V20 + A.V12 * B.V21 + A.V22 * B.V22,
                        A.V02 * B.Vd0 + A.V12 * B.Vd1 + A.V22 * B.Vd2 + A.Vd2);
                }
                public static Vector3D operator *(Matrix3D A, Vector3D V)
                {
                    return new Vector3D(V.x * A.V00 + V.y * A.V10 + V.z * A.V20 + A.Vd0,
                                        V.x * A.V01 + V.y * A.V11 + V.z * A.V21 + A.Vd1,
                                        V.x * A.V02 + V.y * A.V12 + V.z * A.V22 + A.Vd2);
                }
            }

            public static Matrix3D RotateX(float x)
            {
                return new Matrix3D(1, 0, 0, 0, 0, (float)Cos(x), (float)Sin(x), 0, 0, (float)-Sin(x), (float)Cos(x), 0);
            }
            public static Matrix3D RotateY(float x)
            {
                return new Matrix3D((float)Cos(x), 0, (float)Sin(x), 0, 0, 1, 0, 0, (float)-Sin(x), 0, (float)Cos(x), 0);
            }
            public static Matrix3D RotateZ(float x)
            {
                return new Matrix3D((float)Cos(x), (float)Sin(x), 0, 0, (float)-Sin(x), (float)Cos(x), 0, 0, 0, 0, 1, 0);
            }
            public static Matrix3D Translate(float x, float y, float z)
            {
                return new Matrix3D(1, 0, 0, x, 0, 1, 0, y, 0, 0, 1, z);
            }
            public static Matrix3D Scale(float x, float y, float z)
            {
                return new Matrix3D(x, 0, 0, 0, 0, y, 0, 0, 0, 0, z, 0);
            }

            public class Cube
            {
                public Bitmap DrawFaces(Face[] f, int width, int height)
                {
                    Bitmap finalBmp = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(finalBmp);

                    g.Clear(Color.Blue);

                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    Array.Sort(f);
                    for (int i = f.Length - 1; i >= 0; i--) //draw faces from back to front
                    {
                        //g.FillPolygon(Brushes.DarkGray, GetBottomFace());


                        /*g.DrawLine(Pens.Black, faces[i].Corners2D[0], faces[i].Corners2D[1]);
                        g.DrawLine(Pens.Black, faces[i].Corners2D[1], faces[i].Corners2D[2]);
                        g.DrawLine(Pens.Black, faces[i].Corners2D[2], faces[i].Corners2D[3]);
                        g.DrawLine(Pens.Black, faces[i].Corners2D[3], faces[i].Corners2D[0]);*/

                    }

                    g.Dispose();

                    return finalBmp;
                }
            }

            public static Vector3D RotateX(Vector3D point3D, float degrees)
            {
                //[ a  b  c ] [ x ]   [ x*a + y*b + z*c ]
                //[ d  e  f ] [ y ] = [ x*d + y*e + z*f ]
                //[ g  h  i ] [ z ]   [ x*g + y*h + z*i ]

                //[ 1    0        0   ]
                //[ 0   cos(x)  sin(x)]
                //[ 0   -sin(x) cos(x)]

                double cDegrees = degrees * PIOVER180;
                double cosDegrees = Math.Cos(cDegrees);
                double sinDegrees = Math.Sin(cDegrees);

                double y = (point3D.y * cosDegrees) + (point3D.z * sinDegrees);
                double z = (point3D.y * -sinDegrees) + (point3D.z * cosDegrees);

                return new Vector3D(point3D.x, y, z);
            }

            public static Vector3D RotateY(Vector3D point3D, float degrees)
            {
                //[ cos(x)   0    sin(x)]
                //[   0      1      0   ]
                //[-sin(x)   0    cos(x)]

                double cDegrees = degrees * PIOVER180;
                double cosDegrees = Math.Cos(cDegrees);
                double sinDegrees = Math.Sin(cDegrees);

                double x = (point3D.x * cosDegrees) + (point3D.z * sinDegrees);
                double z = (point3D.x * -sinDegrees) + (point3D.z * cosDegrees);

                return new Vector3D(x, point3D.y, z);
            }

            public static Vector3D RotateZ(Vector3D point3D, float degrees)
            {
                //[ cos(x)  sin(x) 0]
                //[ -sin(x) cos(x) 0]
                //[    0     0     1]

                double cDegrees = degrees * PIOVER180;
                double cosDegrees = Math.Cos(cDegrees);
                double sinDegrees = Math.Sin(cDegrees);

                double x = (point3D.x * cosDegrees) + (point3D.y * sinDegrees);
                double y = (point3D.x * -sinDegrees) + (point3D.y * cosDegrees);

                return new Vector3D(x, y, point3D.z);
            }

            public static Vector3D Translate(Vector3D points3D, Vector3D oldOrigin, Vector3D newOrigin)
            {
                Vector3D difference = new Vector3D(newOrigin.x - oldOrigin.x, newOrigin.y - oldOrigin.y, newOrigin.z - oldOrigin.z);
                points3D.x += difference.x;
                points3D.y += difference.y;
                points3D.z += difference.z;
                return points3D;
            }

            public static Vector3D[] RotateX(Vector3D[] points3D, float degrees)
            {
                for (int i = 0; i < points3D.Length; i++)
                {
                    points3D[i] = RotateX((Vector3D)points3D[i], degrees);
                }
                return points3D;
            }

            public static Vector3D[] RotateY(Vector3D[] points3D, float degrees)
            {
                for (int i = 0; i < points3D.Length; i++)
                {
                    points3D[i] = RotateY((Vector3D)points3D[i], degrees);
                }
                return points3D;
            }

            public static Vector3D[] RotateZ(Vector3D[] points3D, float degrees)
            {
                for (int i = 0; i < points3D.Length; i++)
                {
                    points3D[i] = RotateZ((Vector3D)points3D[i], degrees);
                }
                return points3D;
            }

            public static Vector3D[] Translate(Vector3D[] points3D, Vector3D oldOrigin, Vector3D newOrigin)
            {
                for (int i = 0; i < points3D.Length; i++)
                {
                    points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
                }
                return points3D;
            }
        }

        //3D
        public class Face : IComparable<Face>
        {
            public PointF[] Corners2D;
            public float Depth;

            public Vector3D[] Corners3D;
            public Vector3D Center;

            public Color c;

            public Face()
            {
            }

            public Face(Vector3D[] points, Color c)
            {
                this.c = c;

                Corners3D = new Vector3D[points.Length];

                Center = new Vector3D(0, 0, 0);

                for (int i = 0; i < points.Length; i++)
                {
                    Corners3D[i] = new Vector3D(points[i].x, points[i].y, points[i].z);
                    Center.x += points[i].x;
                    Center.y += points[i].y;
                    Center.z += points[i].z;
                }

                Center.x /= points.Length;
                Center.y /= points.Length;
                Center.z /= points.Length;
            }

            public Face(Face f)
            {
                this.c = f.c;

                Corners3D = new Vector3D[f.Corners3D.Length];

                for (int i = 0; i < f.Corners3D.Length; i++)
                {
                    Corners3D[i] = new Vector3D(f.Corners3D[i].x, f.Corners3D[i].y, f.Corners3D[i].z);
                }

                Center = new Vector3D(f.Center.x, f.Center.y, f.Center.z);
                Corners2D = new PointF[f.Corners3D.Length];
            }

            public Face(Face f, Matrix4x3 m)
            {
                this.c = f.c;

                Corners3D = new Vector3D[f.Corners3D.Length];

                for (int i = 0; i < f.Corners3D.Length; i++)
                {
                    float x = f.Corners3D[i].x;
                    float y = f.Corners3D[i].y;
                    float z = f.Corners3D[i].z;

                    float x2 = m.V[0, 0] * x + m.V[1, 0] * y + m.V[2, 0] * z + m.V[3, 0];
                    float y2 = m.V[0, 1] * x + m.V[1, 1] * y + m.V[2, 1] * z + m.V[3, 1];
                    float d2 = m.V[0, 2] * x + m.V[1, 2] * y + m.V[2, 2] * z + m.V[3, 2];
                    Corners3D[i] = new Vector3D(x2, y2, d2);
                }
                {
                    float x = f.Center.x;
                    float y = f.Center.y;
                    float z = f.Center.z;

                    float x2 = m.V[0, 0] * x + m.V[1, 0] * y + m.V[2, 0] * z + m.V[3, 0];
                    float y2 = m.V[0, 1] * x + m.V[1, 1] * y + m.V[2, 1] * z + m.V[3, 1];
                    float d2 = m.V[0, 2] * x + m.V[1, 2] * y + m.V[2, 2] * z + m.V[3, 2];
                    Center = new Vector3D(x2, y2, d2);
                }
                Corners2D = new PointF[f.Corners3D.Length];
            }

            public Face(Face f, float scale)
            {
                this.c = f.c;

                Corners3D = new Vector3D[f.Corners3D.Length];

                for (int i = 0; i < f.Corners3D.Length; i++)
                {
                    float x = f.Corners3D[i].x;
                    float y = f.Corners3D[i].y;
                    float z = f.Corners3D[i].z;
                    Corners3D[i] = new Vector3D(scale * x, scale * y, scale * z);
                }
                {
                    float x = f.Center.x;
                    float y = f.Center.y;
                    float z = f.Center.z;
                    Center = new Vector3D(scale * x, scale * y, scale * z);
                }
                Corners2D = new PointF[f.Corners3D.Length];
            }

            public void EditFace(int vertex, Vector3D newVertex)
            {
                Corners3D[vertex] = newVertex;
                UpdateMidpoint();
            }

            public void EditFace(int vertex, Vector3D newVertex, Color newColor)
            {
                Corners3D[vertex] = newVertex;
                c = newColor;
                UpdateMidpoint();
            }

            void UpdateMidpoint()
            {
                Center = new Vector3D(0, 0, 0);

                for (int i = 0; i < Corners3D.Length; i++)
                {
                    Center.x += Corners3D[i].x;
                    Center.y += Corners3D[i].y;
                    Center.z += Corners3D[i].z;
                }

                Center.x /= Corners3D.Length;
                Center.y /= Corners3D.Length;
                Center.z /= Corners3D.Length;
            }

            public Face(Face f, float scale, float tx, float ty, float tz)
            {
                this.c = f.c;

                Corners3D = new Vector3D[f.Corners3D.Length];

                for (int i = 0; i < f.Corners3D.Length; i++)
                {
                    float x = f.Corners3D[i].x;
                    float y = f.Corners3D[i].y;
                    float z = f.Corners3D[i].z;
                    Corners3D[i] = new Vector3D(scale * x + tx, scale * y + ty, scale * z + tz);
                }
                {
                    float x = f.Center.x;
                    float y = f.Center.y;
                    float z = f.Center.z;
                    Center = new Vector3D(scale * x + tx, scale * y + ty, scale * z + tz);
                }
                Corners2D = new PointF[f.Corners3D.Length];
            }

            public void UpdateFace(float ar, float width, Matrix4x3 transform)
            {
                Corners2D = new PointF[Corners3D.Length];
                for (int i = 0; i < Corners2D.Length; i++)
                {
                    float x = Corners3D[i].x;
                    float y = Corners3D[i].y;
                    float z = Corners3D[i].z;
                    Matrix4x3 n = transform * Matrix4x3.CreateFromTranslationZ(-1);
                    Matrix4x3 m = /*Matrix3x3.Inverse(*/n/*)*/;
                    //x -= 0.5f;
                    //y -= ar / 2;
                    float x2 = m.V[0, 0] * x + m.V[1, 0] * y + m.V[2, 0] * z + m.V[3, 0];
                    float y2 = m.V[0, 1] * x + m.V[1, 1] * y + m.V[2, 1] * z + m.V[3, 1];
                    float d2 = m.V[0, 2] * x + m.V[1, 2] * y + m.V[2, 2] * z + 0 + m.V[3, 2];
                    float x3 = x2 / (d2 + 0) + 0.5f;
                    float y3 = y2 / (d2 + 0) + ar / 2;

                    Corners2D[i].X = (x3 * width);
                    Corners2D[i].Y = (y3 * width);
                }
                {
                    float x = Center.x;
                    float y = Center.y;
                    float z = Center.z;
                    Matrix4x3 n = transform * Matrix4x3.CreateFromTranslationZ(-1);
                    Matrix4x3 m = /*Matrix3x3.Inverse(*/n/*)*/;
                    //x -= 0.5f;
                    //y -= ar / 2;
                    Depth = m.V[0, 2] * x + m.V[1, 2] * y + m.V[2, 2] * z + 0 + m.V[3, 2];
                }
            }

            public void Draw(Graphics g, Pen p)
            {
                if (Depth > 1f)
                {
                    for (int i = 0; i < Corners2D.Length; i++)
                    {
                        g.DrawLine(p, Corners2D[i], Corners2D[(i + 1)  % Corners2D.Length]);
                    }
                }
            }

            public int CompareTo(Face otherFace)
            {
                return -(int)((this.Depth - otherFace.Depth) * 1000); //In order of which is closest to the screen
            }
        }
        public class Object3D
        {
            List<Face> faces;
            public void EditFace(int index, int vertex, Vector3D newVertex)
            {
                faces[index].EditFace(vertex, newVertex);
            }
            public void EditFace(int index, int vertex, Vector3D newVertex, Color newColor)
            {
                faces[index].EditFace(vertex, newVertex, newColor);
            }
            public Object3D(List<Face> f)
            {
                faces = f;
            }
            public Object3D(List<Face> f, Matrix4x3 t)
            {
                faces = new List<Face>();
                foreach (Face fx in f) faces.Add(new Face(fx, t));
            }
            public Object3D(List<Face> f, float scale)
            {
                faces = new List<Face>();
                foreach (Face fx in f) faces.Add(new Face(fx, scale));
            }
            public void add(ref List<Face> f, Matrix4x3 transform)
            {
                foreach (Face fc in faces)
                {
                    f.Add(new Face(fc, transform));
                }
            }
            public void add(ref List<Face> f, float s, float tx, float ty, float tz)
            {
                foreach (Face fc in faces)
                {
                    f.Add(new Face(fc, s, tx, ty, tz));
                }
            }
        }
        public struct Float4
        {
            public float R { set; get; }
            public float G { set; get; }
            public float B { set; get; }
            public float A { set; get; }

            public Float4(float R, float G, float B, float A) : this()
            {
                this.R = R;
                this.G = G;
                this.B = B;
                this.A = A;
            }
            public Float4(float R, float G, float B) : this(R, G, B, 1) { }

            public override string ToString()
            {
                return R.ToString("G") + "," + G.ToString("G") + "," + B.ToString("G") + "," + A.ToString("G");
            }
            public static Float4 Parse(string s)
            {
                string[] ss = s.Split(new char[] { ',' });
                return new Float4(float.Parse(ss[0]), float.Parse(ss[1]), float.Parse(ss[2]), float.Parse(ss[3]));
            }
        }
        public struct Matrix4x3
        {
            public float[,] V { get; set; }

            public Matrix4x3(float V00, float V01, float V02, float V03, float V10, float V11, float V12, float V13, float V20, float V21, float V22, float V23)
            {
                V = new float[4, 3];
                V[0, 0] = V00;
                V[1, 0] = V01;
                V[2, 0] = V02;
                V[3, 0] = V03;
                V[0, 1] = V10;
                V[1, 1] = V11;
                V[2, 1] = V12;
                V[3, 1] = V13;
                V[0, 2] = V20;
                V[1, 2] = V21;
                V[2, 2] = V22;
                V[3, 2] = V23;
            }

            public static Matrix4x3 CreateFromRotationX(float fullRot)
            {
                double x = Math.PI * 2 * fullRot;
                return new Matrix4x3(1, 0, 0, 0, 0, (float)Math.Cos(x), (float)-Math.Sin(x), 0, 0, (float)Math.Sin(x), (float)Math.Cos(x), 0);
            }
            public static Matrix4x3 CreateFromRotationY(float fullRot)
            {
                double x = Math.PI * 2 * fullRot;
                return new Matrix4x3((float)Math.Cos(x), 0, (float)-Math.Sin(x), 0, 0, 1, 0, 0, (float)Math.Sin(x), 0, (float)Math.Cos(x), 0);
            }
            public static Matrix4x3 CreateFromRotationZ(float fullRot)
            {
                double x = Math.PI * 2 * fullRot;
                return new Matrix4x3((float)Math.Cos(x), (float)-Math.Sin(x), 0, 0, (float)Math.Sin(x), (float)Math.Cos(x), 0, 0, 0, 0, 1, 0);
            }
            public static Matrix4x3 CreateFromTranslationZ(float x)
            {
                return new Matrix4x3(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, x);
            }
            public static Matrix4x3 CreateFromTranslationY(float x)
            {
                return new Matrix4x3(1, 0, 0, 0, 0, 1, 0, x, 0, 0, 1, 0);
            }
            public static Matrix4x3 CreateFromTranslationX(float x)
            {
                return new Matrix4x3(1, 0, 0, x, 0, 1, 0, 0, 0, 0, 1, 0);
            }
            public static Matrix4x3 CreateFromScaleY(float x)
            {
                return new Matrix4x3(1, 0, 0, 0, 0, x, 0, 0, 0, 0, 1, 0);
            }
            public static Matrix4x3 CreateFromScaleX(float x)
            {
                return new Matrix4x3(x, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0);
            }
            public static Matrix4x3 CreateFromScaleZ(float x)
            {
                return new Matrix4x3(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, x, 0);
            }

            public static Matrix4x3 operator *(Matrix4x3 a, Matrix4x3 b)
            {
                return new Matrix4x3(
                    a.V[0, 0] * b.V[0, 0] + a.V[1, 0] * b.V[0, 1] + a.V[2, 0] * b.V[0, 2],
                    a.V[0, 0] * b.V[1, 0] + a.V[1, 0] * b.V[1, 1] + a.V[2, 0] * b.V[1, 2],
                    a.V[0, 0] * b.V[2, 0] + a.V[1, 0] * b.V[2, 1] + a.V[2, 0] * b.V[2, 2],
                    a.V[0, 0] * b.V[3, 0] + a.V[1, 0] * b.V[3, 1] + a.V[2, 0] * b.V[3, 2] + a.V[3, 0],
                    a.V[0, 1] * b.V[0, 0] + a.V[1, 1] * b.V[0, 1] + a.V[2, 1] * b.V[0, 2],
                    a.V[0, 1] * b.V[1, 0] + a.V[1, 1] * b.V[1, 1] + a.V[2, 1] * b.V[1, 2],
                    a.V[0, 1] * b.V[2, 0] + a.V[1, 1] * b.V[2, 1] + a.V[2, 1] * b.V[2, 2],
                    a.V[0, 1] * b.V[3, 0] + a.V[1, 1] * b.V[3, 1] + a.V[2, 1] * b.V[3, 2] + a.V[3, 1],
                    a.V[0, 2] * b.V[0, 0] + a.V[1, 2] * b.V[0, 1] + a.V[2, 2] * b.V[0, 2],
                    a.V[0, 2] * b.V[1, 0] + a.V[1, 2] * b.V[1, 1] + a.V[2, 2] * b.V[1, 2],
                    a.V[0, 2] * b.V[2, 0] + a.V[1, 2] * b.V[2, 1] + a.V[2, 2] * b.V[2, 2],
                    a.V[0, 2] * b.V[3, 0] + a.V[1, 2] * b.V[3, 1] + a.V[2, 2] * b.V[3, 2] + a.V[3, 2]
                    );
            }
        }
        public struct Matrix3x3
        {
            public float[,] V { get; set; }

            public Matrix3x3(float V00, float V01, float V02, float V10, float V11, float V12, float V20, float V21, float V22)
            {
                V = new float[3, 3];
                V[0, 0] = V00;
                V[1, 0] = V01;
                V[2, 0] = V02;
                V[0, 1] = V10;
                V[1, 1] = V11;
                V[2, 1] = V12;
                V[0, 2] = V20;
                V[1, 2] = V21;
                V[2, 2] = V22;
            }
            public Matrix3x3(Matrix4x3 a)
            {
                V = new float[3, 3];
                V[0, 0] = a.V[0, 0];
                V[1, 0] = a.V[1, 0];
                V[2, 0] = a.V[2, 0] + a.V[3, 0];
                V[0, 1] = a.V[0, 1];
                V[1, 1] = a.V[1, 1];
                V[2, 1] = a.V[2, 1] + a.V[3, 1];
                V[0, 2] = a.V[0, 2];
                V[1, 2] = a.V[1, 2];
                V[2, 2] = a.V[2, 2] + a.V[3, 2];
            }

            public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b)
            {
                return new Matrix3x3(
                    a.V[0, 0] * b.V[0, 0] + a.V[1, 0] * b.V[0, 1] + a.V[2, 0] * b.V[0, 2],
                    a.V[0, 0] * b.V[1, 0] + a.V[1, 0] * b.V[1, 1] + a.V[2, 0] * b.V[1, 2],
                    a.V[0, 0] * b.V[2, 0] + a.V[1, 0] * b.V[2, 1] + a.V[2, 0] * b.V[2, 2],
                    a.V[0, 1] * b.V[0, 0] + a.V[1, 1] * b.V[0, 1] + a.V[2, 1] * b.V[0, 2],
                    a.V[0, 1] * b.V[1, 0] + a.V[1, 1] * b.V[1, 1] + a.V[2, 1] * b.V[1, 2],
                    a.V[0, 1] * b.V[2, 0] + a.V[1, 1] * b.V[2, 1] + a.V[2, 1] * b.V[2, 2],
                    a.V[0, 2] * b.V[0, 0] + a.V[1, 2] * b.V[0, 1] + a.V[2, 2] * b.V[0, 2],
                    a.V[0, 2] * b.V[1, 0] + a.V[1, 2] * b.V[1, 1] + a.V[2, 2] * b.V[1, 2],
                    a.V[0, 2] * b.V[2, 0] + a.V[1, 2] * b.V[2, 1] + a.V[2, 2] * b.V[2, 2]
                    );
            }
            public static Matrix3x3 Inverse(Matrix3x3 a)
            {
                float detA = a.V[0, 0] * a.V[1, 1] * a.V[2, 2]
                    + a.V[1, 0] * a.V[2, 1] * a.V[0, 2]
                    + a.V[2, 0] * a.V[0, 1] * a.V[1, 2]
                    - a.V[0, 2] * a.V[1, 1] * a.V[2, 0]
                    - a.V[0, 0] * a.V[1, 2] * a.V[2, 1]
                    - a.V[0, 1] * a.V[1, 0] * a.V[2, 2];

                return new Matrix3x3(
                    (a.V[1, 1] * a.V[2, 2] - a.V[2, 1] * a.V[1, 2]) / detA,
                    (a.V[2, 0] * a.V[1, 2] - a.V[1, 0] * a.V[2, 2]) / detA,
                    (a.V[1, 0] * a.V[2, 1] - a.V[2, 0] * a.V[1, 1]) / detA,

                    (a.V[2, 1] * a.V[0, 2] - a.V[0, 1] * a.V[2, 2]) / detA,
                    (a.V[0, 0] * a.V[2, 2] - a.V[2, 0] * a.V[0, 2]) / detA,
                    (a.V[2, 0] * a.V[0, 1] - a.V[0, 0] * a.V[2, 1]) / detA,

                    (a.V[0, 1] * a.V[1, 2] - a.V[1, 1] * a.V[0, 2]) / detA,
                    (a.V[1, 0] * a.V[0, 2] - a.V[0, 0] * a.V[1, 2]) / detA,
                    (a.V[0, 0] * a.V[1, 1] - a.V[1, 0] * a.V[0, 1]) / detA
                    );
            }
        }

        private float Pozadi_Cas = 0;
        private int Pozadi_Typ = 0;
        private int Pozadi_PocetTypu = 1;

        bool lekceSeSpousti = false;
        private void SpustLekci(ILekce l)
        {
            if (lekceSeSpousti) return;
            lekceSeSpousti = true;
            AktualniLekce = new StavPsani();
            AktualniLekce.Inicializuj(l, AktualniUzivatel);
            lekceSeSpousti = false;
            AktualniObrazovka = Obrazovka.Psani;
        }


        private float Menu_Polozka;
        //Univerzalni menu
        private void VykresliMenuUniverzalni(Graphics g, string[] slova)
        {
            for (int i = 0; i < slova.Length; i++)
            {
                int x = Width / 2 - menu_sirkaPole / 2;
                int y = menu_yPole + i * menu_mezery;
                int w = menu_sirkaPole;
                int h = menu_vyskaPole;
                if (poziceY != i)
                {
                    g.FillRectangle(Brushes.Black, new Rectangle(x, y, w, h));
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
        private void AktualizujPoziciMysi(int x, int y)
        {
            if (AktualniObrazovka == Obrazovka.Statistika)
            {
                if (x > 1080 && x < 1280 && y > 0 && y < 100)
                {
                    poziceY = 0;
                }
                else poziceY = -1;
            }
            else
            {
                if (x > Width / 2 - menu_sirkaPole / 2 && x < Width / 2 + menu_sirkaPole / 2)
                {
                    if (y > menu_yPole)
                    {
                        poziceY = (y - menu_yPole) / menu_mezery;
                        if ((y - menu_yPole) % menu_mezery > menu_vyskaPole) poziceY = -1;
                    }
                    else poziceY = -1;
                }
                else poziceY = -1;
            }
        }

        //Pro Vykresleni a vyber v univerzalnim menu
        int poziceY = -1;
        int kliknutoY = -1;
        //Nekonstanty, mohly by se měnit za běhu. (Kazde menu nemusi byt stejne)
        int menu_sirkaPole = 400;
        int menu_vyskaPole = 100;
        int menu_yPole = 100;
        int menu_mezery = 120;
        Font menu_font = new Font("Arial Black", 40);

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pozadi_Cas += timer1.Interval;
            Aktualizuj();
            Invalidate();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            kliknuto = true;
            kliknutoY = poziceY;
            Aktualizuj();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && (AktualniObrazovka == Obrazovka.Statistika || AktualniObrazovka == Obrazovka.Psani))
            {
                if (AktualniObrazovka == Obrazovka.Statistika)
                {
                    AktualniObrazovka = Obrazovka.Menu;
                }
                else
                {
                    DialogResult dr = MessageBox.Show(this, "Chcete ukončit lekci?","Konec",MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        AktualniLekce.Ukonci();
                        AktualniObrazovka = Obrazovka.Menu;
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && (AktualniObrazovka == Obrazovka.Statistika || AktualniObrazovka == Obrazovka.Psani))
            {
                if (AktualniObrazovka == Obrazovka.Statistika)
                {
                    AktualniObrazovka = Obrazovka.Menu;
                }
                else
                {
                    DialogResult dr = MessageBox.Show(this, "Chcete ukončit lekci?", "Konec", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        AktualniLekce.Ukonci();
                        AktualniObrazovka = Obrazovka.Menu;
                    }
                }
            }
        }
    }

    public interface ILekce
    {
        void AktualizujLekci(StavPsani sp);
        void ZahajLekci(StavPsani sp);
        void Vycisti();
    }
    public class StavPsani
    {
        bool dokonceno = false;
        public bool Dokonceno
        {
            get
            {
                return dokonceno;
            }
        }

        private ILekce lekce;
        string radek = "";
        string radekChyb = "";
        public List<string> dalsiRadky = new List<string>();

        int poziceVRadku = 0;
        StavRychlosti rychlost = new StavRychlosti();
        Uzivatel u;
        SeznamZnaku znaky;
        StavZnaku filtr;

        public Tuple<float,float> RychlostChybovost()
        {
            return new Tuple<float, float>(rychlost.OkamzitaRychlost, rychlost.OkamzitaChybovost);
        }
        public void Inicializuj(ILekce lekce, Uzivatel u)
        {
            this.u = u;

            this.lekce = lekce;

            znaky = u.pouzivanaAbeceda;

            lekce.ZahajLekci(this);
            lekce.AktualizujLekci(this);

            if (dalsiRadky.Count == 0) ; //ukonceni


            radek = "";
            while (radek == "" || radek == " ")
            {
                if (AktualizujRadekNeboKonec()) break;
            }


        }
        bool chyba = false;
        public void ZpracujVstup(int ms, char znak)
        {
            if (znak == radek[poziceVRadku])
            {
                radekChyb += " ";
            }
            else if (!chyba)
            {
                radekChyb += znak;
            }

            if (!chyba || znak == radek[poziceVRadku])
            {
                chyba = false;

                if (znak != radek[poziceVRadku]) chyba = true;

                if (ms > 3000) rychlost.Nahlas(3000, znak, radek[poziceVRadku]);
                else rychlost.Nahlas(ms, znak, radek[poziceVRadku]);

                poziceVRadku++;
            }
            

            if (poziceVRadku == radek.Length)
            {
                radek = "";
                radekChyb = "";
                if (!dokonceno) while (radek == "")
                    {
                        if (AktualizujRadekNeboKonec()) break;
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
            // radekPosunX Y
            int rpx = 30;
            int rpy = 30;

            SizeF pravitko = g.MeasureString("A", new Font("Consolas", 20));
            SizeF pravitko2 = g.MeasureString("A", new Font("Consolas", 30));

            if (radek.Length > 0)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(230, 0, 0, 0)), new Rectangle(20, 20, 1280 - 40, 720 - 40));
                // HL RADEK
                g.DrawString(radek, new Font("Consolas", 20), Brushes.Gray, new PointF(rpx, rpy));
                g.DrawString(radek.Remove(poziceVRadku, radek.Length - poziceVRadku), new Font("Consolas", 20), Brushes.White, new PointF(rpx, rpy));
                g.DrawString(radekChyb, new Font("Consolas", 20), Brushes.Cyan, new PointF(rpx, rpy + 25));

                // DALSI RADKY
                for (int i = 0; i < 5; i++)
                {
                    if (i < dalsiRadky.Count) g.DrawString(dalsiRadky[i], new Font("Consolas", 20), Brushes.Gray, new PointF(rpx, rpy + 50 + i * 25));
                }

                rychlost.Vykreslit(g, u);
            }

            g.DrawString("Zmáčkněte ESCAPE pro konec\nJestli je vstup ignorován, klikněte do pole na spodku obrazovky", new Font("Consolas", 8), Brushes.White, new RectangleF(0, 0, 1190, 640), new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far });
        }
        private bool AktualizujRadekNeboKonec()
        {
            if (dalsiRadky.Count > 0)
            {
                lekce.AktualizujLekci(this);

                radek = dalsiRadky[0];
                if (radek.Length > 80)
                {
                    dalsiRadky.RemoveAt(0);
                    if (radek.Contains(" "))
                    {
                        int i = radek.IndexOf(" ");
                        if (i <= 80)
                        {
                            for (int j = 80; j >= 0; j--)
                            {
                                if (radek[j] == ' ')
                                {
                                    i = j;
                                    break;
                                }
                            }
                            string s1 = radek.Remove(i);
                            string s2 = radek.Remove(0, i + 1);
                            radek = s1;
                            if (s2 != "") dalsiRadky.Insert(0, s2);
                        }
                        else
                        {
                            string s1 = radek.Remove(80);
                            string s2 = radek.Remove(0, 80);
                            radek = s1;
                            if (s2 != "") dalsiRadky.Insert(0, s2);
                        }
                    }
                    else
                    {
                        string s1 = radek.Remove(80);
                        string s2 = radek.Remove(0, 80);
                        radek = s1;
                        if (s2 != "") dalsiRadky.Insert(0, s2);
                    }
                }
                else dalsiRadky.RemoveAt(0);

                VyfiltrujAktual();
                VyfiltrujDalsi();

                poziceVRadku = 0;
            }
            else
            {
                if (rychlost.totalZnaku != 0) MessageBox.Show("Konec lekce!\n\nPočet znaků: " + rychlost.totalZnaku + "\nPočet chyb: " + rychlost.pocetChyb + "\nChybovost: " + (100f * rychlost.pocetChyb / rychlost.totalZnaku).ToString("0.0") + "%\nČas: " + rychlost.totalMs / 3600000 + ":" + (rychlost.totalMs % 3600000) / 60000 + ":" + (rychlost.totalMs % 60000) / 1000 + "\nRychlost: " + (60000 * rychlost.totalZnaku / rychlost.totalMs) + " znaků za minutu");
                u.NahlasDokoncenePsani(rychlost.totalZnaku, rychlost.totalMs, rychlost.pocetChyb);
                lekce.Vycisti();
                dokonceno = true;
                return true;
            }
            return false;
        }
        private void VyfiltrujAktual()
        {
            if (!(znaky.pridatVseNaKonci && znaky.obtiznost >= znaky.stupne.Length))
            {
                filtr = new StavZnaku();
                filtr.aktualni = znaky.DostatSeznam();
                radek = filtr.Vyfiltruj(radek, filtr.aktualni.Count < 15 ? FiltrovaciMoznosti.Znak : FiltrovaciMoznosti.Slovo);
            }


            lekce.AktualizujLekci(this);
        }
        private void VyfiltrujDalsi()
        {
            if (dalsiRadky.Count > 0)
            {
                if (!(znaky.pridatVseNaKonci && znaky.obtiznost >= znaky.stupne.Length))
                {
                    filtr = new StavZnaku();
                    filtr.aktualni = znaky.DostatSeznam();
                    dalsiRadky[0] = filtr.Vyfiltruj(dalsiRadky[0], filtr.aktualni.Count < 15 ? FiltrovaciMoznosti.Znak : FiltrovaciMoznosti.Slovo);
                }
                lekce.AktualizujLekci(this);
            }
        }

        public void Ukonci()
        {
            if (rychlost.totalZnaku != 0) MessageBox.Show("Lekce ukončena.\n\nPočet znaků: " + rychlost.totalZnaku + "\nPočet chyb: " + rychlost.pocetChyb + "\nChybovost: " + (100f * rychlost.pocetChyb / rychlost.totalZnaku).ToString("0.0") + "%\nČas: " + rychlost.totalMs / 3600000 + ":" + (rychlost.totalMs % 3600000) / 60000 + ":" + (rychlost.totalMs % 60000) / 1000 + "\nRychlost: " + (60000 * rychlost.totalZnaku / rychlost.totalMs) + " znaků za minutu");
            if (rychlost.totalZnaku != 0) u.NahlasDokoncenePsani(rychlost.totalZnaku, rychlost.totalMs, rychlost.pocetChyb);
            lekce.Vycisti();
            dokonceno = true;
        }
    }
    public class StavRychlosti
    {
        public long totalMs = 0;
        public long totalZnaku = 0;
        public long pocetChyb = 0;

        int ukazatel;
        bool dosazeno100;
        int[] posl100ms;
        int[] posl100chyb;

        int pocetChyb100 = 0;
        int pocetMs100 = 0;

        public void Nahlas(int ms, char znak, char ocekavany)
        {
            if (ocekavany == znak)
            {
                totalMs += ms;
                totalZnaku++;

                posl100ms[ukazatel] += ms;
                pocetMs100 += ms;
                ukazatel++;
                if (ukazatel >= 100) dosazeno100 = true;
                ukazatel %= 100;

                pocetMs100 -= posl100ms[ukazatel];
                pocetChyb100 -= posl100chyb[ukazatel];

                posl100ms[ukazatel] = 0;
                posl100chyb[ukazatel] = 0;
            }
            else
            {
                totalMs += ms;
                totalZnaku++;
                pocetChyb++;

                posl100ms[ukazatel] += ms;
                posl100chyb[ukazatel]++;
                pocetMs100 += ms;
                pocetChyb100++;
                ukazatel++;
                if (ukazatel >= 100) dosazeno100 = true;
                ukazatel %= 100;

                pocetMs100 -= posl100ms[ukazatel];
                pocetChyb100 -= posl100chyb[ukazatel];

                posl100ms[ukazatel] = 0;
                posl100chyb[ukazatel] = 0;
            }
        }
        public void Aktualizovat()
        {

        }
        public void Vykreslit(Graphics g, Uzivatel u)
        {
            float a1 = (totalZnaku / (totalMs / 60000f));
            float a2 = (100f * pocetChyb / totalZnaku);
            VykreslitBar(g, a1 / 400f, "Rychlost (/min)", a1.ToString("0.0"), new Rectangle(30, 450, 200, 50));
            VykreslitBar(g, a2 / 5f, "Chybovost (%)", a2.ToString("0.0"), new Rectangle(30, 520, 200, 50));

            float f1 = 0;
            float f2 = 0;
            if (dosazeno100)
            {
                f1 = OkamzitaRychlost;
                f2 = OkamzitaChybovost;

                VykreslitBar(g, f1 / 400f, "Průb. Rychlost (/min)", f1.ToString("0.0"), new Rectangle(330, 450, 200, 50));
                VykreslitBar(g, f2 / 5f, "Průb. Chybovost (%)", f2.ToString("0.0"), new Rectangle(330, 520, 200, 50));
            }

            VykreslitBar(g, u.pouzivanaAbeceda.obtiznost / (float)u.pouzivanaAbeceda.stupne.Length, "Akt. LVL", u.pouzivanaAbeceda.obtiznost.ToString(), new Rectangle(630, 450, 200, 50));
            VykreslitBar(g, u.pouzivanaAbeceda.obtiznost / (float)u.pouzivanaAbeceda.stupne.Length, "Průb. LVL", u.pouzivanaAbeceda.OcekavanaUroven(f1 == 0 ? a1 : f1, f2 == 0 ? a2 : f2).ToString("0.00"), new Rectangle(630, 520, 200, 50));


            /*g.DrawString("Čas (na výpočty): " + totalMs.ToString(), new Font("Arial", 20), Brushes.White, new PointF(100, 200));
            g.DrawString("Znaky: " + totalZnaku.ToString(), new Font("Arial", 20), Brushes.White, new PointF(100, 225));

            g.DrawString("Rychlost: " + (totalZnaku / (totalMs / 60000f)).ToString("0.0") + "BPM", new Font("Arial", 20), Brushes.White, new PointF(100, 250));
            g.DrawString("Chyby: " + pocetChyb.ToString(), new Font("Arial", 20), Brushes.Red, new PointF(100, 275));
            g.DrawString("Chybovost: " + (100f * pocetChyb / totalZnaku).ToString("0.0") + "%", new Font("Arial", 20), Brushes.Red, new PointF(100, 300));

            if (dosazeno100)
            {
                g.DrawString("Průb. Rychlost: " + (100 / (pocetMs100 / 60000f)).ToString("0.0") + "BPM", new Font("Arial", 20), Brushes.White, new PointF(400, 275));
                g.DrawString("Průb. Chybovost: " + (100f * pocetChyb100 / 100).ToString("0.0") + "%", new Font("Arial", 20), Brushes.Red, new PointF(400, 300));
            }*/
        }

        private void VykreslitBar(Graphics g, float p, string textNad, string text, Rectangle R)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;

            g.DrawString(textNad, new Font("Arial", 7), Brushes.White, new Point(R.X + 3, R.Y - 10));

            g.FillRectangle(Brushes.Black, R);
            g.FillRectangle(Brushes.Cyan, new Rectangle(R.X, R.Y, (int)(R.Width * p), R.Height));
            g.DrawRectangle(Pens.White, R);

            if (p > 0.5f)
            {
                g.DrawString(text, new Font("Arial", 20), Brushes.Black, new Rectangle(R.X, R.Y, (int)(R.Width * p), R.Height), new StringFormat() {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center } );
            }
            else
            {
                g.DrawString(text, new Font("Arial", 20), Brushes.Cyan, new Rectangle(R.X + (int)(R.Width * p), R.Y, (int)(R.Width * (1-p)), R.Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }

        public StavRychlosti()
        {
            posl100chyb = new int[100];
            posl100ms = new int[100];
            ukazatel = 0;
            dosazeno100 = false;
        }

        public float OkamzitaRychlost => dosazeno100 ? (100 / (pocetMs100 / 60000f)) : (totalZnaku / (totalMs / 60000f));
        public float OkamzitaChybovost => dosazeno100 ? (100f * pocetChyb100 / 100) : (100f * pocetChyb / totalZnaku);
    }
    public class SpravceHudby : ISampleProvider
    {
        Hudba? AktualniHudba = null;
        ZrychlovacHudby Prov;

        public WaveFormat WaveFormat => WaveFormat.CreateIeeeFloatWaveFormat(48000, 1);
        public bool HudbaSePrehrava = false;

        void PrehrajZvuk(Zvuk z)
        {
        }
        void PrehrajZvukNapitchovany(Zvuk z)
        {
        }
        void Chyba()
        {
        }
        public void SpustHudbu(Hudba h)
        {
            if (AktualniBPM == 0) AktualniBPM = h.BPM;
            AktualniHudba = h;
            Prov = new ZrychlovacHudby(h.soubor);
            Prov.NastavRychlost(AktualniBPM);
            HudbaSePrehrava = true;
        }
        public void NahlasBPM(float BPM)
        {
            if (BPM < 30) BPM = 30;
            AktualniBPM = BPM;

            if (HudbaSePrehrava)
            {
                Prov.NastavRychlost(BPM / AktualniHudba.Value.BPM);
            }
        }
        public float AktualniBPM { get; private set; }
        void StopHudbu()
        {
            AktualniHudba = null;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            Array.Clear(buffer, 0, buffer.Length);
            if (Prov != null) HudbaSePrehrava = Prov.Read(buffer, 0, count) > 0;
            return count;
        }
    }
    public class Zvuk
    {
        float[] samply;
        float frekvence;
    }
    public struct Hudba
    {
        public string soubor;
        public float BPM;

        public void Ulozit(FileStream fs)
        {
            StreamHelper.SaveString(fs, soubor);
            StreamHelper.SaveBytes(fs, BPM);
        }
        public static Hudba ZeSouboru(FileStream fs)
        {
            Hudba h = new Hudba();
            h.soubor = StreamHelper.LoadString(fs);
            h.BPM = StreamHelper.LoadFloat(fs);
            return h;
        }
    }
    public class SeznamZnaku
    {
        public string stupne;
        public int velkaPismena;

        public bool pridatVseNaKonci;

        public int obtiznost;
        public bool dynamickeZtezovani;

        public int pocatecniRychlost;
        public int konecnaRychlost;
        public float pocatecniChybovost;
        public float koncovaChybovost;

        public void Ulozit(FileStream fs)
        {
            StreamHelper.SaveString(fs, stupne);
            StreamHelper.SaveBytes(fs, velkaPismena);
            StreamHelper.SaveBytes(fs, pridatVseNaKonci);

            StreamHelper.SaveBytes(fs, obtiznost);
            StreamHelper.SaveBytes(fs, dynamickeZtezovani);

            StreamHelper.SaveBytes(fs, pocatecniRychlost);
            StreamHelper.SaveBytes(fs, konecnaRychlost);
            StreamHelper.SaveBytes(fs, pocatecniChybovost);
            StreamHelper.SaveBytes(fs, koncovaChybovost);
        }
        public static SeznamZnaku ZeSouboru(FileStream fs)
        {
            SeznamZnaku sz = new SeznamZnaku();
            sz.stupne = StreamHelper.LoadString(fs);
            sz.velkaPismena = StreamHelper.LoadInt(fs);
            sz.pridatVseNaKonci = StreamHelper.LoadBool(fs);

            sz.obtiznost = StreamHelper.LoadInt(fs);
            sz.dynamickeZtezovani = StreamHelper.LoadBool(fs);

            sz.pocatecniRychlost = StreamHelper.LoadInt(fs);
            sz.konecnaRychlost = StreamHelper.LoadInt(fs);
            sz.pocatecniChybovost = StreamHelper.LoadFloat(fs);
            sz.koncovaChybovost = StreamHelper.LoadFloat(fs);

            return sz;
        }
        public List<char> DostatSeznam()
        {
            List<char> seznam = new List<char>();
            for (int i = 0; i < obtiznost && i < stupne.Length; i++)
            {
                seznam.Add(stupne[i]);
                if (obtiznost > velkaPismena)
                {
                    if (stupne[i] != char.ToUpper(stupne[i]))
                        seznam.Add(char.ToUpper(stupne[i]));
                }
            }
            return seznam;
        }

        public float OcekavanaUroven(float BPM, float chybovost)
        {
            int konecna = stupne.Length - 8;

            float dleRychlosti = ((BPM - pocatecniRychlost) / (konecnaRychlost - pocatecniRychlost)) * konecna;
            float dleChybovosti = ((BPM - pocatecniRychlost) / (konecnaRychlost - pocatecniRychlost)) * konecna;

            float f = (3 * dleRychlosti + dleChybovosti) / 4;
            if (f < 0) f = 0;

            return f + 8;
        }
    }
    public class StavZnaku
    {
        public List<char> aktualni;

        // vyfiltruje znaky/slova co neumis a nahradi dvojite mezery
        public string Vyfiltruj(string radek, FiltrovaciMoznosti fm)
        {
            string[] ss = radek.Split(' ');
            List<string> sl = ss.ToList();



            if (fm == FiltrovaciMoznosti.Znak)
            {
                for (int i = 0; i < sl.Count; i++)
                {
                    List<int> odstranit = new List<int>();
                    int j = 0;
                    foreach (char c in sl[i])
                    {
                        if (!aktualni.Contains(c))
                        {
                            odstranit.Add(j);
                            j++;
                        }
                        else j++;
                    }
                    odstranit.Reverse();
                    foreach (int k in odstranit) sl[i] = sl[i].Remove(k, 1);
                }
                while (sl.Contains("")) sl.Remove("");
            }
            if (fm == FiltrovaciMoznosti.Slovo)
            {
                while (sl.Contains("")) sl.Remove("");
                List<int> odstranit = new List<int>();
                for (int i = 0; i < sl.Count; i++)
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
            while (ret.EndsWith(" ")) ret = ret.Remove(ret.Length - 1);
            return ret;
        }
    }
    public enum FiltrovaciMoznosti { Znak, Slovo }
    public enum Obrazovka { Intro, Menu, Uzivatel, Psani, VyberLekce, Statistika };

    public class Statistika
    {
        long uhozyCelkem;
        long milisekundyCelkem;
        long chybyCelkem;


        float[] poslChybovosti;
        float[] poslRychlosti;
        DateTime[] casyDokonceni;
        int indexZapisu;
        long pocetHer;

        public Statistika()
        {
            poslRychlosti = new float[1000];
            poslChybovosti = new float[1000];
            casyDokonceni = new DateTime[1000];
        }
        public void Ulozit(FileStream fs)
        {
            StreamHelper.SaveBytes(fs, uhozyCelkem);
            StreamHelper.SaveBytes(fs, milisekundyCelkem);
            StreamHelper.SaveBytes(fs, chybyCelkem);

            StreamHelper.SaveBytes(fs, indexZapisu);
            StreamHelper.SaveBytes(fs, pocetHer);

            StreamHelper.SaveBytes(fs, 1000);

            for (int i = 0; i < 1000; i++)
            {
                StreamHelper.SaveBytes(fs, poslRychlosti[i]);
                StreamHelper.SaveBytes(fs, poslChybovosti[i]);
                StreamHelper.SaveBytes(fs, casyDokonceni[i].ToBinary());
            }
        }
        public static Statistika ZeSouboru(FileStream fs)
        {
            Statistika s = new Statistika();

            s.uhozyCelkem = StreamHelper.LoadLong(fs);
            s.milisekundyCelkem = StreamHelper.LoadLong(fs);
            s.chybyCelkem = StreamHelper.LoadLong(fs);

            s.indexZapisu = StreamHelper.LoadInt(fs);
            s.pocetHer = StreamHelper.LoadLong(fs);

            int l = StreamHelper.LoadInt(fs);

            s.poslRychlosti = new float[l];
            s.poslChybovosti = new float[l];
            s.casyDokonceni = new DateTime[l];

            for (int i = 0; i < l; i++)
            {
                s.poslRychlosti[i] = StreamHelper.LoadFloat(fs);
                s.poslChybovosti[i] = StreamHelper.LoadFloat(fs);
                s.casyDokonceni[i] = DateTime.FromBinary(StreamHelper.LoadLong(fs));
            }

            return s;
        }
        public void NahlasDokoncenePsani(long znaky, long ms, long chyby)
        {
            vypocitano = false;
            if (znaky > 100)
            {
                pocetHer++;

                uhozyCelkem += znaky;
                milisekundyCelkem += ms;
                chybyCelkem += chyby;

                poslRychlosti[indexZapisu] = (60000f * znaky / ms);
                poslChybovosti[indexZapisu] = (100f * chyby / znaky);
                casyDokonceni[indexZapisu] = DateTime.Now;

                indexZapisu++;
                indexZapisu %= 1000;
            }
        }

        public void VykresliGrafDatumVsRychlost(Graphics g)
        {
            DateTime dt = DateTime.Now;
            g.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), new Rectangle(5, 60, 450, 250));
            for (int i = 0; i < 7; i++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(25 + 60 * i + 1, 70 + 1, 60 - 2, 220 - 2));
            }
            g.DrawString("Posledních 7 dní - Rychlost", new Font("Arial", 7), Brushes.White, new Point(5, 50));
            for (int i = 0; i < 8; i++)
            {
                g.DrawString((50 * i).ToString(), new Font("Arial", 7), Brushes.White, new Point(5, 70 + (7 - i) * 220 / 7));
                g.DrawLine(new Pen(Color.FromArgb(20, 20, 20)), 25, 70 + (7 - i) * 220 / 7, 25 + 420, 70 + (7 - i) * 220 / 7);
            }
            for (int i = 0; i < 1000 && i < pocetHer; i++)
            {
                if (casyDokonceni[i] > dt.AddDays(-7))
                {
                    TimeSpan ts = dt.Subtract(casyDokonceni[i]);
                    float f = (float)(ts.TotalMinutes / (new TimeSpan(7, 0, 0, 0)).TotalMinutes);
                    float h = poslRychlosti[i];
                    float ch = poslChybovosti[i];
                    if (h > 350) h = 350;
                    if (ch > 3) ch = 3;
                    g.FillEllipse(new SolidBrush(Color.FromArgb((int)(255 * (ch / 3f)), (int)(255 * (1 - ch / 3f)), 0)), new Rectangle((int)(25 + 420 * (1 - f) - 2), (int)(70 + 220 * (1 - h / 350f)), 5, 5));
                }
            }
        }
        public void VykresliGrafDatumVsChybovost(Graphics g)
        {
            DateTime dt = DateTime.Now;
            g.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), new Rectangle(5, 280 + 50, 450, 250));
            for (int i = 0; i < 7; i++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(25 + 60 * i + 1, 280 + 60 + 1, 60 - 2, 220 - 2));
            }
            g.DrawString("Posledních 7 dní - Chybovost", new Font("Arial", 7), Brushes.White, new Point(5, 280 + 40));
            for (int i = 0; i < 7; i++)
            {
                g.DrawString((0.5f * i).ToString() + "%", new Font("Arial", 7), Brushes.White, new Point(5, 280 + 60 + (6 - i) * 220 / 6));
                g.DrawLine(new Pen(Color.FromArgb(20, 20, 20)), 25, 280 + 60 + (6 - i) * 220 / 6, 25 + 420, 280 + 60 + (6 - i) * 220 / 6);
            }
            for (int i = 0; i < 1000 && i < pocetHer; i++)
            {
                if (casyDokonceni[i] > dt.AddDays(-7))
                {
                    TimeSpan ts = dt.Subtract(casyDokonceni[i]);
                    float f = (float)(ts.TotalMinutes / (new TimeSpan(7, 0, 0, 0)).TotalMinutes);
                    float h = poslChybovosti[i];
                    if (h > 3) h = 3;
                    g.FillEllipse(new SolidBrush(Color.FromArgb((int)(255 * (h / 3f)), (int)(255 * (1 - h / 3f)), 0)), new Rectangle((int)(25 + 420 * (1 - f) - 2), 280 + (int)(60 + 220 * (1 - h / 3f)), 5, 5));
                }
            }
        }
        bool vypocitano = false;
        float pr10;
        float pr100;
        float pc10;
        float pc100;
        public void VykresliZbytekStatistik(Graphics g)
        {
            if (!vypocitano)
            {
                int c = 0;
                float sr = 0;
                float sc = 0;
                for (int i = 0; i < 100; i++)
                {
                    if (i < pocetHer)
                    {
                        c++;
                        sr += poslRychlosti[(indexZapisu - 1 - i + 1000) % 1000];
                        sc += poslChybovosti[(indexZapisu - 1 - i + 1000) % 1000];
                    }
                    if (i == 9)
                    {
                        pr10 = sr / c;
                        pc10 = sc / c;
                    }
                    if (i == 99)
                    {
                        pr100 = sr / c;
                        pc100 = sc / c;
                    }
                }

                vypocitano = true;
            }

            int x0 = 470;
            int y0 = 40;
            int dy = 27;
            g.DrawString("Lekcí dokončeno: " + pocetHer, new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 0 * dy));
            g.DrawString("Znaků napsáno: " + uhozyCelkem, new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 1 * dy));
            g.DrawString("Chyby celkem: " + chybyCelkem, new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 2 * dy));
            g.DrawString("Čas psaní: " + (milisekundyCelkem / 3600000).ToString("00") + ":" + ((milisekundyCelkem % 3600000) / 60000).ToString("00") + ":" + ((milisekundyCelkem % 60000) / 1000).ToString("00"), new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 3 * dy));
            g.DrawString("Celková chybovost: " + (100f * chybyCelkem / uhozyCelkem).ToString("0.00") + "%", new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 4 * dy));
            g.DrawString("Celková rychlost: " + (60000f * uhozyCelkem / milisekundyCelkem).ToString("0.00") + " za minutu", new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 5 * dy));

            g.DrawString("Posledních 10 - rychlost: " + pr10.ToString("0.0") + "/min", new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 7 * dy));
            g.DrawString("Posledních 10 - chybovost: " + pc10.ToString("0.0") + "%", new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 8 * dy));

            g.DrawString("Posledních 100 - rychlost: " + pr100.ToString("0.0") + "/min", new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 10 * dy));
            g.DrawString("Posledních 100 - chybovost: " + pc100.ToString("0.0") + "%", new Font("Arial", 20), Brushes.White, new Point(x0, y0 + 11 * dy));
        }
    }

    public class Uzivatel
    {
        List<Hudba> uzivatelskaHudba;
        public SeznamZnaku pouzivanaAbeceda;
        public Statistika uzivatelskaStatistika;
        string soubor;
        public static Uzivatel ZeSouboru(string soubor)
        {
            Uzivatel u = new Uzivatel(soubor);

            FileStream fs = new FileStream(soubor, FileMode.Open);

            u.pouzivanaAbeceda = SeznamZnaku.ZeSouboru(fs);

            int hc = StreamHelper.LoadInt(fs);
            for (int i = 0; i < hc; i++) u.uzivatelskaHudba.Add(Hudba.ZeSouboru(fs));

            u.uzivatelskaStatistika = Statistika.ZeSouboru(fs);

            fs.Close();
            fs.Dispose();

            return u;
        }
        public Uzivatel(string soubor)
        {
            uzivatelskaHudba = new List<Hudba>();
            pouzivanaAbeceda = new SeznamZnaku();
            pouzivanaAbeceda.stupne = "fjdkslaůghrueiwoqptzyxcvbnměščřžýáíé,\"!?-:";
            pouzivanaAbeceda.pridatVseNaKonci = false;
            pouzivanaAbeceda.velkaPismena = 27;
            uzivatelskaStatistika = new Statistika();

            this.soubor = soubor;
        }
        public void Ulozit()
        {
            FileStream fs = new FileStream(soubor, FileMode.Create);
            pouzivanaAbeceda.Ulozit(fs);

            StreamHelper.SaveBytes(fs, uzivatelskaHudba.Count);
            foreach (Hudba h in uzivatelskaHudba) h.Ulozit(fs);

            uzivatelskaStatistika.Ulozit(fs);

            fs.Close();
            fs.Dispose();
        }

        public void NahlasDokoncenePsani(long znaky, long ms, long chyby)
        {
            uzivatelskaStatistika.NahlasDokoncenePsani(znaky, ms, chyby);
        }
    }
    public static class StreamHelper
    {
        public static void SaveBytes(FileStream fs, float input)
        {
            byte[] b = BitConverter.GetBytes(input);
            fs.Write(b, 0, b.Length);
        }
        public static void SaveBytes(FileStream fs, int input)
        {
            byte[] b = BitConverter.GetBytes(input);
            fs.Write(b, 0, b.Length);
        }
        public static void SaveBytes(FileStream fs, long input)
        {
            byte[] b = BitConverter.GetBytes(input);
            fs.Write(b, 0, b.Length);
        }
        public static void SaveBytes(FileStream fs, ulong input)
        {
            byte[] b = BitConverter.GetBytes(input);
            fs.Write(b, 0, b.Length);
        }
        public static void SaveBytes(FileStream fs, bool input)
        {
            byte[] b = BitConverter.GetBytes(input);
            fs.Write(b, 0, b.Length);
        }

        public static void SaveString(FileStream fs, string input)
        {
            byte[] b = Encoding.UTF32.GetBytes(input);
            SaveBytes(fs, b.Length);
            fs.Write(b, 0, b.Length);
        }

        public static int LoadInt(FileStream fs)
        {
            byte[] b = new byte[4];
            fs.Read(b, 0, 4);
            return BitConverter.ToInt32(b, 0);
        }
        public static long LoadLong(FileStream fs)
        {
            byte[] b = new byte[8];
            fs.Read(b, 0, 8);
            return BitConverter.ToInt64(b, 0);
        }
        public static ulong LoadULong(FileStream fs)
        {
            byte[] b = new byte[8];
            fs.Read(b, 0, 8);
            return BitConverter.ToUInt64(b, 0);
        }
        public static float LoadFloat(FileStream fs)
        {
            byte[] b = new byte[4];
            fs.Read(b, 0, 4);
            return BitConverter.ToSingle(b, 0);
        }
        public static bool LoadBool(FileStream fs)
        {
            byte[] b = new byte[1];
            fs.Read(b, 0, 1);
            return BitConverter.ToBoolean(b, 0);
        }

        public static string LoadString(FileStream fs)
        {
            int l = LoadInt(fs);
            byte[] b = new byte[l];
            fs.Read(b, 0, l);

            return Encoding.UTF32.GetString(b);
        }
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
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.Cancel) konec = true;
            
            if (!konec) NactiRadky(sp);
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

        public void Vycisti()
        {
            if (sr != null) sr.Close();
            if (sr != null) sr.Dispose();
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
                if (indexRadku == 0) sp.dalsiRadky.Add("12345678901234567890123456789012345678901234567890123456789012345678901234567 1234567<---77 a 7 znaků");
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
        public void Vycisti()
        {

        }
    }
    public class LekceVyberuVet : ILekce
    {
        System.IO.StreamReader sr;
        bool konec = false;
        List<long> PoziceVet = new List<long>();
        List<int> Delky = new List<int>();
        Random R = new Random();

        public void ZahajLekci(StavPsani sp)
        {
            bool vybrano = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileOk += (s, e) => { sr = new StreamReader(ofd.FileName); vybrano = true; };
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.Cancel) konec = true;

            NactiPoziceVet();
            if (!konec) NactiRadky(sp);
        }
        public void AktualizujLekci(StavPsani sp)
        {
            NactiRadky(sp);
        }
        void NactiRadky(StavPsani sp)
        {
            while (sp.dalsiRadky.Count < 6)
            {
                int index = R.Next(0, PoziceVet.Count);
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(PoziceVet[index], SeekOrigin.Begin);

               string s = "";
                char[] c = new char[Delky[index]];
                sr.ReadBlock(c, 0, c.Length);
                s = new string(c);
                if (s != "") sp.dalsiRadky.Add(s);
            }
        }
        void NactiPoziceVet()
        {
            int c = -1;
            PoziceVet.Add(sr.GetActualPosition());
            bool konecVety = false;
            int p = 0;

            for (int j = 0; !sr.EndOfStream; j++)
            {
                c = sr.Peek();
                if (!konecVety) p++;
                // . ? !
                if (konecVety && c > 33 && c != 46 && c != 63 && c != 13)
                {
                    konecVety = false;
                    PoziceVet.Add(sr.GetActualPosition());
                    c = sr.Read();
                    p++;
                }
                else if (c == 46 || c == 63 || c <= 31 || c == 33)
                {
                    if (c < 32) p--;
                    konecVety = true;
                    if (p == 0) ;
                    else if (p != -1) Delky.Add(p);
                    
                    c = sr.Read();
                    p = 0;
                }
                else sr.Read();
            }
        }

        public void Vycisti()
        {
            sr.Close();
            sr.Dispose();
            PoziceVet = null;
            Delky = null;
        }
    }

    public class SoundOut : ISampleProvider, IDisposable
    {
        public List<ISampleProvider> providers;
        public WaveOut outputDevice;
        public int pos = 0;
        public List<Tuple<float[], int>> instSamples;

        public SoundOut()
        {
            outputDevice = new WaveOut();
            outputDevice.Init(this);
            providers = new List<ISampleProvider>();
        }

        public void Play()
        {
            outputDevice.Play();
        }

        public void Stop()
        {
            outputDevice.Stop();
        }

        public void Dispose()
        {
            outputDevice.Stop();
            outputDevice.Dispose();
        }

        public WaveFormat WaveFormat
        {
            get
            {
                return WaveFormat.CreateIeeeFloatWaveFormat(48000, 1);
            }
        }
        public int Read(float[] buffer, int offset, int count)
        {
            float[] secodaryBuffer = new float[count];
            Array.Clear(buffer, 0, buffer.Length);
            foreach (ISampleProvider provider in providers)
            {
                Array.Clear(secodaryBuffer, 0, count);
                int r = provider.Read(secodaryBuffer, offset, count);
                for (int i = 0; i < r; i++) buffer[i] += secodaryBuffer[i];
            }
            pos += count;
            return count;
        }
    }

    public class ZrychlovacHudby : ISampleProvider
    {
        NAudio.Wave.SampleProviders.WdlResamplingSampleProvider res;
        NAudio.Wave.SampleProviders.SmbPitchShiftingSampleProvider ptc;
        AudioFileReader afr;
        NAudio.Wave.SampleProviders.StereoToMonoSampleProvider stm;

        public ZrychlovacHudby(string s)
        {
            afr = new AudioFileReader(s);
            if (afr.WaveFormat.Channels == 2)
            {
                stm = new NAudio.Wave.SampleProviders.StereoToMonoSampleProvider(afr);
                ptc = new NAudio.Wave.SampleProviders.SmbPitchShiftingSampleProvider(stm);
            }
            else
            {
                stm = null;
                ptc = new NAudio.Wave.SampleProviders.SmbPitchShiftingSampleProvider(afr);
            }
            res = new NAudio.Wave.SampleProviders.WdlResamplingSampleProvider(ptc, 48000);
        }

        public WaveFormat WaveFormat => WaveFormat.CreateIeeeFloatWaveFormat(48000, 1);

        public void NastavRychlost(float rel)
        {
            ptc.PitchFactor = 1f / rel;
            res = new NAudio.Wave.SampleProviders.WdlResamplingSampleProvider(ptc, (int)(48000 / rel));
        }

        public int Read(float[] buffer, int offset, int count)
        {
            return res.Read(buffer, 0, buffer.Length);
        }
    }

    //йцукенгшщзхъ - фывапролджэ - ячсмитьбю


    public static class StreamExt
        {
        public static long GetActualPosition(this StreamReader reader)
    {
        System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField;

        // The current buffer of decoded characters
        char[] charBuffer = (char[])reader.GetType().InvokeMember("charBuffer", flags, null, reader, null);

        // The index of the next char to be read from charBuffer
        int charPos = (int)reader.GetType().InvokeMember("charPos", flags, null, reader, null);

        // The number of decoded chars presently used in charBuffer
        int charLen = (int)reader.GetType().InvokeMember("charLen", flags, null, reader, null);

        // The current buffer of read bytes (byteBuffer.Length = 1024; this is critical).
        byte[] byteBuffer = (byte[])reader.GetType().InvokeMember("byteBuffer", flags, null, reader, null);

        // The number of bytes read while advancing reader.BaseStream.Position to (re)fill charBuffer
        int byteLen = (int)reader.GetType().InvokeMember("byteLen", flags, null, reader, null);

        // The number of bytes the remaining chars use in the original encoding.
        int numBytesLeft = reader.CurrentEncoding.GetByteCount(charBuffer, charPos, charLen - charPos);

        // For variable-byte encodings, deal with partial chars at the end of the buffer
        int numFragments = 0;
        if (byteLen > 0 && !reader.CurrentEncoding.IsSingleByte)
        {
            if (reader.CurrentEncoding.CodePage == 65001) // UTF-8
            {
                byte byteCountMask = 0;
                while ((byteBuffer[byteLen - numFragments - 1] >> 6) == 2) // if the byte is "10xx xxxx", it's a continuation-byte
                    byteCountMask |= (byte)(1 << ++numFragments); // count bytes & build the "complete char" mask
                if ((byteBuffer[byteLen - numFragments - 1] >> 6) == 3) // if the byte is "11xx xxxx", it starts a multi-byte char.
                    byteCountMask |= (byte)(1 << ++numFragments); // count bytes & build the "complete char" mask
                                                                  // see if we found as many bytes as the leading-byte says to expect
                if (numFragments > 1 && ((byteBuffer[byteLen - numFragments] >> 7 - numFragments) == byteCountMask))
                    numFragments = 0; // no partial-char in the byte-buffer to account for
            }
            else if (reader.CurrentEncoding.CodePage == 1200) // UTF-16LE
            {
                if (byteBuffer[byteLen - 1] >= 0xd8) // high-surrogate
                    numFragments = 2; // account for the partial character
            }
            else if (reader.CurrentEncoding.CodePage == 1201) // UTF-16BE
            {
                if (byteBuffer[byteLen - 2] >= 0xd8) // high-surrogate
                    numFragments = 2; // account for the partial character
            }
        }
        return reader.BaseStream.Position - numBytesLeft - numFragments;
    }
}
}
