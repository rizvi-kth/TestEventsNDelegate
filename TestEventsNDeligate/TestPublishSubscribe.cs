﻿using System;
using System.Threading;

namespace TestEventsNDeligate
{
    internal class TestPublishSubscribe
    {

        public void RunTest()
        {

            Publisher pb = new Publisher();
            Thread.Sleep(2000);
            // ONE PROBLEMS FOR USING NACKED DELEGATE -
            // If you call the delegate function with out any subscription - will throw exception.
            // So delegate variable needs a null check in the Raise function
            pb.Raise("TraffZor");
            

            Subscriber1 sub1 = new Subscriber1();
            sub1.SubscribeToPublisher(pb);

            Subscriber2 sub2 = new Subscriber2();
            sub2.SubscribeToPublisher(pb);
            Console.WriteLine("\nRaising event from publisher.");
            pb.Raise("TraffZor");

            
            // TWO PROBLEMS FOR USING NACKED DELEGATE -
            // 1. Any user of the Publisher can call the delegated functions
            Console.WriteLine("\nAny consumer of Publisher calling nacked delegate.");
            pb.processSrting("TraffZor");

            // 2. In the subscriber it is possible to use = instead of := to subscribe. 
            // Using = can replace the previous subscriptions with the second subscription.
            Console.WriteLine("\nA third subscriber is subscribing.");
            Subscriber3 sub3 = new Subscriber3();
            sub3.SubscribeToPublisher(pb);

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
                Console.WriteLine(" * Publisher triggering/raising the event.");
                processSrting(input);
            }
        }
    }

    public class Subscriber1
    {
        
        public void SubscribeToPublisher(Publisher pb )
        {
            Thread.Sleep(1000);
            Console.WriteLine("Subscriber-1 subscribing to Publisher");
            // 2. Subscribe to the publisher with its delegate 
            pb.processSrting += (name) => { Console.WriteLine("Processed string from Subscriber1:" + name.ToUpper()); };
        }

    }

    public class Subscriber2
    {

        public void SubscribeToPublisher(Publisher pb)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Subscriber-2 subscribing to Publisher");
            // 2. Subscribe to the publisher with its delegate 
            pb.processSrting += (name) => { Console.WriteLine("Processed string from Subscriber2:" + name.ToLower()); };
        }

    }

    public class Subscriber3
    {

        public void SubscribeToPublisher(Publisher pb)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Subscriber-3 subscribing to Publisher using '=' instade of '+='");
            // 2. Subscribe to the publisher with its delegate using = instead of := 
            pb.processSrting = (name) => { Console.WriteLine("Processed string from Subscriber3:" + name.ToLower().Substring(0,3).ToUpper()); };
        }

    }
}