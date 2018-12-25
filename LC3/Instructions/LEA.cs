using System;

namespace LC3.Instructions {
    public class LEA : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var register = (Register)(mdr >> 9 & 0b111);
            var value = mdr & 0b1_1111_1111;
            processor[register] = (ushort) (processor[Register.PC] + (ushort)value);

            if (Program.Disassemble) {
                Console.WriteLine($"LEA\t{register}, ${value:X}");
            }
        }
    }
}