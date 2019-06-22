using System;

namespace LC3.Instructions {
    public class BR : Instruction {
        public BR(int instruction, int location) : base(instruction, location) {
            var flags = (CondFlags) (instruction >> 9 & 0b111);
            Name += flags.GetDescription().ToLower();
            AddArgument(ArgumentType.CondFlags, flags);
            AddArgument(ArgumentType.PCOffset, instruction & 0b1_1111_1111);
        }

        public override void Call(Processor processor) {
            var lastResult = (CondFlags) processor[Register.Flag];
            if (((CondFlags) GetArgument(0)).HasFlag(lastResult)) {
                processor[Register.PC] = Convert.ToInt16(GetArgument(1));
            }
        }

        public static short MapResult(short result) {
            if (result < 0) {
                return (short) CondFlags.N;
            }

            return (short) (result == 0 ? CondFlags.Z : CondFlags.P);
        }
    }
}