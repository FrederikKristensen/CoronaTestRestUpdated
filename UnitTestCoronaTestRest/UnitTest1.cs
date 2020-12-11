using System.Collections.Generic;
using CoronaTestRest.Controllers;
using CoronaTestRest.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCoronaTestRest
{
    [TestClass]
    public class UnitTest1
    {
        private CoronaTestsController cntr = null;

        [TestInitialize]
        public void BeforeEachTest()
        {
            cntr = new CoronaTestsController();
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<CoronaTest> liste = new List<CoronaTest>(cntr.Get());

            Assert.AreEqual(8, liste.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<CoronaTest> liste = new List<CoronaTest>(cntr.GetHighTemperature());

            Assert.AreEqual(4, liste.Count);
        }
    }
}
