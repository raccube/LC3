using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LC3 {
    public class Instruction {
        public static Dictionary<OpCode, IInstruction> opcodeMap = new Dictionary<OpCode, IInstruction>();
        
        public static IInstruction Get(ushort opcode) {
            return Get((OpCode) opcode);
        }
        
        public static IInstruction Get(int opcode) {
            return Get((OpCode) opcode);
        }

        public static IInstruction Get(OpCode opcode) {
            if (!opcodeMap.ContainsKey(opcode)) {
                var types = Assembly.GetExecutingAssembly().GetTypes();
                var type = types.FirstOrDefault(t => t.Name == opcode.ToString()) ??
                           throw new NotImplementedException($"Opcode not implemented: {opcode}");
                opcodeMap[opcode] = (IInstruction) Activator.CreateInstance(type);
            }

            return opcodeMap[opcode];
        }
    }
}