using System;

namespace MarvellousString
{
    public class StringMethods
    {
        public void DisplayLargestWord( string line)
        {
            string[] words = line.Split(' ');
            string largeString = string.Empty;
            foreach (var word in words)
            {
                if( largeString.Length < word.Length)
                {
                    largeString = word;
                }
            }
            Console.WriteLine("Largest Word form the string is: {0}", largeString);
        }

        public bool ChkPalindrome( string word)
        {
            string str = word.ToLower();
            int i, j;
            for( i = 0, j = str.Length - 1; i<=j; i++,j--)
            {
                if (str[i] != str[j])
                    break;
            }

            if (i < j)
                return false;
            return true;
        }
    }
}