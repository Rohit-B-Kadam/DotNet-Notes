using System;


namespace Ques1Numbers
{
    class Numbers
    {
        protected int iSize;
        protected int[] arr;

        //Default Constructor
        public Numbers() : this(10) // calling parametrised constructor
        {
            /*
            iSize = 10;
            arr = new int[iSize];
            */
        }

        // Parametrised Constructor
        public Numbers(int arraySize)
        {
            iSize = arraySize;
            arr = new int[iSize];
        }

        // Copy Constructor
        public Numbers( Numbers obj): this(obj.iSize)
        {
            /* Deep Copy */
            for( int i = 0; i < iSize; i++ )
            {
                this.arr[i] = obj.arr[i];
            }
        }

        // To Accept value of array
        public void Accept()
        {
            Console.WriteLine($"Enter {iSize} Number: ");
            for( int i = 0; i < iSize; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Display All element of Array
        public void Display()
        {
            Console.Write("Element of Array are: ");
            for (int i = 0; i < iSize; i++)
            {
                Console.Write($" {arr[i]} ");
            }
            Console.WriteLine();
        }
    }

    class ArrayOperations : Numbers
    {
        public ArrayOperations() : base()
        { }

        public ArrayOperations( int no ): base( no)
        { }

        public ArrayOperations( ArrayOperations obj ): base(obj)
        { }

        public int Maximum()
        {
            int max = base.arr[0];
            for( int i = 1; i < iSize; i++)
            {
                if( max < base.arr[i])
                {
                    max = base.arr[i];
                }
            }
            return max;
        }

        public int Minimum()
        {
            int min = base.arr[0];
            for (int i = 1; i < iSize; i++)
            {
                if ( min > base.arr[i])
                {
                    min = base.arr[i];
                }
            }
            return min;
        }
    }

    class ArrayCombine : Numbers
    {
        public ArrayCombine() : base()
        { }

        public ArrayCombine( int no ) : base(no)
        { }

        public ArrayCombine( ArrayCombine obj ) : base(obj)
        { }

        // Accept one number and return position at which it occur
        public int Search(int no)
        {
            int index;
            for( index = 0; index < iSize; index++ )
            {
                if (base.arr[index] == no)
                    break;
            }
            if (index == iSize)
                return -1;
            return index + 1;
        }

        // Accept one number and Return frequency of that number in Array 
        public int Frequency( int no )
        {
            int iFreq = 0;

            for (int iCnt = 0; iCnt < iSize; iCnt++)
            {
                if (base.arr[iCnt] == no)
                    iFreq++;
            }

            return iFreq;
        }

        //Return the Summation of all the elements of array
        public int Summation()
        {
            int iSum = 0;

            foreach (var element in base.arr)
            {
                iSum += element;
            }
            return iSum;
        }

        //Return the Average of all the elements of array
        public float Average()
        {
            float iTotal = 0;
            float iAverage = 0;

            iTotal = this.Summation();
            iAverage = iTotal / base.iSize;
            return iAverage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /****  Ques1
            
            // creating object using default constructor
            Numbers nobj1 = new Numbers();
            nobj1.Accept();
            nobj1.Display();

            // Creating object using parametrised Constructor
            Numbers nobj2 = new Numbers(5);
            nobj2.Accept();
            nobj2.Display();

            // Creating copy of obj2
            Numbers nobj3 = new Numbers(nobj2);
            nobj3.Display();

            *****/

            /***** Ques 2
             

            // object 1
            ArrayOperations aobj1 = new ArrayOperations();
            aobj1.Accept();
            aobj1.Display();
            Console.WriteLine($"Maximum Number is : { aobj1.Maximum() }");
            Console.WriteLine($"Minimum Number is : { aobj1.Minimum() }");

            // object 2
            ArrayOperations aobj2 = new ArrayOperations(6);
            aobj2.Accept();
            aobj2.Display();
            Console.WriteLine($"Maximum Number is : { aobj2.Maximum() }");
            Console.WriteLine($"Minimum Number is : { aobj2.Minimum() }");

            // object3 
            ArrayOperations aobj3 = new ArrayOperations(aobj2);
            aobj3.Display();
            Console.WriteLine($"Maximum Number is : { aobj3.Maximum() }");
            Console.WriteLine($"Minimum Number is : { aobj3.Minimum() }");

            *****/

            /*** Ques 3
             */

            ArrayCombine acobj1 = new ArrayCombine(5);
            int no;
            int iRet;
            acobj1.Accept();
            acobj1.Display();

            // Search
            Console.Write("Enter number that you want to Search: ");
            no = Convert.ToInt32(Console.ReadLine());
            iRet = acobj1.Search(no);

            if (iRet != -1)
                Console.WriteLine($"Position is : { iRet } ");
            else
                Console.WriteLine("Number is not present in Array");

            // Freaquence
            Console.Write("Enter number that you want to find the Frequence: ");
            no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Frequence of { no } is : { acobj1.Frequency(no) } ");

            // Summation
            Console.WriteLine($" Summation of all elements in array is : {acobj1.Summation() } ");

            // Average
            Console.WriteLine($" Average of all elements in array is : {acobj1.Average() } ");
        }
    }
}
