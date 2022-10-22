using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;

namespace SOSLogic
{
    public class SOSEngine
    {
        private Game? previousGame, currentGame;
        private AccessibilityManager accessibilityManager;

        public SOSEngine()
        {
            accessibilityManager = new AccessibilityManager(this);

            previousGame = null;
            currentGame = null;
        }

        public bool IsRedTurn()
        {
            if (currentGame is null)
                return false;
            else
                return currentGame.IsRedTurn();
        }

        public bool InGame()
        {
            return (currentGame is null) ? false : true;
        }

        public bool ExistsPreviousGame()
        {
            return (previousGame is null) ? false : true;
        }

        public bool InReplay()
        {
            return false;
        }

        public bool IsBlueComputer()
        {
            return false;
        }

        public bool IsRedComputer()
        {
            return false;
        }

        public Game GetPreviousGame()
        {
            if (previousGame is null)
                throw new Exception("No previous game exists");
            else
                return previousGame;
        }

        public Game GetCurrentGame()
        {
            if (currentGame is null)
                throw new Exception("No current game exists");
            else
                return currentGame;
        }

        public void StartGame()
        {
            currentGame = new Game();
        }

        public void EndGame()
        {
            previousGame = currentGame;
            currentGame = null;
        }

    }

       
}
