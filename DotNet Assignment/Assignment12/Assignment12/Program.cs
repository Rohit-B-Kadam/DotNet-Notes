using System;
using System.Diagnostics;
using System.Globalization;


/*
 *  Assignment is on DateTime
 */

namespace Assignment12Ques1
{
    // Ques 1:-->
    delegate void noParameter();

    class Marvellous
     {
        // Demostration of out parameter
        public void Fun()
        {
            for (int i = 0; i < 2000; i++)
            {
                Console.Write("\t {0} ", i);
            }
        }

        public void Gun()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("\t {0} ", i);
            }
        }
    }

    class FuncElapsedTime
    {
        public static void FunctionWithNoParameter( noParameter DelFunc)
        {
            // like Stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            DelFunc();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine();
            Console.WriteLine("Elapsed Time -->");
            Console.WriteLine("In nanosecond : {0}", ts.Ticks * 100);
            Console.WriteLine("In millisecond : {0} ", ts.TotalMilliseconds);
            Console.WriteLine("In second : {0} ", ts.TotalSeconds);

        }
    }
   
    
    // Ques 2:-->
   
    class InvalidDateException : Exception
    {
        public InvalidDateException(string str) : base(str) {
            Console.WriteLine("Exception: "+str);
        }

    }

    class BirthDate
    {

        DateTime bdate;

        public BirthDate()
        { }

        public void Accept()
        {

            string dateInput;
            string pattern = "dd-MM-yyyy";
            DateTime parsedDate = new DateTime();

            Console.Write("Enter your BirthDate(dd-MM-yyyy): ");
            dateInput = Console.ReadLine();

            if (DateTime.TryParseExact(dateInput, pattern, null, DateTimeStyles.None, out parsedDate))
            {
                if (parsedDate > DateTime.Now)
                {
                    throw new InvalidDateException("Invalid BirthDate");
                }
            }
            else
                throw new InvalidDateException("Invalid BirthDate");


            bdate = parsedDate;
            Console.WriteLine("Date is set to {0}", bdate);
        }

        public void Display()
        {

            DateTime centuryBegin = bdate;
            DateTime currentDate = DateTime.Now;

            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            DateTime dt = new DateTime(elapsedTicks);
            
            // by default day month year are increased by one(because date can't set to 0 it is set to 1)
            Console.WriteLine("Your Age is: {0} year {1} month {2} day {3} hours {4} min {5} sec",
                                dt.Year - 1 , dt.Month - 1, dt.Day - 1, dt.Hour, dt.Minute, dt.Second);
         
        }
    }


    // Ques 3--->

    class Employee
    {

        DateTime joinDate;

        public Employee()
        { }

        public void Accept()
        {

            string dateInput;
            string pattern = "dd-MM-yyyy";
            DateTime parsedDate = new DateTime();

            Console.Write("Enter your Joining Date(dd-MM-yyyy): ");
            dateInput = Console.ReadLine();

            if (DateTime.TryParseExact(dateInput, pattern, null, DateTimeStyles.None, out parsedDate))
            {
                if (parsedDate > DateTime.Now)
                {
                    throw new InvalidDateException("Invalid BirthDate");
                }
            }
            else
                throw new InvalidDateException("Invalid BirthDate");

            joinDate = parsedDate;
            Console.WriteLine("Date is set to {0}", joinDate);
        }

        public void Display()
        {

            DateTime centuryBegin = joinDate;
            DateTime currentDate = DateTime.Now;

            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            DateTime dt = new DateTime(elapsedTicks);

            // by default day month year are increased by one(because date can't set to 0 it is set to 1)
            switch(dt.Year-1)
            {
                case 0:
                    Console.WriteLine("Your Designation is: Associate Software Engineer");
                    break;
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("Your Designation is: Senior Software Engineer Level 1");
                    break;
                case 4:
                case 5:
                    Console.WriteLine("Your Designation is: Senior Software Engineer Level 2");
                    break;
                default:
                    Console.WriteLine("Your Designation is: Senior Software Engineer");
                    break;

            }
        }
    }

    // Main Class :--->
    class Program
    {
        static void Main(string[] args)
        {
            /*-------------- Ques 1 -----------------*/
            /*
            Marvellous mobj = new Marvellous();
            FuncElapsedTime.FunctionWithNoParameter(mobj.Fun);
            FuncElapsedTime.FunctionWithNoParameter(mobj.Gun);
            */

            /*-------------- Ques 2 -----------------*/
            /*        
            BirthDate dob = new BirthDate();
            try
            {
                dob.Accept();
                dob.Display();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            */


            /*-------------- Ques 2 -----------------*/
            /*
            Employee emp = new Employee();
            try
            {
                emp.Accept();
                emp.Display();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            */
        }
    }
}
/*
 * Information From:
 * https://docs.microsoft.com/en-us/dotnet/api/system.datetime.ticks?view=netframework-4.7.2
 * https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
 */
