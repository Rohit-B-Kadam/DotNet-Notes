using System;

using MarvellousConvertor;
using MarvellousString;

/*

    Command use:
    csc /target:library /out:library1.dll MarvellousConvertor.cs
    csc /target:library /out:library2.dll MarvellousString.cs
    csc /reference:Library1.dll,Library2.dll /out:myexe.exe ProgramA15_Q2.cs
    myexe.exe

*/
class Program15
{
    static void Main(String[] args)
    {
        /*------- MarvellousConvertor-----------*/
        int no;
        NumberConvertor mc;

        Console.Write("Enter the Number: ");
        no = Convert.ToInt32(Console.ReadLine());

        mc = new NumberConvertor(no);
        mc.DisplayBinary();
        mc.DisplayOctal();
        mc.DisplayHexadecimal();


        /*----------- MarvellousString ----------------*/
        string str;
        StringMethods sm = new StringMethods();
        Console.WriteLine();
        Console.Write("Enter the one Line: ");
        str = Console.ReadLine();
        sm.DisplayLargestWord(str);

        Console.Write("Enter the word to check palindrome or not: ");
        str = Console.ReadLine();
        if (sm.ChkPalindrome(str))
        {
            Console.WriteLine("Word is palindrome");
        }
        else
        {
            Console.WriteLine("Word is not palindrome");
        }

    }
}