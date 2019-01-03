using System;
using System.ComponentModel;

namespace LC3 {
    [Flags]
    public enum CondFlags : short {
        [Description("")]
        None = 0,
        [Description("p")]
        P = 1,
        [Description("z")]
        Z = 2,
        [Description("zp")]
        ZP = 3,
        [Description("n")]
        N = 4,
        [Description("np")]
        NP = 5,
        [Description("nz")]
        NZ = 6,
        [Description("nzp")]
        All = 7
    }
}