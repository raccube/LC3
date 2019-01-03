using System;

namespace LC3.Instructions {
    public class LD : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var register = (Register)(mdr >> 9 & 0b111);
            var value = mdr & 0b1_1111_1111;
            
            var result = (short) processor.Memory[processor[Register.PC] + value];
            processor[register] = result;
            processor[Register.Flag] = BR.MapResult(result);

            if (Program.Disassemble) {
                Console.WriteLine($"LD\t{register}, #{value:X}");
            }
        }
    }
}