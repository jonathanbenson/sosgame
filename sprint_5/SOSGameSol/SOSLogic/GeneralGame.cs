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
        
        public GeneralGame(bool recordGame, int boardSize = 8, PlayerType bluePlayerType = PlayerType.Human, PlayerType redPlayerType = PlayerType.Human)
            : base(recordGame, boardSize, bluePlayerType, redPlayerType)
        {

        }

        public override GameMode GetGameMode()
        {
            return GameMode.General;
        }

        public override bool IsOver()
        {
            // If the board is full, the game is over
            return GetMoves().Count == (GetBoardSize() * GetBoardSize());
        }

        public override void NewTurn()
        {
            if (GetSOSLines().Count > 0)
            {
                SOSLine lastSOSLine = GetSOSLines().Last();
                Move lastMove = GetMoves().Last();

                // if the last move was a SOS, the player gets another turn
                if (lastSOSLine.HasMove(lastMove) && lastSOSLine.GetPlayer() == GetCurrentPlayer())
                    return;
            }

            SwitchTurns();
        }
    }
}
