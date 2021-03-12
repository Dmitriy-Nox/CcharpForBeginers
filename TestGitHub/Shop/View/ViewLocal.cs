using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shop.View
{
    public class ViewLocal : IView
    {
        public string SendText { get; set; }
        public string ClientRequest { get; set; }
        public string ServerAnswer { get; set; }
        public AutoResetEvent WaitRequest => null;
        public AutoResetEvent WaitAnswer => null;
        public void Clear()
        {
            SendText = "";
            Console.Clear();
        }
        public int ReadInt(int maxNum)
        {
            int outVal = 0;
            if (int.TryParse(Console.ReadLine(), out outVal))
                return outVal;

            WriteTextBuffer("Некорректное значение. Повторите ввод");
            return ReadInt(maxNum);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void WriteTextBuffer(string Text = "")
        {
            Console.WriteLine(SendText+Text);
        }
    }
}
