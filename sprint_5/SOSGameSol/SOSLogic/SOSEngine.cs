using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SOSLogic
{

    public class MoveEntry
    {
        public string playerType { get; set; } // human or computer
        public string color { get; set; } // blue or red
        public string moveType { get; set; } // S or O
        public int row { get; set; }
        public int col { get; set; }
    }

    public class SOSEngine
    {
        /*
         * The SOSEngine class handles the logic associated with the entire application, minus the GUI.
         * 
         */

        private Game? previousGame, currentGame;
        private bool inReplay;

        public SOSEngine()
        {
            // the previous and current game do not exist because no game has begun or completed yet.
            previousGame = null;
            currentGame = null;

            inReplay = false;
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
            return inReplay;
        }

        public bool IsBlueComputer()
        {
            // Check to see if the blue player is a computer
            if (!InGame())
                return false;
            else
                return currentGame?.GetBluePlayer().GetPlayerType() == PlayerType.Computer ? true : false;
        }

        public bool IsRedComputer()
        {
            // Check to see if the red player is a computer
            if (!InGame())
                return false;
            else
                return currentGame?.GetRedPlayer().GetPlayerType() == PlayerType.Computer ? true : false;
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

        public void StartGame(bool recordGame, GameMode gameMode = GameMode.Simple, int boardSize = 8, PlayerType bluePlayerType = PlayerType.Human, PlayerType redPlayerType = PlayerType.Human)
        {
            // start a new game based on the game mode, size of the board, and on the roles of the players

            // if there is already a game underway
            // then start a new game with the same settings as the current game (board size, player types, game mode)
            if (InGame())
            {
                previousGame = currentGame;

                bluePlayerType = currentGame.GetBluePlayer().GetPlayerType();
                redPlayerType = currentGame.GetRedPlayer().GetPlayerType();

                switch (currentGame.GetGameMode())
                {
                    case GameMode.Simple:
                        currentGame = new SimpleGame(recordGame, currentGame.GetBoardSize(), bluePlayerType, redPlayerType);
                        break;

                    case GameMode.General:
                        currentGame = new GeneralGame(recordGame, currentGame.GetBoardSize(), bluePlayerType, redPlayerType);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Invalid game mode!");
                }

            }
            else
            {
                switch (gameMode)
                {
                    case GameMode.Simple:
                        currentGame = new SimpleGame(recordGame, boardSize, bluePlayerType, redPlayerType);
                        break;

                    case GameMode.General:
                        currentGame = new GeneralGame(recordGame, boardSize, bluePlayerType, redPlayerType);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Invalid game mode!");
                }
            }

        }

        public void EndGame()
        {
            // A method to handle the high-level logic associated with ending a game
            // TODO: implement me further!

            previousGame = currentGame;

            // Write contents to a text file
            if (previousGame.GetRecordGame())
                using (StreamWriter writer = new StreamWriter("PreviousGame.txt"))
                {
                    List<MoveEntry> moveEntries = new List<MoveEntry>();

                    foreach (Move move in previousGame?.GetMoves())
                    {
                        Player player = move.GetPlayer();

                        MoveEntry moveEntry = new MoveEntry
                        {
                            playerType = player.GetPlayerType() == PlayerType.Human ? "human" : "computer",
                            color = player.GetColor() == Color.Blue ? "blue" : "red",
                            moveType = move.GetMoveType() == MoveType.S ? "S" : "O",
                            row = move.GetRow(),
                            col = move.GetCol()
                        };

                        moveEntries.Add(moveEntry);
                    }

                    string json = JsonSerializer.Serialize(moveEntries, new JsonSerializerOptions { WriteIndented = true });

                    writer.Write(json);
                }
            else
                File.Delete("PreviousGame.txt");

            currentGame = null;

        }

        public void EndReplay()
        {
            currentGame = null;
        }

        public void SetInReplay(bool inReplay)
        {
            this.inReplay = inReplay;
        }


    }

       
}
