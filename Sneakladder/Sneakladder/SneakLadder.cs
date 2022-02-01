using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneakladder
{
     class SneakLadder
    {
        //Instance Variable
        public int player;
        public const int noPlay = 0;
        public const int snake = 1;
        public const int ladder = 2;
        public int trials = 0;
        public string nxtMove;

        Random random = new Random();
        //Method or function create
        public int PlayGame()               
        {
            while (player < 100)
            {
                int diceCount = random.Next(1, 7);          //Counting dice number from 1 to 6
                int option = random.Next(0, 3);             //0 for noplay, 1 for snake, 2 for ladder
                switch (option)
                {
                    case noPlay: nxtMove = "No Move"; break;
                    case snake:
                        if (player > 0)
                        {
                            nxtMove = "Snake";
                            if ((player - diceCount) < 0)        //player position less than zero then 0th position
                            {
                                player = 0;
                            }
                            else
                                player -= diceCount;          //snake then subtract dice number from original position
                        }
                        break;
                    case ladder:
                        nxtMove = "Ladder";
                        if (player + diceCount <= 100)           //Ladder and less than 100 then add the dice number in original position
                            player += diceCount;
                        break;
                }
                trials++;                                   //increment trials untill one gets win
                Console.WriteLine("trial:" + trials + " Dice Count: " + diceCount + " option: " + option + " next move:" + nxtMove + " Player Score: " + player);
            }
            return trials;                  //print how many trials attempted
        }
        static void Main(string[] args)         //main function or method
        {
            SneakLadder gamePlay1 = new SneakLadder();      //object created
            int player1Trials = gamePlay1.PlayGame();         //calling function

            SneakLadder gamePlay2 = new SneakLadder();      //object created
            int player2Trials = gamePlay2.PlayGame();         //Called function 

            if (player1Trials < player2Trials)                 //condition to decide who win the game
                Console.WriteLine("Player1: " + player1Trials + " Player2: " + player2Trials + "\n Player1 is winner!!!");
            else if (player1Trials > player2Trials)
                Console.WriteLine("Player1: " + player1Trials + " Player2: " + player2Trials + "\n Player2 is winner!!!");
            else
                Console.WriteLine("Its a Tie");
            Console.ReadLine();
        }
    }
}
