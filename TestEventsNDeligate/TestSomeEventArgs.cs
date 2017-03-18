using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEventsNDeligate.SomeEventArgs
{
    class TestSomeEventArgs
    {

        public void RunTest()
        {
            Publisher pb = new Publisher();
            Subscriber sb = new Subscriber();
            sb.SubscribeAndRaise(pb);

        }

        public class ErrorEventArgs : EventArgs
        {
            private string myProperty;
            public ErrorEventArgs(string myProperty) { this.myProperty = myProperty; }
            public string MyProperty { get { return myProperty; } }
        }



        public class Publisher
        {
            // A generic event handler
            public event EventHandler<ErrorEventArgs> GenericErrorEventhandler = delegate { };
            public void RaiseGeneric(ErrorEventArgs eventArgsFromSubscribers)
            {
                GenericErrorEventhandler(this, eventArgsFromSubscribers);
            }

            // A non-generic event handler
            public event EventHandler ErrorEventhandler = delegate { };
            public void RaiseNonGeneric(ErrorEventArgs eventArgsFromSubscribers)
            {
                ErrorEventhandler(this, eventArgsFromSubscribers);
            }


        }

        public class Subscriber
        {

            public void SubscribeAndRaise(Publisher pb)
            {
                // With Generic Event Args its possible to 
                // 1. Send a custom EventArgs from the subscriber.
                // 2. Send message from subscriber to event handeler(i.e. GenericErrorEventhandler)
                pb.GenericErrorEventhandler += delegate (object sender, ErrorEventArgs e) { Console.WriteLine($"With GenericErrorEventhandler:\n { e.MyProperty }"); };
                pb.RaiseGeneric(new ErrorEventArgs(" <Value from my custom event args property> " + "<Message from subscriber>"));

                // With NON-Generic Event Args its NOT possible to 
                // 1. Send a custom EventArgs from the subscriber.
                // 2. Send message from subscriber to event handeler(i.e. ErrorEventhandler)
                pb.ErrorEventhandler += delegate (object sender, EventArgs e) { Console.WriteLine($"With NonGenericErrorEventhandler:\n  <{ e.ToString() }> Can't retrive a custom EventArgs"); };
                pb.RaiseNonGeneric(new ErrorEventArgs(" <Value from my custom event args property> " + "<Message from subscriber>"));



            }



        }


    }
}
