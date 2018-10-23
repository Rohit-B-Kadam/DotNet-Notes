using System;

using MarvellousArithmatic;

/*

    Command:
    csc /target:library /out:Library1 MarvellousArithmatic.cs
    csc /reference:Library1.dll /out:myexe.exe ClientApplicationA14Q1.cs
    myexe.exe
*/
class ClientApplication
{
    public static void Main(String[] args)
    {
        int iRet;
        Arithmatic aobj = new Arithmatic(12,3);

        iRet = aobj.Addition();
        Console.WriteLine("Addition is: {0}", iRet);

        iRet = aobj.Subtraction();
        Console.WriteLine("Subtraction is: {0}", iRet);

        iRet = aobj.Multiplication();
        Console.WriteLine("Multiplication is: {0}", iRet);

        iRet = aobj.Division();
        Console.WriteLine("Division is: {0}", iRet);

    }
}