using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que4JaggedArray
{
    class JaggedArray
    {
        int[][] iArr;
        int iJaggedRows;

        // Allocating Array
        public void ArrayAllocated()
        {
            int iTemp;

            // Allocating size of row
            Console.Write("Enter the Number of Rows: ");
            iJaggedRows = Convert.ToInt32(Console.ReadLine());
            iArr = new int[iJaggedRows][];

            // Allocating size of each rows 
            for(int i = 0 ; i < iJaggedRows ; i++)
            {
                Console.Write("Enter the size of {0} rows: ", i);
                iTemp = Convert.ToInt32(Console.ReadLine());
                iArr[i] = new int[iTemp];
            }
            Console.WriteLine("Jagged Array is allocated");
        }


        //Initialing whole array
        public void ArrayInitializing()
        {
            // Traversing  rows of Array
            for (int i = 0; i < iJaggedRows; i++)
            {
                Console.WriteLine("Enter the element value of {0} rows: ", i);
                // Traversing each elemnt in row
                for (int j = 0; j < iArr[i].Length; j++)
                {
                    Console.Write("Array[{0}][{1}] : ", i , j);
                    iArr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("All value in Jagged Array are set");
        }


        //Displaying whole array
        public void ArrayDisplay()
        {
            Console.WriteLine("Array Display: ");
            // Traversing  rows of Array
            for (int i = 0; i < iJaggedRows; i++)
            {
                // Traversing each elemnt in row
                for (int j = 0; j < iArr[i].Length; j++)
                {
                    Console.Write(" [{0}] ", iArr[i][j]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("All value in Jagged Array are set");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            JaggedArray obj = new JaggedArray();
            obj.ArrayAllocated();
            obj.ArrayInitializing();
            obj.ArrayDisplay();
        }
    }
}
