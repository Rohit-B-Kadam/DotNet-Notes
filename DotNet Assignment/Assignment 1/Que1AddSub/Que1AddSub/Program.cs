using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que1AddSub
{
    class Arithmetric
    {

        // Characteristics
        int iNo1;
        int iNo2;
        int iResult;

        // Behaviours
        public void Accept(int x, int y)
        {
            iNo1 = x;
            iNo2 = y;
        }

        // Description: Add two number
        public void Add()
        {
            iResult = iNo1 + iNo2;
        }

        // Description: sub two number
        public void Sub()
        {
            iResult = iNo1 - iNo2;
        }

        public void Display()
        {
            Console.WriteLine("First Argument: {0}", iNo1);
            Console.WriteLine("Second Argument: {0}", iNo2);
            Console.WriteLine("Result is: {0}", iResult);
        }
    }

    class Program
    {
        //Entry point function
        static void Main(string[] args)
        {
            //Creating object of Arithmetric class
            Arithmetric obj1 = new Arithmetric();

            // calling behavious to set characteristics
            obj1.Accept(20, 10);

            // Calling the behavious to perform addition
            obj1.Add();

            // Calling the behaviour to display the output
            obj1.Display();
            
            // Calling the behaviour to perform substration
            obj1.Sub();

            // Calling the behaviour to display the output
            obj1.Display();

        }
    }
}
