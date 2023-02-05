using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleConsole_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Math();
            Console.ReadLine();
        }

        static void Math()
        {
            Console.WriteLine("Start");
            Thread.Sleep(5000);
            Console.WriteLine("Finish");
        }
    }
}
