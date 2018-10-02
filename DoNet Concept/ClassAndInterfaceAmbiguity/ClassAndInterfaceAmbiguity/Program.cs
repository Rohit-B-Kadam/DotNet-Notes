using System;

/* 1. If there is two or more interface having same function name and same prototype, 
 *      then there will be no error, If we inplement that funtion in implemented class.
 * 2. If there is two or more interface havimg same prototype except there return value.
 *      Then you have to implement all that Function, 
 *      But Rule of overload:- We can't overload function with differ in return type.
 *      So We can't implement all the Function.
 *      To resolve the problem see below code.
 */
namespace ClassAndInterfaceAmbiguity
{
    class Demo
    {
        public virtual void Fun()
        {
            Console.WriteLine("Fun in Demo");
        }
    }

    interface Welcome
    {
        void Fun();
    }

    interface Hello
    {
        float Fun();
    }

    interface World
    {
        int Fun();
    }
    class Derived : Demo, Hello, World
    {

        // This function is override of fun in Demo class and Welcome Interface.
        // If we not added this function, there will be no error for Welcome Interface because Base class have function automatic inherited
        public override void Fun()
        {
            Console.WriteLine("void Fun in Derived");
        }

        // This function can't be called. we have added because we have inplement Hello interface, 
        //      so to remove error we have write like this. 
        float Hello.Fun()
        {
            Console.WriteLine("void Fun in Derived");
            return 10f;
        }

        int World.Fun()
        {
            Console.WriteLine("void Fun in Derived");
            return 10;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Derived dobj = new Derived();
            dobj.Fun();
        }
    }
}
