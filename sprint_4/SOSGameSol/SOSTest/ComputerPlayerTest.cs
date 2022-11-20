using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSLogic;
using System.Drawing;

namespace SOSTest
{
    [TestClass]
    public class ComputerPlayerTest
    {
        private ComputerPlayer player;

        [TestInitialize()]
        public void Initialize()
        {
            player = new ComputerPlayer(new SimpleGame(), Color.Blue);
        }

        [TestMethod]
        public void TestGetPlayerType()
        {
            // UT #5
            Assert.AreEqual(player.GetPlayerType(), PlayerType.Computer);
        }

        [TestMethod]
        public void TestMakeSimpleMove()
        {
            // create a new simple game with two computer players
            SimpleGame simpleGame = new SimpleGame(8, PlayerType.Computer, PlayerType.Computer);

            while (!simpleGame.IsOver())
            {
                ComputerPlayer currentPlayer = (ComputerPlayer)simpleGame.GetCurrentPlayer();

                bool firstCoinFlip = CoinFlip.IsHeads();
                bool secondCoinFlip = CoinFlip.IsHeads();

                bool existsSOSOpportunity = simpleGame.GetSOSOpportunities().Count > 0 ? true : false;

                currentPlayer.MakeSimpleMove(firstCoinFlip, secondCoinFlip);

                if (existsSOSOpportunity && firstCoinFlip && secondCoinFlip)
                {
                    // AC 8.3 -> Computer makes a move when there is an opportunity to complete an SOS in a simple game

                    // if there was an opportunity to complete an SOS
                    // ... and both coin flips were heads
                    // ... then the computer should have chosen to complete the SOS and win the game
                    Assert.AreEqual(simpleGame.GetSOSLines().Count, 1);
                    Assert.IsTrue(simpleGame.IsOver());
                }
                else
                {
                    // AC 8.1 -> Computer makes a move on an empty board in a simple game or general game

                    // AC 8.2 -> Computer makes a move on a nonempty board in a simple game or general game
                    // ... when there is no opportunity to complete an SOS


                    // if there was not an opportunity to complete an SOS or one of the coin tosses was not heads
                    // ... then the computer should have chosen to not complete the SOS
                    // ... and instead make a move on a randomly selected empty cell
                    Assert.AreEqual(simpleGame.GetSOSLines().Count, 0);
                    Assert.IsTrue(!simpleGame.IsOver());
                }
            }
        }

        [TestMethod]
        public void TestMakeGeneralMove()
        {
            // AC 8.1 -> Computer makes a move on an empty board in a simple game or general game

            // AC 8.2 -> Computer makes a move on a nonempty board in a simple game or general game
            // ... when there is no opportunity to complete an SOS

            // AC 8.4 -> Computer makes a move when there is an opportunity to complete only one SOS in a general game

            // AC 8.5 -> Computer makes a move when there are multiple opportunities to complete
            // ... an SOS in a general game
        }
    }
}
