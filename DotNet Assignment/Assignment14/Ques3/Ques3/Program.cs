using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Assignment 14 Ques3
 * 
 * one generic class with Bubble sort, Efficient Bubble sort, ...
 */

namespace Ques3
{
    public class MarvellousArray<T> where T : IComparable<T>
    {
        private T[] array;
        private T[] reArrange;               
        public MarvellousArray(int size)
        {
            array = new T[size];
            reArrange = new T[size];
        }

        public void Accept()
        {
            string str;
            Console.WriteLine("Enter the element in array: ");
            for(int i = 0; i < array.Length; i++)
            {
                str = Console.ReadLine();
                array[i] = (T)Convert.ChangeType(str, typeof(T));
            }
            // ChangeType: Returns an object of the specified type and whose value is equivalent to the specified object.
            array.CopyTo(reArrange , 0);
        }

        public void Display()
        {
            Console.Write("Element in array are: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" {0}", array[i]);
            }
            Console.WriteLine();
        }

        public void BubbleSort()
        {
            T temp;
            for(int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        //sort
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSortEfficient()
        {
            bool sorted = true;
            T temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                //for sorted array no swap will done
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        //swap
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        sorted = false;
                        //if one of swap is done , then element is not in sorted array
                    }
                }
                if (sorted)
                    break;
            }
        }

