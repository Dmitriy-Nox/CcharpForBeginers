using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VarAndLinq
{
    public class Issues :  IEnumerable<Issue>
    {
        public Issue[] _mas;
        public int currPosition;
        public Issues(Issue[] mas)
        {
            _mas = mas;
        }

        public IEnumerator GetEnumerator()
        {
            return new IssueEnumerator(_mas);
        }

        IEnumerator<Issue> IEnumerable<Issue>.GetEnumerator()
        {
            return new IssueEnumerator(_mas);
        }
    }
}
