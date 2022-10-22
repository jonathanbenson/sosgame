using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public enum MoveType
    {
        S,
        O
    }
    
    public class Move
    {
        private Player player;
        private MoveType moveType;
        private int row, col;

        public Move(Player player, MoveType moveType, int row, int col)
        {
            this.player = player;
            this.moveType = moveType;
            this.row = row;
            this.col = col;
        }

        public bool DoesConflict(Move otherMove)
        {
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
            return player;
        }

        public MoveType GetMoveType()
        {
            return moveType;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetCol()
        {
            return col;
        }
    }


}
