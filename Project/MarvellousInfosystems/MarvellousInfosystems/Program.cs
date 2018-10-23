using System;
using System.Collections.Generic;

/*
 * Project to stored the information about each Course and student in that Course.
 * We will use Collection to stores the information
 * Overview 
 *      - Student Class: To hold the infomation about each student.
 *      - Course Class: To hold the infomation about each Course. Each Course will contain list of Batchno(eg LSP)
 *      - Batchno Class: Each Batch number will contain Student linklist(eg LSP1 ,LSP2 ...)
 *      - Mavellous Class: To hold the information about Class and the linklist of Course.
 *      
 * In short
 * Marvellous -> Course -> BatchNo -> Student
 */

    // As same student can be in multiple Course.(make it one in future)
namespace MarvellousInfosystems
{
    
    class Student
    {
        // characteristic
        string Name;
        string Email;
        string PhoneNo;
        string Address;
        int RegNo;              // Register Number
        //int StudId;             // Unique ID    (this is future idea)
        //int isPlaced;             // student or placed (this is future idea)

        public Student(int no)
        {
            RegNo = no;
        }
        // Behaviour
        public void AcceptStudentInfo()
        {
            Console.WriteLine("Enter the detail of Student:->");

            Console.Write("Name: ");
            Name = Console.ReadLine();

            Console.Write("Email: ");
            Email = Console.ReadLine();

            Console.Write("PhoneNo: ");
            PhoneNo = Console.ReadLine();

            Console.Write("Address: ");
            Address = Console.ReadLine();
            
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine("Student Detail:-->");

            Console.WriteLine("\tName: "+Name);
            Console.WriteLine("\tEmail: " + Email);
            Console.WriteLine("\tPhoneNo: " + PhoneNo);
            Console.WriteLine("\tAddress: " + Address);
        }

        public override string ToString()
        {
            string str = String.Format("{0}\t{1}\t{2}\t{3}",RegNo,Name,Email,PhoneNo);
            return str;
        }
    }

    class BatchNo
    {
        public int BatchNumber;
        public string BatchShortName;
        public DateTime StartingDate;
        public double BatchFee;            // because batch fee can be change, to save batch fee at time of batch started.
        public int BatchStrenght = 0;
        public bool status;                 // whether batch admission is open(true) or close(false)
        List<Student> studentList = new List<Student>();

        public BatchNo( int number,string shortName ,double fee )
        {
            BatchNumber = number;
            BatchFee = fee;
            BatchShortName = shortName;
            status = true;
        }

        public void AcceptBatchInfo()
        {
            try
            {
                Console.Write("Enter starting date of batch(dd-MM-yy): ");
                StartingDate = DateTime.Parse(Console.ReadLine());
            }catch(Exception)
            {
                Console.WriteLine("Enter Date Again:");
                AcceptBatchInfo();
            }
        }

        public void DisplayBatchInfo()
        {
            Console.WriteLine("Batch Name: {0}{1}",BatchShortName,BatchNumber);
            Console.WriteLine("Batch Starting Date: {0}", StartingDate.ToString("dd-MM-yy"));
            Console.WriteLine("Batch Fee: {0} ", BatchFee);
            Console.WriteLine("Strenght of this batch is: {0}", BatchStrenght);
            Console.WriteLine("Total Income of this batch is: {0}", BatchStrenght * BatchFee);
            if (status)
                Console.WriteLine("Admission is Open");
            else
                Console.WriteLine("Admission is Close");
        }

        public void AddStudent()
        {
            BatchStrenght++;
            Student student = new Student(BatchStrenght);
            student.AcceptStudentInfo();
            studentList.Add(student);

            Console.WriteLine("Student is Successfully add to {0} {1}", BatchShortName, BatchNumber);
        }

