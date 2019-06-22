namespace LC3.Instructions {
    public class RET : Instruction {
        public RET(int instruction, int location) : base(instruction, location) {
        }

        public override void Call(Processor processor) {
            throw new System.NotImplementedException();
        }
    }
}