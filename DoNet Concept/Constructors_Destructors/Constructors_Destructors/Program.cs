using System;

/*
 *  Constructor:
 *      - Constructor is the function which gets called implicitly when objects memory gets allocated.
 *      - It is used to allocate resources.
 *      - It is used to initialise non static characteristics.
 *    
 *    There are five types of constructors as
 *      1. Default constructor
 *      2. Parametrised constructor
 *      3. Copy constructor
 *      4. Private constructor
 *      5. Static constructor
 *      
 *   Destructor:
 *       - Destructor is the function which gets called implicitly when object memory gets deallocated.
 *       - It is used to deallocate resources which are allocated in contructor.
 *   
 *   Static Constructor:
 *      - It is used to initialise static members of class.
 *      - It get executed only once when class is loaded.
 *
 *  Private Constructor:
 *      - It is used when we not want the developed to create the object using constructor that we have mention as a private constructor
 *      - It is generally used in classes that contain static members only. 
 *      - If a class has one or more private constructors and no public constructors, 
 *              other classes (except nested classes) cannot create instances of this class
 *      - We can not inherit that class.
 */

namespace Constructors_Destructors
{
    // "Application 1"   which demonstrate use of Default, Parametrised and Copy constructors.
    class Demo
    {
        public int i;

        // Default Constructor
        public Demo()
        {
            this.i = 11;
            Console.WriteLine("Inside default constructor");
        }

        // Parametrised Constructor
        public Demo(int no)
        {
            this.i = no;
            Console.WriteLine("Inside parametrised constructor");
        }

        // Copy Constructor
        public Demo( Demo obj)
        {
            this.i = obj.i;
            Console.WriteLine("Inside copy constructor");
        }

        // Destructor
        ~Demo()
        {
            Console.WriteLine("Inside Destructor");
        }
    }

    // "Application 2" which demonstrate static constructor.
    class StaticDemo
    {
        static public int i;
        public int j;

        // Static constructor can't have parameter.
        static StaticDemo()
        {
            i = 11;
            Console.WriteLine("Inside static constructor of StaticDemo");
        }

        // Default constructor
        public StaticDemo()
        {
            j = 21;
            Console.WriteLine("Inside Default constructor of StaticDemo");
        }

    }

    // "Application 3" which demonstrate private constructor.
    class PrivateDemo
    {
        public int i;

        // private Default Constructor
        private PrivateDemo()
        {
            // This is part will never executed
            this.i = 11;
            Console.WriteLine("Inside default constructor");
        }

        // Parametrised Constructor
        public PrivateDemo(int no)
        {
            this.i = no;
            Console.WriteLine("Inside parametrised constructor of PrivateDemo");
        }

        // Destructor
        ~PrivateDemo()
        {
            Console.WriteLine("Inside Destructor of PrivateDemo");
        }
    }

    internal class MyDemo : PrivateDemo
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            /* Application 1 */
            /*
               Demo obj1 = new Demo(); // Default constructor gets invoked
               Demo obj2 = new Demo(21); // Parametrised constructor gets invoked
               Demo obj3 = new Demo(obj2); // Copy constructor gets invoked
            */

            /* Application 2 */
            /*
              StaticDemo sdobj1 = new StaticDemo();
              StaticDemo sdobj2 = new StaticDemo();
              StaticDemo sdobj3 = new StaticDemo();
            */

            /* Application 3 */
            // We can not create object using default constructor due to private constructor
            //PrivateDemo pdobj = new PrivateDemo();
            PrivateDemo pdobj = new PrivateDemo(20);
        }
    }
}
