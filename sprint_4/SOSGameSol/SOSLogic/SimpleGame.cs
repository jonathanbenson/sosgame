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
        public SimpleGame(int boardSize = 8, PlayerType bluePlayerType = PlayerType.Human, PlayerType redPlayerType = PlayerType.Human)
            : base(boardSize, bluePlayerType, redPlayerType)
        {
            
        }


        public override bool IsOver()
        {
            // If there is at least one SOS line or the board is full, the game is over
            return GetSOSLines().Count > 0 || GetMoves().Count == (GetBoardSize() * GetBoardSize());
        }

        public override GameMode GetGameMode()
        {
            return GameMode.Simple;
        }

        public override void NewTurn()
        {
            SwitchTurns();
        }
    }
}
