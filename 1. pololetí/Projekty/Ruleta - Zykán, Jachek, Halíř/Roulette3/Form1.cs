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
        int money = 100;
        int betmoney;
        bool choose = false;
        bool choose2 = false;
        bool choose3 = false;
        bool choose4 = false;
        bool chooseOdd = false;
        bool chooseEven = false;


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
                if (number % 2 != 0 && number > 10 && number < 18)
                {
                    color = "Black";
                }

                else
                {

                    if (number % 2 != 0 && number > 28 && number < 36)
                    {
                        color = "Black";
                    }


                    else
                    {
                        if (number % 2 == 0 && number < 11)
                        {
                            color = "Black";
                        }
                        else
                        {
                            if (number % 2 == 0 && number > 18 && number < 29)
                            {
                                color = "Black";
                            }
                            else
                            {
                                color = "Red";
                            }
                        }
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
            if (choose3 == true)
            {
                if (number < 19)
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
            if (choose4 == true)
            {
                if (number > 18)
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
            if (chooseOdd == true)
            {
                if (number % 2 != 0)
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
            if (chooseEven == true)
            {
                if (number % 2 == 0)
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
            choose = true;
            choose2 = false;
            choose3 = false;
            choose4 = false;
            chooseOdd = false;
            chooseEven = false;
            //betmoney = 5;
            textBoxBet.Text = betmoney.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            betcolor = (((Button)sender).Text);
            textBox1.Text = betcolor;
            choose = false;
            choose2 = true;
            choose3 = false;
            choose4 = false;
            chooseOdd = false;
            chooseEven = false;
            //betmoney = 5;
            textBoxBet.Text = betmoney.ToString();
        }

        private void textBoxMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void buttonOdd_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Odd";
            choose = false;
            choose2 = false;
            choose3 = false;
            choose4 = false;
            chooseEven = false;
            chooseOdd = true;
            //betmoney = 5;
            textBoxBet.Text = betmoney.ToString();
        }

        private void buttonEven_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Even";
            choose = false;
            choose2 = false;
            choose3 = false;
            choose4 = false;
            chooseOdd = false;
            chooseEven = true;
            //betmoney = 5;
            textBoxBet.Text = betmoney.ToString();
        }

        private void buttonLower_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1-18";
            choose = false;
            choose2 = false;
            choose4 = false;
            chooseOdd = false;
            chooseEven = false;
            choose3 = true;
            //betmoney = 5;
            textBoxBet.Text = betmoney.ToString();
        }

        private void buttonHigher_Click(object sender, EventArgs e)
        {
            textBox1.Text = "19-36";
            choose = false;
            choose2 = false;
            choose3 = false;
            chooseOdd = false;
            chooseEven = false;
            choose4 = true;
            //betmoney = 5;
            textBoxBet.Text = betmoney.ToString();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (betmoney >= money)
            {
                MessageBox.Show("Bet too high");
                betmoney = money;
            }
            else
            {   betmoney ++;
                money = money - 1;
                textBoxMoney.Text = Convert.ToString(money);
                textBoxBet.Text = Convert.ToString(betmoney);
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (betmoney <=1)
            {
                MessageBox.Show("Bet has to be at least 1");
                betmoney = 1;
            }
            else
            {
                betmoney--;
                money = money + 1;
                textBoxMoney.Text = Convert.ToString(money);
                textBoxBet.Text = Convert.ToString(betmoney);
            }
        }

        private void buttonPlus10_Click(object sender, EventArgs e)
        {
            if (betmoney+10 > money)
            {
                MessageBox.Show("Bet increase too high");
            }
            else
            {
                betmoney+=10;
                money = money - 10;
                textBoxMoney.Text = Convert.ToString(money);
                textBoxBet.Text = Convert.ToString(betmoney);
            }

        }

        private void buttonMinus10_Click(object sender, EventArgs e)
        {
            if (betmoney-10 < 1)
            {

                MessageBox.Show("Bet decrease too high");
            }
            else
            {
                betmoney-=10;
                money = money + 10;
                textBoxMoney.Text = Convert.ToString(money);
                textBoxBet.Text = Convert.ToString(betmoney);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxMoney.Text = Convert.ToString(money);
            textBoxBet.Text = Convert.ToString(betmoney); 
        }

        
    }
}
