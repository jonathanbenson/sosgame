using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class SimpleGame : Game
    {
        /* 
         * A class to handle the logic associated with a simple game.
         * 
         * In a simple game, the first player to create a SOS wins the game.
         * If all the cells are filled and no SOS has been created, the game is a draw.
         * 
         */
        public SimpleGame(int boardSize, bool isBlueComputer, bool isRedComputer)
            : base(boardSize, isBlueComputer, isRedComputer)
        {
            
        }
    }
}
