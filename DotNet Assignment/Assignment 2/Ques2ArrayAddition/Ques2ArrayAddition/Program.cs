using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2ArrayAddition
{
    class Array
    {
        public static int Addition(int[] arr)
        {
            int iResult = 0;
            for (int i = 0; i < arr.Length; i++)
                iResult += arr[i];
            return iResult;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int iRet;
            int[] iInputArr;

            // Taking size of array
            Console.Write("Enter the size of array: ");
            n = Convert.ToInt32(Console.ReadLine());

            // Dynamic allocation th size of array
            iInputArr = new int[n];

            Console.WriteLine("Enter {0} value", n);

            for (int i = 0; i < n; i++)
            {
                iInputArr[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Getting Addition of all element of array
            iRet = Array.Addition(iInputArr);

            Console.WriteLine("Addition is: {0}", iRet);
        }
    }
}
