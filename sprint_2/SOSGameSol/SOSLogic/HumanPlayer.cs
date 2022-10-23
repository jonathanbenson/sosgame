using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSLogic
{
    public class HumanPlayer : Player
    {
        /*
         * 
         * A class that handles the logic associated with a human player
         * 
         * A human player makes moves manually.
         * 
         * 
         */
        
        public HumanPlayer(Game game, Color color) : base(game, color)
        {

        }
    }
}
