using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Assignment 14 Question 2
 * Create generic Delegate which can call all methods from below class
 */
namespace Ques2
{
    class Marvellous
    {
        public int AddI(int val1, int val2)
        {
            int result;
            result = val1 + val2;
            return result;
        }

        public float AddF(float val1, float val2)
        {
            float result;
            result = val1 + val2;
            return result;
        }
        public double AddD(double val1, double val2)
        {
            double result;
            result = val1 + val2;
            return result;
        }
        public string AddS(string str1, string str2)
        {
            string result;
            result = str1 + str2;
            return result;
        }
    }

    // Create Generic Delegate
    public delegate T GenDel<T>(T val1, T val2);

    class Program
    {
        static void Main(string[] args)
        {
            Marvellous mobj = new Marvellous();
            GenDel<int> intDel = new GenDel<int>(mobj.AddI);
            Console.WriteLine(" Adding of (2,3) are: {0} ", intDel(2,3));

            GenDel<float> floatDel = new GenDel<float>(mobj.AddF);
            Console.WriteLine(" Adding of (2.3f,3.2f) are: {0} ", floatDel(2.3f, 3.2f));

            GenDel<double> doubleDel = new GenDel<double>(mobj.AddD);
            Console.WriteLine(" Adding of (2.12,3.21) are: {0} ", doubleDel(2.12, 3.21));

            GenDel<string> stringDel = new GenDel<string>(mobj.AddS);
            Console.WriteLine(" Adding of ('rohit','Kadam') are: {0} ", stringDel("rohit", "Kadam"));
        }
    }
}
