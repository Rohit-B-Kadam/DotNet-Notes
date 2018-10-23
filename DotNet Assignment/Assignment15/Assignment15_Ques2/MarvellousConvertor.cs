using System;


namespace MarvellousConvertor
{
    public class NumberConvertor
    {
        int iNo;
        public NumberConvertor(int iNo)
        {
            this.iNo = iNo;
        }

        private void RecurBinary( int n)
        {
            if (n == 0)
                return;
            RecurBinary(n / 2);
            Console.Write("{0}", n % 2);
        }

        public void DisplayBinary()
        {
            Console.Write("Binary form: ");
            RecurBinary(iNo);
            Console.WriteLine();
        }

        private void RecurOctal(int n)
        {
            if (n == 0)
                return;
            RecurOctal(n / 8);
            Console.Write("{0}", n % 8);
        }

        public void DisplayOctal()
        {
            Console.Write("Octal form: ");
            RecurOctal(iNo);
            Console.WriteLine();
        }

        private void RecurHex(int n)
        {
            string hexchar = "0123456789ABCDEF";
            if (n == 0)
                return;
            RecurHex(n / 16);

            Console.Write("{0}", hexchar[n % 16]);
        }

        public void DisplayHexadecimal()
        {
            Console.Write("Hexdecimal form: ");
            RecurHex(iNo);
            Console.WriteLine();
        }
    }
}