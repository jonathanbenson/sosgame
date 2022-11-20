using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public enum MoveType
    {
        // In SOS, a player may either place a S or an O.
        
        S,
        O
    }
    
    public class Move
    {
        /*
         * A class to represent a move in the SOS game
         * 
         */
        
        private Player player;
        private MoveType moveType;
        private int row, col;

        public Move(Player player, MoveType moveType, int row, int col)
        {
            // Constructor
            // The move depends on the player, the move type, and the row and column of the move
            
            this.player = player;
            this.moveType = moveType;
            this.row = row;
            this.col = col;
        }

        public bool DoesConflict(Move otherMove)
        {
            // Checks to see if a move conflicts with another move
            // A move conflicts with another move if they are in the same row and column

            // if the other move's row and column are the same as this move's row and column
            // Then return true, else false
            if (otherMove.GetRow() == row && otherMove.GetCol() == col)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Player GetPlayer()
        {
            // Getter for the player who made the move
            
            return player;
        }

        public MoveType GetMoveType()
        {
            // Getter for the type of move (S or O)
            
            return moveType;
        }

        public int GetRow()
        {
            // Getter for the row of the move
            
            return row;
        }

        public int GetCol()
        {
            // Getter for the column of the move
            
            return col;
        }
    }


}
