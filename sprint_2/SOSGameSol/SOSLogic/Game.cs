using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSLogic
{
    public class Game
    {
        private Player bluePlayer, redPlayer, currentPlayer;
        
        private List<Move> moves;

        public Game()
        {
            bluePlayer = new Player(this, Color.Blue);
            redPlayer = new Player(this, Color.Red);

            currentPlayer = bluePlayer;
            
            moves = new List<Move>();
        }

        public void AddMove(Move move)
        {
            if (IsMoveValid(move))
            {
                moves.Add(move);
                SwitchTurns();
            }
            else
                throw new ArgumentException("Move is not valid");
        }

        public void SwitchTurns()
        {
            if (currentPlayer == bluePlayer)
                currentPlayer = redPlayer;
            else
                currentPlayer = bluePlayer;
        }

        public bool IsMoveValid(Move move)
        {
            foreach (Move previousMove in moves)
            {
                if (previousMove.DoesConflict(move))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRedTurn()
        {
            return currentPlayer == redPlayer;
        }

        public Player GetCurrentPlayer()
        {
            if (IsRedTurn())
                return redPlayer;
            else
                return bluePlayer;
        }

        public Player GetBluePlayer()
        {
            return bluePlayer;
        }

        public Player GetRedPlayer()
        {
            return redPlayer;
        }

        public List<Move> GetMoves()
        {
            return moves;
        }
    }
}
