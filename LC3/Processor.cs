namespace LC3 {
    public class Processor {
        private ushort[] _registers = new ushort[10];

        public ushort GetRegister(int register) {
            return _registers[register];
        }

        public void SetRegister(int register, ushort value) {
            _registers[register] = value;
        }
        
        public ushort this[ushort key] {
            get => GetRegister(key);
            set => SetRegister(key, value);
        }
    }
}