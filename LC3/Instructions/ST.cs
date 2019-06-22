namespace LC3.Instructions {
    public class ST : Instruction {
        public ST(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.SR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.PCOffset, instruction & 0b1_1111_1111);
        }

        public override void Call(Processor processor) {
            throw new System.NotImplementedException();
        }
    }
}