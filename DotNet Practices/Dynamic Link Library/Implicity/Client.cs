using System;
using Marvellous;

// Class declaration
class Demo
{
    // Entry point function
    public static void Main(string[] args)
    {
        Console.WriteLine("Inside Client application");
        // Create object of class from DLL
        Hello hobj = new Hello();
        // Call the exported method from DLL
        hobj.fun();
    }
}
