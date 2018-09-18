using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que3CountUppercaseAndLowercase
{
    class String
    {
        // Counting Uppercase letter from string
        public static int CountUpperCaseLetter(string str)
        {
            int iCnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsUpper(str[i]))
                {
                    iCnt++;
                }
            }
            return iCnt;
        }

        // Counting Lowercase letter from string
        public static int CountLowerCaseLetter(string str)
        {
            int iCnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLower(str[i]))
                {
                    iCnt++;
                }
            }
            return iCnt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string sName;
            int iRet;
            Console.Write("Enter your name: ");
            sName = Console.ReadLine();

            Console.WriteLine("Your Name is: {0}",sName);

            iRet = String.CountUpperCaseLetter(sName);
            Console.WriteLine("Number of Capital letter present in given string is: {0}", iRet);

            iRet = String.CountLowerCaseLetter(sName); 
            Console.WriteLine("Number of LowerCase letter present in given string is: {0}", iRet);
        }
    }
}
