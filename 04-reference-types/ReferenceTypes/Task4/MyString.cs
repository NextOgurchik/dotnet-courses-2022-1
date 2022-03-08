using System.Linq;

namespace Task4
{
    internal class MyString
    {
        public char[] CharString { get; set; }

        public MyString(char[] charString)
        {
            CharString = charString;
        }
        public static MyString operator +(MyString c1, MyString c2)
        {
            return new MyString(c1.CharString.Concat(c2.CharString).ToArray());
        }
        public static MyString operator -(MyString c1, MyString c2)
        {
            return new MyString(new string(c1.CharString).Replace(new string(c2.CharString), "").ToCharArray());
        }
        public static bool operator ==(MyString c1, MyString c2)
        {
            if (c2 as object == null)
            {
                return false;
            }
            return c1.CharString.SequenceEqual(c2.CharString);
        }
        public static bool operator !=(MyString c1, MyString c2)
        {
            return !(c1 == c2);
        }
        public override string ToString()
        {
            return new string(CharString);
        }
    }
}
