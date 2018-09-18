using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedApproch
{
    class Arithmetic
    {
        // Characteristic
        private int iNo1;   
        private int iNo2;
        
        // Behaviour

        //To accept the two number
        public void Accept(int iNo1, int iNo2)
        {
            this.iNo1 = iNo1;
            this.iNo2 = iNo2;
        }

        // display the addition of iNo1 and iNo2
        public void Add()
        {
            Console.WriteLine(" Addition of {0} and {1} is {2}", this.iNo1, this.iNo2, this.iNo1 + this.iNo2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Arithmetic aObj = new Arithmetic();

            aObj.Accept(20, 30);
            aObj.Add();
        }
    }
}
