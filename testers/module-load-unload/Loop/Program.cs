using System;

namespace Loop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running MyGenericTest");
            MyGenericTest genericTest = new MyGenericTest();
            genericTest.TestFunc();
            Console.WriteLine("Finished DeepGenerics");
        }

        public void Foo(string[] args)
        {
            Console.WriteLine("Running MyGenericTest");
            MyGenericTest genericTest = new MyGenericTest();
            genericTest.TestFunc();
            Console.WriteLine("Finished DeepGenerics");
        }
    }
}
