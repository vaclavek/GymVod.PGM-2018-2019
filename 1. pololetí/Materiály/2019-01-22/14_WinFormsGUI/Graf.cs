using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Graf : Form
    {
        public string Username { get; set; }

        public Graf()
        {
            InitializeComponent();
        }

        public void SetPassword(string password)
        {
        }

        private void Graf_Load(object sender, EventArgs e)
        {
        }

        public void PredejUdajeAZobraz(string username, string password)
        {
            lblUsername.Text = username;
            lblPassword.Text = password;
            ShowDialog();
        }
    }
}
