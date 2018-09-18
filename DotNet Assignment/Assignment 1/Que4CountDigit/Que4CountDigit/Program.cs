using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que3Factorial
{

    class Numbers
    {
        int iNum;
        int iCount;

        // To accept input
        public void Accept()
        {
            Console.Write("Enter the number: ");
            iNum = Convert.ToInt32(Console.ReadLine());
        }

        // To count digit  of given input
        public void CountDigit()
        {
            iCount = 0;
            int i = 1;
            while ((iNum / i ) != 0 )
            {
                iCount++;
                i *= 10;
            }
        }

        // To display result 
        public void Display()
        {
            Console.WriteLine("Number of digit in {0} is: {1}", iNum, iCount);
        }
    }

    // Loader class
    class Program
    {
        static void Main(string[] args)
        {
            Numbers obj = new Numbers();

            obj.Accept();
            obj.CountDigit();
            obj.Display();
        }
    }
}

