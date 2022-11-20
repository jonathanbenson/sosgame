using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Diagnostics;

namespace SOSLogic
{
    public enum GameMode
    {
        /* 
         * There are two game modes for the SOS game: Simple and General.
         * 
         * In a simple game, the first player to create a SOS wins the game.
         * If all the cells are filled and no SOS has been created, the game is a draw.
         * 
         * In a general game, the game ends once all the cells are filled.
         * The winner is the player with the most SOSs. If the number of SOSs is equal, the game is a draw.
         * If a user makes a SOS, then they get a extra turn.
         * 
         */
        
        Simple,
        General
    }

    public class Cell
    {
        public Cell(int r, int c)
        {
            row = r;
            col = c;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetCol()
        {
            return col;
        }

        private int row, col;
    }
    
    public abstract class Game
    {
        /*
         * The Game class is the base class for the SimpleGame and GeneralGame classes.
         * 
         * It handles the base logic for the SOS game.
         * 
         */
        
        private int boardSize;
        
        private Player bluePlayer, redPlayer, currentPlayer;

        private List<Move> moves;
        private List<SOSLine> sosLines;

        private bool isOver;

        public Game(int boardSize = 8, PlayerType bluePlayerType = PlayerType.Human, PlayerType redPlayerType = PlayerType.Human)
        {
            // the board size is the number of rows and columns in the board
            // ensure the board size is between the values of 8 and 12
            if (!IsBoardSizeValid(boardSize))
            {
                throw new ArgumentOutOfRangeException("Invalid board size");
            }

            this.boardSize = boardSize;

            

            // instantiate the blue player depending on whether it is a computer or human
            if (bluePlayerType == PlayerType.Computer)
                bluePlayer = new ComputerPlayer(this, Color.Blue);
            else
                bluePlayer = new HumanPlayer(this, Color.Blue);

            // instantiate the red player depending on whether it is a computer or human
            if (redPlayerType == PlayerType.Computer)
                redPlayer = new ComputerPlayer(this, Color.Red);
            else
                redPlayer = new HumanPlayer(this, Color.Red);

            // set the current player to blue
            currentPlayer = bluePlayer;
            
            // initialize the list of moves and list of sos lines
            // they are empty because the game has just started
            moves = new List<Move>();
            sosLines = new List<SOSLine>();

            // A game that just started is not over yet
            isOver = false;
        }

        public void MakeMove(Move move)
        {
            // A method that handles the logic for making a move
            Debug.WriteLine(move.GetRow().ToString() + ' ' + move.GetCol().ToString());

            // If the move is valid, then add it to the history of moves.
            // ...and check if it made a SOS.
            if (IsMoveValid(move))
            {
                CheckSOS(move);
                GetMoves().Add(move);

                if (!IsOver())
                    NewTurn();
            }
            // If the move is not valid, then throw an exception that will be received by the GUI
            // to show the user an error message.
            else
                throw new ArgumentException("Invalid move!");
        }

        public abstract bool IsOver();

        public Player? GetWinner()
        {
            if (!IsOver())
                throw new Exception("Game is not over yet!");

            // Count the number of SOSs made by the blue and red players
            int blueSOSLineCount = 0, redSOSLineCount = 0;

            foreach (SOSLine sosLine in GetSOSLines())
            {
                if (sosLine.GetPlayer() == GetBluePlayer())
                    blueSOSLineCount++;
                else if (sosLine.GetPlayer() == GetRedPlayer())
                    redSOSLineCount++;
            }

            // If the blue player has more SOSs, then they are the winner
            if (blueSOSLineCount > redSOSLineCount)
                return GetBluePlayer();
            // If the red player has more SOSs, then they are the winner
            else if (blueSOSLineCount < redSOSLineCount)
                return GetRedPlayer();
            // If the number of SOSs is equal, then the game is a draw
            else
                return null;
        }

        private static bool IsBoardSizeValid(int boardSize)
        {
            // The board size is not valid if is is less than 8 or greater than 12
            return (boardSize < 6 || boardSize > 12) ? false : true;
        }

