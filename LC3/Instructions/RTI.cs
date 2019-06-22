namespace LC3.Instructions {
    public class RTI : Instruction {
        public RTI(int instruction, int location) : base(instruction, location) {
        }

        public override void Call(Processor processor) {
            throw new System.NotImplementedException();
        }
    }
}