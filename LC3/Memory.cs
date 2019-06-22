using static System.UInt16;

namespace LC3 {
    public class Memory {
        private readonly ushort[] _memory = new ushort[MaxValue + 1];
        private readonly IInstruction[] _jit = new IInstruction[MaxValue + 1];

        public Memory() {
            // Initialise memory with zeroes.
            for (var i = 0; i < MaxValue + 1; i++) {
                _memory[i] = 0;
            }
        }

        private ushort Get(ushort location) => _memory[location];
        public IInstruction GetInstr(int location) => _jit[location];

        public void Put(ushort location, ushort value) {
            _memory[location] = value;
            _jit[location] = Instruction.Get(value, location);
        }

        public ushort this[int key] {
            get => this[(ushort) key];
            set => this[(ushort) key] = value;
        }


        public ushort this[ushort key] {
            get => Get(key);
            set => Put(key, value);
        }
    }
}