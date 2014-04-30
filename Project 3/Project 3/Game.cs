using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3
{
    class Game
    {
        private System.Object lock1 = new System.Object();
        private System.Object lock2 = new System.Object();
        private System.Object lock3 = new System.Object();
        private System.Object lock4 = new System.Object();

        public int target;//Stores the targent value for subsequent rolls.
        public bool outcome;//Stores if the game was a win or a loss.
        public int seed;

        aDie Dice1 = new aDie();
        aDie Dice2 = new aDie();


       public List<Roll> roll = new List<Roll>();//contains a list of rolls. 
       public List<int> rollTotal = new List<int>();//contains a list of the roll totals.

        /// <summary>
        /// Method to play 1 game of craps. 
        /// </summary>
        public void game()
        {

            Roll firstRoll = new Roll();//stores the first roll.

            lock (lock1)
            {
                firstRoll.roll1 = Dice1.Roll();
            }
            lock (lock2)
            {
                firstRoll.roll2 = Dice2.Roll();
            }

            int sum = firstRoll.roll1 + firstRoll.roll2;

            roll.Add(firstRoll);
            rollTotal.Add(sum);
            

            if (sum == 7 || sum == 11)//If the first roll is 7 or 11, the player wins
                outcome = true;
            else if (sum == 2 || sum == 3 || sum == 12)//if the first roll is 2, 3, or 12, the player loses
                outcome = false;
            else//if the first roll is not any of the above values, the first roll is set as the target for all subsequent rolls
            {
                target = sum;

                while (true)//loop will run untill either the player rolls 7 or the target.
                {
                    Roll newRoll = new Roll();//creates a new roll.
                    lock (lock3)
                    {
                        newRoll.roll1 = Dice1.Roll();
                    }
                    lock (lock4)
                    {
                        newRoll.roll2 = Dice2.Roll();
                    }
                    sum = newRoll.roll1 + newRoll.roll2;//stores the sum of the dice.
                    //MessageBox.Show(Convert.ToString(sum));

                    roll.Add(newRoll);//adds the roll to roll list.
                    rollTotal.Add(sum);//adds the sum to total list.

                    if (sum == 7)//if the player rolls 7, they lose.
                    {
                        outcome = false;
                        break;
                    }
                    else if (sum == target)//if the player rolls the target, they win.
                    {
                        outcome = true;
                        break;
                    }
                }
            }
        }

    }
}
