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
    // Tests the SOSLogic.Game class via its subclass GeneralGame
    {
        int boardSizeDefault;
        int boardSizeUpperLimit;
        int boardSizeLowerLimit;
        Player? bluePlayer, redPlayer;
        private GeneralGame? game;
        int boardSize;

        [TestInitialize()]
        public void Initialize()
        {
            boardSizeDefault = 8;
            boardSizeUpperLimit = 12;
            boardSizeLowerLimit = 6;

            game = new GeneralGame();

            boardSize = game.GetBoardSize();

            bluePlayer = game.GetBluePlayer();
            redPlayer = game.GetRedPlayer();
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
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SimpleGame(false, i));

            // the Game constructor should throw an exception if the board size is greater than 12
            for (int i = boardSizeUpperLimit + 1; i < 100; ++i)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SimpleGame(false, i));
            

            // AC 1.3 - User does not select a board size

            // the default board size will be set to 8
            Assert.AreEqual(new SimpleGame().GetBoardSize(), boardSizeDefault);


            
            // AC 1.4 - User selects a valid board size outside of a game

            // the board size of the game should equal the board size passed to the Game constructor
            for (int i = boardSizeLowerLimit; i <= boardSizeUpperLimit; ++i)
                Assert.AreEqual(new SimpleGame(false, i).GetBoardSize(), i);

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
                        Game game = new SimpleGame(false, boardSize);

                        Color turn = Color.Blue;

                        int moveCount = 0;
                        
                        for (int row = 0; row < boardSize; ++row)
                            for (int col = 0; col < boardSize; ++col)
                            {
                                Player currentPlayer = game.GetCurrentPlayer();
                                
                                if (turn == Color.Blue)
                                {

                                    // AC 4.5
                                    // the red player tries to make a move when its not the red players turn
                                    Assert.ThrowsException<ArgumentException>(() => game.GetRedPlayer().MakeMove(row, col));

                                }
                                else
                                {

                                    // AC 4.5
                                    // the blue player tries to make a move when its not the blue players turn
                                    Assert.ThrowsException<ArgumentException>(() => game.GetBluePlayer().MakeMove(row, col));

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

        [TestMethod]
        public void TestSwitchTurns()
        {
            // UT #7
            
            // Make sure the turn is blue before switch turns
            Assert.AreSame(game.GetCurrentPlayer(), game.GetBluePlayer());

            // check if the turn has switched back to red after switch turns
            game.SwitchTurns();
            Assert.AreSame(game.GetCurrentPlayer(), game.GetRedPlayer());
            
        }

        [TestMethod]
        public void TestCheckSOS()
        {

            int lastORow = boardSize - 2;
            int lastOCol = boardSize - 2;
            int lastSRow = boardSize - 3;
            int lastSCol = boardSize - 3;

            // UT #15 - SOS line (last O) ->vertical line case

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow + 1, lastOCol);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow - 1, lastOCol);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastORow, lastOCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #16 - SOS line (last O) ->horizontal line case

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow, lastOCol - 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow, lastOCol + 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastORow, lastOCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #17 - SOS line (last O) -> positive diagonal case

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow + 1, lastOCol - 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow - 1, lastOCol + 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastORow, lastOCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #18 - SOS line (last O) -> negative diagonal case

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow - 1, lastOCol - 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastORow + 1, lastOCol + 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastORow, lastOCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #19 - SOS line (last S) -> vertical line case (last move on top S)
            
            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow + 2, lastSCol);
            
            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow + 1, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #20 - SOS line (last S) -> vertical line case (last move on bottom S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow - 2, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow - 1, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #21 - SOS line (last S) -> horizontal line case (last move on right S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol - 2);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol - 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #22 - SOS line (last S) -> horizontal line case (last move on left S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol + 2);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol + 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #23 - SOS line (last S) -> positive diagonal case (last move on top-right S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow + 2, lastSCol - 2);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow + 1, lastSCol - 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #24 - SOS line (last S) -> positive diagonal case (last move on bottom-left S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow - 2, lastSCol + 2);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow - 1, lastSCol + 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #25 - SOS line (last S) -> negative diagonal case (last move on top-left S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow + 2, lastSCol + 2);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow + 1, lastSCol + 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);

            // UT #26 - SOS line (last S) -> negative diagonal case (last move on bottom-right S)

            game = new GeneralGame();

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow - 2, lastSCol - 2);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(lastSRow - 1, lastSCol - 1);

            Assert.AreEqual(game.GetSOSLines().Count, 0);

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(lastSRow, lastSCol);

            Assert.AreEqual(game.GetSOSLines().Count, 1);



        }
    }
}
