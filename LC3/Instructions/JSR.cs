using System;

namespace LC3.Instructions {
    public class JSR : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var flag = mdr >> 11;
            if ((flag & 1) == 0) {
                throw new NotImplementedException("Yo dog you messed up");
            }
            var offset = mdr & 0b111_1111_1111;

            processor[Register.R7] = (ushort) (processor[Register.PC] + 1);

            processor[Register.PC] = (ushort) (processor[Register.PC] + offset);
            
            Console.WriteLine($"JSR\t{offset}");
        }
    }
}