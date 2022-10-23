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
        /*
         * The SOSEngine class handles the logic associated with the entire application, minus the GUI.
         * 
         */

        private Game? previousGame, currentGame;

        public SOSEngine()
        {
            // the previous and current game do not exist because no game has begun or completed yet.
            previousGame = null;
            currentGame = null;
        }

        public bool IsRedTurn()
        {

            // it is nobody's turn if there is no game playing
            if (currentGame is null)
                return false;
            // if the game is underway, ask the game whose turn it is
            else
                return currentGame.IsRedTurn();
        }

        public bool InGame()
        {
            // Check to see if there is a game underway
            return (currentGame is null) ? false : true;
        }

        public bool ExistsPreviousGame()
        {
            // Check to see if a previous game has been played
            return (previousGame is null) ? false : true;
        }

        public bool InReplay()
        {
            // Check to see if the user is watching a replay
            return false;
        }

        public bool IsBlueComputer()
        {
            // Check to see if the blue player is a computer
            return false;
        }

        public bool IsRedComputer()
        {
            // Check to see if the red player is a computer
            return false;
        }

        public Game GetPreviousGame()
        {
            // Return the previous game if it exists, else raise an error
            if (previousGame is null)
                throw new Exception("No previous game exists");
            else
                return previousGame;
        }

        public Game GetCurrentGame()
        {
            // Return the current game if it exists, else raise an error
            if (currentGame is null)
                throw new Exception("No current game exists");
            else
                return currentGame;
        }

        public void StartGame(GameMode gameMode, int boardSize, bool isBlueComputer, bool isRedComputer)
        {
            // start a new game based on the game mode, size of the board, and on the roles of the players

            switch (gameMode)
            {
                case GameMode.Simple:
                    currentGame = new SimpleGame(boardSize, isBlueComputer, isRedComputer);
                    break;

                case GameMode.General:
                    currentGame = new GeneralGame(boardSize, isBlueComputer, isRedComputer);
                    break;
            }

        }

        public void EndGame()
        {
            // A method to handle the high-level logic associated with ending a game
            // TODO: implement me further!

            previousGame = currentGame;
            currentGame = null;
        }

    }

       
}
