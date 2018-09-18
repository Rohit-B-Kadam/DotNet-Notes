using System;

namespace Que5Swap
{
    class Swapping
    {
        public unsafe void SwapByAddress(int* p, int* q)
        {
            *p = *p + *q;
            *q = *p - *q;
            *p = *p - *q;
        }

        public void SwapByReference( ref int p, ref int q)
        {
            int temp;
            temp = p;
            p = q;
            q = temp;
        }
 
    }
    class Program
    {
        static void Main(string[] args)
        {
            int iNo1 = 45;
            int iNo2 = 76;

            Swapping obj = new Swapping();

            Console.WriteLine("Swapping using passed by address technique");
            Console.WriteLine("Value Before Call iNo1 = {0} and iNo2 = {1}", iNo1, iNo2);
            unsafe
            {
                obj.SwapByAddress(&iNo1, &iNo2);
            }
            Console.WriteLine("Value After Call iNo1 = {0} and iNo2 = {1}", iNo1, iNo2);


            Console.WriteLine("\nSwapping using passed by reference technique");
            Console.WriteLine("Value Before Call iNo1 = {0} and iNo2 = {1}", iNo1, iNo2);
            obj.SwapByReference(ref iNo1, ref iNo2);
            Console.WriteLine("Value After Call iNo1 = {0} and iNo2 = {1}", iNo1, iNo2);            
        }
    }
}
