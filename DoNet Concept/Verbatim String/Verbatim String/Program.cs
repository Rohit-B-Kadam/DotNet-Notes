using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbatim_String
{
    class MyString
    {
        public string vstr;

        public MyString(string vstr)
        {
            this.vstr = vstr;
        }

        public int CountNoOfEscapeSequence()
        {
            StringBuilder str = new StringBuilder(vstr);
            Console.WriteLine("verbatim string: {0}", vstr);
            Console.WriteLine("Normal string: {0}", str.ToString());
            return 1;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Both str1 and str2 have same hashcode
            String str1 = @"S\trings";
            String str2 = "S\\trings";

            Console.WriteLine($"{str1} ==> { str1.GetHashCode()}");
            Console.WriteLine($"{str2} ==> {str2.GetHashCode()}");
            */
            
            string str;
            Console.WriteLine("Enter the String with Escape sequence");
            str = Console.ReadLine();

            MyString sobj = new MyString(@"stri\ng");
            
            Console.WriteLine("Number of EscapeSequence and Special Character are: {0}", sobj.CountNoOfEscapeSequence());
        }
    }
}
