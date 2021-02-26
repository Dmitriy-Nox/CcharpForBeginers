using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitHub
{
    public class Stack
    {
        public Box Last;
        public Box CurrView;
        private int _count;
        public int Count => _count;

        public void Push(object val)
        {
            Box box = new Box(val);

            if (Last == null)
            {
                Last = box;

            }
            else
            {
                var last = Last;
                Last = box;
                Last.Next = last;
                
            }
            _count++;


        }


        public Box Pull()
        {
            if (Last == null)
                return null;
            var retValue = Last;
            Last = Last.Next;
            CurrView = Last;
            _count--;

            return retValue;


        }
    }
}
