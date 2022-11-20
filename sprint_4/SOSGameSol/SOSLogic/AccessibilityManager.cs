using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class AccessibilityManager
    {
        /*
         * The AccessibilityManager class assists with determining which controls are accessible or not in the GUI.
         * 
         * A control is accessible if the user can interact with it.
         * 
         * Furthermore, a control can be made inaccessible by hiding it or non-responsive.
         * 
         */
        
        private SOSEngine sosEngine;

        public AccessibilityManager(SOSEngine sosEngine)
        {
            // The AccessibilityManager class is used by the SOSEngine class
            this.sosEngine = sosEngine;
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
            // A method to determine whether the user can select the game mode.
            
            return IsAccessible(false, false, false, false);
        }

        public bool IsBlueRoleAccessible()
        {
            // A method to determine whether the blue player can pick between a human and a computer
            
            return IsAccessible(false, false, false, true);
        }

        public bool IsRedRoleAccessible()
        {
            // A method to determine whether the red player can pick between a human and a computer
            
            return IsAccessible(false, false, true, false);
        }

        public bool IsRecordButtonAccessible()
        {
            // A method to determine whether the user can start recording their game via the record button

            // return IsAccessible(false, false, true, true);

            return false;
        }

        public bool IsReplayButtonAccessible()
        {
            // A method to determine whether the user can watch a replay of the previous game via the replay button

            // The user may not watch a replay if a previous game does not exist
            //return sosEngine.ExistsPreviousGame() ? IsAccessible(false, true, false, true) : false;

            return false;
        }

        public bool IsNewGameButtonAccessible()
        {
            // A method to determine whether the user may start a new game via the new game button
            
            return IsAccessible(false, true, false, true);
        }

        public bool IsBoardSizeAccessible()
        {
            // A method to determine whether the user may change the board size via the board size selection tool
            
            return IsAccessible(false, true, true, false);
        }

        public bool IsBlueSOAccessible()
        {
            // A method to determine whether the blue player may choose between a S or O move via the blue S/O controls
            
            return IsAccessible(false, true, true, true);
        }

        public bool IsRedSOAccessible()
        {
            // A method to determine whether the red player may choose between a S or O move via the red S/O controls
            
            return IsAccessible(true, false, false, false);
        }

        public bool IsBoardAccessible()
        {
            // A method to determine whether the player is able to make a move on the board (ex. place a S or O)
            
            return IsAccessible(true, false, false, true);
        }

        public bool IsQuitReplayButtonAccessible()
        {
            // A method to determine whether the user can see the quit replay button

            //return IsAccessible(true, false, true, false);
            return false;
        }

        public bool IsCurrentTurnDisplayAccessible()
        {
            // A method to determine whether the user can see the current turn of the game
            
            return IsAccessible(true, false, true, true);
        }

        public bool IsScoreDisplayAccessible()
        {
            // A method to determine whether the user can see the score of the game for the red and blue players

            return IsAccessible(true, true, false, false);
        }
    }
}
