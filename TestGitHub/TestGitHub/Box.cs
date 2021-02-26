using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitHub
{
    public class Box
    {

        public Box(object value)
        {
            Val = value;
            Next = null;

        }
        public object Val { get; set; }
        public Box Next { get; set; }
    }
}
