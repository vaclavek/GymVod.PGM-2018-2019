using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormPouzitiKnihovny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPozdrav_Click(object sender, EventArgs e)
        {
            MojeKnihovna.Pozdravy pozdravy = new MojeKnihovna.Pozdravy();
            pozdravy.RekniAhoj(txtJazyk.Text);
        }
    }
}
