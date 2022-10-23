using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class GeneralGame : Game
    {
        /* 
         * A class to handle the logic associated with a general game.
         * 
         * In a general game, the game ends once all the cells are filled.
         * The winner is the player with the most SOSs. If the number of SOSs is equal, the game is a draw.
         * If a user makes a SOS, then they get a extra turn.
         * 
         */
        
        public GeneralGame(int boardSize = 8, bool isBlueComputer = false, bool isRedComputer = false)
            : base(boardSize, isBlueComputer, isRedComputer)
        {

        }

        public override GameMode GetGameMode()
        {
            return GameMode.General;
        }
    }
}
