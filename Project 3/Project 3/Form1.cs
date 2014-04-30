using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3
{
    public partial class Form1 : Form
    {
        Simulation game;
        int[] count;
        int[] winloss;
        int seed;
        Random randseed = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        public void runGame()
        {
            if (Seed.Text != "")
                seed = Convert.ToInt32(Seed.Text);
            else
                seed = randseed.Next();

            game = new Simulation();

            game.run();
        }

        public void getData()
        {
            count = new int[11];
            winloss = new int[2];

            foreach( Game x in game.Games)
            {
                if (x.outcome == true)
                    winloss[0]++;
                else
                    winloss[1]++;

                foreach (int rollT in x.rollTotal)
                {
                    if (rollT == 2)
                        count[0]++;
                    else if (rollT == 3)
                        count[1]++;
                    else if (rollT == 4)
                        count[2]++;
                    else if (rollT == 5)
                        count[3]++;
                    else if (rollT == 6)
                        count[4]++;
                    else if (rollT == 7)
                        count[5]++;
                    else if (rollT == 8)
                        count[6]++;
                    else if (rollT == 9)
                        count[7]++;
                    else if (rollT == 10)
                        count[8]++;
                    else if (rollT == 11)
                        count[9]++;
                    else
                        count[10]++;
                }
            }
            label4.Text = Convert.ToString(winloss[0]);
            label5.Text = Convert.ToString(winloss[1]);


        }

        private void bindData()
        {
            chart1.Series["Series1"].Points.Clear();

            for(int i = 0; i < 11; i++)
            {
                this.chart1.Series["Series1"].Points.AddXY((i + 2), count[i]);
            }
        }

        private void display()
        {
            int i = 1;
            foreach(Game x in game.Games)
            {
                if (i == 6)
                    break;
                else
                {
                    int prev = -1;
                    int b = 0;
                    MessageBox.Show("GAME " + i);
                    foreach (Roll a in x.roll)
                    {   
                        string result = "User rolls a " + a.roll1 + " and " + a.roll2 + " for a total of " + (a.roll1 + a.roll2) + ".";
                        MessageBox.Show(result);
                        if(b == 0 && ((a.roll1 + a.roll2) == 7 || (a.roll1 + a.roll2) == 11))
                            MessageBox.Show("You Win!");
                        else  if(b == 0 && ((a.roll1 + a.roll2) == 2 || (a.roll1 + a.roll2) == 3 || (a.roll1 + a.roll2) == 12))
                            MessageBox.Show("You Lose!");
                        else if (b != 0 && (a.roll1 + a.roll2) == 7)
                            MessageBox.Show("You lose!");
                        else if( prev == (a.roll1 + a.roll2))
                            MessageBox.Show("You Win!");
                        else if(b == 0)
                            prev = a.roll1 + a.roll2;
                        b++;
                    }
                    i++;
                }

            }

            if( winloss[0] >= winloss[1])
                MessageBox.Show("You Should play this game!");
            else
                MessageBox.Show("You Should not play this game!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            runGame();
            getData();
            bindData();
            display();
        }
    }
}
