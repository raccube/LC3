using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LC3 {
    internal static class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Hello Dög!");
            if (args.Length > 0) {
                var bytes = File.ReadAllBytes(args[0]);
                Start(bytes);
            }
        }

        private static void Start(byte[] bytes) {
            var proc = new Processor();
            
            var originBytes = bytes.Take(2);
            if (BitConverter.IsLittleEndian)
                originBytes = originBytes.Reverse();

            ushort origin = BitConverter.ToUInt16(originBytes.ToArray());

            Debug.WriteLine($"Origin: {origin}");
            var payload = bytes.Skip(2).ToArray();
            for (ushort i = 0; i < payload.Length; i++) {
                var location = (ushort) (origin + i);
                proc.Memory.Put(location, payload[i]);
            }

            proc[Register.ProgramCounter] = origin;
            proc.Fetch();
        }
    }
}