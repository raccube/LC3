using System;

namespace LC3.Instructions {
    public class LD : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var register = (Register)(mdr >> 9 & 0b111);
            var value = mdr & 0b1_1111_1111;
            processor[register] = processor.Memory[(ushort) (processor[Register.PC] + (ushort)value)];
            
            Console.WriteLine($"LD\t{register}, ${value:X}");
        }
    }
}