using System;
using System.Threading;

namespace Assignment9
{
    class Display1
    {
        public void DisplayRange(int iStart , int iEnd)
        {
            for( int i = iStart; i <= iEnd; i++)
            {
                Console.WriteLine($" {i} ");
            }
        }
    }

    class Display2
    {
        // Display Forward
        public void DisplayRangeF(int iStart, int iEnd)
        {
            for (int i = iStart; i <= iEnd; i++)
            {
                Console.WriteLine($"--{i} ");
            }
        }

        //display Backword
        public void DisplayRangeB(int iStart, int iEnd)
        {
            for (int i = iEnd; i>=  iStart; i--)
            {
                Console.WriteLine($"----{i} ");
            }
        }
    }

    // thread info
    class Display3
    {
        public void ThreadInfo()
        {
            Console.WriteLine("Thread info--->");
            Console.WriteLine("Thread Name: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread Priority: {0}", Thread.CurrentThread.Priority);
            if(Thread.CurrentThread.IsAlive)
            {
                Console.WriteLine("Thread is alive");
            }

            if (Thread.CurrentThread.IsBackground)
            {
                Console.WriteLine("Thread is at Background");
            }
            else
            {
                Console.WriteLine("Thread is not at Background");
            }

        }
    }
    /*
     * ThreadStart is delegates
     */
    class Program
    {
        static void Main(string[] args)
        {
            /* remove comment to run */




            /*  ------------- Ques 1 -------------*/
            /*
            Display1 obj1 = new Display1();

            // it is like a function call my function
            ThreadStart starter = delegate() { obj1.DisplayRange(5, 20); };
            Thread t1 = new Thread(starter);
            t1.Start();
            */




            /*  ------------- Ques 2 -------------*/
            /*
            Display2 d2Obj = new Display2();

            Thread t2 = new Thread(delegate() { d2Obj.DisplayRangeF(50, 100); });
            Thread t3 = new Thread(() => { d2Obj.DisplayRangeB(50, 100); });        //lamba expression
            t2.Start();
            t3.Start();
            */




            /*  ------------- Ques 3 -------------*/
            /*

            Display3 d3Obj = new Display3();
            Thread t4 = new Thread( new ThreadStart(d3Obj.ThreadInfo));
            t4.Name = "Thread4";
            t4.Start();
            */




            /*  ------------- Ques 4 -------------*/
            /*

            Display2 d2Obj2 = new Display2();

            Thread t2 = new Thread(delegate () { d2Obj2.DisplayRangeF(50, 100); });
            Thread t3 = new Thread(() => { d2Obj2.DisplayRangeB(50, 100); });        //lamba expression
            t2.Start();
            //join
            t2.Join();
            t3.Start();           
            */
        }
    }
}
