using System;

namespace TestGitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var Queue = new Queue();
            Queue.EnQueue(1);
            Queue.EnQueue(2);
            Queue.EnQueue(3);
            Queue.EnQueue(4);


            while (Queue.Count > 0)
                Console.WriteLine(Queue.DeQueue().Val);

            var Stack = new Stack();
            Stack.Push("10");
            Stack.Push("20");
            Stack.Push("30");
            Stack.Push("40");


            while (Stack.Count > 0)
                Console.WriteLine(Stack.Pull().Val);

            var ClassList = new ClassList();
            ClassList.Add(1.5);
            ClassList.Add(2.5);
            ClassList.Add(3.5);
            ClassList.Add(4.5);

            do
            {
                Console.WriteLine(ClassList.CurrBoxView.Val);
            } while (ClassList.AvalibleNext);


        }
    }
}
