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

    public class Program
    {
        public static void Main(string[] args)
        {
            ITaskRunnable test = new ReportingProgress();
            test.Run();


            Console.ReadLine();
        }
    }
}