        public void SelectionSort()
        {
            int pos;
            T temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                pos = i;
                for (int j = i + 1 ; j < array.Length ; j++)
                {
                    if ( array[pos].CompareTo(array[j]) > 0)
                    {
                        pos = j;
                    }
                }
                //swap
                temp = array[i];
                array[i] = array[pos];
                array[pos] = temp;
            }
        }

        public void InsertionSort()
        {
            T key;
            int i, j;

            for (i = 1; i < array.Length ; i++) //unsorted set
            {
                key = array[i];
                for (j =  i-1 ; j >= 0; j--) // sorted set
                {
                    if (key.CompareTo(array[j]) < 0) //if key is small move the element by 1
                    {
                        array[j + 1] = array[j];
                    }
                    else
                    {//if key is greater then break it
                        break;
                    }
                }
                array[j + 1] = key;
            }
        }

        public int LinearSearch(T value)
        {
            int i;
            for(i = 0; i < array.Length; i++)
            {
                if( array[i].CompareTo(value) == 0)
                {
                    break;
                }
            }

            if( i >= array.Length)
            {//element not found
                return -1;
            }
            return i;
        }

        public int LinearSearchBidirectional(T value)
        {
            // Search specific element using linear search
            // Traverse the array from front and rear
            int i, j;
            int pos = -1;   // if element is not present -1 will be return
            for (i = 0 , j = array.Length-1; i <= j ; i++,j--)
            {
                if (array[i].CompareTo(value) == 0)
                {
                   pos = i;
                    break;
                }
                if (array[j].CompareTo(value) == 0)
                {
                    pos = j;
                    break;
                }
            }

            return pos;
        }

        public int BinarySearch(T value)
        {
            //First we have to sort the element

            int top = 0;
            int bottom = array.Length;
            int mid = -1;
            while(top <= bottom)
            {
                mid = (top + bottom) / 2;
                if(value.CompareTo(array[mid]) == 0)
                {
                    break;
                }
                else
                {
                    if(value.CompareTo(array[mid]) < 0)
                    {
                        bottom = mid - 1;
                    }
                    else
                    {
                        top = mid + 1;
                    }
                }
            }

            if( top > bottom)
                return -1;
            return mid;
        }

        public void GetPreviousArrayValue()
        {
            reArrange.CopyTo(array, 0);
        }
        
    }

    // To calculate time required
    delegate void sortedFunction();
    delegate int searchFunction<T>(T value);

    class FuncElapsedTime<T>
    {
        public void FunctionWithNoParameter(sortedFunction DelFunc, string str)
        {
            // like Stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            DelFunc();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine();
            /*
            Console.WriteLine("Elapsed Time -->");
            Console.WriteLine("In nanosecond : {0}", ts.Ticks * 100);
            Console.WriteLine("In millisecond : {0} ", ts.TotalMilliseconds);
            Console.WriteLine("In second : {0} ", ts.TotalSeconds);
            */
            Console.WriteLine(" {0} \t {1} \t {2} \t {3}", str, ts.Ticks * 100, ts.TotalMilliseconds, ts.TotalSeconds);
        }

        public int FunctionWithParameter(searchFunction<T> DelFunc, T value , string str)
        {
            int iRet;
            // like Stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            iRet = DelFunc(value);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;


            Console.WriteLine(" {0} \t {1} \t {2} \t {3} \t{4}", str, ts.Ticks * 100, ts.TotalMilliseconds, ts.TotalSeconds, iRet);
            return iRet;
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            
            /* making simple to run */
            int choose;
            int no;
            int size;
            int iRet;
            int iKey;
            string sKey;
            double dKey;

            Console.Write("Enter the 1(int) 2(double) 3(string) 4(toGetTimeofEachFunction)");
            no = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the size of element: ");
            size = Convert.ToInt32(Console.ReadLine());

            MarvellousArray<int> intArray = new MarvellousArray<int>(size);
            MarvellousArray<string> stringArray = new MarvellousArray<string>(size);
            MarvellousArray<double> doubleArray = new MarvellousArray<double>(size);

            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("1: Add element in Array");
                Console.WriteLine("2: Display the element");
                Console.WriteLine("3: Bubble Sort");
                Console.WriteLine("4: Efficient bubble Sort");
                Console.WriteLine("5: Selection Sort");
                Console.WriteLine("6: Insertion Sort");
                Console.WriteLine("7: Linear Search");
                Console.WriteLine("8: Linear Search Bidirection");
                Console.WriteLine("9: Binary search");
                Console.WriteLine("10: Change type");
                Console.WriteLine("11: Exit");
                Console.WriteLine("12: Get Previous Data");
                Console.WriteLine("---------------------------------------------------------------------------");

                Console.Write("\nWhat you want to do? ");
                choose = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                if (no == 1)
                {
                    switch (choose)
                    {
                        case 1:
                            intArray.Accept();
                            break;

                        case 2:
                            intArray.Display();
                            break;

                        case 3:
                            // bubble sort
                            intArray.BubbleSort();
                            Console.WriteLine("Element in Sorted order");
                            intArray.Display();
                            break;

                        case 4:
                            // BubbleSort efficient
                            intArray.BubbleSortEfficient();
                            Console.WriteLine("Element in Sorted order");
                            intArray.Display();
                            break;

                        case 5:
                            //Selection
                            intArray.SelectionSort();
                            Console.WriteLine("Element in Sorted order");
                            intArray.Display();
                            break;

                        case 6:
                            // Insertion
                            intArray.InsertionSort();
                            Console.WriteLine("Element in Sorted order");
                            intArray.Display();
                            break;

                        case 7:
                            // Linear searching
                            Console.Write("Enter the element you want to search: ");
                            iKey = Convert.ToInt32(Console.ReadLine());
                            iRet = intArray.LinearSearch(iKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;

                        case 8:
                            //linear searching bidirection
                            Console.Write("Enter the element you want to search: ");
                            iKey = Convert.ToInt32(Console.ReadLine());
                            iRet = intArray.LinearSearchBidirectional(iKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;
                        case 9:
                            //binary
                            intArray.InsertionSort();
                            Console.WriteLine("Element in Sorted order");
                            intArray.Display();

                            Console.Write("Enter the element you want to search: ");
                            iKey = Convert.ToInt32(Console.ReadLine());
                            iRet = intArray.BinarySearch(iKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;
                        case 10:
                            //change
                            Console.Write("Enter the 1(int) 2(double) 3(string) ");
                            no = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 11:
                            //exit
                            Console.WriteLine("Thank you for using");
                            break;
                        case 12:
                                intArray.GetPreviousArrayValue();
                                Console.WriteLine("Element is rearrange");
                                intArray.Display();
                                break;
                        default:
                            Console.WriteLine("Wrong Choose");
                            break;
                    }
                }
                else if( no == 2 )
                {
                    switch (choose)
                    {
                        case 1:
                            doubleArray.Accept();
                            break;

                        case 2:
                            doubleArray.Display();
                            break;

                        case 3:
                            // bubble sort
                            doubleArray.BubbleSort();
                            Console.WriteLine("Element in Sorted order");
                            doubleArray.Display();
                            break;

                        case 4:
                            // BubbleSort efficient
                            doubleArray.BubbleSortEfficient();
                            Console.WriteLine("Element in Sorted order");
                            doubleArray.Display();
                            break;

                        case 5:
                            //Selection
                            doubleArray.SelectionSort();
                            Console.WriteLine("Element in Sorted order");
                            doubleArray.Display();
                            break;

                        case 6:
                            // Insertion
                            doubleArray.InsertionSort();
                            Console.WriteLine("Element in Sorted order");
                            doubleArray.Display();
                            break;

                        case 7:
                            // Linear searching
                            Console.Write("Enter the element you want to search: ");
                            dKey = Convert.ToDouble(Console.ReadLine());
                            iRet = doubleArray.LinearSearch(dKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;

                        case 8:
                            //linear searching bidirection
                            Console.Write("Enter the element you want to search: ");
                            dKey = Convert.ToDouble(Console.ReadLine());
                            iRet = doubleArray.LinearSearchBidirectional(dKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;
                        case 9:
                            //binary
                            doubleArray.InsertionSort();
                            Console.WriteLine("Element in Sorted order");
                            doubleArray.Display();

                            Console.Write("Enter the element you want to search: ");
                            dKey = Convert.ToDouble(Console.ReadLine());
                            iRet = doubleArray.BinarySearch(dKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;

                        case 10:
                            //change
                            Console.Write("Enter the 1(int) 2(double) 3(string) ");
                            no = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 11:
                            //exit
                            Console.WriteLine("Thank you for using");
                            break;
                                
                        case 12:
                            intArray.GetPreviousArrayValue();
                            Console.WriteLine("Element is rearrange");
                            intArray.Display();
                            break;

                        default:
                            Console.WriteLine("Wrong Choose");
                            break;
                    }
                }
                else
                {
                    switch (choose)
                    {
                        case 1:
                            stringArray.Accept();
                            break;

                        case 2:
                            stringArray.Display();
                            break;

                        case 3:
                            // bubble sort
                            stringArray.BubbleSort();
                            Console.WriteLine("Element in Sorted order");
                            stringArray.Display();
                            break;

                        case 4:
                            // BubbleSort efficient
                            stringArray.BubbleSortEfficient();
                            Console.WriteLine("Element in Sorted order");
                            stringArray.Display();
                            break;

                        case 5:
                            //Selection
                            stringArray.SelectionSort();
                            Console.WriteLine("Element in Sorted order");
                            stringArray.Display();
                            break;

                        case 6:
                            // Insertion
                            stringArray.InsertionSort();
                            Console.WriteLine("Element in Sorted order");
                            stringArray.Display();
                            break;

                        case 7:
                            // Linear searching
                            Console.Write("Enter the element you want to search: ");
                            sKey = Console.ReadLine();
                            iRet = stringArray.LinearSearch(sKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;

                        case 8:
                            //linear searching bidirection
                            Console.Write("Enter the element you want to search: ");
                            sKey = Console.ReadLine();
                            iRet = stringArray.LinearSearch(sKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;
                        case 9:
                            //binary
                            stringArray.InsertionSort();
                            Console.WriteLine("Element in Sorted order");
                            stringArray.Display();

                            Console.Write("Enter the element you want to search: ");
                            sKey = Console.ReadLine();
                            iRet = stringArray.LinearSearch(sKey);
                            if (iRet != -1)
                                Console.WriteLine("Element is Found At index; {0}", iRet);
                            else
                                Console.WriteLine("Element not found");
                            break;

                        case 10:
                            //change
                            Console.Write("Enter the 1(int) 2(double) 3(string) ");
                            no = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 11:
                            //exit
                            Console.WriteLine("Thank you for using");
                            break;
                        case 12:
                                intArray.GetPreviousArrayValue();
                                Console.WriteLine("Element is rearrange");
                                intArray.Display();
                                break;
                        default:
                            Console.WriteLine("Wrong Choose");
                            break;
                    }
                }
                

                if (choose != 11)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.Write("Press Enter to see Menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (choose != 11);

            Console.Clear();
            Console.WriteLine("Time Complexcity");
            MarvellousArray<int> myArray = new MarvellousArray<int>(10);
            FuncElapsedTime<int> elapsedTime = new FuncElapsedTime<int>();
            myArray.Accept();
            myArray.Display();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("FunctionName \t nanosecond \t millisecond \t second \t value");
            Console.WriteLine("------------------------------------------------------------------");
            elapsedTime.FunctionWithNoParameter(myArray.BubbleSort, "BubbleSort");
            myArray.GetPreviousArrayValue();

            elapsedTime.FunctionWithNoParameter(myArray.BubbleSortEfficient, "BS_Efficient");
            myArray.GetPreviousArrayValue();
            elapsedTime.FunctionWithNoParameter(myArray.SelectionSort, "SelectionSort");
            myArray.GetPreviousArrayValue();
            elapsedTime.FunctionWithNoParameter(myArray.InsertionSort, "InsertionSort");
            myArray.GetPreviousArrayValue();

            Console.Write("Enter the element you want to search: ");
            iKey = Convert.ToInt32(Console.ReadLine());
            iRet = intArray.LinearSearchBidirectional(iKey);

            elapsedTime.FunctionWithParameter(myArray.LinearSearch, iKey, "LinearSearch");
            myArray.GetPreviousArrayValue();

            elapsedTime.FunctionWithParameter(myArray.LinearSearchBidirectional, iKey, "Bidirection");
            myArray.GetPreviousArrayValue();

            myArray.InsertionSort();
            elapsedTime.FunctionWithParameter(myArray.BinarySearch, iKey, "BinarySearch");
            myArray.GetPreviousArrayValue();


        }
    }
}
