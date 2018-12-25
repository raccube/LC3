using System;

namespace LC3.Instructions {
    public class LDR : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var offset = mdr & 0b11_1111;
            var baseRegister = (Register) (mdr >> 6 & 0b111);
            var dest = (Register) (mdr >> 9 & 0b111);

            processor[dest] = processor.Memory[processor[baseRegister] + offset];
            if (Program.Disassemble) {
                Console.WriteLine($"LDR\t{dest}, {baseRegister}, #{offset}");
            }
        }
    }
}