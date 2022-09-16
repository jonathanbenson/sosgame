
using SOSLogic;

namespace SOSTest
{
    [TestClass]
    public class ExampleTest
    {
        [TestMethod]
        public void TestGetTrue()
        {
            Example example = new Example();

            Assert.IsTrue(example.GetTrue());

        }

        [TestMethod]
        public void TestGetFalse()
        {
            Example example = new Example();

            Assert.IsFalse(example.GetFalse());
        }
    }
}