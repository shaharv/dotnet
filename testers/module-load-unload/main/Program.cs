using System;
using System.Reflection;
using System.Threading;

namespace main
{
    class ProxyObject : MarshalByRefObject
    {
        private Type _type;
        private Object _object;

        public void InstantiateObject(string AssemblyPath, string typeName, object[] args)
        {
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + AssemblyPath); // LoadFrom loads dependent DLLs (assuming they are in the app domain's base directory)
            _type = assembly.GetType(typeName);
            _object = Activator.CreateInstance(_type, args);
        }

        public void InvokeMethod(string methodName, object[] args)
        {
            var methodinfo = _type.GetMethod(methodName);
            methodinfo.Invoke(_object, args);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                AppDomain domain = AppDomain.CreateDomain("MyDomain", null);
                ProxyObject proxyObject = (ProxyObject)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(ProxyObject).FullName);
                proxyObject.InstantiateObject("Loop.exe", "Loop.Program", new object[] {});
                String[] strArgs = { "bar" };
                proxyObject.InvokeMethod("Foo" , new object[] { strArgs });

                GC.Collect(); // collects all unused memory
                GC.WaitForPendingFinalizers(); // wait until GC has finished its work
                GC.Collect();

                Console.WriteLine("Unloading assembly MyGenericTest started");
                AppDomain.Unload(domain);
                Console.WriteLine("Unloading assembly MyGenericTest ended");

                Console.WriteLine("Sleep for 4 seconds...");
                Thread.Sleep(4000);
            }
        }
    }
}
