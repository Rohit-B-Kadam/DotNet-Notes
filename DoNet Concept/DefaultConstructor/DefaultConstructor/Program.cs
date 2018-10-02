using System;
/*
    Default Constructor:
        1. Default Constructor is explicitly added by C# Compiler if the programmmer have not provided.
        2. Its access specifier is public.
        3. If we write one parametrised contructor then we have implicitly add default constructor.
        4. All Derived Constructor explicitly call base class default constructor if we provider constructor should be call from base.

 */

namespace DefaultConstructor
{
    class Demo
    {
        public int i;

        public Demo()
        {
            Console.WriteLine("Inside Default Constructor of Demo");
            i = int.MaxValue;
        }

        public Demo(int i)
        {
            this.i = i;
            Console.WriteLine("Inside parametrised Constructor of Demo");
        }
    }

    class Hello : Demo
    {
        public Hello(): base()
        {
            Console.WriteLine("Inside Default Constructor of Hello");
        }

        public Hello(int i)
        {
            base.i = i;
            Console.WriteLine("Inside parametrised Constructor of Hello");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Demo dobj1 = new Demo();
            Demo dobj2 = new Demo(12);
            */

            Hello hobj1 = new Hello(12);
        }
    }
}
