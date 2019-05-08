using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Ruletka.GameForms
{
    public partial class MenuForm : Form
    {
        private string lang = "cz-CZ";
        public MenuForm()
        {
            InitializeComponent();

            buttonHelp.MouseEnter += OnMouseEnterButtonHelp;
            buttonHelp.MouseLeave += OnMouseLeaveButtonHelp;

            ChangeLanguage(lang);
            ReloadTexts();
        }

        private void ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
        }

        private void ReloadTexts()
        {
            buttonNewGame.Text = strings.NewGame;
            buttonLoadGame.Text = strings.LoadGame;
            buttonCloseApp.Text = strings.ExitGame;
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            buttonChangeLang.BackgroundImage = Properties.Resources.vlajka1;
            ReloadTexts();
        }

        private Jazyky AktualniJazyk;
        enum Jazyky
        {
            Cestina,
            Ang
        }

        private int timesClicked;
        protected void buttonChangeLang_Click(object sender, EventArgs e)
        {
            switch (timesClicked)
            {
                case 0:
                    AktualniJazyk = Jazyky.Ang;
                    buttonChangeLang.BackgroundImage = Properties.Resources.vlajka2;
                    timesClicked++;
                    lang = "en-US";
                    break;
                case 1:
                    buttonChangeLang.BackgroundImage = Properties.Resources.vlajka3;
                    timesClicked++;
                    lang = "de-DE";
                    break;
                case 2:
                    buttonChangeLang.BackgroundImage = Properties.Resources.vlajka1;
                    timesClicked++;
                    lang = "cz-CZ";
                    break;

            }
            if (timesClicked > 2)
            {
                timesClicked = 0;
            }

            ChangeLanguage(lang);

            ReloadTexts();
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(strings.TargetURL); //wiki stranka s ruletou
        }
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            double newBalanceAmount = 2000;
            SaveFormatter.Save(0);
            GameForm gameForm = new GameForm(newBalanceAmount);
            gameForm.Show();
            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = this.Location;
            this.Hide();
        }
        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            double newBalanceAmount = SaveFormatter.Load();
            if (newBalanceAmount != 0)
            {
                GameForm gameForm = new GameForm(newBalanceAmount);
                gameForm.Show();
                gameForm.StartPosition = FormStartPosition.Manual;
                gameForm.Location = this.Location;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nepodařilo se načíst hru, prosím vytvořte novou.");
            }
        }
        private void buttonCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        #region UI zbytečnost

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
