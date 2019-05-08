using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roulette
{
    public partial class Form1 : Form
    {
        int number;
        int betnumber;
        string color;
        string betcolor;
        int money = 500;
        int betmoney;
        bool choose = false;
        bool choose2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRoll_It_Click(object sender, EventArgs e)
        {

            Random rand = new Random();
            number = rand.Next(0, 37);

            if (number == 0)
            {
                color = "Green";
            }

            else
            {
                if (number % 2 != 0 && number > 10 && number < 18 || number > 28 && number < 36)
                {
                    color = "Black";
                }


                else
                {

                    if (number % 2 != 0 && number < 11 || number > 17 || number > 29)
                    {
                        color = "Black";
                    }


                    else
                    {
                        color = "Red";
                    }
                }
            }

            textBoxRolled.Text = number.ToString();

            if (color == "Black")
            {
                textBoxRolled.ForeColor = Color.Beige;
                textBoxRolled.BackColor = Color.Black;
            }
            else
            {
                if (color == "Red")
                {
                    textBoxRolled.ForeColor = Color.Beige;
                    textBoxRolled.BackColor = Color.Red;
                }
                else
                {
                    textBoxRolled.ForeColor = Color.Beige;
                    textBoxRolled.BackColor = Color.Green;
                }
            }

            if (choose == true)
            {
                if (betnumber == number)
                {
                    textBox2.Text = "Výhra";
                    money = money + (betmoney * 35);
                    textBoxMoney.Text = Convert.ToString(money);
                    betmoney = 0;
                    textBoxBet.Text = Convert.ToString(betmoney);
                }

                else
                {
                    textBox2.Text = "Prohra";
                    betmoney = 0;
                    textBoxBet.Text = Convert.ToString(betmoney);
                }
            }

            if (choose2 == true)
            {
                if (betcolor == color)
                {
                    textBox2.Text = "Výhra";
                    money = money + (betmoney * 2);
                    textBoxMoney.Text = Convert.ToString(money);
                    betmoney = 0;
                    textBoxBet.Text = Convert.ToString(betmoney);
                }

                else
                {
                    textBox2.Text = "Prohra";
                    betmoney = 0;
                    textBoxBet.Text = Convert.ToString(betmoney);
                }
            }

            //Kontrolní MSG box. AKA Neposral jsem něco?
            //MessageBox.Show("Rolled number " + number + ", color " +color);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            betnumber = Convert.ToInt32(((Button)sender).Text);
            textBox1.Text = Convert.ToString(betnumber);
            money = money - 10;
            betmoney = betmoney + 10;
            textBoxMoney.Text = Convert.ToString(money);
            textBoxBet.Text = Convert.ToString(betmoney);
            choose = true;
            choose2 = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            betcolor = (((Button)sender).Text);
            textBox1.Text = betcolor;
            money = money - 10;
            betmoney = betmoney + 10;
            textBoxMoney.Text = Convert.ToString(money);
            textBoxBet.Text = Convert.ToString(betmoney);
            choose2 = true;
            choose = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
