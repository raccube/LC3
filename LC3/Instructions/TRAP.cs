using System;

namespace LC3.Instructions {
    public class TRAP : Instruction {
        public TRAP(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.TrapVector, instruction & 0b1111_1111);
        }

        public override void Call(Processor processor) {
            var vector = (TrapVector) GetArgument(0);

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
        }
    }
}