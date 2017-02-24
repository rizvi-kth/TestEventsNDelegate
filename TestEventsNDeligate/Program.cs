using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEventsNDeligate.EvebtBased;
using TestEventsNDeligate.SecureWithDynamicInvoke;
namespace TestEventsNDeligate
{
    class Program
    {
        static void Main(string[] args)
        {

            TestDelegate td = new TestDelegate();
            //td.TestSimpleDelegate();
            //td.TestBuiltinDelegate();

            TestPublishSubscribe tps = new TestPublishSubscribe();
            //tps.RunTest();

            TestPublishSubscribeEventBased tpse = new TestPublishSubscribeEventBased();
            //tpse.RunTest();

            TestSecureEventDynamicInvoke tsedi = new TestSecureEventDynamicInvoke();
            tsedi.RunTest();





            Console.WriteLine("\n\nHit enter to exit.");
            Console.ReadLine();
        }
    }
}

