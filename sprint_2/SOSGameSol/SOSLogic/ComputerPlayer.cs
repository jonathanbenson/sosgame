using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSLogic
{
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
    }
}
