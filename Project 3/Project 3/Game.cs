using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    class Game
    {
        public int target;
        public bool outcome;

        aDie Dice1;
        aDie Dice2;



        public void game()
        {
            
            int sum = Dice1.Roll() + Dice2.Roll();

            if (sum == 7 || sum == 11)
                outcome = true;
            else if (sum == 2 || sum == 3 || sum == 12)
                outcome = false;
            else
            {
                target = sum;

                while (true)
                {
                    sum = Dice1.Roll() + Dice2.Roll();

                    if (sum == 7)
                    {
                        outcome = false;
                        break;
                    }
                    else if (sum == target)
                    {
                        outcome = true;
                        break;
                    }
                }
            }
        }

    }
}
