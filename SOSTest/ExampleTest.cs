
using SOSLogic;

namespace SOSTest
{
    [TestClass]
    public class ExampleTest
    {
        [TestMethod]
        public void Test_getTrue()
        {
            Example example = new Example();

            Assert.IsTrue(example.getTrue());

        }

        [TestMethod]
        public void test_getFalse()
        {
            Example example = new Example();

            Assert.IsFalse(example.getFalse());
        }
    }
}