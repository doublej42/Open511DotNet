using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open511DotNet;

namespace _511Tests
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void TestListing()
        {
            var est = new EventSubType();
            var dict = est.ToDictionary();
            Assert.IsTrue(dict.Count > 2);
            Assert.IsTrue(dict.ContainsKey("ACCIDENT"));
            Assert.IsTrue(dict.ContainsValue("road maintenance"));
            Assert.IsTrue(dict["EMERGENCY_MAINTENANCE"] == "emergency maintenance");
        }
    }
}
