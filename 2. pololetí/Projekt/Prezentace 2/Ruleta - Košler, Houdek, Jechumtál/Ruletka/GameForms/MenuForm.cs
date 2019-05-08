using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruletka.GameForms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            buttonHelp.MouseEnter += OnMouseEnterButtonHelp;
            buttonHelp.MouseLeave += OnMouseLeaveButtonHelp;

            

            
        }
       

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangeLang_Click(object sender, EventArgs e)
        {/*
            for (int timesClicked = 0; timesClicked < 3; timesClicked++)
            {
                Image image;
                switch (timesClicked)
                {
                    case 0:
                        image = Image.FromFile("1.png"); buttonChangeLang.Image = image;
                        break;
                    case 1:
                        image = Image.FromFile("2.jpg"); buttonChangeLang.Image = image;
                        break;
                    case 2:
                        image = Image.FromFile("3.jpg"); buttonChangeLang.Image = image;
                        break;

                } 
            }
            */
            /*if (timesClicked == 0)
            {
                Image image = Image.FromFile("1.jpg"); pictureBox1.Image = image;
            }
            else if (timesClicked == 1)
            {
                Image image = Image.FromFile("2.jpg"); pictureBox1.Image = image;
            }
            else if (timesClicked == 2)
            {
                Image image = Image.FromFile("3.jpg"); pictureBox1.Image = image;
            }
            else if (timesClicked == 3)
            {
                Image image = Image.FromFile("4.jpg"); pictureBox1.Image = image;
            }*/
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string targetURL = @"https://en.wikipedia.org/wiki/Roulette";
            System.Diagnostics.Process.Start(targetURL);
        }//presmeruje na wiki stranku s ruletou

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            Form gameModal = new NewGameModalForm();
            gameModal.ShowDialog(this);
        }

        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            Form gameModal = new LoadGameModalForm();
            gameModal.ShowDialog(this);
        }


        private void buttonCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }//ukonci aplikaci

        #region UI picoviny 
        private void OnMouseEnterButtonHelp(object sender, EventArgs e)
        {
            buttonHelp.ForeColor = Color.Red;          
        }
        private void OnMouseLeaveButtonHelp(object sender, EventArgs e)
        {
            buttonHelp.ForeColor = Color.Black;
        }
        #endregion
    }
}
