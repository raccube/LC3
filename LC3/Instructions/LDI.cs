using System;

namespace LC3.Instructions {
    public class LDI : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var register = (Register)(mdr >> 9 & 0b111);
            var ptr = mdr & 0b1_1111_1111;
            
            var result = (short) processor.Memory[processor.Memory[ptr]];
            processor[register] = result;
            processor[Register.Flag] = BR.MapResult(result);

            if (Program.Disassemble) {
                Console.WriteLine($"LDI\t{register}, #{ptr:X}");
            }
        }
    }
}