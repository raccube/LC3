using System;

namespace LC3.IO {
    public class ConsoleAdapter : IIOAdapter {
        public void Write(char c) => Console.Write(c);

        public void Write(string s) => Console.Write(s);

        public void WriteLine(char[] chars) => Console.WriteLine(chars);

        public void WriteLine(string s) => Console.WriteLine(s);

        public char ReadKey() => Console.ReadKey().KeyChar;
    }
}