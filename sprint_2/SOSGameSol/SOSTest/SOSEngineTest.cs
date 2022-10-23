using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSLogic;

namespace SOSTest
{

    [TestClass]
    public class SOSEngineTest
    {
        private int defaultBoardSize;

        [TestInitialize]
        public void Initialize()
        {
            defaultBoardSize = 8;
        }

        [TestMethod]
        public void TestStartGame()
        {
            // AC 2.1 - User attempts to select an invalid game mode

            // the StartGame method should throw an exception if the game mode is invalid
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SOSEngine().StartGame((GameMode)(-1)));
            

            // AC 2.3 - User does not select a game mode

            // the default game mode will be set to GameMode.Simple
            SOSEngine sosEngine = new SOSEngine();
            sosEngine.StartGame();
            Assert.AreEqual(sosEngine.GetCurrentGame().GetGameMode(), GameMode.Simple);


            // AC 2.4 - User selects a valid game mode outside of a game

            // user selects a game mode of simple
            sosEngine = new SOSEngine();
            sosEngine.StartGame(GameMode.Simple);
            Assert.AreEqual(sosEngine.GetCurrentGame().GetGameMode(), GameMode.Simple);
            
            // user selects a game mode of general
            sosEngine = new SOSEngine();
            sosEngine.StartGame(GameMode.General);
            Assert.AreEqual(sosEngine.GetCurrentGame().GetGameMode(), GameMode.General);


            // AC 3.1 - User starts a new game during a game
            // and... AC 3.2 - User starts a new game outside of a game

            foreach (PlayerType bluePlayerType in Enum.GetValues(typeof(PlayerType)))
            {
                foreach (PlayerType redPlayerType in Enum.GetValues(typeof(PlayerType)))
                {
                    foreach (GameMode gameMode in Enum.GetValues(typeof(GameMode)))
                    {
                        // AC 3.2
                        // the new game should start with the desired settings
                        sosEngine = new SOSEngine();
                        sosEngine.StartGame(gameMode, defaultBoardSize, bluePlayerType, redPlayerType);

                        Assert.AreEqual(sosEngine.GetCurrentGame().GetGameMode(), gameMode);
                        Assert.AreEqual(sosEngine.GetCurrentGame().GetBoardSize(), defaultBoardSize);
                        Assert.AreEqual(sosEngine.GetCurrentGame().GetBluePlayer().GetPlayerType(), bluePlayerType);
                        Assert.AreEqual(sosEngine.GetCurrentGame().GetRedPlayer().GetPlayerType(), redPlayerType);

                        // AC 3.1
                        // the new game should start with the same settings as the current game
                        sosEngine.StartGame();

                        Assert.AreEqual(sosEngine.GetCurrentGame().GetGameMode(), gameMode);
                        Assert.AreEqual(sosEngine.GetCurrentGame().GetBoardSize(), defaultBoardSize);
                        Assert.AreEqual(sosEngine.GetCurrentGame().GetBluePlayer().GetPlayerType(), bluePlayerType);
                        Assert.AreEqual(sosEngine.GetCurrentGame().GetRedPlayer().GetPlayerType(), redPlayerType);

                    }
                }
            }
        }


    }
}
