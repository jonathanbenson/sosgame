using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
   
    public class Player
    {
        private Game game;
        private Color color;
        private MoveType moveType;

        public Player(Game game, Color color)
        {
            this.game = game;
            this.color = color;
            this.moveType = MoveType.S;
        }
        
        public void MakeMove(int row, int col)
        {
            Move move = new Move(this, moveType, row, col);
            game.MakeMove(move);
        }

        public Color GetColor()
        {
            return color;
        }

        public void SetMoveType(MoveType moveType)
        {
            this.moveType = moveType;
        }
        
        public MoveType GetMoveType()
        {
            return moveType;
        }

    }
}
