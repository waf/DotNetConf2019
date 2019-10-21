using System;

namespace DotNetConfThailand.NullableReferences
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Person miguel = new Person("Theeranit", "Pongtongmuan");
            int length = GetLengthOfMiddleName(miguel);
            Console.WriteLine(length);
        }

        public static int GetLengthOfMiddleName(Person p)
        {
            return p.MiddleName.Length;
        }
    }
}
