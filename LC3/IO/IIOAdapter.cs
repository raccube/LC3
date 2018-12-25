namespace LC3.IO {
    public interface IIOAdapter {
        void Write(char c);
        void Write(string s);

        void WriteLine(char[] chars);
        void WriteLine(string s);

        char ReadKey();
    }
}