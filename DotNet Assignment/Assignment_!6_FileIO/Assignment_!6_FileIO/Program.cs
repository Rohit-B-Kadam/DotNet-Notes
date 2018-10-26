using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment__6_FileIO
{
    class MarvellousFile
    {
        private string fileName;
        private FileInfo fObj;

        public MarvellousFile(string name)
        {
            fileName = name;
            fObj = new FileInfo(fileName);
            if (fObj.Exists)
                Console.WriteLine("File is successfully open");
            else
                Console.WriteLine("File is successfully open");
        }

        public void DisplayContents()
        {
            string buffer;
            using (StreamReader sr = fObj.OpenText())
            {
                Console.WriteLine("File Contain: ");
                while ((buffer = sr.ReadLine()) != null)
                {
                    Console.WriteLine(buffer);
                }
            }
            
        }

        public void DeleteFile()
        {
            fObj.Delete();
            Console.WriteLine("File is Deleted");
        }

        public void DisplayTime()
        {
            Console.WriteLine("Last Access time: {0} ",fObj.LastAccessTime);
            Console.WriteLine("Last Write time: {0} ", fObj.LastWriteTime);
        }

        public long FileLength()
        {
            return fObj.Length;
        }

        public void DisplayExtension()
        {
            Console.WriteLine("File Extension is: {0}",fObj.Extension);
        }

        public void CopyFile(string newFile)
        {
            fObj.CopyTo(newFile);
        }

        public void SearchString(string str)
        {
            string buffer;
            int line = 0;
            bool flag = false;
            StreamReader sr; ;

            if (fObj.Extension.Equals(".txt"))
            {
                using (sr = fObj.OpenText())
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        line++;
                        if (buffer.Contains(str))
                        {
                            Console.WriteLine("Found at Line{0}: {1} ", line, buffer);
                            flag = true;
                        }
                    }
                    if (!flag)
                        Console.WriteLine("{0} is not found", str);
                }
            }
            else
                Console.WriteLine("File is not text file");
        }

        public void CountCapSmall()
        {
            int iCntCap = 0;
            int iCntSmall = 0;
            string buffer;
            StreamReader sr; ;

            if (fObj.Extension.Equals(".txt"))
            {
                using (sr = fObj.OpenText())
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        foreach (var ch in buffer)
                        {
                            if (ch >= 'a' && ch <= 'z')
                            {
                                iCntSmall++;
                            }
                            else if (ch >= 'A' && ch <= 'Z')
                            {
                                iCntCap++;
                            }
                        }
                        
                    }
                    Console.WriteLine("Capital count: {0}", iCntCap);
                    Console.WriteLine("Small count: {0}", iCntSmall);
                }
            }
            else
                Console.WriteLine("File is not text file");
        }

        public void AppendString(string str)
        {
            using (StreamWriter sw = fObj.AppendText())
            {
                sw.WriteLine(str);
                sw.Flush();
                Console.WriteLine("Data is appended");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int choose = 0;
            string name;
            string buffer;
            MarvellousFile mfObj;

            Console.Write("Enter the File Name: ");
            name = Console.ReadLine();
            mfObj = new MarvellousFile(name);

            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("1: Display Content");
                Console.WriteLine("2: Delete file");
                Console.WriteLine("3: Display access and write time.");
                Console.WriteLine("4: File Length");
                Console.WriteLine("5: Display File Extension");
                Console.WriteLine("6: Copy file to.");
                Console.WriteLine("7: Search string in file");
                Console.WriteLine("8: Count Capital and small letter.");
                Console.WriteLine("9: Append the string");
                Console.WriteLine("2: Delete file to Exit");
                Console.WriteLine("---------------------------------------------------------------------------");

                Console.Write("\nWhat you want to do? ");
                choose = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (choose)
                {
                    case 1:
                        mfObj.DisplayContents();
                        break;
                    case 2:
                        mfObj.DeleteFile();
                        break;
                    case 3:
                        mfObj.DisplayTime();
                        break;
                    case 4:
                        Console.WriteLine("File Length is: {0}",mfObj.FileLength());
                        break;
                    case 5:
                        mfObj.DisplayExtension();
                        break;
                    case 6:
                        Console.Write("Enter the name of copy file: ");
                        buffer = Console.ReadLine();
                        mfObj.CopyFile(buffer);
                        break;
                    case 7:
                        Console.Write("Enter the string to search: ");
                        buffer = Console.ReadLine();
                        mfObj.SearchString(buffer);
                        break;
                    case 8:
                        mfObj.CountCapSmall();
                        break;
                    case 9:
                        Console.Write("Enter the string to Append: ");
                        buffer = Console.ReadLine();
                        mfObj.AppendString(buffer);
                        break;
                    default:
                        Console.WriteLine("Wrong Choose");
                        break;
                }
                if (choose != 2)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.Write("Press Enter to see Menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (choose != 2);
        }

    }
}

