using SOSLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSTest
{
    [TestClass]
    public class SimpleGameTest
    {
        private int boardSize;
        private SimpleGame? game;
        private Player? bluePlayer, redPlayer;

        [TestInitialize()]
        public void Initialize()
        {

            game = new SimpleGame();
            
            bluePlayer = game.GetBluePlayer();
            redPlayer = game.GetRedPlayer();

            boardSize = game.GetBoardSize();
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }


        [TestMethod]
        public void TestIsOver()
        {

            // AC 5.1 - User makes move that wins a simple game
            
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

            // 5.1
            // A user wins a simple game by completing the first SOS
            // In this case, it is the blue player
            Assert.IsTrue(game.IsOver());
            Assert.AreSame(game.GetWinner(), bluePlayer);


            // AC 5.2 - User makes move that does not win a simple game
            // ... and AC 5.3 - Simple game ends in a draw

            game = new SimpleGame();
            
            // the simple game is not over when it is first created
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
                        // AC 5.2
                        
                        // the simple game is over when the last move is made
                        Assert.IsTrue(game.IsOver());

                        // the simple game will return null if the game is a draw
                        Assert.IsNull(game.GetWinner());
                    }
                    else
                    {
                        // AC 5.3
                        
                        // the simple game is not over when the last move is not made
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
            // UT #9
            Assert.AreSame(game.GetCurrentPlayer(), bluePlayer);

            game.NewTurn();

            // Switching turns in a simple game when it is the blue player's turn,
            // it should now be the red player's turn
            Assert.AreSame(game.GetCurrentPlayer(), redPlayer);

            // UT #10

            game.NewTurn();

            // Switching turns in a simple game when it is the red player's turn,
            // it should now be the blue player's turn
            Assert.AreSame(game.GetCurrentPlayer(), bluePlayer);





        }
 
    }
}
