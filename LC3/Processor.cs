using System;
using System.Diagnostics;

namespace LC3 {
    public class Processor {
        private readonly short[] _registers = new short[12];
        public readonly Memory Memory = new Memory();
        
        public short GetRegister(int register) => _registers[register];

        public void SetRegister(int register, short value) => _registers[register] = value;
        public void SetRegister(int register, ushort value) => _registers[register] = (short)value;


        public short this[int key] {
            get => GetRegister(key);
            set => SetRegister(key, value);
        }

        public short this[Register key] {
            get => this[(int) key];
            set => this[(int) key] = value;
        }

        public void Increment(Register register) {
            this[register]++;
        }

        public IInstruction Fetch() {
            this[Register.MemoryAddress] = this[Register.PC];
            Increment(Register.PC);
            return Memory.GetInstr(this[Register.PC] - 1);
        }
    }
}