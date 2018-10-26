using System;
using System.Reflection;

namespace CalculatorDemo
{
    // To Perform all the operation of Calculator
    class Calculator
    {
        // Basic Characteristic
        public int operand1;            //  To store value of operand1
        public int operand2;            //  To store value of operand1
        public string currentOperator;  //  What operation should do? like Add,Subt,Multi,Div...
        public string lastOperator;  //  What operation should do? like Add,Subt,Multi,Div...
        public string displayType;      //  In which format to display [Hex , Dec , Oct , Bin]
        public string screenData;

        // Adv characteristic
        public Assembly DLL;
        public Type ArithmetricT;              //  To store Address of Arithmetric class present inside DLL
        public Type NumberT;                   //  To store Address of Number class present inside DLL
        public Type BitwiseT;                  //  To store Address of Bitwise class present inside DLL

        // Behaviour
        public Calculator()
        {
            //Setting Default value to Characteristic
            operand1 = 0;
            operand2 = 0;
            currentOperator = "Add";
            lastOperator = "Add";
            displayType = "Dec";
            screenData = "0";

            // Loaded DLL
            try
            {
                DLL = Assembly.LoadFile(@"H:\Technology\Dot Net\Learning\Project\CalculatorClassLibrary\CalculatorClassLibrary\bin\Debug\CalculatorClassLibrary.dll");
                
                // Get Addr of Arithmetric Class
                ArithmetricT = DLL.GetType("Arithmetric");
                
                // Get Addr of Number Class
                NumberT = DLL.GetType("Number");
                
                // Get Addr of BitWise Class
                BitwiseT = DLL.GetType("Bitwise");
                
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Demo()
        {
            Type ExpressionT = DLL.GetType("EvaluateString");
            Console.WriteLine(" {0} datatype is fetched form DLL", ExpressionT);

            object eObj = Activator.CreateInstance(ExpressionT);
            
            MethodInfo mi = ExpressionT.GetMethod("Evaluate");

            string exp = "2 + 3 * 5";
            object[] param = new object[1];
            param[0] = exp;

            object iRet = mi.Invoke(eObj, param);
            //------------------------//
            
            Console.WriteLine("Screen data:------>>> {0} ", iRet.ToString());

        }

        public void DisplayScreenData()
        {
            Console.WriteLine("ScreenData------> {0}",screenData);
        }

        public void PreformArithmetricOperation()
        {
            object aObj = Activator.CreateInstance(ArithmetricT);
            // Binary Operator
            MethodInfo mi = ArithmetricT.GetMethod(lastOperator);
            object[] param = new object[2];
            param[0] = operand1;
            param[1] = operand2;

            object iRet = mi.Invoke(aObj, param);
            //------------------------//

            lastOperator = currentOperator;
            screenData = iRet.ToString();
            operand1 = (int)iRet;
            operand2 = 0;
            currentOperator = "";
            Console.WriteLine("Screen data:------>>> {0} ", operand1);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int operand;
            string opr;

            Console.WriteLine("Inside Client Application");
            Calculator cal = new Calculator();
            cal.Demo();
        }
    }
}
