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
            public void RaiseGeneric()
            {
                GenericErrorEventhandler(this, new ErrorEventArgs(" <Value from my custom event args property> "));
            }

            // A non-generic event handler
            public event EventHandler ErrorEventhandler = delegate { };
            public void RaiseNonGeneric()
            {
                ErrorEventhandler(this, new ErrorEventArgs(" <Value from my custom event args property> "));
            }


        }

        public class Subscriber
        {

            public void SubscribeAndRaise(Publisher pb)
            {
                pb.GenericErrorEventhandler += delegate (object sender, ErrorEventArgs e) { Console.WriteLine($"With GenericErrorEventhandler { e.MyProperty }"); };
                pb.RaiseGeneric();

                pb.ErrorEventhandler += delegate (object sender, EventArgs e) { Console.WriteLine($"With NonGenericErrorEventhandler  <{ e.ToString() }> Can't retrive a custom EventArgs"); };
                pb.RaiseNonGeneric();



            }



        }


    }
}
