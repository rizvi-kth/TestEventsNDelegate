using System;
using System.ComponentModel;
using System.Threading;

namespace TestEventsNDeligate
{
    internal class TestPublishSubscribe
    {

        public void RunTest()
        {

            Publisher pb = new Publisher();
            Thread.Sleep(2000);

            Subscriber1 sub1 = new Subscriber1();
            sub1.SubscribeToPublisher(pb);

            Subscriber2 sub2 = new Subscriber2();
            sub2.SubscribeToPublisher(pb);

            pb.Raise("TraffZor");



        }


    }

    public class Publisher
    {
        // 1. Declare and Initialize the built-in delegate 
        public Action<string> processSrting;

        // 3. Raise the event 
        public void Raise(string input)
        {
            if (processSrting != null)
            {
                Console.WriteLine("Publisher triggering/raising the event.");
                processSrting(input);
            }
        }
    }

    public class Subscriber1
    {
        
        public void SubscribeToPublisher(Publisher pb )
        {
            Console.WriteLine("Subscriber-1 subscribing to Publisher");
            // 2. Subscribe to the publisher with its delegate 
            pb.processSrting += (name) => { Console.WriteLine("Processed string from Subscriber1:" + name.ToUpper()); };
        }

    }

    public class Subscriber2
    {

        public void SubscribeToPublisher(Publisher pb)
        {
            Console.WriteLine("Subscriber-2 subscribing to Publisher");
            // 2. Subscribe to the publisher with its delegate 
            pb.processSrting += (name) => { Console.WriteLine("Processed string from Subscriber1:" + name.ToLower()); };
        }

    }
}