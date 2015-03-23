using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelosColor.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRgbHex()
        {
            string[] correctValues = { "#345F78", "345f78", "000000", "#000000" };
            string[] incorrectValues = { "#3456G8", "3456G8", "000000 ", "#0000000", "1111","#1111" };
            foreach (var item in correctValues)
            {
                Assert.IsTrue(ModelosColor.Core.RgbColor.ValidHex(item));
            }
            foreach (var item in incorrectValues)
            {
                Assert.IsFalse(ModelosColor.Core.RgbColor.ValidHex(item));
            }
        }
    }
}
