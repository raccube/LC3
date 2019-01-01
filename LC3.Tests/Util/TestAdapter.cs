using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC3.IO;

namespace LC3.Tests.Util {
    public class TestAdapter : IIOAdapter {
        public Queue<char> input = new Queue<char>();
        public StringBuilder output = new StringBuilder();

        public void Write(char c) => output.Append(c);
        public void Write(string s) => output.Append(s);
        public void WriteLine(char[] chars) => output.Append(chars);
        public void WriteLine(string s) => output.AppendLine(s);
        public char ReadKey() => input.Dequeue();

        public void ClearOutput() => output.Clear();
        public string GetOutput() => output.ToString();
        public void AddInput(string s) => s.ToList().ForEach(input.Enqueue);
    }
}