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
    public class PlayerTest
    {
        private HumanPlayer player;

        [TestInitialize()]
        public void Initialize()
        {
            player = new HumanPlayer(new SimpleGame(), Color.Blue);
        }

        [TestMethod]
        public void TestSetMoveType()
        {
            // AC 8.2 - User does not select a move option
            // the default move type will be set to MoveType.S
            Assert.AreEqual(player.GetMoveType(), MoveType.S);


            // AC 8.1 - User attempts to select an invalid move type
            Assert.ThrowsException<ArgumentException>(() => player.SetMoveType((MoveType)(-1)));

            
            // AC 8.3 - User selects a valid move type with the values S or O

            // the move type should be set to the value passed in
            player.SetMoveType(MoveType.S);
            Assert.AreEqual(MoveType.S, player.GetMoveType());

            player.SetMoveType(MoveType.O);
            Assert.AreEqual(MoveType.O, player.GetMoveType());

        }
    
    }
}
