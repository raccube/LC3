namespace LC3.Instructions {
    public class NOT : Instruction {
        public NOT(int instruction, int location) : base(instruction, location) {
            AddArgument(ArgumentType.DR, instruction >> 9 & 0b111);
            AddArgument(ArgumentType.SR, instruction >> 6 & 0b111);
        }

        public override void Call(Processor processor) {
            throw new System.NotImplementedException();
        }
    }
}