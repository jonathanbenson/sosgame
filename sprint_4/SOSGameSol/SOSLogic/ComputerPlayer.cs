using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace SOSLogic
{
    public class CoinFlip
    {
        public static bool IsHeads()
        {
            Random random = new Random();

            if (random.Next(0, 2) == 0)
                return true;
            else
                return false;
        }
    }

    public class ComputerPlayer : Player
    {
        /*
         * 
         * A class that handles the logic associated with a computer player
         * 
         * A computer player makes moves according to an algorithm.
         * 
         */
        public ComputerPlayer(Game game, Color color) : base(game, color)
        {
        }
        public override PlayerType GetPlayerType()
        {
            return PlayerType.Computer;
        }

        public override void MakeMove(int row = -1, int col = -1)
        {
            if (game.GetGameMode() == GameMode.Simple)
                MakeSimpleMove(CoinFlip.IsHeads(), CoinFlip.IsHeads());
            else if (game.GetGameMode() == GameMode.General)
                MakeGeneralMove(CoinFlip.IsHeads());
        }

        private void MakeSimpleMove(bool firstCoinFlip, bool secondCoinFlip)
        {
            List<Move> possibleSOSMoves = game.GetSOSOpportunities();

            if (possibleSOSMoves.Count > 0 && firstCoinFlip && secondCoinFlip)
                MakeRandomSOSMove(possibleSOSMoves);
            else
                MakeRandomMove();
        }

        private void MakeGeneralMove(bool coinFlip)
        {
            List<Move> possibleSOSMoves = game.GetSOSOpportunities();

            Debug.WriteLine("something");

            if (possibleSOSMoves.Count > 0 && coinFlip)
                MakeRandomSOSMove(possibleSOSMoves);
            else
                MakeRandomMove();
        }

        public void ChooseRandomMoveType()
        {
            // get the random move type
            MoveType randomMoveType = MoveType.S;

            if (CoinFlip.IsHeads())
                randomMoveType = MoveType.O;

            SetMoveType(randomMoveType);
        }

        private void MakeRandomMove()
        {
            // get a random empty cell to make the move on
            List<Cell> emptyCells = game.GetEmptyCells();

            Random random = new Random();

            int randomIndex = random.Next(emptyCells.Count);

            Cell randomEmptyCell = emptyCells[randomIndex];

            // make the random move
            Move move = new Move(this, GetMoveType(), randomEmptyCell.GetRow(), randomEmptyCell.GetCol());

            game.MakeMove(move);

        }

        private void MakeRandomSOSMove(List<Move> possibleSOSMoves)
        {
            Random random = new Random();

            int randomSOSMoveIndex = random.Next(possibleSOSMoves.Count);

            Move randomSOSMove = possibleSOSMoves[randomSOSMoveIndex];

            game.MakeMove(randomSOSMove);
        }
    }
}
