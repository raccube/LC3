namespace LC3 {
    public enum OpCode {
        /// <summary>Branch</summary>
        BR = 0b0000,
        /// <summary>Add</summary>
        ADD = 0b0001,
        /// <summary>Load</summary>
        LD = 0b0010,
        ST = 0b0011,
        /// <summary>Jump Register</summary>
        JSR = 0b0100,
        /// <summary>Bitwise AND</summary>
        AND = 0b0101,
        /// <summary>Load Register</summary>
        LDR = 0b0110,
        /// <summary>Store Register</summary>
        STR = 0b0111,
        /// <summary>Reserved</summary>
        RTI = 0b1000,
        /// <summary>Bitwise NOT</summary>
        NOT = 0b1001,
        RET = 0b1100,
        /// <summary>Indirect Load</summary>
        LDI = 0b1010,
        /// <summary>Indirect Store</summary>
        STI = 0b1011,
        /// <summary>Jump</summary>
        JMP = 0b1100,
        /// <summary>Reserved</summary>
        RES = 0b1101,
        /// <summary>Load Effective Address</summary>
        LEA = 0b1110,
        /// <summary>Interrupt</summary>
        TRAP = 0b1111,
    }
}