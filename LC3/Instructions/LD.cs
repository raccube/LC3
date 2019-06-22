using System;

namespace LC3.Instructions {
    public class LD : Instruction {
        public LD(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.DR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.PCOffset, instruction & 0b1_1111_1111);
        }

        public override void Call(Processor processor) {
            var register = (Register) GetArgument(0);
            var value = (int) GetArgument(1);
            
            var result = (short) processor.Memory[processor[Register.PC] + value];
            processor[register] = result;
            processor[Register.Flag] = BR.MapResult(result);
        }
    }
}