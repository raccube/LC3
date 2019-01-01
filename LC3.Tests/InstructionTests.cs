using LC3.Instructions;
using LC3.Tests.Util;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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

        [TestMethod]
        public void TRAP_PutS() {
            var proc = new Processor {
                [Register.MemoryData] = ((int) OpCode.TRAP << 12) +
                                        (int) TrapVector.PutS,
                [Register.R0] = 0x6A,
                Memory = {
                    [0x6A] = 'T',
                    [0x6B] = 'e',
                    [0x6C] = 's',
                    [0x6D] = 't'
                }
            };
            
            var io = new TestAdapter();
            Program.IoAdapter = io;
            new TRAP().Call(proc);

            Assert.AreEqual("Test\0", io.GetOutput());
        }
    }
}