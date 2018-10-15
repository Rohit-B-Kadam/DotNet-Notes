using System;
using System.Threading;

namespace Assignment10
{
    /*
     * Check Prime and Prefect number
     */
    class Marvellous
    {
        int iNo;

        public Marvellous(int iValue)
        {
            iNo = iValue;
        }

        private int SumFactor()
        {
            int iSum = 0;
            for (int iCnt = 1; iCnt <= iNo / 2; iCnt++)
            {
                if ((iNo % iCnt) == 0)
                {
                    iSum += iCnt;
                }
            }
            
            return iSum;
        }

        public void CheckPerfect()
        {
            int iRet = 0;

            iRet = SumFactor();
            if (iRet == iNo)
            {
                Console.WriteLine($" { iNo } is a Prefect Number ");
            }
            else
            {
                Console.WriteLine($" { iNo } is not a Prefect Number ");

            }
        }

        public void CheckPrime()
        {
            int iRet = 0;
            iRet = SumFactor();
            if (iRet == 1)
            {
                Console.WriteLine($" {iNo} is a Prime Number");
            }
            else
            {
                Console.WriteLine($" {iNo} is not a Prime Number");
            }
        }
    }


    /* 
     * Display even and odd from array
     */
    class MarvellousNumber
    {
        public int[] arr;
        public MarvellousNumber(int iValue)
        {
            arr = new int[iValue];
        }

        public void Accept()
        {
            Console.WriteLine("Enter elements: ");
            for( int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void EvenDisplay()
        {
            for( int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                    Console.WriteLine("Even: {0} ",arr[i]);
            }
        }

        public void OddDisplay()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                    Console.WriteLine(" Odd: {0} ", arr[i]);
            }
        }
    }

    // Find Max and Min
    class MarvellousNew : MarvellousNumber
    {
        public MarvellousNew(int iValue): base(iValue) { }

        public void Max()
        {
            Console.WriteLine("Max Fun started ");
            int iMax = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (iMax < arr[i])
                {
                    iMax = arr[i];
                }
            }
            Console.WriteLine("Maximum number is: {0}", iMax);
        }

        public void Min()
        {
            Console.WriteLine("Min Fun started ");
            int iMin = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (iMin > arr[i])
                {
                    iMin = arr[i];
                }
            }
            Console.WriteLine("Minimum number is: {0}", iMin);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* ------------ Que 1 -------------- */
            /*
            
            Marvellous mObj = new Marvellous(29);
            Thread t11 = new Thread(new ThreadStart(mObj.CheckPerfect));
            Thread t12 = new Thread(new ThreadStart(mObj.CheckPrime));
            t11.Start();
            t12.Start();

            */



            /* ------------ Que 2 -------------- */
            /*
            MarvellousNumber mnObj = new MarvellousNumber(10);
            mnObj.Accept();

            Thread t21 = new Thread(new ThreadStart(mnObj.EvenDisplay));
            Thread t22 = new Thread(new ThreadStart(mnObj.OddDisplay));
            t21.Start();
            t22.Start();
            */



            /* ------------ Que 3 -------------- */
            /*
            
            MarvellousNew mnObj2 = new MarvellousNew(10);
            mnObj2.Accept();
            Thread t31 = new Thread(new ThreadStart(mnObj2.Max));
            Thread t32 = new Thread(new ThreadStart(mnObj2.Min));
            t31.Start();
            t32.Start();
            */
        }
    }
}
