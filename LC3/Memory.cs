using static System.UInt16;

namespace LC3 {
    public class Memory {
        private readonly ushort[] _memory = new ushort[MaxValue + 1];

        public Memory() {
            // Initialise memory with zeroes.
            for (var i = 0; i < MaxValue + 1; i++) {
                _memory[i] = 0;
            }
        }

        public ushort Get(ushort location) {
            return _memory[location];
        }

        public void Put(ushort location, ushort value) {
            _memory[location] = value;
        }

        public ushort this[ushort key] {
            get => Get(key);
            set => Put(key, value);
        }
    }
}