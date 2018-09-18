using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* POINTER : Pointer is varible which store address.
 * Two Type of Pointer
 *  1. Specfic: can only point specfic address
 *  2. Generic: can point at any specfic address
 */ 
namespace Pointer
{
    class Program
    {
        public unsafe static void Main(string[] args)
        {
            // Specfic Pointer 
        
            // Integer Pointer
            int iNo = 20;
            int* iPtr = &iNo;

            Console.WriteLine("Value of iNo = {0}", iNo);
            Console.WriteLine("Value of iPtr = {0}", (int)iPtr);
            Console.WriteLine("Value at iPtr pointer is pointing = {0}\n", *iPtr);

            // Character Pointer

            char cLetter = 'S';
            char* cPtr = &cLetter;

            Console.WriteLine("Value of cLetter = {0}", cLetter);
            Console.WriteLine("Value of cPtr = {0}", (int)cPtr);
            Console.WriteLine("Value at cPtr pointer is pointing = {0}\n", *cPtr);


            // Generic

            // Generic Pointer is pointing to Interger
            void* vPtr = &iNo;

            Console.WriteLine("vPtr is Pointing to iNo(integer)");
            Console.WriteLine("Value of vPtr = {0}", (int)vPtr);
            Console.WriteLine("Value at where vPtr is pointing = {0}\n", *(int *)vPtr);

            // Same Generic Pointer is pointing to Character
            vPtr = &cLetter;

            Console.WriteLine("vPtr is Pointing to cletter(character)");
            Console.WriteLine("Value of vPtr = {0}", (int)vPtr);
            Console.WriteLine("Value at where vPtr is pointing = {0}", *(char*)vPtr);

        
        }
    }
}
