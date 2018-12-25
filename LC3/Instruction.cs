using System;
using System.Linq;
using System.Reflection;

namespace LC3 {
    public class Instruction {
        public static IInstruction Get(ushort opcode) {
            return Get((OpCode) opcode);
        }
        
        public static IInstruction Get(int opcode) {
            return Get((OpCode) opcode);
        }

        public static IInstruction Get(OpCode opcode) {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var type = types.FirstOrDefault(t => t.Name == opcode.ToString()) ??
                       throw new NotImplementedException($"Opcode not implemented: {opcode}");
            return (IInstruction) Activator.CreateInstance(type);
        }
    }
}