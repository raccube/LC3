using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LC3 {
    internal static class Program {
        private static void Main(string[] args) {
            if (args.Length > 0) {
                var filename = args.TakeLast(1);
                var bytes = File.ReadAllBytes(filename.First());
                Start(bytes, args.Contains("-d"));
            }
        }

        private static IEnumerable<ushort> GetShorts(byte[] bytes) {
            return bytes.InSetsOf(2)
                .Select(i => {
                    i.Reverse();
                    return BitConverter.ToUInt16(i.ToArray());
                });
        }
        private static void Start(byte[] bytes, bool disassemble) {
            var proc = new Processor(disassemble);
            var data = GetShorts(bytes).ToArray();
            
            var origin = data[0];

            Debug.WriteLine($"Origin: {origin}");
            var payload = data.Skip(1).ToArray();
            for (ushort i = 0; i < payload.Length; i++) {
                var location = (ushort) (origin + i);
                proc.Memory.Put(location, payload[i]);
            }

            proc[Register.PC] = origin;

            while (true) {
                // Fetch & Execute
                proc.Decode(proc.Fetch()).Call(proc);
            }
            
        }
    }
}