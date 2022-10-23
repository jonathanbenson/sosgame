using SOSLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSTest
{
    [TestClass]
    public class GameTest
    // Tests the SOSLogic.Game class via its subclass SimpleGame
    {
        int boardSizeDefault;
        int boardSizeUpperLimit;
        int boardSizeLowerLimit;

        [TestInitialize()]
        public void Initialize()
        {
            boardSizeDefault = 8;
            boardSizeUpperLimit = 12;
            boardSizeLowerLimit = 6;
        }

        [TestCleanup()]
        public void Cleanup()
        {
        
        }

        
        [TestMethod]
        public void TestGame()
        // Tests the SOSLogic.Example.GetTrue method
        {
            // AC 1.1 - User attempts to select an invalid board size

            // the Game constructor should throw an exception if the board size is less than 6
            for (int i = -100; i < boardSizeLowerLimit; ++i)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SimpleGame(i));

            // the Game constructor should throw an exception if the board size is greater than 12
            for (int i = boardSizeUpperLimit + 1; i < 100; ++i)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SimpleGame(i));
            

            // AC 1.3 - User does not select a board size

            // the default board size will be set to 8
            Assert.AreEqual(new SimpleGame().GetBoardSize(), boardSizeDefault);


            
            // AC 1.4 - User selects a valid board size outside of a game

            // the board size of the game should equal the board size passed to the Game constructor
            for (int i = boardSizeLowerLimit; i <= boardSizeUpperLimit; ++i)
                Assert.AreEqual(new SimpleGame(i).GetBoardSize(), i);

        }
    }
}
