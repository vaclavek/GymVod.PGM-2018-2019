using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ruletka.GameForms;


namespace Ruletka
{
    public partial class GameForm : Form
    {
        
        #region deklarace promennych
        private double balance;
        private double maxBet = 500; // maximalni sazka na cislo

        private int spinNumber;

        private double currentBetAmount; //definuje vysi pricitane sazky za click     

        private Random rand = new Random(); //vytvoreni instance syst. tridy Random, zatim nejlepsi zpusob rng
        private double win;

        private int[] red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36};

        private double redBet;
        private double blackBet;
        private double evenBet;
        private double oddBet;
        private double lowerBet;
        private double higherBet;
        private double zeroBet;
        #endregion

        #region nacteni formulare a promennych FormAlpha()
        public GameForm(double balance)
        {
            InitializeComponent();
            labelRolledNumber.Text = "";

            this.balance = balance;
        }
        private void ReloadTexts()
        {
            labelRolledNum.Text = strings.RolledNumber + ":";
            buttonLower.Text = strings.LowerBet;
            buttonRaise.Text = strings.RaiseBet;
            buttonSpin.Text = strings.Spin;
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            Labels_Refresh();  
            ReloadTexts();
        }
        #endregion
        private void buttonSpin_Click(object sender, EventArgs e)
        { 
            if (redBet > 0 || blackBet > 0 || evenBet > 0 || oddBet > 0 || lowerBet > 0 || higherBet > 0 || zeroBet > 0)
            {
                spinNumber = rand.Next(0, 37);//strop je vzdycky +1
                LastRolledNumber();
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
                string BetErr = strings.BetError;
                MessageBox.Show(BetErr);
            }
            SetAllToZero();
            Labels_Refresh();
            SaveFormatter.Save(balance);
        }
        
        private void buttonRaise_Click(object sender, EventArgs e)
        {
            currentBetAmount = GetBetAmount();
            if (radioButtonRed.Checked)
                SetBetHigher(currentBetAmount, ref redBet);
            else if (radioButtonBlack.Checked)
                SetBetHigher(currentBetAmount, ref blackBet);
            else if (radioButtonEven.Checked)
                SetBetHigher(currentBetAmount, ref evenBet);
            else if (radioButtonOdd.Checked)
                SetBetHigher(currentBetAmount, ref oddBet);
            else if (radioButtonLower.Checked)
                SetBetHigher(currentBetAmount, ref lowerBet);
            else if (radioButtonHigh.Checked)
                SetBetHigher(currentBetAmount, ref higherBet);
            else if (radioButtonZero.Checked)
                SetBetHigher(currentBetAmount, ref zeroBet);
            Labels_Refresh();
        }
        
        private void buttonLower_Click(object sender, EventArgs e)
        {
            currentBetAmount = GetBetAmount();
            if (radioButtonRed.Checked)
                SetBetLower(currentBetAmount, ref redBet);
            else if (radioButtonBlack.Checked)
                SetBetLower(currentBetAmount, ref blackBet);
            else if (radioButtonEven.Checked)
                SetBetLower(currentBetAmount, ref evenBet);
            else if (radioButtonOdd.Checked)
                SetBetLower(currentBetAmount, ref oddBet);
            else if (radioButtonLower.Checked)
                SetBetLower(currentBetAmount, ref lowerBet);
            else if (radioButtonHigh.Checked)
                SetBetLower(currentBetAmount, ref higherBet);
            else if (radioButtonZero.Checked)
                SetBetLower(currentBetAmount, ref zeroBet);
            Labels_Refresh();
        }

        #region pomocne metody
        private void SetBetHigher(double currentBetAmount, ref double currentBetNumber)
        {
            if (balance > 0 && balance >= currentBetAmount && currentBetNumber <= (maxBet - currentBetAmount))
            {
                currentBetNumber += currentBetAmount;
                balance -= currentBetAmount;
            }
        }
        private void SetBetLower(double currentBetAmount, ref double currentBetNumber)
        {
            if ((currentBetNumber - currentBetAmount) >= 0)
            {
                currentBetNumber -= currentBetAmount;
                balance += currentBetAmount;
            }
        }
        private static bool IsWithin(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
        private void SetAllToZero()
        {
            blackBet = 0; redBet = 0; evenBet = 0; oddBet = 0; lowerBet = 0; higherBet = 0; zeroBet = 0; win = 0;
        }
        private double currentGetBetAmount;
        private double GetBetAmount()
        {
            //urcuje podle radiobuttonu vyssi sazky
            if (radioButton1.Checked)
                currentGetBetAmount = double.Parse(radioButton1.Text);  
            else if (radioButton2.Checked)
                currentGetBetAmount = double.Parse(radioButton2.Text); 
            else if (radioButton3.Checked) 
                currentGetBetAmount = double.Parse(radioButton3.Text);  
            else if (radioButton4.Checked)
                currentGetBetAmount = double.Parse(radioButton4.Text);    
            else if (radioButton5.Checked)
                currentGetBetAmount = double.Parse(radioButton5.Text);
            return currentGetBetAmount;
        }
        private void Labels_Refresh()
        {
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
        private void LastRolledNumber()
        {
            labelRolledNumber.Text = spinNumber.ToString();
            if (spinNumber == 0)
                labelRolledNumber.BackColor = Color.Green;
            else if (red.Contains(spinNumber))
                labelRolledNumber.BackColor = Color.Red;
            else
            {
                labelRolledNumber.BackColor = Color.Black;
            }
        }
        #endregion
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            FormManager.MainMenu.Show();
            FormManager.MainMenu.Location = this.Location;
            this.Close();
        } 
    }
}
