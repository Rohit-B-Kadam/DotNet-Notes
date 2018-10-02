using System;

/* Points
 * 
 * 1. To redefine the function you have to use new keyboard ie to cut overriding. check Fun()
 * 2. To override you have to use virtual and override keyword. check Gun()
 * 3. If there is no override function written in refer class then above or last override function is called.
 *      if there is three class A->B->C then B class override function will be called.  check Sun()
 * 4. - If Function is virtual it will go down till end of override function.
 *    - You cannot write same function virtual in base class and derived class. 
 *          If you have to write the virtual keyword in Derived Class Function you have to write new keyword. 
 *          This will stop above overriding function and start new overriding Function 
 *    - check Run() 
 *  5. We can override the virtual function at any level of multilevel inheritance. check Tun()
 *  
 *  
 *  Form Above we can predict
 *  
 *  1. You can override function only if that function is virtual, abstract or override in Base class.
 *  2. If we make a function virtual which is already virtual then we have stop the override of previous function and started new override.
 *  3. If there is Virtual function, then it goes up (means to its derived class) and check if there is override function
 *          If we found then we goes up again till the override of that is stop or it reach to refer type class.
 * 
 */

namespace OverridingAndRedefinition
{
    
    class Base
    {
        // Function without 'virtual' keyword
        public void Fun()
        {
            Console.WriteLine("In fun of Base");
        }

        // Function with 'virtual' keyword
        public virtual void Gun()
        {
            Console.WriteLine("In gun of Base");
        }

        public virtual void Sun()
        {
            Console.WriteLine("In sun of Base");
        }

        public virtual void Run()
        {
            Console.WriteLine("In Run of Base");
        }

        public virtual void Tun()
        {
            Console.WriteLine("In Tun of Base");
        }
    }

    class Derived1 : Base
    {
        // Function with 'new' Keyword
        // 'new' keyword is use to hidding base.fun() function 
        public new void Fun()
        {
            Console.WriteLine("In fun of Derived1");
        }

        // Function with 'override' keyword
        // 'override' keyword is use to make above base.gun() to override
        public override void Gun()
        {
            Console.WriteLine("In gun of Derived1");
        }

        // There we have stop overriding above class function
        public override void Sun()
        {
            Console.WriteLine("In sun of Derived1");
        }

        public virtual new void Run()
        {
            Console.WriteLine("In Run of Derived1");
        }
    }

    class Derived2: Derived1
    {
        // Redefination 
        public new void Fun()
        {
            Console.WriteLine("In fun of Drived1");
        }

        // OverLoading
        public override void Gun()
        {
            Console.WriteLine("In gun of Derived2 class");
        }

        // override Run() function only from Derived1 class
        public override void Run()
        {
            Console.WriteLine("In run of Drived2");
        }

        public override void Tun()
        {
            Console.WriteLine("In Tun of Derived2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Base dobj2 = new Derived2();
            dobj2.Fun();    //Base
            dobj2.Gun();    //Derived2
            dobj2.Sun();    //Derived1
            dobj2.Run();    //base
            dobj2.Tun();    //Derived2

            Derived1 dobj1 = new Derived2();
            dobj1.Tun();
            dobj1.Fun();
        }
    }
}
