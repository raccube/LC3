using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC3.Tests {
    [TestClass]
    public class MemoryTests {
        [TestMethod]
        public void Put() {
            Memory m = new Memory();
            m[0x42] = 0x11;
            Assert.AreEqual(0x11, m[0x42]);
        }
    }
}