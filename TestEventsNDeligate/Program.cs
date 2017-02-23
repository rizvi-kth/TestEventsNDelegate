using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEventsNDeligate
{
    class Program
    {
        static void Main(string[] args)
        {

            TestDelegate td = new TestDelegate();
            td.TestSimpleDelegate();
            td.TestBuiltinDelegate();

            TestPublishSubscribe tpcb = new TestPublishSubscribe();
            tpcb.RunTest();



            Console.WriteLine("\n\nHit enter to exit.");
            Console.ReadLine();
        }
    }
}

