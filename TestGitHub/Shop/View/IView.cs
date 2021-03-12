using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shop.View
{
    public interface IView
    {
        public String SendText { get; set; }
        public String ClientRequest { get; set; }
        public String ServerAnswer { get; set; }
        public AutoResetEvent WaitRequest { get; }
        public AutoResetEvent WaitAnswer { get; }
        public string ReadLine();
        public int ReadInt(int maxNum);
        public void WriteTextBuffer(String Text = "");
        public void Clear();

    }
}
