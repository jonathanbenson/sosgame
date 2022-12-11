using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOSLogic.Test
{
    [TestClass]
    public class ReplayTest
    {
        [TestMethod]
        public void TestGetNextMoveEntry()
        {
            // Arrange
            var replay = new Replay();
            replay.Parse("PreviousGame.txt");

            // AC #7.3 -> User replays game outside of a game with previous game played
            var moveEntry1 = replay.GetNextMoveEntry();
            var moveEntry2 = replay.GetNextMoveEntry();
            var moveEntry3 = replay.GetNextMoveEntry();
            var moveEntry4 = replay.GetNextMoveEntry();
            var moveEntry5 = replay.GetNextMoveEntry();

            // Assert
            Assert.AreEqual("computer", moveEntry1.playerType);
            Assert.AreEqual("blue", moveEntry1.color);
            Assert.AreEqual("S", moveEntry1.moveType);
            Assert.AreEqual(2, moveEntry1.row);
            Assert.AreEqual(3, moveEntry1.col);

            Assert.AreEqual("computer", moveEntry2.playerType);
            Assert.AreEqual("red", moveEntry2.color);
            Assert.AreEqual("S", moveEntry2.moveType);
            Assert.AreEqual(3, moveEntry2.row);
            Assert.AreEqual(0, moveEntry2.col);

            Assert.AreEqual("computer", moveEntry3.playerType);
            Assert.AreEqual("blue", moveEntry3.color);
            Assert.AreEqual("S", moveEntry3.moveType);
            Assert.AreEqual(2, moveEntry3.row);
            Assert.AreEqual(0, moveEntry3.col);

            Assert.AreEqual("computer", moveEntry4.playerType);
            Assert.AreEqual("red", moveEntry4.color);
            Assert.AreEqual("S", moveEntry4.moveType);
            Assert.AreEqual(3, moveEntry4.row);
            Assert.AreEqual(2, moveEntry4.col);

            Assert.AreEqual("computer", moveEntry5.playerType);
            Assert.AreEqual("blue", moveEntry5.color);
            Assert.AreEqual("O", moveEntry5.moveType);
            Assert.AreEqual(3, moveEntry5.row);
            Assert.AreEqual(1, moveEntry5.col);
        }

        [TestMethod]
        public void TestAtEnd()
        {
            // Arrange
            var replay = new Replay();
            replay.Parse("PreviousGame.txt");

            // Act
            Assert.IsFalse(replay.AtEnd());

            var moveEntry1 = replay.GetNextMoveEntry();
            Assert.IsFalse(replay.AtEnd());

            var moveEntry2 = replay.GetNextMoveEntry();
            Assert.IsFalse(replay.AtEnd());

            var moveEntry3 = replay.GetNextMoveEntry();
            Assert.IsFalse(replay.AtEnd());

            var moveEntry4 = replay.GetNextMoveEntry();
            Assert.IsTrue(replay.AtEnd());

        }
    }
}