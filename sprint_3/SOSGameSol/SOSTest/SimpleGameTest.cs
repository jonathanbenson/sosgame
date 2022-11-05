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
        int boardSizeDefault;
        int boardSizeUpperLimit;
        int boardSizeLowerLimit;
        private SimpleGame game;

        [TestInitialize()]
        public void Initialize()
        {
            boardSizeDefault = 8;
            boardSizeUpperLimit = 12;
            boardSizeLowerLimit = 6;

            game = new SimpleGame();
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }


        [TestMethod]
        public void TestIsOver()
        {
            Assert.IsFalse(game.IsOver());
        }

        [TestMethod]
        public void TestNewTurn()
        {
            
        }
 
    }
}
