using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VarAndLinq
{
    public class IssueEnumerator : IEnumerator<Issue>
    {
        private Issue[] _mas;
        private int currPos= -1;
        public IssueEnumerator(Issue[] mas)
        {
            _mas = mas;
        }

        public Issue Current
        {
            get
            {
                if (currPos == -1 || currPos >= _mas.Length)
                    throw new InvalidOperationException();
                return _mas[currPos];
            }
        }

        object IEnumerator.Current => _mas[currPos];

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (currPos < _mas.Length - 1)
            {
                currPos++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            currPos = -1;
        }
    }
}
