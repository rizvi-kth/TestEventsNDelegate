
using System;

namespace TestEventsNDeligate
{
    public class TestDelegate
    {
        // 1. Declare a delegate type
        public delegate int Calculate(int x, int y);

        public void TestSimpleDelegate()
        {
            

            // 2. Create a delegate type variable
            // 3. Assign a function to the delegate type with a lamda expression
            Calculate Addx = (p, q) => { return (p + q); } ;
            Calculate Subx = (p, q) => { return (p - q); };
            
            // 4. Function Call using delegate
            int r = Addx(3, 2);
            int s = Subx(3, 2);
            
            Console.WriteLine();
            Console.WriteLine("\nMethods call with Delegate type declaration with delegate keyword");
            Console.WriteLine("Add result {0}", r);
            Console.WriteLine("Substruction result {0}", s);

            return;
        }


        public void TestBuiltinDelegate()
        {
            // .NET framework has a couple of built-in delegate like Action<>(for void return type), Func<>(for typed return type)
            // 1. Create a delegate type variable
            // 2. Assign a function to the delegate type with a lamda expression
            Action<int, int> Addx = (p, q) => { Console.WriteLine(p + q); };
            Func<int, int, int> Subx = (p1, q1) =>{ return (p1 - q1); };


            // 4. Function Call using delegate
            int s = Subx(3, 2);


            Console.WriteLine();
            Console.WriteLine("\nMethods call with built-in .NET delegate like Action<int, int> and Func<int, int, int>");
            Console.Write("Add result ");
            // 4. Function Call using delegate
            Addx(3, 2);
            Console.WriteLine("Substruction result {0}", s);

            


        }   

    }
}