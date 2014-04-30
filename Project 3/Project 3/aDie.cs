using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;

namespace Project_3
{
   public class aDie : Random//subclass that simulates a die. Uses Random as a base class.
    {
       private const int one = 1;//Privatly stores the lowest value for a dice roll;
       private const int seven = 7;//Privatly stores the highest value for a dice roll

       static Random diceRoll = new Random();//Creates a new random number generator with the specified seed.
       
       /// <summary>
       /// Method to roll a die. Returns the value as an int.
       /// </summary>
       /// <returns></returns>
       public int Roll()
       {
           
           int rollValue = diceRoll.Next(one, seven);//Rolls the dice, producing an integer between 1 and 6.
           //MessageBox.Show(Convert.ToString(rollValue));
           return rollValue;//returns the dices value

       }
    }
}
