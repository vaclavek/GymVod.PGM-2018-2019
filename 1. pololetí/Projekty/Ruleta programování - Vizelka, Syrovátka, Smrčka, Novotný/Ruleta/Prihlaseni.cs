﻿using System;
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
    public partial class Prihlaseni : Form
    {
        public Prihlaseni()
        {
            InitializeComponent();
        }

        private void Prihlaseni_Load(object sender, EventArgs e)
        {
            //usazení aplikace do fullscreen okna
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FormLogin login = new FormLogin();
           login.ShowDialog();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.ShowDialog();
        }
    }
}
