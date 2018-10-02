using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Demostrating Equals function in Object class and String Class
 */
namespace OverLoading_Static_NonStatic_Function
{
    class MyString
    {
        public string str;

        public MyString( string str)
        {
            this.str = str;
        }

        
        // override Equal function to make case insensitive equal function
        public override bool Equals(Object obj)
        {
            // Converting both string to UpperCase
            String str1 = str.ToUpper();
            String str2 = obj.ToString().ToUpper();

            if (str1 == str2)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // We have override because I have use in Equals Function
        public override string ToString()
        {
            return str;
        }

        // static Equals Function(we can't override static function)
        public new static bool Equals(Object obj1 , Object obj2)
        {
            // Converting both object into UpperCase String
            String str1 = obj1.ToString().ToUpper(); ;
            String str2 = obj2.ToString().ToUpper();

            if (str1 == str2)
                return true;
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyString sobj1 = new MyString("rohit");
            MyString sobj2 = new MyString("roHit");
            string sobj3 = "RoHit";
            int i = 12;

            Console.WriteLine("Both string is same :--> {0}", sobj1.Equals(i));
            Console.WriteLine("Both string is same :--> {0}", sobj1.Equals(sobj3));


            Console.WriteLine("\nStatic Funtion");
            Console.WriteLine("Both string is same :--> {0}", MyString.Equals(sobj1,sobj2));
        }
    }
}
