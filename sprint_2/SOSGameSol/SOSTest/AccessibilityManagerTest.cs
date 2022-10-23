using SOSLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSTest
{

    [TestClass]
    public class AccessibilityManagerTest
    {
        SOSEngine sosEngine;
        AccessibilityManager accessibilityManager;

        [TestInitialize()]
        public void Initialize()
        {
            sosEngine = new SOSEngine();
            accessibilityManager = new AccessibilityManager(sosEngine);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestIsBoardSizeAccessible()
        {
            // AC 1.4 - User selects a valid board size outside of a game

            // the board size should be accessible before a game has started
            Assert.IsTrue(accessibilityManager.IsBoardSizeAccessible());


            // AC 1.2 - User attempts to select a board size within a game

            // the IsBoardSizeAccessible method should return false if the game is in progress
            sosEngine.StartGame();
            Assert.IsFalse(accessibilityManager.IsBoardSizeAccessible());
        }

        [TestMethod]
        public void TestIsGameModeAccessible()
        {
 
            // AC 2.4 - User selects a valid game mode outside of a game

            // the game mode should be accessible before a game has started
            Assert.IsTrue(accessibilityManager.IsGameModeAccessible());

            // AC 2.2 - User attempts to select a game mode inside of a game

            // the game mode should be inaccessible after a game has started
            sosEngine.StartGame();
            Assert.IsFalse(accessibilityManager.IsGameModeAccessible());
        }

        [TestMethod]
        public void TestIsBoardAccessible()
        {
            // AC 4.1 - User attempts to select a board size outside of a game

            // the board should be inaccessible before a game has started
            Assert.IsFalse(accessibilityManager.IsBoardAccessible());

            // the board should be inaccessible after a game has started
            sosEngine.StartGame();
            Assert.IsTrue(accessibilityManager.IsBoardAccessible());
        }

        [TestMethod]
        public void TestIsSOAvailable()
        {
            // AC 8.4 - User attempts to select a board size outside of a game

            // the SO should be inaccessible before a game has started
            Assert.IsFalse(accessibilityManager.IsBlueSOAccessible());
            Assert.IsFalse(accessibilityManager.IsRedSOAccessible());

            // the SO should be accessible after a game has started
            sosEngine.StartGame();
            Assert.IsTrue(accessibilityManager.IsBlueSOAccessible());
            Assert.IsTrue(accessibilityManager.IsRedSOAccessible());
        }
    }
}
