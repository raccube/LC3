using System;

namespace LC3.Instructions {
    public class LDR : Instruction {
        public LDR(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.DR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.BaseR, instruction >> 6 & 0b111);
            AddArgument(ArgumentType.Offset, instruction & 0b11_1111);
        }

        public override void Call(Processor processor) {
            var result = (short) processor.Memory[processor[(Register) GetArgument(1)] + (int) GetArgument(2)];
            processor[(Register) GetArgument(0)] = result;
            processor[Register.Flag] = BR.MapResult(result);
        }
    }
}