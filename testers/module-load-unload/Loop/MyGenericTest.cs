using System;
using System.Collections.Generic;

namespace Loop
{
    public class MyGenList<T>
    {
        public List<T> _tList;

        public MyGenList(List<T> tList)
        {
            _tList = tList;
        }
    }

    class MyGenericTest
    {
        public void TestFunc()
        {
            MyGenList<String> genList = new MyGenList<String>(new List<string> { "A", "B", "C" });

            try
            {
                throw new Exception();
            }
            catch (Exception)
            {

            }
        }
    }
}
