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
            return (IInstruction) Activator.CreateInstance(types.First(type => type.Name == opcode.ToString()));
        }
    }
}