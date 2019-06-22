using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using LC3.Instructions;

namespace LC3 {
    public abstract class Instruction : IInstruction {
        #region Static Methods

        private static readonly Dictionary<int, Type> opcodeMap = new Dictionary<int, Type>();

        public static Type FindType(ushort instruction) {
            int opcode = instruction >> 12;
            if (!opcodeMap.ContainsKey(opcode)) {
                var types = Assembly.GetExecutingAssembly().GetTypes();
                var instructionOpcode = (OpCode) opcode;
                var type = types.FirstOrDefault(t => t.Name == instructionOpcode.ToString()) ??
                           throw new NotImplementedException($"Opcode not implemented: {instructionOpcode}");
                opcodeMap[opcode] = type;
            }

            return opcodeMap[opcode];
        }

        #endregion

        public Instruction(int instruction, int location) {
            Name = this.GetType().Name;
            Location = location;
        }

        protected string Name {
            get => _name ?? GetType().Name;
            set => _name = value;
        }

        private string _name;
        protected int Location;

        public abstract void Call(Processor processor);

        private readonly List<Tuple<ArgumentType, ValueType>> args = new List<Tuple<ArgumentType, ValueType>>();

        protected void AddArgument(ArgumentType type, ValueType value) {
            args.Add(new Tuple<ArgumentType, ValueType>(type, value));
        }

        protected List<Tuple<ArgumentType, ValueType>> GetArguments() => args;

        public string Disassemble() {
            var prefix = $"0x{Location:X}:\t{Name}\t";
            
            var s = new List<string>();
            foreach (var (type, value) in args) {
                switch (type) {
                    case ArgumentType.BaseR:
                    case ArgumentType.DR:
                    case ArgumentType.SR:
                        s.Add(((Register) value).ToString());
                        break;
                    case ArgumentType.ImmediateValue:
                    case ArgumentType.PCOffset:
                    case ArgumentType.Offset:
                        s.Add($"#{value:X}");
                        break;
                    case ArgumentType.TrapVector:
                        s.Add(((TrapVector) value).ToString());
                        break;
                    case ArgumentType.CondFlags:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return prefix + string.Join(", ", s);
        }

        public ValueType GetArgument(int index) => args[index].Item2;

        public static IInstruction Get(ushort value, ushort location) {
            var type = FindType(value);
            try {
                return (IInstruction) type.GetConstructor(new[] {typeof(int), typeof(int)})
                    .Invoke(new object[] {value, location});
            } catch (Exception e) {
                throw new NotImplementedException($"No valid constructor found for {type.Name}");
            }
        }
    }
}