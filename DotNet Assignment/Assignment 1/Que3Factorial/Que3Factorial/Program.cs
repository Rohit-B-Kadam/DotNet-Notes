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
        int iResult;

        // To accept input
        public void Accept()
        {
            Console.Write("Enter the number: ");
            iNum = Convert.ToInt32(Console.ReadLine());
        }

        // To perform Factorial of given input
        public void FindFactorial()
        {
            iResult = 1;
            while (iNum != 0)
            {
                iResult *= iNum;
                iNum--;
            }
        }

        // To display result 
        public void Display()
        {
            Console.WriteLine("Factorial is: {0}", iResult);
        }
    }

    // Loader class
    class Program
    {
        static void Main(string[] args)
        {
            Numbers obj = new Numbers();

            obj.Accept();
            obj.FindFactorial();
            obj.Display();
        }
    }
}
