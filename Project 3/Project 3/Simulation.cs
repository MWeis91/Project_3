using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    class Simulation//class that simulates 10,000 games of craps
    {
        public List<Game> Games = new List<Game>();//list to store 10k games
        public int seed;

       public void run()
       {
           for (int i = 0; i < 10000; i++)
           {
               Game newGame = new Game();
               newGame.seed = seed;
               newGame.game();
               Games.Add(newGame);
           }
       }


        
    }
}
