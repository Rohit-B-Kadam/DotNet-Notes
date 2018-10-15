using System;


namespace Assignment11
{
    class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string str): base(str)
        {
            Console.WriteLine("Invalid Password it must contain 2 capital, 2 small, 2 number letter");
        }
    }

    class InvalidNameException : Exception
    {
        public InvalidNameException(string str) : base(str)
        {
            Console.WriteLine("Name is Invalid");
        }
    }

    class InvalidAgeException : Exception
    {
        public InvalidAgeException(string str) : base(str)
        {
            Console.WriteLine("Age is Invalid");
        }
    }

    class InvalidBloodGroupException : Exception
    {
        public InvalidBloodGroupException(string str) : base(str)
        {
            Console.WriteLine("Blood Group");
        }
    }

    class MarvellousAuthentication
    {
        public string password;

        public MarvellousAuthentication( string str)
        {
            password = str;
        }
        

        public Boolean ChkPassword()
        {
            int iCapitalCnt = 0;
            int iSmallCnt = 0;
            int iNumberCnt = 0;

            foreach (var ch in password)
            {
                if ('a' <= ch && ch <= 'z')
                {
                    iSmallCnt++;
                }
                else if ('A' <= ch && ch <= 'Z')
                {
                    iCapitalCnt++;
                }
                else if (0 <= ch && ch <= 9)
                {
                    iNumberCnt++;
                }
            }

            if (iSmallCnt < 2 || iCapitalCnt < 2 || iNumberCnt < 2)
            {
                return false;
            }
            return true;
        }
        
    }

    class MarvellousEmployee
    {
        public string EName;
        public int EAge;
        public string EBloodGroup;

        public void Accept()
        {
            try
            {

                Console.WriteLine("Enter the Detail of Employee: ");
                Console.Write("Enter Name: ");
                EName = Console.ReadLine();
                if(ChkInvalidName())
                {
                    throw new InvalidNameException("Invalid Name");
                }
                    
                Console.Write("Enter Age: ");
                EAge = Convert.ToInt32(Console.ReadLine());
                if (EAge < 0)
                    throw new InvalidAgeException("Invalid Age");

                Console.Write("Enter the Blood Group: ");
                EBloodGroup = Console.ReadLine();
                if (ChkInvalidBloodGroup())
                {
                    throw new InvalidBloodGroupException("Invalid BloodGroup");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void Display()
        {
            Console.WriteLine("Detail of Employee:-> ");
            Console.WriteLine("Name: {0}", EName);
            Console.WriteLine("Age: {0}", EAge);
            Console.WriteLine("Blood Group: {0}", EBloodGroup);
        }

        public bool ChkInvalidName()
        {
            int i;

            for ( i = 0; i < EName.Length; i++)
            {
                if ( !('a' <= EName[i] && EName[i] <= 'z') && !('A' <= EName[i] && EName[i] <= 'Z'))
                {
                    break;
                }
            }

            if( i < EName.Length)
                return true;

            return false;
        }

        public bool ChkInvalidBloodGroup()
        {
            string[] BloodGroup = { "A+", "B+", "O+", "AB+", "A-", "B-", "O-", "AB-" };
            int i;
            for( i = 0; i < BloodGroup.Length; i++)
            {
                if( BloodGroup[i].Equals(EBloodGroup))
                {
                    break;
                }
            }
            if (i < BloodGroup.Length)
                return false;
             else
                return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /* --------------- Que 1 ---------------- */
            /*

            MarvellousAuthentication maObj;
            bool bret;
            string str;

            Console.Write("Enter the Password: ");
            str = Console.ReadLine();

            maObj = new MarvellousAuthentication(str);
            bret = maObj.ChkPassword();

            try
            {
                if(bret == false)
                {
                    throw new InvalidPasswordException("Invalid Password");
                }
            }
            catch(InvalidPasswordException e)
            {
                Console.WriteLine(e);
            }
            */


            /*  ------------- Que 2 ---------------*/

            /*
            MarvellousEmployee meobj = new MarvellousEmployee();
            meobj.Accept();
            meobj.Display();
            */
        }
    }


}
