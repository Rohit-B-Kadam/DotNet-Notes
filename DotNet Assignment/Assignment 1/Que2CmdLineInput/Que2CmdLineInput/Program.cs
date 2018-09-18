using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que2CmdLineInput
{
    class Addition
    {
        // Static method to add all element from array
        public static int StringArray( string[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += Convert.ToInt32(arr[i]);
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Checking if user have proper given 5 input through command line
            if (args.Length != 5)
            {
                Console.WriteLine("Give proper five number  as a input through command line");
                return;
            }

            // Static method can be call by class name
            int iRet = Addition.StringArray(args);

            Console.WriteLine("Addition is : {0}", iRet);
        }
    }
}
