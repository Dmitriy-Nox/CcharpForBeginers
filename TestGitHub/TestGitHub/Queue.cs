using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitHub
{
    public class Queue
    {

        public Box First;
        public Box Last;
        public Box CurrView;
        private int _count;
        public int Count => _count;

        public void EnQueue(object val)
        {
            Box box = new Box(val);

            if (First == null && Last == null)
            {
                First = box;
                Last = box;

            }
            else
            {
                Last.Next = box;
                Last = box;
            }
            _count++;


        }


        public Box DeQueue()
        {
            if (First == null)
                return null;
            var retValue = First;
            First = First.Next;
            CurrView = First;
           _count--;

            return retValue;


        }
        
    }
}
