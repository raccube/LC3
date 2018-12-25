using System;
using LC3.Instructions;

namespace LC3 {
    public class Instruction {
        public static IInstruction Get(ushort opcode) {
            return Get((OpCode) opcode);
        }
        
        public static IInstruction Get(int opcode) {
            return Get((OpCode) opcode);
        }

        public static IInstruction Get(OpCode opcode) {
            switch (opcode) {
                case OpCode.LD:
                    return new LD();
                case OpCode.LEA:
                    return new LEA();
                case OpCode.TRAP:
                    return new TRAP();
                case OpCode.JSR:
                    return new JSR();
                case OpCode.STR:
                    return new STR();
                case OpCode.ADD:
                    return new ADD();
                default:
                    throw new NotImplementedException($"Opcode not implemented {opcode}");
            }
        }
    }
}