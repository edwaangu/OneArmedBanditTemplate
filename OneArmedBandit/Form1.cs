using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OneArmedBandit
{
    public partial class Form1 : Form
    {
        // random number generator

        Random randGen = new Random();

        // int value for score initialized to 10

        int score = 10;
        int leftReel = 0;
        int midReel = 0;
        int rightReel = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void spinButton_Click(object sender, EventArgs e) 
        {
            // Go through a for loop of 50
            for (int i = 0; i < 50; i++)
            {

                // get random values for each reel (store each in separate int variable)
                leftReel = randGen.Next(1, 4);
                midReel = randGen.Next(1, 4);
                rightReel = randGen.Next(1, 4);

                // check value of reel 1 with a switch statement to set appropriate image to
                // BackgroundImage property of pictureBox. Get images from Properties.Resources
                switch (leftReel)
                {
                    case 1:
                        pictureBox1.BackgroundImage = Properties.Resources.cherry_100x125;
                        break;
                    case 2:
                        pictureBox1.BackgroundImage = Properties.Resources.diamond_100x125;
                        break;
                    case 3:
                        pictureBox1.BackgroundImage = Properties.Resources._7_100x125;
                        break;
                }

                // check value of reel 2 with a switch statement to set appropriate image to
                // BackgroundImage property of pictureBox. Get images from Properties.Resources
                switch (midReel)
                {
                    case 1:
                        pictureBox2.BackgroundImage = Properties.Resources.cherry_100x125;
                        break;
                    case 2:
                        pictureBox2.BackgroundImage = Properties.Resources.diamond_100x125;
                        break;
                    case 3:
                        pictureBox2.BackgroundImage = Properties.Resources._7_100x125;
                        break;
                }

                // check value of reel 3 with a switch statement to set appropriate image to
                // BackgroundImage property of pictureBox. Get images from Properties.Resources
                switch (rightReel)
                {
                    case 1:
                        pictureBox3.BackgroundImage = Properties.Resources.cherry_100x125;
                        break;
                    case 2:
                        pictureBox3.BackgroundImage = Properties.Resources.diamond_100x125;
                        break;
                    case 3:
                        pictureBox3.BackgroundImage = Properties.Resources._7_100x125;
                        break;
                }

                pictureBox1.Refresh();
                pictureBox2.Refresh();
                pictureBox3.Refresh();

                // Start the pause length at 20, and increase it by 8 each time (to get to 412ms)
                Thread.Sleep(20 + (i * 8));

            }

            /// STOP HERE ----------------------------------------------------------
            /// Test to make sure that your program will display random
            /// images to each reel. Only continue on after you know this works
            /// --------------------------------------------------------------------


            // Use compound if statement to check if all reels are equal. 
            // If yes show "winner" statement and add 3 to score.
            // If no show "play again" statement and subtract 1 from score.         
            if(leftReel == midReel && midReel == rightReel)
            {
                score += 3;
                outputLabel.Text = "Winner!";
            }
            else
            {
                score --;
                outputLabel.Text = "Play Again?";

            }

            // if score has reached 0 display "lose" message and set button enabled property to false
            if(score == 0)
            {
                outputLabel.Text = "Lose";
                spinButton.Enabled = false;
            }

            // display updated score
            scoreDisplay.Text = $"{score}";
        }
    }
}
