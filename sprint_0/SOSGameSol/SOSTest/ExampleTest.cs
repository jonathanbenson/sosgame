
using SOSLogic;

namespace SOSTest
{
    [TestClass]
    public class ExampleTest
        // Tests the SOSLogic.Example class
    {
        [TestMethod]
        public void TestGetTrue()
            // Tests the SOSLogic.Example.GetTrue method
        {
            Example example = new Example();

            // Expect the method to return true
            Assert.IsTrue(example.GetTrue());

        }

        [TestMethod]
        public void TestGetFalse()
        // Tests the SOSLogic.Example.GetFalse method
        {
            Example example = new Example();

            // Expect the method to return flase
            Assert.IsFalse(example.GetFalse());
        }
    }
}