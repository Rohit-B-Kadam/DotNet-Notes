using System;

namespace Assignment6
{
    abstract class Marvellous
    {
        public int no;

        public Marvellous() { }
        public Marvellous(int value)
        {
            no = value;
        }

        public double Power(int x , int y)
        {
            return Math.Pow(x, y);
        }

        public int SumFactor( int no)
        {
            int iSum = 0;
            for (int iCnt = 1; iCnt <= no/2; iCnt++)
            {
                if ((no % iCnt) == 0)
                {
                    iSum += iCnt;
                }
            }
            return iSum;
        }

        public int CountDigit(int no)
        {
            int iCnt = 0;
            while(no!=0)
            {
                iCnt++;
                no /= 10;
            }
            return iCnt;
        }

        // Abstract Methods
        public abstract bool CheckStrong();
        public abstract bool CheckArmstrong();
    }

    class Numbers : Marvellous
    {
        public Numbers() { }
        public Numbers(int value) :base(value) { }

        // Sum of digit raise to power of 371 eg 3**3 + 7**3 + 1**3 = 371
        public override bool CheckArmstrong()
        {
            int iValue = base.no;
            int iSum = 0;
            while( iValue != 0)
            {
                iSum += Convert.ToInt32(base.Power((iValue % 10), 3));
                iValue /= 10;
            }

            if (iSum == base.no)
                return true;
             return false;
        }

        // Sum of factorial of digit 145 eg 1! + 4! + 5! = 145
        public override bool CheckStrong()
        {
            int iValue = base.no;
            int iSum = 0;
            int iDigit = 0;
            int iMult = 1;
            while (iValue != 0)
            {
                iDigit = iValue % 10;
                iMult = 1;
                for ( int i = 1; i<= iDigit; i++)
                {
                    iMult *= i;
                }
                iSum += iMult;
                iValue /= 10;
            }

            if (iSum == base.no)
                return true;
            return false;
        }
    }

    abstract class MarvellousRange
    {
        public int iStart;
        public int iEnd;

        public MarvellousRange(int value1 , int value2)
        {
            iStart = value1;
            iEnd = value2;
        }

        // abstract method

        public abstract int SumRange();
        public abstract void DisplayEven();
        public abstract void DisplayOdd();
        public abstract void DisplayPrime();
        public abstract void DisplayPerfect();

    }

    class MyRange : MarvellousRange
    {
        public MyRange( int value1 , int value2) : base(value1, value2) { }

        public override void DisplayEven()
        {
            Console.Write("Even Number are: ");
            for (int i = iStart; i <= iEnd; i++)
            {
                if (i % 2 == 0)
                    Console.Write(" {0} ", i);
            }
            Console.WriteLine();
        }

        public override void DisplayOdd()
        {
            Console.Write("Odd Number are: ");
            for (int i = iStart; i <= iEnd; i++)
            {
                if (i % 2 != 0)
                    Console.Write(" {0} ", i);
            }
            Console.WriteLine();
        }

        public override void DisplayPerfect()
        {
            int iRet = 0;
            Numbers nobj = new Numbers();
            Console.Write("Prefect Number are: ");
            for (int index = iStart; index <= iEnd; index++)
            {
                iRet = nobj.SumFactor(index);
                if (iRet == index)
                    Console.Write($" { index } ");
            }

            Console.WriteLine();
        }

        public override void DisplayPrime()
        {
            int iHalf , i;
            Console.Write("Prime are: ");
            for (int index = iStart; index <= iEnd; index++)
            {
                if(index % 2 != 0)
                {
                    iHalf = index / 2;
                    
                    for ( i = 2; i <= iHalf; i++)
                    {
                        if ((index % i) == 0)
                            break;
                    }

                    if (i >= iHalf)
                        Console.Write(" {0} ", index);
                }
            }

            Console.WriteLine();
        }

        public override int SumRange()
        {
            int sum = 0;
            for( int i = iStart; i <= iEnd; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            // Question 1
            Numbers nobj = new Numbers(145);
            Console.WriteLine("Number of Digit are: {0}", nobj.CountDigit(123456));
            Console.WriteLine("3 Power of 2 is: {0}", nobj.Power(2 , 3));
            Console.WriteLine("Sum of all factor of 12 is: {0}", nobj.SumFactor(12));
            Console.WriteLine("Is given number {1} is Armstrong Number : {0} ", nobj.CheckArmstrong() , nobj.no);
            Console.WriteLine("Is given number {1} is Strong Number : {0} ", nobj.CheckStrong() , nobj.no);
           
            // Question 2
            MyRange range = new MyRange(10, 30);
            range.DisplayEven();
            range.DisplayOdd();
            range.DisplayPerfect();
            range.DisplayPrime();
            Console.WriteLine($" Sum of range: {range.SumRange()} ");
        }
    }
}
