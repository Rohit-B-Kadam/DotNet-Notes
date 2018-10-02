using System;

namespace PointerInCsharp
{

    /* Checking is array is treat as a poinnter */
    internal class Pointer1
    {
       
        
        public unsafe void Display()
        {
            int[] iArr = new int[] { 1, 2, 3, 4, 5 };
            int iVar = 20;
            int* iPtr;
            iPtr = &iVar;
            Console.WriteLine("Value: {0}", *iPtr);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Pointer1 pobj1 = new Pointer1();
            pobj1.Display();


        }
    }
}
