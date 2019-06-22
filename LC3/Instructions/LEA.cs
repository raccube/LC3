using System;

namespace LC3.Instructions {
    public class LEA : Instruction {
        public LEA(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.BaseR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.PCOffset, instruction & 0b1_1111_1111);
        }

        public override void Call(Processor processor) {
            var register = (Register) GetArgument(0);
            var value = GetArgument(1);

            var result = (short) (processor[Register.PC] + (int) value);
            processor[register] = result;
            processor[Register.Flag] = BR.MapResult(result);
        }
    }
}