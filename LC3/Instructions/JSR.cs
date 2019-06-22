using System;

namespace LC3.Instructions {
    public class JSR : Instruction {
        public JSR(int instruction, int location) : base(instruction, location) {
            var flag = instruction >> 11;
            if ((flag & 1) == 0) {
                Name += "R";
                AddArgument(ArgumentType.BaseR, instruction >> 6 & 0b111);
            } else {
                AddArgument(ArgumentType.PCOffset, instruction & 0b111_1111_1111);
            }
        }

        public override void Call(Processor processor) {
            processor[Register.R7] = (short) (processor[Register.PC] + 1);
            processor[Register.PC] = (short) (processor[Register.PC] + (int) GetArgument(0));
        }
    }
}