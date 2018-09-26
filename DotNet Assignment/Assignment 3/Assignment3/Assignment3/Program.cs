using System;

namespace Assignment3
{
    abstract class NumTemplate
    {
        protected int iNumber;

        public NumTemplate()
        {
            iNumber = 0;
        }

        public NumTemplate( int value)
        {
            iNumber = value;
        }

        public abstract void Accept();
        public abstract void Display();
        public abstract void ChkEven();
        public abstract void DisplayFactors();
        public abstract int SumFactors();

    }

    class NumOperation : NumTemplate
    {
        public NumOperation():base()
        { }

        public NumOperation( int value ): base( value)
        { }

        public override void Accept()
        {
            Console.Write("Enter the number: ");
            base.iNumber = Convert.ToInt32(Console.ReadLine());
        }

        public override void ChkEven()
        {
            if( (base.iNumber % 2) == 0)
            {
                Console.WriteLine("Number is Even");
            }
            else
            {
                Console.WriteLine("Number is Odd");
            }
        }


        public override void Display()
        {
            Console.WriteLine("Number is {0}", base.iNumber);
        }

        public override void DisplayFactors()
        {
            Console.Write("Factor of {0} is: ", base.iNumber);
            for( int iCnt = 1; iCnt <= base.iNumber; iCnt++)
            {
                if( (iNumber % iCnt) == 0)
                {
                    Console.Write($" {iCnt} ");
                }
            }
            Console.WriteLine();
        }

        // Sum of all factors of number
        public override int SumFactors()
        {
            int iSum = 0;
            for (int iCnt = 1; iCnt <= base.iNumber; iCnt++)
            {
                if ((iNumber % iCnt) == 0)
                {
                    iSum += iCnt;
                }
            }
            return iSum;
        }
        
    }

    class NumberActivity : NumOperation
    {
        public NumberActivity():base()
        { }

        public NumberActivity( int value ) : base( value)
        { }

        public bool ChkPrime()
        {
            int iHalf = base.iNumber / 2;       // Divisor range of any number [ 1 , number/2 ]

            // Checking if there is any divisble of that number. if there is we return false 
            int i;
            for ( i = 2; i <= iHalf; i++)
            {
                if ((base.iNumber % i) == 0)
                    break;
            }

            if (i >= iHalf)
                return true;
            return false;
        }

        /* Perfect number that is equa;l to the sum of its proper divisors*/ 
        public bool ChkPerfect()
        {
            int iVaries = base.iNumber / 2;         // Divisor range of any number [ 1 , half of number ]
            int iSum = 1;                    // Initializing with 1 because every number is divisble by 1

            // Finding and adding divisor of given number
            for (int i = 2; i < iVaries; i++)
            {
                if ((base.iNumber % i) == 0)
                {
                    iSum += i;
                    iVaries = base.iNumber / i;
                    iSum += iVaries;
                }
            }

            if (iSum == base.iNumber)
                return true;
            return false;
        }

        public long Factorial()
        {
            long iResult = 1;
            int iTemp = base.iNumber;
            while (iTemp != 0)
            {
                iResult *= iTemp;
                iTemp--;
            }
            return iResult;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NumberActivity obj = new NumberActivity();
            obj.Accept();
            obj.Display();
            obj.ChkEven();
            obj.DisplayFactors();
            Console.WriteLine($"Sum of all Factors is: { obj.SumFactors() }");
            Console.WriteLine($"Factorial is: { obj.Factorial() }");

            if ( obj.ChkPrime() )
                Console.WriteLine("Number is Prime");
            else
                Console.WriteLine("Number is not Prime");

            if (obj.ChkPerfect())
                Console.WriteLine("Number is Perfect number");
            else
                Console.WriteLine("Number is not Perfect number");
            
        }
    }
}
