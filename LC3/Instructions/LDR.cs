using System;

namespace LC3.Instructions {
    public class LDR : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var offset = mdr & 0b11_1111;
            var baseRegister = (Register) (mdr >> 6 & 0b111);
            var dest = (Register) (mdr >> 9 & 0b111);

            var result = (short) processor.Memory[processor[baseRegister] + offset];
            processor[dest] = result;
            processor[Register.Flag] = BR.MapResult(result);
            
            if (Program.Disassemble) {
                Console.WriteLine($"LDR\t{dest}, {baseRegister}, #{offset:X}");
            }
        }
    }
}