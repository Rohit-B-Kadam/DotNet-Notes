using System;
using System.Collections.Generic;


namespace Assignment14_Ques1 
{
    class MarvellousArray<T> where T : IComparable<T>
    {
        public List<T> array = new List<T>();
        
        public void Add( T item)
        {
            array.Add(item);
        }
        
        public void Insert( int index , T item)
        {
            if( index >= 0 && index < array.Count)
            {
                array.Insert(index, item);
            }
            else
            {
                Console.WriteLine("Give proper index value");
            }
        }

        public void AcceptMultipleValue()
        {
            string str;
            T value;
            Console.Write("How many item you want to add: ");
            int no = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the element in array: ");
            for (int i = 0; i < no; i++)
            {
                str = Console.ReadLine();
                value = (T)Convert.ChangeType(str, typeof(T));
                Add(value);
            }
            // ChangeType: Returns an object of the specified type and whose value is equivalent to the specified object.

        }

        public int CountFrequency( T item)
        {
            int iCnt = 0;
            foreach (var element in array)
            {
                if(element.CompareTo(item) == 0)
                {
                    iCnt++;
                }
            }
            return iCnt;
        }

        public int FindFirstOccurrence(T item)
        {
            int index;
            for (index = 0; index < array.Count; index++)
            {
                if(array[index].CompareTo(item) == 0)
                {
                    break;
                }
            }
            if (index < array.Count)
                return index;
            else
                return -1;
        }

        public int FindLastOccurrence(T item)
        {
            int index;
            for (index = array.Count - 1 ; index >= 0; index--)
            {
                if (array[index].CompareTo(item) == 0)
                {
                    break;
                }
            }
            if (index >= 0)
                return index;
            else
                return -1;
        }

        public int LargestElement()
        {
            int index = 0;

            for ( int i = 1; i < array.Count; i++)
            {
                
                if (array[i].CompareTo( array[index]) > 0)
                {
                    index = i;
                }
            }
            return index;
        }

        public int SmallestElement()
        {
            int index = 0;

            for (int i = 1; i < array.Count; i++)
            {

                if (array[i].CompareTo(array[index]) < 0)
                {
                    index = i;
                }
            }
            return index;
        }

        public void Display()
        {
            Console.WriteLine("Element are: ");
            foreach (var element in array)
            {
                Console.Write(" {0}", element);
            }
            Console.WriteLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int choose;
            int iRet, iPos, index;
            int iItem;
            string sItem;
            int no;
            MarvellousArray<int> intArray = new MarvellousArray<int>();
            MarvellousArray<string> stringArray = new MarvellousArray<string>();

            Console.Write("Enter the 1(int) 2(string): ");
            no = Convert.ToInt32(Console.ReadLine());

            
            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("1: Add Multi value item in Array");
                Console.WriteLine("2: Insert item in specific position");
                Console.WriteLine("3: Find the Frequence of element");
                Console.WriteLine("4: Find the First occurrence from array.");
                Console.WriteLine("5: Find the last occurrence from array.");
                Console.WriteLine("6: Find out largest element from array.");
                Console.WriteLine("7: Find out smallest element from array.");
                Console.WriteLine("8: Display array");
                Console.WriteLine("9: Exit");
                Console.WriteLine("---------------------------------------------------------------------------");

                Console.Write("\nWhat you want to do? ");
                choose = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                if(no == 1)
                {
                    switch (choose)
                    {
                        case 1:
                            intArray.AcceptMultipleValue();
                            break;

                        case 2:
                            
                            Console.Write("Enter the index: ");
                            iPos = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the item: ");
                            iItem = Convert.ToInt32(Console.ReadLine());
                            intArray.Insert(iPos, iItem);
                            break;

                        case 3:
                            Console.Write("Enter the item to search: ");
                            iItem = Convert.ToInt32(Console.ReadLine());
                            iRet = intArray.CountFrequency(iItem);
                            Console.WriteLine("Frequence of value {0} from array is: {1}", iItem, iRet);
                            break;

                        case 4:

                            Console.Write("Enter the item: ");
                            iItem = Convert.ToInt32(Console.ReadLine());
                            iRet = intArray.FindFirstOccurrence(iItem);
                            Console.WriteLine("First occurrence of value {0} from array is: {1}", iItem, iRet);
                            break;

                        case 5:

                            Console.Write("Enter the item: ");
                            iItem = Convert.ToInt32(Console.ReadLine());
                            iRet = intArray.FindLastOccurrence(iItem);
                            Console.WriteLine("Last occurrence of value {0} from array is: {1}", iItem, iRet);
                            break;

                        case 6:
                            index = intArray.LargestElement();
                            Console.WriteLine("largest element is: {0}", intArray.array[index]);
                            break;

                        case 7:
                            index = intArray.SmallestElement();
                            Console.WriteLine("Smallest element is: {0}", intArray.array[index]);
                            break;

                        case 8:
                            intArray.Display();
                            break;
                        case 9:
                            Console.WriteLine("Thank you for using");
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
                            stringArray.AcceptMultipleValue();
                            break;

                        case 2:
                            
                            Console.Write("Enter the index: ");
                            iPos = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the item: ");
                            sItem = Console.ReadLine();
                            stringArray.Insert(iPos, sItem);
                            break;

                        case 3:
                            Console.Write("Enter the item to search: ");
                            sItem = Console.ReadLine();
                            iRet = stringArray.CountFrequency(sItem);
                            Console.WriteLine("Frequence of value {0} from array is: {1}", sItem, iRet);
                            break;

                        case 4:

                            Console.Write("Enter the item: ");
                            sItem = Console.ReadLine();
                            iRet = stringArray.FindFirstOccurrence(sItem);
                            Console.WriteLine("First occurrence of value {0} from array is: {1}", sItem, iRet);
                            break;

                        case 5:

                            Console.Write("Enter the item: ");
                            sItem = Console.ReadLine();
                            iRet = stringArray.FindLastOccurrence(sItem);
                            Console.WriteLine("Last occurrence of value {0} from array is: {1}", sItem, iRet);
                            break;

                        case 6:
                            index = stringArray.LargestElement();
                            Console.WriteLine("largest element is: {0}", stringArray.array[index]);
                            break;

                        case 7:
                            index = stringArray.SmallestElement();
                            Console.WriteLine("Smallest element is: {0}", stringArray.array[index]);
                            break;

                        case 8:
                            stringArray.Display();
                            break;
                        case 9:
                            Console.WriteLine("Thank you for using");
                            break;
                        default:
                            Console.WriteLine("Wrong Choose");
                            break;
                    }
                }
                
                if (choose != 9)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.Write("Press Enter to see Menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (choose != 9);
        }
    }
}
