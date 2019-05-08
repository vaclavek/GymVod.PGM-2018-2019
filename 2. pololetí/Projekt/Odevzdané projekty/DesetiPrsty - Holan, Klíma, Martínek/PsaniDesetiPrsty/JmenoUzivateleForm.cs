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
    public partial class JmenoUzivateleForm : Form
    {
        public delegate void TextEvnetHandler(object sender, TextEventArgs e);
        public event TextEvnetHandler TextZadan;

        public JmenoUzivateleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextZadan?.Invoke(this, new TextEventArgs() { text = textBox1.Text });
        }
    }

    public class TextEventArgs : EventArgs
    {
        public string text;
    }
}
