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

        public short Fetch() {
            this[Register.MemoryAddress] = this[Register.PC];
            Increment(Register.PC);
            this[Register.MemoryData] = (short) Memory[this[Register.MemoryAddress]];
            return this[Register.MemoryData];
        }

        public IInstruction Decode(ushort instruction) {
            var opcode = instruction >> 12;
            Debug.WriteLine($"Opcode: {Convert.ToString(opcode, 2).PadLeft(4, '0')}");
            return Instruction.Get(opcode);
        }

        public IInstruction Decode(short instruction) => Decode((ushort) instruction);
    }
}