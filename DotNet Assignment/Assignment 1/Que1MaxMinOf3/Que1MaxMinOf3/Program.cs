using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que1MaxMinOf3
{
    class Numbers
    {
        int iNo1;
        int iNo2;
        int iNo3;

        // constructor to initialize all three number
        public Numbers(int x, int y, int z)
        {
            iNo1 = x;
            iNo2 = y;
            iNo3 = z;
        }

        // To find Maximum of Three Number
        public int Max()
        {
            if( iNo1 > iNo2)
            {
                if( iNo1 > iNo3)
                    return iNo1;
                else
                    return iNo3;
            }
            else
            {
                if( iNo2 > iNo3)
                    return iNo2;
                else
                    return iNo3;
           }
        }

        // return Minimum number among three characteristic
        public int Min()
        {
            if (iNo1 < iNo2)
            {
                if (iNo1 < iNo3)
                    return iNo1;
                else
                    return iNo3;
            }
            else
            {
                if (iNo2 < iNo3)
                    return iNo2;
                else
                    return iNo3;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int iRet;
            int iNo1 = 23;
            int iNo2 = 43;
            int iNo3 = 12;

            Numbers obj = new Numbers(iNo1 , iNo2 , iNo3);

            iRet = obj.Max();

            Console.WriteLine("Maximum number among ( {0} , {1} , {2} ) is {3} ",iNo1, iNo2, iNo3, iRet);

            iRet = obj.Min();

            Console.WriteLine("Minmum number among ( {0} , {1} , {2} ) is {3} ",iNo1, iNo2, iNo3, iRet);

        }
    }
}
