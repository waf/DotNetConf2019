using System;


namespace DotNetConfThailand.NullableReferences
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Person aaron = new Person("Theeranit", "Pongtongmuan");
            int length = GetLengthOfMiddleName(aaron);
            Console.WriteLine(length);
        }

        public static int GetLengthOfMiddleName(Person p)
        {
            var middle = p.MiddleName;
            return middle.Length;
        }
    }
}
