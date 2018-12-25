using System;

namespace LC3.Instructions {
    public class TRAP : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var vector = (TrapVector)(mdr & 0b1111_1111);

            switch (vector) {
                case TrapVector.PutS:
                    char c;
                    int i = processor[Register.R0];
                    do {
                        c = (char) processor.Memory[(ushort)i];
                        if (Program.Output) Program.IoAdapter.Write(c);
                        i++;
                    } while (c != 0x0);

                    break;
                default:
                    throw new NotImplementedException($"Unknown TRAP Vector: {vector}");                    
            }

            if (Program.Disassemble) {
                Console.WriteLine($"TRAP\t{vector}");
            }
        }
    }
}