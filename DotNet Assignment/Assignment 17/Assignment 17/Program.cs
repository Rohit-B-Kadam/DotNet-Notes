using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assignment_17
{
    class MarvellousDirectory
    {
        DirectoryInfo di;
        string dirName;

        public bool CreateDirective(string dir)
        {
            dirName = dir;
            try
            {
                di = new DirectoryInfo(dirName);

                if (di.Exists)
                {
                    // Indicate that the directory already exists.
                    Console.WriteLine("That path exists already.");
                    return false;
                }

                di.Create();
                Console.WriteLine("Directory is successfully created");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return false;
            }
        }

        public bool OpenDirective(string dir)
        {
            dirName = dir;
            try
            {
                di = new DirectoryInfo(dirName);

                if (di.Exists)
                {
                    Console.WriteLine("That path exists already.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Directory not found");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return false;
            }
        }
        
        public bool CreateFile(string fileName)
        {
            FileInfo file;
            try
            {

                file = new FileInfo(Path.Combine(di.FullName, fileName));
                if (file.Exists) //no considering directory is newly created
                {
                    // Indicate that the directory already exists.
                    Console.WriteLine("That file is already  exists .");
                    return false;
                }

                file.Create();

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return true;
        }

        public void DisplayAllFilesName()
        {
            try
            {
                FileInfo[] files = di.GetFiles();
                if (files.Length == 0)
                {
                    Console.WriteLine("No file is present in this directory");
                    return;
                }

                Console.WriteLine("File present in this directory are: ");
                int iCnt = 1;
                foreach (var file in files)
                {
                    Console.WriteLine("{0}: {1}", iCnt++, file.Name);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DisplayLargestRegularFile()
        {
            try
            {
                FileInfo[] files = di.GetFiles();
                FileInfo maxFile = null;
                long size = -1;
                if (files.Length == 0)
                {
                    Console.WriteLine("No file is present in this directory");
                    return;
                }
                
                foreach (var file in files)
                {
                    if (file.Extension.Equals(".txt"))
                    {
                        if (size <= file.Length) //if largest file size is zero
                        {
                            maxFile = file;
                            size = file.Length;
                        }
                    }
                }
                Console.WriteLine("Largest file is: {0}",maxFile.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DisplayDirInfo()
        {
            try
            {
                Console.WriteLine("Directory Info");
                Console.WriteLine("Name:  {0}",di.Name);
                Console.WriteLine("FullPath: {0}",di.FullName);
                Console.WriteLine("Creation Time: {0}",di.CreationTime);
                Console.WriteLine("last access time: {0}",di.LastAccessTime);
                Console.WriteLine("last write time: {0}",di.LastWriteTime);
                Console.WriteLine("Root of Directory {0}",di.Root);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MarvellousDirectory mdObj = new MarvellousDirectory();
            int choose;
            string buffer;

            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("1: Create new directory and neew fileside it");
                Console.WriteLine("2: Display all file in directory.");
                Console.WriteLine("3: largest regular file in directory");
                Console.WriteLine("4: Detail about Directory");
                Console.WriteLine("5: Exit");
                Console.WriteLine("---------------------------------------------------------------------------");

                Console.Write("\nWhat you want to do? ");
                choose = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (choose)
                {
                    case 1:
                        Console.Write("Enter the Name of Directory create: ");
                        buffer = Console.ReadLine();
                        if (mdObj.CreateDirective(buffer))
                        {
                            Console.Write("Enter the Name of file to create: ");
                            buffer = Console.ReadLine();
                            mdObj.CreateFile(buffer);
                        }
                        break;
                    case 2:
                        Console.Write("Enter the Name of Directory create: ");
                        buffer = Console.ReadLine();
                        if(mdObj.OpenDirective(buffer))
                        {
                            mdObj.DisplayAllFilesName();
                        }
                        break;
                    case 3:
                        Console.Write("Enter the Name of Directory create: ");
                        buffer = Console.ReadLine();
                        if (mdObj.OpenDirective(buffer))
                        {
                            mdObj.DisplayLargestRegularFile();
                        }
                        break;
                    case 4:
                        Console.Write("Enter the Name of Directory create: ");
                        buffer = Console.ReadLine();
                        if (mdObj.OpenDirective(buffer))
                        {
                            mdObj.DisplayDirInfo();
                        }
                        break;
                    
                    default:
                        Console.WriteLine("Wrong Choose");
                        break;
                }
                if (choose != 5)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.Write("Press Enter to see Menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (choose != 5);
        }
    }
}
