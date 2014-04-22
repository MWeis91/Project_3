using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
   public class aDie : Random//subclass that simulates a die. Uses Random as a base class.
    {
       public int seed;//Stores the seed for the random number generator.

       private const int one = 1;//Privatly stores the lowest value for a dice roll;
       private const int seven = 7;//Privatly stores the highest value for a dice roll;

       /// <summary>
       /// Method to roll a die. Returns the value as an int.
       /// </summary>
       /// <returns></returns>
       public int Roll()
       {
           Random diceRoll = new Random(seed);//Creates a new random number generator with the specified seed.
           int rollValue = diceRoll.Next(one, seven);//Rolls the dice, producing an integer between 1 and 6.

           return rollValue;//returns the dices value
       }
    }
}
