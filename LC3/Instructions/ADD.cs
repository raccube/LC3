using System;

namespace LC3.Instructions {
    public class ADD : Instruction {
        public ADD(int instruction, int location) : base(instruction, location) {
            // Dest
            AddArgument(ArgumentType.DR, instruction >> 9 & 0b111);
            // SR1
            AddArgument(ArgumentType.SR, instruction >> 6 & 0b111);
            if ((instruction >> 5 & 1) == 0) {
                AddArgument(ArgumentType.SR, instruction & 0b111);
            } else {
                AddArgument(ArgumentType.ImmediateValue, instruction & 0b1_1111);
            }
        }

        public override void Call(Processor processor) {
            var dest = (Register) GetArgument(0);
            var sr1 = (Register) GetArgument(1);
            var leftVal = processor[sr1];

            var (type, rightVal) = GetArguments()[2];
            if (type == ArgumentType.ImmediateValue) {
                rightVal = (int) rightVal;
            } else {
                var sr2 = (Register) rightVal;
                rightVal = processor[sr2];
            }

            var result = (short) (leftVal + (int) rightVal);
            processor[dest] = result;
            processor[Register.Flag] = BR.MapResult(result);
        }
    }
}