using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestEventsNDeligate.SecureWithDynamicInvoke
{
    class TestSecureEventDynamicInvoke
    {
        

        public void RunTest()
        {

            Publisher pb = new Publisher();
            

            Console.WriteLine("\nSubscribing to the event delegate ...");
            
            // 2. Subscribe to the publisher with its delegate 
            // 1st Subscription
            pb.OnAnyChange += (sender,e) => { Console.WriteLine("Sender {" + sender.ToString() + "} sent the message: " + e);  };
            // 2nd Subscription
            pb.OnAnyChange += (sender,e) => { throw new Exception("Custom exception");  };
            // 3rd Subscription
            pb.OnAnyChange += (sender,e) => { Console.WriteLine("Sender {" + sender.ToString() + "} sent the message: " + e);  };

            Thread.Sleep(1000);
            Console.WriteLine("\nRaising the event ...");

            // 3a. Raise the event call 
            try
            {
                //Try the calls one at a time

                // With   SECURE event method invocation - the second subscription method with "Custom Exception" invocation will NOT DISRUPT the following calls.
                pb.RaiseSecure();

                // With UNSECURE event method invocation - the second subscription method with "Custom Exception" invocation will     DISRUPT the following calls.
                //pb.RaiseUnsecure();
            }
            catch (Exception e)
            {
                Console.WriteLine("Final Exception Message: " + e.Message);
                
            }
            


        }
    }

    public class Publisher
    {
        // 1. Declare and Initialize the built-in delegate 
        // The Publisher class uses an EventHandler<T>, which specifies the type of the event arguments.
        // When raising this event, you are required to pass an instance of T.
        public event EventHandler<string> OnAnyChange = delegate { };


        // 3. Raise the event 
        public void RaiseUnsecure()
        {
            OnAnyChange(this, "A messaage from unsecure publisher.");
        }

        // 3. Raise the event 
        public void RaiseSecure()
        {
            var exceptions = new List<Exception>();

            foreach (var handler in OnAnyChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, "A messaage from secure publisher.");
                }
                catch (Exception e)
                {
                    exceptions.Add(e);           
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
            
        }


        

    }

}
