using SOSLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSLogic;
using System.Drawing;

namespace SOSTest
{
    [TestClass]
    public class HumanPlayerTest
    {
        private HumanPlayer player;

        [TestInitialize()]
        public void Initialize()
        {
            player = new HumanPlayer(new SimpleGame(), Color.Blue);
        }

        [TestMethod]
        public void TestGetPlayerType()
        {
            // UT #6
            Assert.AreEqual(player.GetPlayerType(), PlayerType.Human);
        }
    }
}
