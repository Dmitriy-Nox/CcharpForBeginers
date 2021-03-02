using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            int? num = default(int);
            var sss = num ?? 2;
            var sss1 = num.GetValueOrDefault();

            Console.WriteLine("Hello World!");
        }
    }
}
