using System;

namespace TestGitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var ClassList = new ClassList();
            ClassList.Add(1);
            ClassList.Add(2);
            ClassList.Add(3);
            ClassList.Add(4);

            do
            {
                Console.WriteLine(ClassList.CurrBoxView.Val);
            } while (ClassList.AvalibleNext);


        }
    }
}
