using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shop.View
{
    public class ViewServer:IView
    {
        public String ClientRequest { get; set; }
        public String ServerAnswer { get; set; }
        private AutoResetEvent waitRequest = new AutoResetEvent(false);
        public AutoResetEvent WaitRequest => waitRequest;
        private AutoResetEvent waitAnswer = new AutoResetEvent(false);
        public AutoResetEvent WaitAnswer => waitAnswer;
        public String SendText { get; set; }
        public string ReadLine()
        {
            WaitRequest.WaitOne();
            return ClientRequest;
        }
        public int ReadInt(int maxNum)
        {
            WaitRequest.WaitOne();
            var readLine = ClientRequest;
            var outVal = 0;
            if (int.TryParse(readLine, out outVal))
            {
                if (outVal < maxNum && outVal > 0)
                    return outVal;
            }
            WriteTextBuffer("Некорректное значение. Повторите ввод");
            return ReadInt(maxNum);
        }
        public void Clear()
        {
            SendText = "";
        }
        public void WriteTextBuffer(String Text="")
        {
            ServerAnswer = SendText+Text;
            WaitAnswer.Set();
        }
    }
}
