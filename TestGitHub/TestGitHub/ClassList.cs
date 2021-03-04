using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitHub
{
    internal class ClassList
    {
        public ClassList()
        {

        }
        public Box First;
        public Box Last;
        public int _count;

        public void Add(object val)
        {
            Box box = new Box(val);

            if (First == null && Last == null)
            {
                First = box;
                Last = box;

            }
            else
            {
                //if(First.Next==null)
                //    First.Next = box;

                Last.Next = box;
                Last = box;
            }
            _count++;

        }


        private Box currBoxView;
        public Box CurrBoxView
        {
            get
            {
                if (currBoxView == null)
                {
                    currBoxView = First;
                    return currBoxView;
                }


                currBoxView = currBoxView.Next;
                return currBoxView;
            }
        }

        public bool AvalibleNext
        {
            get
            {
                if (currBoxView.Next == null)
                    return false;
                else
                    return true;
            }
        }

        public int Count { get; }

    }    
    
}
