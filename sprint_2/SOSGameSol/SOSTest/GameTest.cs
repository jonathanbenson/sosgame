using SOSLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
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

        [TestMethod]
        public void TestMakeMove()
        {
            // AC 4.1 - User makes a move on a nonempty cell
            // ... and AC 4.2 - User makes a move outside the game board
            // ... and AC 4.3 - User makes a move on an empty cell
            // ... and AC 4.5 - User makes a move when it's not their turn
            

            foreach (MoveType bluePlayerMoveType in Enum.GetValues(typeof(MoveType)))
                foreach (MoveType redPlayerMoveType in Enum.GetValues(typeof(MoveType)))
                    for (int boardSize = boardSizeLowerLimit; boardSize <= boardSizeUpperLimit; ++boardSize)
                    {
                        Game game = new SimpleGame(boardSize);

                        Color turn = Color.Blue;

                        int moveCount = 0;
                        
                        for (int row = 0; row < boardSize; ++row)
                            for (int col = 0; col < boardSize; ++col)
                            {
                                Player currentPlayer = game.GetCurrentPlayer();
                                
                                if (turn == Color.Blue)
                                {
                                    Assert.AreSame(currentPlayer, game.GetBluePlayer());

                                    // AC 4.5
                                    // the red player tries to make a move when its not the red players turn
                                    Assert.ThrowsException<ArgumentException>(() => game.GetRedPlayer().MakeMove(row, col));

                                    currentPlayer.SetMoveType(bluePlayerMoveType);
                                }
                                else
                                {
                                    Assert.AreSame(currentPlayer, game.GetRedPlayer());

                                    // AC 4.5
                                    // the blue player tries to make a move when its not the blue players turn
                                    Assert.ThrowsException<ArgumentException>(() => game.GetBluePlayer().MakeMove(row, col));

                                    currentPlayer.SetMoveType(redPlayerMoveType);
                                }

                                // AC 4.2

                                // user makes a move outside above the game board
                                Assert.ThrowsException<ArgumentException>(() => currentPlayer.MakeMove(row - 1000, col));

                                // user makes a move outside below the game board
                                Assert.ThrowsException<ArgumentException>(() => currentPlayer.MakeMove(row + 1000, col));

                                // user makes a move outside to the left of the gameboard
                                Assert.ThrowsException<ArgumentException>(() => currentPlayer.MakeMove(row, col - 1000));

                                // user makes a move outside to the right of the gameboard
                                Assert.ThrowsException<ArgumentException>(() => currentPlayer.MakeMove(row, col + 1000));


                                // AC 4.3
                                // the user may make a move on an empty cell
                                currentPlayer.MakeMove(row, col); moveCount++;
                                Assert.AreEqual(game.GetMoves().Count, moveCount);

                                // AC 4.1
                                // make sure the user is not able to make a move on an empty cell
                                Assert.ThrowsException<ArgumentException>(() => currentPlayer.MakeMove(row, col));
                                

                                if (turn == Color.Blue)
                                    turn = Color.Red;
                                else
                                    turn = Color.Blue;
                            }

                    }
        }
    }
}
