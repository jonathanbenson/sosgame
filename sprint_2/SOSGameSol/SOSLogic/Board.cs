using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    public class Board
    {
        private int size;

        private bool isRedTurn, inGame, existsPreviousGame, inReplay, isBlueComputer, isRedComputer;

        public Board()
        {
            isRedTurn = false;
            inGame = false;
            existsPreviousGame = false;
            inReplay = false;
            isBlueComputer = false;
            isRedComputer = false;
        }

        public void SwitchTurns()
        {
            isRedTurn = !isRedTurn;
        }

        private bool IsAccessible(bool a, bool b, bool c, bool d)
        {
            bool e = inReplay;
            bool f = inGame;
            bool g = isRedTurn;
            bool h = isBlueComputer;
            bool i = isRedComputer;

            return (a && !b && c && !d && e) || (a && !b && !c && d && !e && f) || (a && !b && !c && !e && f && !i) || (!a && b && !c && d && !e) || (!a && b && d && !e && f && !h) || (!a && !b && !e && !f) || (!a && !d && !e && !f);
        }

        public bool IsGameModeAccessible()
        {
            return IsAccessible(false, false, false, false);
        }

        public bool IsBlueRoleAccessible()
        {
            return IsAccessible(false, false, false, true);
        }

        public bool IsRedRoleAccessible()
        {
            return IsAccessible(false, false, true, false);
        }

        public bool IsRecordButtonAccessible()
        {
            return IsAccessible(false, false, true, true);
        }

        public bool IsReplayButtonAccessible()
        {
            return existsPreviousGame ? IsAccessible(false, true, false, true) : false;
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
    }
}
