using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public enum PlayerType
    {
        Human,
        Computer
    }

    public abstract class Player
    {
        /*
         * 
         * A base class that handles the logic associated with a player
         * 
         * A human player makes moves manually.
         * 
         * A computer player makes moves according to an algorithm.
         * 
         */
        
        
        protected Game game;
        protected Color color;
        protected MoveType moveType;
        
        public Player(Game game, Color color)
        {
            this.game = game;
            this.color = color;
            this.moveType = MoveType.S;
        }

        public abstract void MakeMove(int row = -1, int col = -1);

        public Color GetColor()
        {
            return color;
        }

        public void SetMoveType(MoveType moveType)
        {
            if (moveType == MoveType.S || moveType == MoveType.O)
            {
                this.moveType = moveType;
            }
            else
                throw new ArgumentException("Invalid move type!");
        }
        
        public MoveType GetMoveType()
        {
            return moveType;
        }

        public abstract PlayerType GetPlayerType();

    }
}
