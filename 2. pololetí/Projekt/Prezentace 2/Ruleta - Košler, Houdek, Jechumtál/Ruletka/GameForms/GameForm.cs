using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruletka
{
    public partial class GameForm : Form
    {
        #region deklarace promennych
        double currentBetAmountInternal; // sazka za kolo pouzita v metode BetAmount(), sry za ruinovani OOP :(

        double balance = 125; //nemeckych eury
        double maxBet = 500; // maximalni sazka na cislo

        double currentBetAmount; //definuje vysi pricitane sazky za click     

        Random rand = new Random(); //vytvoreni instance syst. tridy Random, zatim nejlepsi zpusob rng
        double win;

        int[] red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36};

        
        double redBet;
        double blackBet;
        double evenBet;
        double oddBet;
        double lowerBet;
        double higherBet;
        double zeroBet;
        #endregion

        #region nacteni formulare a promennych FormAlpha()
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            Labels_Refresh(); //custom trida abych nemusel porad kopirovat, nutnost updatu pri nacteni formulare
        }
        #endregion

        private void buttonSpin_Click(object sender, EventArgs e)
        {

            //jen testuju, si nevsimejte
            if (redBet > 0 || blackBet > 0 || evenBet > 0 || oddBet > 0 || lowerBet > 0 || higherBet > 0 || zeroBet > 0)
            {
                int spinNumber = rand.Next(0, 37);//strop je vzdycky +1
                if (spinNumber != 0)
                {
                    if (lowerBet > 0 && IsWithin(spinNumber, 1, 18))//lower
                    {
                        win += lowerBet * 2;
                    }
                    else if (higherBet > 0 && IsWithin(spinNumber, 19, 36))//higher
                    {
                        win += higherBet * 2;
                    }
                    else if (evenBet > 0 && (spinNumber % 2) == 0)//even
                    {
                        win += evenBet * 2;
                    }
                    else if (oddBet > 0 && (spinNumber % 2) != 0)//odd
                    {
                        win += oddBet * 2;
                    }
                    else if (redBet > 0 && red.Contains(spinNumber))//red
                    {
                        win += redBet * 2;
                    }
                    else if (blackBet > 0 && !(red.Contains(spinNumber)))//black
                    {
                        win += blackBet * 2;
                    }
                }
                else if (zeroBet > 0)//je nula
                {
                    win += zeroBet * 36;
                }
                balance += win;
            }
            else
            {
                MessageBox.Show("Nejdřív musíš vsadit");
            }
            SetAllToZero();
            Labels_Refresh();
        }
        private void SetBetHigher(double currentBetAmount, ref double currentBetNumber)
        {
            if (balance > 0 && balance >= currentBetAmount && currentBetNumber <= (maxBet - currentBetAmount))
            {
                currentBetNumber += currentBetAmount;
                balance -= currentBetAmount;
            }
        }
        private void buttonRaise_Click(object sender, EventArgs e)
        {
            currentBetAmount = GetBetAmount();
            if (radioButton6.Checked == true)
                SetBetHigher(currentBetAmount, ref redBet);
            else if (radioButton7.Checked == true)
                SetBetHigher(currentBetAmount, ref blackBet);
            else if (radioButton8.Checked == true)
                SetBetHigher(currentBetAmount, ref evenBet);
            else if (radioButton9.Checked == true)
                SetBetHigher(currentBetAmount, ref oddBet);
            else if (radioButton10.Checked == true)
                SetBetHigher(currentBetAmount, ref lowerBet);
            else if (radioButton11.Checked == true)
                SetBetHigher(currentBetAmount, ref higherBet);
            else if (radioButton12.Checked == true)
                SetBetHigher(currentBetAmount, ref zeroBet);
            Labels_Refresh();
        }
        private void SetBetLower(double currentBetAmount, ref double currentBetNumber)
        {
            if ((currentBetNumber - currentBetAmount) >= 0)
            {
                currentBetNumber -= currentBetAmount;
                balance += currentBetAmount;
            }
        }
        private void buttonLower_Click(object sender, EventArgs e)
        {
            currentBetAmount = GetBetAmount();
            if (radioButton6.Checked == true)
                SetBetLower(currentBetAmount, ref redBet);
            else if (radioButton7.Checked == true)
                SetBetLower(currentBetAmount, ref blackBet);
            else if (radioButton8.Checked == true)
                SetBetLower(currentBetAmount, ref evenBet);
            else if (radioButton9.Checked == true)
                SetBetLower(currentBetAmount, ref oddBet);
            else if (radioButton10.Checked == true)
                SetBetLower(currentBetAmount, ref lowerBet);
            else if (radioButton11.Checked == true)
                SetBetLower(currentBetAmount, ref higherBet);
            else if (radioButton12.Checked == true)
                SetBetLower(currentBetAmount, ref zeroBet);
            Labels_Refresh();
        }

        #region pomocne metody pro zprehledneni kodu zde
        //pod timto jsou pomocne tridy, aby i houdis chapal co se deje
        private static bool IsWithin(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
        private void SetAllToZero()
        {
            blackBet = 0; redBet = 0; evenBet = 0; oddBet = 0; lowerBet = 0; higherBet = 0; zeroBet = 0; win = 0;
        }
        
        private double GetBetAmount()
        {
            
            //urcuje podle radiobuttonu vyssi sazky
            if (radioButton1.Checked == true)
                currentBetAmountInternal = double.Parse(radioButton1.Text);
            else if (radioButton2.Checked == true)
                currentBetAmountInternal = double.Parse(radioButton2.Text);
            else if (radioButton3.Checked == true)
                currentBetAmountInternal = double.Parse(radioButton3.Text);
            else if (radioButton4.Checked == true)
                currentBetAmountInternal = double.Parse(radioButton4.Text);
            else if (radioButton5.Checked == true)
                currentBetAmountInternal = double.Parse(radioButton5.Text);
            return currentBetAmountInternal;
        }
        private void Labels_Refresh()
        {
            //slouzi k updatovani labelu na zustatek a sazku (nebo jakychkoliv jinych :*)
            string dollarSign = " $";
            labelBalance.Text = balance.ToString() + dollarSign;
            labelRED.Text = redBet.ToString();
            labelBLACK.Text = blackBet.ToString();
            labelEVEN.Text = evenBet.ToString();
            labelODD.Text = oddBet.ToString();
            labelLOWER.Text = lowerBet.ToString();
            labelHIGHER.Text = higherBet.ToString();
            labelZERO.Text = zeroBet.ToString();
        }


        #endregion

       
    }
}
