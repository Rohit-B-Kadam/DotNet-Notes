using System;

namespace Assignment5
{
    // declare delegates
    delegate int MyDel();

    class Arithmetric
    {
        public int iNo1;
        public int iNo2;

        public Arithmetric(int x , int y)
        {
            iNo1 = x;
            iNo2 = y;
        }

        public int Add()
        {
            return iNo1 + iNo2;
        }

        public int Sub()
        {
            return iNo1 - iNo2;
        }

        public int Mult()
        {
            return iNo1 * iNo2;
        }

        public int Div()
        {
            return iNo1 / iNo2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 
            // Question 1
            Arithmetric aobj = new Arithmetric(10, 2);

            MyDel dObj1 = new MyDel(aobj.Add);
            Console.WriteLine($"Addition is { dObj1() }");

            MyDel dObj2 = new MyDel(aobj.Sub);
            Console.WriteLine($"Substraction is { dObj2() }");

            MyDel dObj3 = new MyDel(aobj.Mult);
            Console.WriteLine($"Multiplication is { dObj3() }");

            MyDel dObj4 = new MyDel(aobj.Div);
            Console.WriteLine($"Division is { dObj4() }");
            */

            /*
            // Question 2
            Arithmetric aobj = new Arithmetric(10, 2);

            MyDel[] dObj = new MyDel[4];
            dObj[0] = new MyDel(aobj.Add);
            dObj[1] = new MyDel(aobj.Sub);
            dObj[2] = new MyDel(aobj.Mult);
            dObj[3] = new MyDel(aobj.Div);

            string[] display = { "Additon", "Substration", "Multiplication", "Division" };
            for( int i = 0; i < 4; i++)
            {
                Console.WriteLine($" { display[i] } of 10 and 2  is: { dObj[i]() }");
            }
            */

            // Question 3 Multicast
            Arithmetric aobj = new Arithmetric(10, 2);

            MyDel dObj = new MyDel(aobj.Add);
            dObj += new MyDel(aobj.Sub);
            dObj += new MyDel(aobj.Mult);
            dObj += new MyDel(aobj.Div);

            Console.WriteLine($"Division of 10 and 2 is: { dObj() }");

            dObj -= new MyDel(aobj.Div);
            Console.WriteLine($"Multiplication of 10 and 2 is: { dObj() }");

            dObj -= new MyDel(aobj.Mult);
            Console.WriteLine($"Substraction of 10 and 2 is: { dObj() }");

            dObj -= new MyDel(aobj.Sub);
            Console.WriteLine($"Addition is of 10 and 2 is: { dObj() }");
        }
    }
}
