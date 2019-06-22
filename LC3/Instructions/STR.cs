using System;

namespace LC3.Instructions {
    public class STR : Instruction {
        public STR(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.SR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.BaseR, instruction >> 6 & 0b111);
            AddArgument(ArgumentType.Offset, instruction & 0b11_1111);
        }
        
        public override void Call(Processor processor) {
            var sr = (int) GetArgument(0);
            var baseR = (int) GetArgument(1);
            var offset = (int) GetArgument(2);
            
            processor.Memory[(ushort) (processor[baseR] + offset)] = (ushort) processor[sr];
        }
    }
}