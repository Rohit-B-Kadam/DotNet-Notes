using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que5MaxMinFromArray
{
    class Array
    {
        // To find the maximum number from given array
        public static int Maximum(int[] arr)
        {
            int iMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (iMax < arr[i])
                {
                    iMax = arr[i];
                }
            }
            return iMax;
        }


        // To find the minimum number from given array
        public static int Minimum(int[] arr)
        {
            int iMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (iMax > arr[i])
                {
                    iMax = arr[i];
                }
            }
            return iMax;
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

            // Finding Maximum number
            iRet = Array.Maximum(iInputArr);
            Console.WriteLine("Maximum Number in Array: {0}", iRet);

            // Finding Minimum number
            iRet = Array.Minimum(iInputArr);
            Console.WriteLine("Minimum Number in Array: {0}", iRet);
        }
    }
}
