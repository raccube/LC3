using System;

namespace LC3.Instructions {
    public class ADD : IInstruction {
        public void Call(Processor processor) {
            var mdr = processor[Register.MemoryData];
            var dest = (Register) (mdr >> 9 & 0b111);
            var sr1 = (Register) (mdr >> 6 & 0b111);
            var leftVal = processor[sr1];
            var fromImmediate = mdr >> 5 & 1;

            int rightVal;
            if (fromImmediate == 1) {
                rightVal = mdr & 0b1_1111;
                if (Program.Disassemble) {
                    Console.WriteLine($"ADD\t{dest}, {sr1}, #{rightVal:X}");
                }
            } else {
                var sr2 = (Register) (mdr & 0b111);
                rightVal = processor[sr2];
                if (Program.Disassemble) {
                    Console.WriteLine($"ADD\t{dest}, {sr1}, {sr2}");
                }
            }

            var result = (short) (leftVal + rightVal);
            processor[dest] = result;
            processor[Register.Flag] = BR.MapResult(result);
        }
    }
}