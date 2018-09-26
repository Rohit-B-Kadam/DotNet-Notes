using System;

/* POINTER
 *   Pointer is variable can point at any thing.
 * 
 */
namespace Pointer
{
    class Demo
    {
        public int i = 10;

        public void fun()
        {
            Console.WriteLine("Hello from demo");
        }
    }

    class PointerAsArray
    {
        public void Display()
        {
            // Normal pointer to an object.
            int[] a = new int[5] { 10, 20, 30, 40, 50 };
            // Must be in unsafe code to use interior pointers.
            unsafe
            {
                // Must pin object on heap so that it doesn't move while using interior pointers.
                fixed (int* p = &a[0])
                {
                    // p is pinned as well as object, so create another pointer to show incrementing it.
                    int* p2 = p;
                    Console.WriteLine(*p2);
                    // Incrementing p2 bumps the pointer by four bytes due to its type ...
                    p2 += 1;
                    Console.WriteLine(*p2);
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");
                    Console.WriteLine(*p);
                    // Dereferencing p and incrementing changes the value of a[0] ...
                    *p += 1;
                    Console.WriteLine(*p);
                    *p += 1;
                    Console.WriteLine(*p);
                }

                
            }

            Console.WriteLine("--------");
          
        }
    }
    class Program
    {
        static unsafe void Main(string[] args)
        {
            /*
            // Pointer pointing to Userdefine class object member
            Demo dobj = new Demo();
            Console.WriteLine("Value of i is {0}", dobj.i);
            fixed(int* iPtr = &dobj.i)
            {
                (*iPtr)++;
                Console.WriteLine("Value of i is {0}", *iPtr);
                Console.WriteLine("Value of i is {0}", dobj.i);
            }

            fixed( int* vPtr = &dobj.i)
            {

            }
            */

            // Pointer as Array
            PointerAsArray obj = new PointerAsArray();
            obj.Display();
        }
    }
}
