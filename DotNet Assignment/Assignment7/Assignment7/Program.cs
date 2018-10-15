using System;

namespace Assignment7
{
    class MarvellousString
    {
        public string str;

        public MarvellousString(string name)
        {
            str = name;
        }

        public int StrLenX()
        {
            char ch;
            int iLength = 0;
            try
            {
                while( true)
                {
                    ch = str[iLength];
                    iLength++;
                }
            }catch(Exception e)
            {
                //timepass
            }
            return iLength;
        }

        public int CountCapital()
        {
            int iCnt = 0;
            for( int i = 0; i < str.Length; i++)
            {
                if ('A' <= str[i] && str[i] <= 'Z')
                    iCnt++;
            }
            return iCnt;
        }

        public int CountSmall()
        {
            int iCnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ('a' <= str[i] && str[i] <= 'z')
                    iCnt++;
            }
            return iCnt;
        }

        public int Frequency( char ch)
        {
            int iCnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ( str[i] == ch )
                    iCnt++;
            }
            return iCnt;
        }

        public int CountVowels()
        {
            int iCnt = 0;
            String vowels = "aeious";
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(str[i].ToString()))
                    iCnt++;
            }
            return iCnt;
        }

        public int CountSpace()
        {
            int iCnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ( str[i] == ' ')
                    iCnt++;
            }
            return iCnt;
        }

        public int SearchFirst(char ch)
        {
            int i;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                    break;
            }
            return i+1;
        }

        public int SearchLast( char ch)
        {
            int i;
            for (i = (str.Length - 1); i >= 0; i--)
            {
                if (str[i] == ch)
                    break;
            }
            return i + 1;
        }

        public bool CheckPalindrome()
        {
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MarvellousString obj = new MarvellousString("Mavellous I");
            Console.WriteLine("Lenght of string is : {0}", obj.StrLenX());
            Console.WriteLine("Capital counts : {0}", obj.CountCapital());
            Console.WriteLine("Small letter counts : {0}", obj.CountSmall());
            Console.WriteLine("Frequence of  'l' : {0}", obj.Frequency('l'));
            Console.WriteLine("Search 'l' from first : {0}", obj.SearchFirst('l'));
            Console.WriteLine("Search 'l' from last : {0}", obj.SearchLast('l'));
            Console.WriteLine("Space in String  : {0}", obj.CountSpace());
            Console.WriteLine("Vowels in string: {0}", obj.CountVowels());
        }
    }
}
