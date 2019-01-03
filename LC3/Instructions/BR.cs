using System;

namespace LC3.Instructions {
    public class BR : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var value = mdr & 0b1_1111_1111;
            var flags = (CondFlags) (mdr >> 9 & 0b111);
            var lastResult = (CondFlags) processor[Register.Flag];

            if (flags.HasFlag(lastResult)) {
                processor[Register.PC] = (short) value;
            }

            if (Program.Disassemble) {
                Console.WriteLine($"BR{flags.GetDescription().ToLower()}\t#{value:X}");
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