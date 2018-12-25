using System;

namespace LC3.Instructions {
    public class STR : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var offset = mdr & 0b11_1111;
            var baseR = (Register) (mdr << 6 & 0b1_11);
            var sr = (Register) (mdr << 9 & 0b111);

            processor.Memory[(ushort) (processor[baseR] + offset)] = processor[sr];

            if (Program.Disassemble) {
                Console.WriteLine($"STR\t{sr}, {baseR}, #{offset}");
            }
        }
    }
}