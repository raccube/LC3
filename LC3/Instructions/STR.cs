using System;

namespace LC3.Instructions {
    public class STR : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var offset = mdr & 0b0000_0000_0011_1111;
            var baseR = (Register) (mdr << 6 & 0b0000_0001_11);
            var sr = (Register) (mdr << 9 & 0b0000_111);

            processor.Memory[(ushort) (processor[baseR] + offset)] = processor[sr];

            if (Program.Disassemble) {
                Console.WriteLine($"STR\t{sr}, {baseR}, #{offset}");
            }
        }
    }
}