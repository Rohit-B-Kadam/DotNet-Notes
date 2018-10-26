using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;

namespace Marvellous_Calculator
{
    class Calculator
    {
        // Basic Characteristic
        public string operand1;                 //  To store value of operand1
        public string operand2;                 //  To store value of operand1
        public string currentOperator;          //  What operation should do? like Add,Subt,Multi,Div...
        public string lastOperator;             //  What operation should do? like Add,Subt,Multi,Div...
        public string displayType;              //  In which format to display [Hex , Dec , Oct , Bin]
        public string screenData;
        public bool ClearScreen;               //   To Clear Screen
        public bool FunctionOutput;
        string expression = String.Empty;

        // Adv characteristic
        public Assembly DLL;
        public Type ArithmetricT;               //  To store Address of Arithmetric class present inside DLL
        public Type NumberT;                   //  To store Address of Number class present inside DLL
        public Type BitwiseT;                  //  To store Address of Bitwise class present inside DLL

        // Object of each Class
        public object aObj;                 //  Object of Arithmetric
        public object nObj;                 //  Object of Number
        public object bObj;                 //  Object of Bitwise

        //NumberFunctionList
        public List<string> NumberFunctName;


        // Behaviour
        public Calculator()
        {
            ClearAll();
            displayType = "Dec";
            // Loaded DLL
            try
            {
                DLL = Assembly.LoadFile(@"H:\Technology\Dot Net\Learning\Project\CalculatorClassLibrary\CalculatorClassLibrary\bin\Debug\CalculatorClassLibrary.dll");
                Console.WriteLine("DLL Loaded into memory");

                // Get Addr of Arithmetric Class
                ArithmetricT = DLL.GetType("Arithmetric");
                Console.WriteLine(" {0} datatype is fetched form DLL", ArithmetricT);

                // Get Addr of Number Class
                NumberT = DLL.GetType("Number");
                Console.WriteLine(" {0} datatype is fetched form DLL", NumberT);

                // Get Addr of BitWise Class
                BitwiseT = DLL.GetType("Bitwise");
                Console.WriteLine(" {0} datatype is fetched form DLL", BitwiseT);

                // Create the object of each Class in Dll
                aObj = Activator.CreateInstance(ArithmetricT);
                nObj = Activator.CreateInstance(NumberT);
                bObj = Activator.CreateInstance(BitwiseT);

                FieldInfo field = NumberT.GetField("FunctionList");
                NumberFunctName = (List<string>)field.GetValue(nObj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ClearAll()
        {
            //Setting Default value to Characteristic
            operand1 = "0";
            operand2 = "0";
            currentOperator = "Add";
            lastOperator = "Add";
            screenData = "0";
            ClearScreen = true;
            FunctionOutput = false;
        }

        public void DisplayScreenData()
        {
            Console.WriteLine("ScreenData------> {0}", screenData);
        }

        public void DigitClick(string str)
        {
            if (ClearScreen == true)
            {
                screenData = str;
                ClearScreen = false;
            }
            else
                screenData += str;
            
            if(screenData.Equals("00"))
            {
                screenData = "0";
            }
        }

        public string PreformArithmetricOperation(string opr)
        {
            // Binary Operator
            
            try
            {
                MethodInfo mi = ArithmetricT.GetMethod(opr);
                object[] param = new object[2];
                param[0] = operand1;
                param[1] = operand2;

                object iRet = mi.Invoke(aObj, param);
                return iRet.ToString();

            }
            catch (TargetInvocationException ex)
            {
                Exception e = ex.InnerException;
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
                ClearScreen = true;
                lastOperator = "Add";
                return "0";
            }
            

        }

        public void BinaryOperator(string opr)
        {
            operand2 = GetScreenData();
            operand1 = PreformArithmetricOperation(lastOperator);
            lastOperator = opr;
            screenData = DataConversion(operand1, "Dec", displayType);
            ClearScreen = true;
        }

        public void UniaryOperator(string opr)
        {
            try
            {
                operand2 = GetScreenData();
                string iRet = PreformArithmetricOperation(lastOperator);
                operand1 = iRet.ToString();

                MethodInfo mi = ArithmetricT.GetMethod(opr);
                object[] param = new object[1];
                param[0] = operand1;

                object oRet = mi.Invoke(aObj, param);
                operand1 = oRet.ToString();
                screenData = DataConversion(operand1, "Dec", displayType);
                operand1 = "0";
                lastOperator = "Add";
            }
            catch (TargetInvocationException ex)
            {
                Exception e = ex.InnerException;
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
                ClearScreen = true;
                lastOperator = "Add";
                operand1 = "0";
            }
        }

        public void EqualOpeartor()
        {
            operand2 = GetScreenData();
            string iRet = PreformArithmetricOperation(lastOperator);
            operand1 = iRet.ToString();
            screenData = DataConversion(operand1, "Dec", displayType);
            ClearScreen = true;
            operand1 = "0";
            lastOperator = "Add";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> Return dec data </returns>
        public string GetScreenData()
        {
            string data;

            if (displayType.Equals("Hex"))
            {
                // Hex to dec to string
                data = Convert.ToInt32(screenData, 16).ToString();
            }
            else if (displayType.Equals("Dec"))
            {
                // Dec to dec to string
                data = screenData;
            }
            else if (displayType.Equals("Oct"))
            {
                // Oct to dec to string
                data = Convert.ToInt32(screenData, 8).ToString();
            }
            else
            {
                // Bin to dec to string
                data = Convert.ToInt32(screenData, 2).ToString();
            }
            return data;
        }

        public void BitwiseOperation( string opr , int pos)
        {
            operand2 = GetScreenData();
            string iRet = PreformArithmetricOperation(lastOperator);
            operand1 = iRet.ToString();

            MethodInfo mi = BitwiseT.GetMethod(opr);
            object[] param = new object[2];
            param[0] = operand1;
            param[1] = pos;

            object oRet = mi.Invoke(bObj, param);
            operand1 = oRet.ToString();
            screenData = DataConversion(operand1, "Dec", displayType);
            operand1 = "0";
            lastOperator = "Add";
        }

        public string DataConversion(string data , string from , string to)
        {
            string decData;
            string ConvData;
            int mode = 10;

            if (to.Equals("Hex"))
                mode = 16;
            else if (to.Equals("Dec"))
                mode = 10;
            else if (to.Equals("Oct"))
                mode = 8;
            else
                mode = 2;

            // convert to decimal
            if (from.Equals("Hex"))
            {
                decData = Convert.ToInt64(data, 16).ToString();
            }
            else if (from.Equals("Oct"))
            {
                decData = Convert.ToInt64(data, 8).ToString();
            }
            else if (from.Equals("Bin"))
            {
                decData = Convert.ToInt64(data, 2).ToString();
            }
            else
            {
                decData = data;
            }

            // then decimal to specific 
            ConvData = Convert.ToString(Convert.ToInt64(decData), mode);

            return ConvData.ToUpper();
        }

        public void NumberFunction(string functName)
        {
            try
            {

                operand2 = GetScreenData();
                string iRet = PreformArithmetricOperation(lastOperator);
                operand1 = iRet.ToString();

                MethodInfo mi = NumberT.GetMethod(functName);
                object[] param = new object[1];
                param[0] = operand1;

                object oRet = mi.Invoke(nObj, param);
                string temp = $"{operand1} {functName}: {oRet.ToString()}";
                screenData = temp;
                //screenData = DataConversion(operand1, "Dec", displayType);
                //operand1 = "0";
                FunctionOutput = true;
                ClearScreen = true;
                lastOperator = "Add";
            }
            catch (TargetInvocationException ex)
            {
                Exception e = ex.InnerException;
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
                OffFunctionOutputDisplay();
            }
        }

        public void OffFunctionOutputDisplay()
        {
            if(FunctionOutput == true)
            {
                screenData = DataConversion(operand1, "Dec", displayType);
                operand1 = "0";
                FunctionOutput = false;
                lastOperator = "Add";
            }
        }
    }
}
