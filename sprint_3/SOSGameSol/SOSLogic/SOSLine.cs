using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class SOSLine
    {
        /*
         * A simple class to represent a completed SOS.
         */
        
        private Player player;
        private Move s1, o, s2;
    
        public SOSLine(Player player, Move s1, Move o, Move s2)
        {
            this.player = player;

            this.s1 = s1;
            this.o = o;
            this.s2 = s2;
        }

        public bool HasMove(Move move)
        {
            return s1 == move || o == move || s2 == move;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Move GetS1()
        {
            return s1;
        }

        public Move GetO()
        {
            return o;
        }

        public Move GetS2()
        {
            return s2;
        }
    }
}
