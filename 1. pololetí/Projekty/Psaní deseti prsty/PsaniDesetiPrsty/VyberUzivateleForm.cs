using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PsaniDesetiPrsty
{
    public partial class VyberUzivateleForm : Form
    {
        public delegate void TextEvnetHandler(object sender, TextEventArgs e);
        public event TextEvnetHandler TextZadan;

        public VyberUzivateleForm()
        {
            InitializeComponent();
        }

        private void VyberUzivateleForm_Load(object sender, EventArgs e)
        {
            List<string> s = new List<string>();

            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
            FileInfo[] files = di.GetFiles("U_*.txt");

            foreach (FileInfo fi in files)
            {
                s.Add(fi.Name.Remove(fi.Name.Length - 4, 4).Remove(0, 2));
            }

            listBox1.DataSource = s;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            TextZadan?.Invoke(this, new TextEventArgs() { text = listBox1.SelectedItem as string });
        }
    }
}
