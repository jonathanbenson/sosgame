using SOSLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSTest
{
    [TestClass]
    public class GeneralGameTest
    {
        int boardSizeDefault;
        int boardSizeUpperLimit;
        int boardSizeLowerLimit;
        private GeneralGame game;

        [TestInitialize()]
        public void Initialize()
        {
            boardSizeDefault = 8;
            boardSizeUpperLimit = 12;
            boardSizeLowerLimit = 6;

            game = new GeneralGame();
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }


        [TestMethod]
        public void TestIsOver()
        {

            // AC 6.1 - User makes move that wins a general game
            // ... and AC 6.2 - User makes move that does not win a general game but completes an SOS
            int boardSize = game.GetBoardSize();
            
            // the general game is not over when it is first created
            Assert.IsFalse(game.IsOver());


            // Let the blue player complete an SOS for testing AC 6.2
            Player bluePlayer = game.GetBluePlayer();
            Player redPlayer = game.GetRedPlayer();

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(0, 0);

            Assert.IsFalse(game.IsOver());
            Assert.ThrowsException<Exception>(() => game.GetWinner());

            game.GetCurrentPlayer().SetMoveType(MoveType.O);
            game.GetCurrentPlayer().MakeMove(0, 1);

            Assert.IsFalse(game.IsOver());
            Assert.ThrowsException<Exception>(() => game.GetWinner());

            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            game.GetCurrentPlayer().MakeMove(0, 2);

            // AC 6.2
            // Blue player just completed an SOS, so it should still be the blue player's turn
            Assert.AreSame(game.GetCurrentPlayer(), bluePlayer);

            // Then fill up the rest of the boards with S's
            game.GetCurrentPlayer().SetMoveType(MoveType.S);
            
            for (int c = 3; c < boardSize; ++c)
                game.GetCurrentPlayer().MakeMove(0, c);


            for (int r = 1; r < boardSize; ++r)
            {
                for (int c = 0; c < boardSize; ++c)
                {
                    Player player = game.GetCurrentPlayer();

                    player.SetMoveType(MoveType.S);
                    player.MakeMove(r, c);

                    if (r == boardSize - 1 && c == boardSize - 1)
                    {
                        // AC 6.1

                        // the general game is over when the last move is made
                        Assert.IsTrue(game.IsOver());

                        // the winner of this general game is the blue player because they have completed the most SOSs
                        Assert.AreEqual(game.GetWinner(), bluePlayer);
                    }
                    else
                    {
                        // the general game is not over when the last move is not made
                        Assert.IsFalse(game.IsOver());

                        // throw an exception if the game tries to get a winner when the game is not over
                        Assert.ThrowsException<Exception>(() => game.GetWinner());
                    }
                }
            }

            // AC 6.3 - User makes move that does not win a general game and does not complete an SOS
            // ... and AC 6.4 - User makes move that ends a general game in a draw

            game = new GeneralGame();

            // the general game is not over when it is first created
            Assert.IsFalse(game.IsOver());

            boardSize = game.GetBoardSize();

            for (int r = 0; r < boardSize; ++r)
            {
                for (int c = 0; c < boardSize; ++c)
                {
                    Player player = game.GetCurrentPlayer();

                    player.SetMoveType(MoveType.S);
                    player.MakeMove(r, c);

                    if (r == boardSize - 1 && c == boardSize - 1)
                    {
                        // AC 6.4

                        // the general game is over when the last move is made
                        Assert.IsTrue(game.IsOver());

                        // the general game will return null if the game is a draw
                        Assert.IsNull(game.GetWinner());
                    }
                    else
                    {
                        // AC 6.3

                        // the general game is not over when the last move is not made
                        Assert.IsFalse(game.IsOver());

                        // throw an exception if the game tries to get a winner when the game is not over
                        Assert.ThrowsException<Exception>(() => game.GetWinner());
                    }
                }
            }

        }

        [TestMethod]
        public void TestNewTurn()
        {

        }
    }
}