        public void DisplayStudentList()
        {
            Console.WriteLine();
            Console.WriteLine("RegNo\tName\t\tEmail\t\tPhone ");
            foreach (var student in studentList)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public double TotalBatchNoIncome()
        {
            return BatchStrenght * BatchFee;
        }

        public void DisplayBatchNoMenu()
        {
            //Clear the command Prompt
            Console.Clear();
            int menuSelected;
            do
            {
                Console.WriteLine();
                Console.WriteLine("{0}{1}",BatchShortName ,BatchNumber);
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: Register new Student to this batch. ");
                Console.WriteLine("2: Display Student List. ");
                Console.WriteLine("3: Display the strength of this batch");
                Console.WriteLine("4: Display total Income from this batch");
                Console.WriteLine("5: Complete Information about is batch");
                Console.WriteLine("6: Go Back");
                Console.WriteLine("------------------------------------------------------");

                Console.Write("What you want to do? ");
                menuSelected = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (menuSelected)
                {
                    case 1:
                        if (status)
                            AddStudent();
                        else
                            Console.WriteLine("This Batch admission is Stop");
                        break;
                    case 2:
                        DisplayStudentList();
                        break;
                    case 3:
                        Console.WriteLine("Strenght of this batch is: {0}",BatchStrenght);
                        break;
                    case 4:
                        Console.WriteLine("Total Income of this batch is: {0}", TotalBatchNoIncome());
                        break;
                    case 5:
                        DisplayBatchInfo();
                        break;
                    default:
                        Console.WriteLine("Wrong Choose");
                        break;

                }
                if (menuSelected != 6)
                {
                    Console.WriteLine();
                    Console.Write("Press any key go to menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (menuSelected != 6);

            Console.Clear();
        }

        public override string ToString()
        {
            string str = String.Format("{0}{1}\t{2}\t{3}", BatchShortName, BatchNumber, StartingDate.ToString("dd-MM-yy"),BatchStrenght);
            return str;
        }
    }

    class Course
    {
        public string CourseName;
        string CourseShortName;
        int CourseDuration;
        double CourseFee;           //save current batch fee

        BatchNo LastBatch = null;         // refering on going batch
        public int batchCount = 0;

        List<BatchNo> batchNoList = new List<BatchNo>(); 

        public void AcceptCourseInfo()
        {   
            // Course Info
            Console.WriteLine("\nEnter the Course detail: ");
            Console.WriteLine("---------------------------------------------------------------\n");
            Console.Write("Course Name: ");
            CourseName = Console.ReadLine();

            Console.Write("Course Short Name: ");
            CourseShortName = Console.ReadLine();

            Console.Write("Course Dusration(in months): ");
            CourseDuration = Convert.ToInt32(Console.ReadLine());

            Console.Write("Course Fee: ");
            CourseFee = Convert.ToDouble(Console.ReadLine());

            // Batchno Info
            batchCount++;
            LastBatch = new BatchNo(batchCount, CourseShortName, CourseFee);
            LastBatch.AcceptBatchInfo();
            batchNoList.Add(LastBatch);
            Console.WriteLine("\nCourse is successfully created");
            Console.WriteLine("{0}{1} admission is Started\n", CourseShortName, LastBatch.BatchNumber);
        }

        public void StartNewBatch()
        {
            batchCount++;
            BatchNo newbatch = new BatchNo(batchCount, CourseShortName, CourseFee);
            newbatch.AcceptBatchInfo();
            batchNoList.Add(newbatch);
            LastBatch.status = false;
            LastBatch = newbatch;
            Console.WriteLine("{0}{1} admission is Started\n", CourseName, LastBatch.BatchNumber);
        }

        public void DisplayBatchNoList()
        {
            int index = 0;
            Console.WriteLine();
            Console.WriteLine("Batch List");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("BatchNumber\tStart Date\tStrength");
            Console.WriteLine("------------------------------------------------------");
            foreach (var batch in batchNoList)
            {
                index++;
                Console.WriteLine("{0}\t{1}",index,batch.ToString());

            }
            Console.WriteLine("------------------------------------------------------");
        }

        public double TotalCourseIncome()
        {
            double dTotal = 0;
            foreach (var batch in batchNoList)
            {
                dTotal += batch.TotalBatchNoIncome();
            }
            return dTotal;
        }

        public void DisplayCourseName()
        {
            Console.WriteLine(" {0} {0}dur {0}fee", CourseName, CourseDuration, CourseFee);
        }

        public void AddStudent()
        {
            if (LastBatch.status)
            {
                LastBatch.AddStudent();
                Console.WriteLine("Student is Successfully add to {0} {1}", CourseName, LastBatch.BatchNumber);
            }
            else
                Console.WriteLine("Addmission is close");
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine("Course detail: ");
            Console.WriteLine("\tCourse Name: {0}", CourseName);
            Console.WriteLine("\tCourse Short Name: {0}", CourseShortName);
            Console.WriteLine("\tCourse Duration: {0} months", CourseDuration);
            Console.WriteLine("\tCourse Fee: {0}", CourseFee);
            Console.WriteLine("\tNumber batch taken: {0}", batchCount);
            Console.WriteLine("\tLast Batch: {0}{1}", CourseShortName, batchCount);

        }

        public void DisplayCourseMenu()
        {
            //Clear the command Prompt
            Console.Clear();
            int menuSelected;
            do
            {
                Console.WriteLine();
                Console.WriteLine("{0} {1}", CourseName, CourseShortName);
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("While Creating cousre new batch is automatically created");
                Console.WriteLine("1: Register new Student");
                Console.WriteLine("2: List the all the Batch"); 
                Console.WriteLine("3: Start New Batch. ");
                Console.WriteLine("4: Display total Income from this Course");
                Console.WriteLine("5: Complete Information about this Course");
                Console.WriteLine("6: Stop the admission");
                Console.WriteLine("7: Get Information about Any Batch.");
                Console.WriteLine("8: Go Back");
                Console.WriteLine("------------------------------------------------------");

                Console.Write("What you want to do? ");
                menuSelected = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (menuSelected)
                {
                    case 1:
                        // new student will be add to lastbatch
                        AddStudent();
                        break;
                    case 2:
                        DisplayBatchNoList();
                        break;
                    case 3:

                        StartNewBatch();
                        break;
                    case 4:
                        Console.WriteLine("Total Income of this batch is: {0}", TotalCourseIncome());
                        break;
                    case 5:
                        DisplayCourseInfo();
                        break;
                    case 6:
                        string sFlag;
                        Console.Write("Are you sure that you want to close the addmission(y|n): ");
                        sFlag = Console.ReadLine();
                        if (sFlag[0] == 'y')
                        {
                            LastBatch.status = false;
                            Console.WriteLine("This Batch Admission is close");
                        }
                        break;
                    case 7:
                        DisplayBatchNoList();
                        Console.Write("Enter the Batch number: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        batchNoList[n - 1].DisplayBatchNoMenu();
                        break;
                    case 8:
                        //go back
                        break;
                    default:
                        Console.WriteLine("Wrong Choose");
                        break;

                }
                if (menuSelected != 8)
                {
                    Console.WriteLine();
                    Console.Write("Press any key go to menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (menuSelected != 8);

            Console.Clear();
        }

        public override string ToString()
        {
            string str = string.Format("{0}\t{1}\t{2}\t{3}", CourseName, CourseDuration, CourseFee, batchCount);
            return str;
        }
    }

    class Marvellous
    {
        // Characteristic
        List<Course> CourseList = new List<Course>();

        /* 
         * Description: To add new Course.
         */
        public void AddNewCourse()
        {
            Course Course = new Course();
            Course.AcceptCourseInfo();
            CourseList.Add(Course);
        }

        /* 
         * Description: Display all the infomation of Course
         */
        public void DisplayAllCourses()
        {
            Console.WriteLine("\n  All Mavellous Courses");
            Console.WriteLine("---------------------------------------------------------------\n");
            foreach (var Course in CourseList)
            {
                Course.DisplayCourseInfo();
                Console.WriteLine("");
            }
        }

        public void DisplayCourseList()
        {
            int index = 0;
            Console.WriteLine();
            Console.WriteLine("Course List");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("CourseName\tDuration\tFee\tBatchCount");
            Console.WriteLine("------------------------------------------------------");
            foreach (var course in CourseList)
            {
                index++;
                Console.WriteLine("{0}\t{1}",index,course.ToString());
            }
            Console.WriteLine("------------------------------------------------------");
        }

        public double TotalMarvellousIncome()
        {
            double dTotal = 0;
            foreach (var course in CourseList)
            {
                dTotal += course.TotalCourseIncome();
            }
            return dTotal;
        }


        public void DisplayMarvellousMenu()
        {
            //Clear the command Prompt
            Console.Clear();
            int menuSelected;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Marvellous InfoSystem");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: Add new Course.");
                Console.WriteLine("2: Display Course List.");
                Console.WriteLine("3: Display complete info about each Courses.");
                Console.WriteLine("4: Display total Income");
                Console.WriteLine("5: Get Information about Any Course.");
                Console.WriteLine("6: Exit");
                Console.WriteLine("------------------------------------------------------");

                Console.Write("What you want to do? ");
                menuSelected = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (menuSelected)
                {
                    case 1:
                        AddNewCourse();
                        break;
                    case 2:
                        DisplayCourseList();
                        break;
                    case 3:
                        DisplayAllCourses();
                        break;
                    case 4:
                        Console.WriteLine("Total Income of this batch is: {0}", TotalMarvellousIncome());
                        break;
                    case 5:
                        
                        DisplayCourseList();
                        Console.WriteLine();
                        Console.Write("Enter the Course number: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        CourseList[n - 1].DisplayCourseMenu();
                        break;
                    case 6:
                        Console.WriteLine("Thankyou for using");
                        break;
                    default:
                        Console.WriteLine("Wrong Choose");
                        break;

                }
                if (menuSelected != 6)
                {
                    Console.WriteLine();
                    Console.Write("Press any key go to menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (menuSelected != 6);

            Console.Clear();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Marvellous marvellous = new Marvellous();
            marvellous.DisplayMarvellousMenu();
        }
    }
}
