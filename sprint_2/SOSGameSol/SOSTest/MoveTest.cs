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
    public class MoveTest
    {
    
        public void TestDoesConflict()
        {


            Game game = new SimpleGame();
            Player player1 = new HumanPlayer(game, Color.Blue);
            Player player2 = new HumanPlayer(game, Color.Red);
            
            
            // UT #8

            for (int row = 0; row < game.GetBoardSize(); ++row)
                for (int col = 0; col < game.GetBoardSize(); ++col)
                    foreach (MoveType moveType1 in Enum.GetValues(typeof(MoveType)))
                        foreach (MoveType moveType2 in Enum.GetValues(typeof(MoveType)))
                        {
                            Move move1 = new Move(player1, moveType1, row, col);
                            Move move2 = new Move(player2, moveType2, row, col);

                            // Check that the moves conflict if and only if they have the same column and row
                            Assert.IsTrue(move1.DoesConflict(move2));
                        }
        }
    
    }
}
