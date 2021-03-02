using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VarAndLinq
{
    public class TestEnumerator 
    {
        int[] _mas;
        public TestEnumerator(int[] mas)
        {
            _mas = mas;
        }
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
