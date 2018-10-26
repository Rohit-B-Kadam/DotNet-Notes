using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.IO;

namespace Marvellous_Calculator
{
    class Calculator
    {
        // Basic Characteristic
        public string value;                        //toStore Value
        public string displayType;                  //  In which format to display [Hex , Dec , Oct , Bin]
        public string screenData;
        public bool ClearScreen;                   //   To Clear Screen
        public string expression;
        public int openBracketsCnt;
        public bool isLastOprThere;
        public bool clearExpression;

        // Adv characteristic
        public Assembly DLL;
        public Type NumberT;                   //  To store Address of Number class present inside DLL
        public Type BitwiseT;                  //  To store Address of Bitwise class present inside DLL
        public Type EvaluateStringT;

        // Object of each Class
        public object nObj;                 //  Object of Number
        public object bObj;                 //  Object of Bitwise
        public object eObj;

        //NumberFunctionList
        public List<string> NumberFunctName;

        //Write Inside the File
        StreamWriter sw;

        // Behaviour
        public Calculator()
        {
            string fileName;
            ClearAll();
            displayType = "Dec";
 
            // Loaded DLL
            try
            {
                DLL = Assembly.LoadFile(@"H:\Technology\Dot Net\Learning\Project\CalculatorClassLibrary\CalculatorClassLibrary\bin\Debug\CalculatorClassLibrary.dll");
                
                
                // Get Addr of Number Class
                NumberT = DLL.GetType("Number");
                
                // Get Addr of BitWise Class
                BitwiseT = DLL.GetType("Bitwise");
                
                // Get Addr of BitWise Class
                EvaluateStringT = DLL.GetType("EvaluateString");
                
                // Create the object of each Class in Dll
                nObj = Activator.CreateInstance(NumberT);
                bObj = Activator.CreateInstance(BitwiseT);
                eObj = Activator.CreateInstance(EvaluateStringT);

                FieldInfo field = NumberT.GetField("FunctionList");
                NumberFunctName = (List<string>)field.GetValue(nObj);


                //creating File
                fileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss");
                fileName += ".txt";
                sw = new StreamWriter(fileName);
                sw.WriteLine("All Calculation Perform at  " + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss"));
                sw.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ClearAll()
        {
            //Setting Default value to Characteristic
            value = "0";
            expression = string.Empty;
            screenData = "0";
            ClearScreen = true;
            clearExpression = false;
            isLastOprThere = false;
            openBracketsCnt = 0;
        }

        public string DataConversion(string data, string from, string to)
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
        
        public void DigitClick(string str)
        {
            if(clearExpression == true)
            {
                expression = "";
                clearExpression = false;
            }

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

        public string PreformEvaluation()
        {
            // Binary Operator
            try
            {
                if (openBracketsCnt == 0)
                {
                    MethodInfo mi = EvaluateStringT.GetMethod("Evaluate");
                    object[] param = new object[1];
                    param[0] = expression;

                    object iRet = mi.Invoke(eObj, param);
                    return iRet.ToString();
                }
                else
                {
                    return value;
                }

            }
            catch (TargetInvocationException ex)
            {
                Exception e = ex.InnerException;
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
                ClearAll();
                return "0";
            }
            catch ( Exception e)
            {
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
                ClearAll();
                return "0";
            }
            
        }

        public void BinaryOperator(string opr)
        {
            if (clearExpression == true)
            {
                expression = "";
                clearExpression = false;
            }
            int len = expression.Length;
            value = GetScreenData();
            expression += $" {value}";
            if( len != 0 )
            { 
                value = PreformEvaluation();
                
            }

            screenData = DataConversion(value, "Dec", displayType);
            ClearScreen = true;
            expression += $" {opr}";
            isLastOprThere = true;
        }

        public void UniaryOperator(string opr)
        {
            try
            {
                value = GetScreenData();

                MethodInfo mi = BitwiseT.GetMethod("Not");
                object[] param = new object[1];
                param[0] = value;

                object oRet = mi.Invoke(bObj, param);
                value = oRet.ToString();
                screenData = DataConversion(value, "Dec", displayType);

            }
            catch (TargetInvocationException ex)
            {
                Exception e = ex.InnerException;
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
                ClearAll();
            }
        }
        
        public void EqualOpeartor()
        {
            if (clearExpression == true)
            {
                expression = "";
                clearExpression = false;
            }
            if (isLastOprThere)
            {
                value = GetScreenData();
                expression += $" {value}";
                value = PreformEvaluation();
            }

            screenData = DataConversion(value, "Dec", displayType);

            // write Data in File
            string Buffer = $"Calculation:\n {expression}\n Answer: {screenData}{displayType}";
            sw.WriteLine(Buffer);
            sw.Flush();

            ClearScreen = true;
            value = "0";
            clearExpression = true;
            isLastOprThere = false;
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
            value = GetScreenData();
            MethodInfo mi = BitwiseT.GetMethod(opr);
            object[] param = new object[2];
            param[0] = value;
            param[1] = pos;

            object oRet = mi.Invoke(bObj, param);
            value = oRet.ToString();
            screenData = DataConversion(value, "Dec", displayType);
        }

        public void NumberFunction(string functName)
        {
            try
            {
                value = GetScreenData();
                MethodInfo mi = NumberT.GetMethod(functName);
                object[] param = new object[1];
                param[0] = value;

                object oRet = mi.Invoke(nObj, param);
                string temp = $"{value} {functName}: {oRet.ToString()}";
                MessageBox.Show($"{temp}", "Marvellous Calculator");
            }
            catch (TargetInvocationException ex)
            {
                Exception e = ex.InnerException;
                MessageBox.Show($"{e.Message}", "Marvellous Calculator");
               
            }
        }
        
        public void Brackets(string bkt)
        {
            if(bkt.Equals("("))
            {
                openBracketsCnt++;
            }
            else
            {
                value = GetScreenData();
                expression += $" {value}";
                openBracketsCnt--;
            }


            expression += $" {bkt}";
            if(openBracketsCnt == 0)
            {
                value = PreformEvaluation();
                screenData = DataConversion(value, "Dec", displayType);
            }

        }

        ~Calculator()
        {
            sw.Close();
        }
    }
}
