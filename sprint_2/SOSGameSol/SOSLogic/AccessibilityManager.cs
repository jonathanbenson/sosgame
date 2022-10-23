using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class AccessibilityManager
    {
        
        private SOSEngine sosEngine;

        public AccessibilityManager(SOSEngine game)
        {
            this.sosEngine = game;
        }

        private bool IsAccessible(bool a, bool b, bool c, bool d)
        {
            // Determines whether or not a widget (ex. replay button) is accessible depending on the state of the application
            // The parameters a, b, c, and d encode the widget in question
            // ...and e, f, g, h, and i below represent the state of the application

            /*
             * Game Mode Selection                      = 0000
             * Blue Role Selection (human/computer)     = 0001
             * Red Role Selection (human/computer)      = 0010
             * Record Game Button                       = 0011
             * Replay Game Button                       = 0100
             * New Game Button                          = 0101
             * Board Size Selection                     = 0110
             * Blue S/O Selection                       = 0111
             * Red S/O Selection                        = 1000
             * Game Board (whether a move can be made)  = 1001
             * Quit Replay Button (stop a replay)       = 1010
             * Current Turn Display                     = 1011
             * Score display                            = 1100
             * 
             */

            bool e = sosEngine.InReplay();
            bool f = sosEngine.InGame();
            bool g = sosEngine.IsRedTurn();
            bool h = sosEngine.IsBlueComputer();
            bool i = sosEngine.IsRedComputer();

            // Boolean function generated from the output column of the accessibility truth table
            return (a && b && !c && !d && e) || (a && b && !c && !d && f) || (a && !b && c && e) || (a && !b && !c && !e && f && !i) || (a && !b && d && !e && f) || (!a && b && !c && d && !e) || (!a && b && d && !e && f && !h) || (!a && !b && !e && !f) || (!a && !d && !e && !f);
        }

        public bool IsGameModeAccessible()
        {
            return IsAccessible(false, false, false, false);
        }

        public bool IsBlueRoleAccessible()
        {
            // return IsAccessible(false, false, false, true);
            return false;
        }

        public bool IsRedRoleAccessible()
        {
            // return IsAccessible(false, false, true, false);
            return false;
        }

        public bool IsRecordButtonAccessible()
        {
            return IsAccessible(false, false, true, true);
        }

        public bool IsReplayButtonAccessible()
        {
            return sosEngine.ExistsPreviousGame() ? IsAccessible(false, true, false, true) : false;
        }

        public bool IsNewGameButtonAccessible()
        {
            return IsAccessible(false, true, false, true);
        }

        public bool IsBoardSizeAccessible()
        {
            return IsAccessible(false, true, true, false);
        }

        public bool IsBlueSOAccessible()
        {
            return IsAccessible(false, true, true, true);
        }

        public bool IsRedSOAccessible()
        {
            return IsAccessible(true, false, false, false);
        }

        public bool IsBoardAccessible()
        {
            return IsAccessible(true, false, false, true);
        }

        public bool IsQuitReplayButtonAccessible()
        {
            return IsAccessible(true, false, true, false);
        }

        public bool IsCurrentTurnDisplayAccessible()
        {
            return IsAccessible(true, false, true, true);
        }

        public bool IsScoreDisplayAccessible()
        {
            return IsAccessible(true, true, false, false);
        }
    }
}
