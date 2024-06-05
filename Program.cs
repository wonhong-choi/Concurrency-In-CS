using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestConsole.Examples;

namespace TestConsole
{

    public interface ITest
    {
        void Test();
    }

    public class CTest : ITest
    {
        void ITest.Test()
        {
            Console.WriteLine("Explicit");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ITaskRunnable test = new ProcessingTasksAsTheyComplete();
            test.Run();



            Console.ReadLine();
        }
    }
}
