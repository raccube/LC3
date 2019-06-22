namespace LC3.Instructions {
    public class STI : Instruction {
        public STI(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.DR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.PCOffset, instruction & 0b1_1111_1111);
        }

        public override void Call(Processor processor) {
            throw new System.NotImplementedException();
        }
    }
}