using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que1CheckPrimePrefect
{
    class Numbers
    {

        // To check whether number is prime or not
        public static bool isPrime(int iNum)
        {
            int iHalf = iNum / 2;       // Divisor range of any number [ 1 , number/2 ]

            // Checking if there is any divisble of that number. if there is we return false 
            for (int i = 2; i <= iHalf; i++)
            {
                if ((iNum % i) == 0)
                    return false;
            }
            return true;
        }

        /*
        // To check whether number is prefect or not
        public static bool isPrefect(int iNum)
        {
            int iHalf = iNum / 2;       // Divisor range of any number [ 1 , number/2 ]
            int iSum = 1;               // Initializing with 1 because every number is divisble by 1

            // Finding and adding divisor of given number
            for (int i = 2; i <= iHalf; i++)
            {
                if ((iNum % i) == 0)
                    iSum += i;
            }

            if (iSum == iNum)
                return true;
            return false;
        }
         */
        public static bool isPrefect(int iNum)
        {
            int iVaries = iNum / 2 ;         // Divisor range of any number [ 1 , half of number ]
            int iSum = 1;                    // Initializing with 1 because every number is divisble by 1

            // Finding and adding divisor of given number
            for (int i = 2; i < iVaries; i++)
            {
                if( (iNum % i) == 0 )
                {
                    iSum += i;
                    iVaries = iNum / i;
                    iSum += iVaries;
                }
            }

            if (iSum == iNum)
                return true;
            return false;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int iInput;

            Console.Write("Enter the number to check if its is prime or prefect : ");
            iInput = Convert.ToInt32(Console.ReadLine());

            if (Numbers.isPrime(iInput))
                Console.WriteLine("Number is Prime");
            else
                Console.WriteLine("Number is not Prime");

            if (Numbers.isPrefect(iInput))
                Console.WriteLine("Number is Prefect");
            else
                Console.WriteLine("Number is not Prefect");

        }
    }
}
