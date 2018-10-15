using System;

/*

    1    1     0     0     1    0
     
    5th  4th   3rd   2nd  1st   0th
 */
namespace Assignment8
{
    abstract class MarvellousNumber
    {
        public int no;

        public MarvellousNumber( int value)
        {
            no = value;
        }

        public abstract int CountOnBit();
        public abstract void DisplayBinary();
        public abstract bool CheckBit(int pos);
        public abstract void OffBit(int pos);
        public abstract void ToggleBit(int pos);
    }

    class Bitwise : MarvellousNumber
    {
        public Bitwise(int value): base(value) { }

        public override int CountOnBit()
        {
            int iCnt = 0;
            int temp = no; 
            
            while( temp != 0 )
            {
                if( (temp % 2) == 1)
                    iCnt++;
                temp /= 2;
            }
            return iCnt;
        }

        void Binary(int n)
        {
            if (n != 0)
            {
                Binary(n / 2);
                Console.Write($"{n % 2}");
            }
            return;
        }

        public override bool CheckBit(int pos)
        {
            int mark = 0;
            mark = Convert.ToInt32(Math.Pow(2, pos));

            if ((base.no & mark) == 0)
                return false;
            return true;
        }

        public override void DisplayBinary()
        {
            Binary(base.no);
        }

        public override void OffBit(int pos)
        {
            int mark = 0;
            mark = Convert.ToInt32(Math.Pow(2, pos));
            
            // I have make that bit 1
            base.no = base.no | mark;
            // Then I XOR that bit to make it 0
            base.no = base.no ^ mark;
         }

        public override void ToggleBit(int pos)
        {
            int mark = 0;
            mark = Convert.ToInt32(Math.Pow(2, pos));
            base.no = base.no ^ mark;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bitwise obj = new Bitwise(39);

            Console.WriteLine("Number of 1s is: {0}", obj.CountOnBit());
            Console.Write("Binary representation is- ");
            obj.DisplayBinary();
            Console.WriteLine();
            
            if( obj.CheckBit(5))
            {
                Console.WriteLine("Bit at 5th position is on");
            }
            else
            {
                Console.WriteLine("Bit at 5th position is off");
            }
            
            // dispaly binary
            obj.DisplayBinary();
            Console.WriteLine();

            obj.OffBit(1);
            Console.WriteLine("Off the 1st bit Updated number is {0}", obj.no);

            // dispaly binary
            obj.DisplayBinary();
            Console.WriteLine();

            //Toggle
            obj.ToggleBit(3);
            Console.WriteLine("Toggle 3th bit Updated number is {0}", obj.no);

            // dispaly binary
            obj.DisplayBinary();
            Console.WriteLine();

        }
    }
}
