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
        public void TestMakeMove()
        {

        }
    }
}
