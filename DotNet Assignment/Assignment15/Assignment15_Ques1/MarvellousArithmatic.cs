using System;


namespace MarvellousArithmatic
{
    public class Arithmatic
    {
        int iNo1;
        int iNo2;

        public Arithmatic(int no1, int no2)
        {
            iNo1 = no1;
            iNo2 = no2;
        }

        public int Addition()
        {
            return iNo1 + iNo2;
        }

        public int Subtraction()
        {
            return iNo1 - iNo2;
        }

        public int Multiplication()
        {
            return iNo1 * iNo2;
        }

        public int Division()
        {
            if (iNo2 == 0)
                return 0;
            return iNo1 / iNo2;
        }

    }
}