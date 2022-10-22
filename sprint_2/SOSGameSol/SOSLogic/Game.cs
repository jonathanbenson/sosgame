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
        private int boardSize;
        
        private Player bluePlayer, redPlayer, currentPlayer;
        
        private List<Move> moves;
        private List<SOSLine> sosLines;

        public Game(int boardSize)
        {
            this.boardSize = boardSize;
            
            bluePlayer = new Player(this, Color.Blue);
            redPlayer = new Player(this, Color.Red);

            currentPlayer = bluePlayer;
            
            moves = new List<Move>();
            sosLines = new List<SOSLine>();
        }
        
        public void MakeMove(Move move)
        {
            if (IsMoveValid(move))
            {
                CheckSOS(move);
                moves.Add(move);
                SwitchTurns();
            }
            else
                throw new ArgumentException("Move is not valid");
        }

        public void CheckSOS(Move lastMove)
        {
            List<List<Move?>> board = new List<List<Move?>>();

            for (int i = 0; i < boardSize; ++i)
            {
                board.Add(new List<Move?>());

                for (int j = 0; j < boardSize; ++j)
                {
                    board[i].Add(null);
                }
            }

            foreach (Move move in moves)
                board[move.GetRow()][move.GetCol()] = move;

            

            if (lastMove.GetMoveType() == MoveType.O)
            {
                // vertical line case
                try
                {
                    Move? s1 = board[lastMove.GetRow() - 1][lastMove.GetCol()];
                    Move? s2 = board[lastMove.GetRow() + 1][lastMove.GetCol()];

                    if (!(s1 is null) && !(s2 is null))
                    {
                        if (s1.GetMoveType() == MoveType.S && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), s1, lastMove, s2));
                            return;
                        }
                    }
                }
                catch (Exception exc)
                { }


                // horizontal line case
                try
                {
                    Move? s1 = board[lastMove.GetRow()][lastMove.GetCol() - 1];
                    Move? s2 = board[lastMove.GetRow()][lastMove.GetCol() + 1];

                    if (!(s1 is null) && !(s2 is null))
                    {
                        if (s1.GetMoveType() == MoveType.S && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), s1, lastMove, s2));
                            return;
                        }
                    }
                }
                catch (Exception exc)
                { }

                // positive diagonal case
                try
                {
                    Move? s1 = board[lastMove.GetRow() + 1][lastMove.GetCol() - 1];
                    Move? s2 = board[lastMove.GetRow() - 1][lastMove.GetCol() + 1];

                    if (!(s1 is null) && !(s2 is null))
                    {
                        if (s1.GetMoveType() == MoveType.S && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), s1, lastMove, s2));
                            return;
                        }
                    }
                }
                catch (Exception exc)
                { }

                // negative diagonal case
                try
                {
                    Move? s1 = board[lastMove.GetRow() - 1][lastMove.GetCol() - 1];
                    Move? s2 = board[lastMove.GetRow() + 1][lastMove.GetCol() + 1];

                    if (!(s1 is null) && !(s2 is null))
                    {
                        if (s1.GetMoveType() == MoveType.S && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), s1, lastMove, s2));
                            return;
                        }
                    }
                }
                catch (Exception exc)
                { }
                
            }
            else if (lastMove.GetMoveType() == MoveType.S)
            {
                // vertical line case

                // horizontal line case

                // positive diagonal case

                // negative diagonal case
            }

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

        public int RedScore()
        {
            int score = 0;

            foreach (SOSLine line in sosLines)
            {
                if (line.GetPlayer() == redPlayer)
                    score += 1;
            }

            return score;
        }
        public int BlueScore()
        {
            int score = 0;

            foreach (SOSLine line in sosLines)
            {
                if (line.GetPlayer() == bluePlayer)
                    score += 1;
            }

            return score;
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
        
        public List<SOSLine> GetSOSLines()
        {
            return sosLines;
        }
    }
}