        public void CheckSOS(Move lastMove)
        {
            /*
             * A method that checks if the last move created a SOS.
             * 
             * 
             */
            
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
                catch (ArgumentOutOfRangeException exc)
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
                catch (ArgumentOutOfRangeException exc)
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
                catch (ArgumentOutOfRangeException exc)
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
                catch (ArgumentOutOfRangeException exc)
                { }
                
            }
            else if (lastMove.GetMoveType() == MoveType.S)
            {
                // vertical line case (last move on top S)
                try
                {
                    Move? o = board[lastMove.GetRow() + 1][lastMove.GetCol()];
                    Move? s2 = board[lastMove.GetRow() + 2][lastMove.GetCol()];
                    
                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // vertical line case (last move on bottom S)
                try
                {
                    Move? o = board[lastMove.GetRow() - 1][lastMove.GetCol()];
                    Move? s2 = board[lastMove.GetRow() - 2][lastMove.GetCol()];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // horizontal line case (last move on right S)
                try
                {
                    Move? o = board[lastMove.GetRow()][lastMove.GetCol() - 1];
                    Move? s2 = board[lastMove.GetRow()][lastMove.GetCol() - 2];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // horizontal line case (last move on left S)
                try
                {
                    Move? o = board[lastMove.GetRow()][lastMove.GetCol() + 1];
                    Move? s2 = board[lastMove.GetRow()][lastMove.GetCol() + 2];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // positive diagonal case (last move on top-right S)
                try
                {
                    Move? o = board[lastMove.GetRow() + 1][lastMove.GetCol() - 1];
                    Move? s2 = board[lastMove.GetRow() + 2][lastMove.GetCol() - 2];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // positive diagonal case (last move on bottom-left S)
                try
                {
                    Move? o = board[lastMove.GetRow() - 1][lastMove.GetCol() + 1];
                    Move? s2 = board[lastMove.GetRow() - 2][lastMove.GetCol() + 2];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // negative diagonal case (last move on top-left S)
                try
                {
                    Move? o = board[lastMove.GetRow() - 1][lastMove.GetCol() - 1];
                    Move? s2 = board[lastMove.GetRow() - 2][lastMove.GetCol() - 2];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }

                // negative diagonal case (last move on bottom-right S)
                try
                {
                    Move? o = board[lastMove.GetRow() + 1][lastMove.GetCol() + 1];
                    Move? s2 = board[lastMove.GetRow() + 2][lastMove.GetCol() + 2];

                    if (!(o is null) && !(s2 is null))
                    {
                        if (o.GetMoveType() == MoveType.O && s2.GetMoveType() == MoveType.S)
                        {
                            sosLines.Add(new SOSLine(lastMove.GetPlayer(), lastMove, o, s2));
                            return;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException exc)
                { }
            }

        }

        public abstract void NewTurn();

        public void SwitchTurns()
        {
            // Switches the current players turn
            
            // If the current player is a blue player, then switch to red
            if (currentPlayer == bluePlayer)
                currentPlayer = redPlayer;
            // If the current player is a red player, then switch to blue
            else
                currentPlayer = bluePlayer;
        }

        public bool IsMoveValid(Move move)
        {
            // Checks if the provided move is valid or not

            // The move is not valid if it is not the move's player's turn
            if (move.GetPlayer() != currentPlayer)
                return false;

            // the move is not valid if it is not on the board (row and col index starts at 0, so -1 the board size)
            if (move.GetRow() < 0 || move.GetCol() < 0 || move.GetRow() > boardSize - 1 || move.GetCol() > boardSize - 1)
            {
                return false;
            }

            // Make sure that the move does not conflict with any other move
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
            // Returns true if it is red's turn, false otherwise
            return currentPlayer == redPlayer;
        }

        public int RedScore()
        {
            // A method to count up the number of completed SOSs of the red player
            
            int score = 0;

            // Count up the number of SOSs created by the red player
            foreach (SOSLine line in sosLines)
            {
                if (line.GetPlayer() == redPlayer)
                    score += 1;
            }

            return score;
        }
        public int BlueScore()
        {
            // A method to count up the number of completed SOSs of the blue player
            
            int score = 0;

            // Count up the number of SOSs created by the blue player
            foreach (SOSLine line in sosLines)
            {
                if (line.GetPlayer() == bluePlayer)
                    score += 1;
            }

            return score;
        }

        protected void EndGame()
        {
            // Ends the game
            isOver = true;
        }


        public Player GetCurrentPlayer()
        {
            // Returns the current player (based on whose turn it is)
            
            if (IsRedTurn())
                return redPlayer;
            else
                return bluePlayer;
        }

        public Player GetBluePlayer()
        {
            // Getter for the blue player
            
            return bluePlayer;
        }

        public Player GetRedPlayer()
        {
            // Getter for the red player
            
            return redPlayer;
        }

        public List<Move> GetMoves()
        {
            // Getter for the list of moves
            return moves;
        }
        
        public List<SOSLine> GetSOSLines()
        {
            // Getter for the list of SOS lines
            
            return sosLines;
        }

        public int GetBoardSize()
        {
            // Getter for the board size

            return boardSize;
        }

        public abstract GameMode GetGameMode();

        public List<Cell> GetEmptyCells()
        {
            List<Cell> emptyCells = new List<Cell>();

            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    bool isEmpty = true;

                    foreach (Move move in moves)
                        if (move.GetRow() == r && move.GetCol() == c)
                        {
                            isEmpty = false;
                            break;
                        }

                    if (isEmpty)
                        emptyCells.Add(new Cell(r, c));
                }
            }

            return emptyCells;
        }
    }
}
