using LC3.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC3.Tests {
    [TestClass]
    public class InstructionTests {
        [TestMethod]
        public void LD() {
            var proc = new Processor {
                [Register.MemoryData] = ((int) OpCode.ADD << 12) +
                                        ((int) Register.R5 << 9) +
                                        3,
                [Register.PC] = 0xA3
            };
            
            proc.Memory[0xA6] = 236;
            
            new LD().Call(proc);
            Assert.AreEqual(236, proc[Register.R5]);
        }

        [TestMethod]
        public void LEA() {
            var proc = new Processor {
                [Register.MemoryData] = ((int) OpCode.LEA << 12) +
                                        ((int) Register.R3 << 9) +
                                        7,
                [Register.PC] = 0x9D,
            };

            proc.Memory[0x9D] = 7;
        }
    }
}