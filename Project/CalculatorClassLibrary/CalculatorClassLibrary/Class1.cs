using System;
using System.Collections.Generic;
using System.Text;



/// <summary>
/// EvaluationString: Using Shunting-yard algorithm to solve the expression inside string
/// </summary>
public class EvaluateString
{

    // bracket logic is used , but in calculator it is not used
    public string operSupport = "+-*/|&^!%><";

    // Stack for numbers: values 
    public Stack<long> values = new Stack<long>();

    // Stack for Operators: ops 
    public Stack<char> ops = new Stack<char>();

    public string Evaluate(string expression)
    {
        string tokens = expression;


        for (int i = 0; i < tokens.Length; i++)
        {
            // Current token is a whitespace, skip it 
            if (tokens[i] == ' ')
                continue;

            // Current token is a number, push it to stack for numbers 
            if (tokens[i] >= '0' && tokens[i] <= '9')
            {
                StringBuilder sbuf = new StringBuilder();
                while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                {
                    sbuf.Append(tokens[i++]);
                }
                values.Push(Convert.ToInt64(sbuf.ToString()));
            }


            else if (tokens[i] == '(')
            {
                ops.Push(tokens[i]);
            }

            // Closing brace encountered, solve the expression till ')' 
            else if (tokens[i] == ')')
            {
                while (ops.Peek() != '(')
                    values.Push(DoOperation(ops.Pop(), values.Pop(), values.Pop()));
                ops.Pop();
            }

            // Current token is an operator. 
            else if (operSupport.Contains(tokens[i].ToString()))
            {
                while ((ops.Count != 0) && HasPrecedence(tokens[i], ops.Peek()))
                {
                    values.Push(DoOperation(ops.Pop(), values.Pop(), values.Pop()));
                }
                ops.Push(tokens[i]);
            }
        }

        while (ops.Count != 0)
        {
            values.Push(DoOperation(ops.Pop(), values.Pop(), values.Pop()));
        }

        return values.Pop().ToString();
    }

    // Returns true if 'op2' has higher or same precedence as 'op1', 
    // otherwise returns false. 
    public bool HasPrecedence(char op1, char op2)
    {
        int value1 = FindPrecedence(op1);
        int value2 = FindPrecedence(op2);

        if (value2 >= value1)
            return true;

        return false;
    }

    /* Given precedence according to:
     * https://introcs.cs.princeton.edu/java/11precedence/
     **/
    public int FindPrecedence(char opr)
    {
        int value = 0;

        switch (opr)
        {
            case '*':
            case '/':
            case '%':
                value = 12;
                break;
            case '+':
            case '-':
                value = 11;
                break;
            case '>':
            case '<':  //left sift and right shift
                value = 10;
                break;
            case '!':
                value = 14;
                break;
            case '&':
                value = 7;
                break;
            case '^':
                value = 6;
                break;
            case '|':
                value = 5;
                break;
        }
        return value;
    }

    // A utility method to apply an operator 'op' on operands 'a'  
    // and 'b'. Return the result. 
    public long DoOperation(char op, long b, long a)
    {
        Bitwise bw = new Bitwise();
       checked
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                case '%':
                    return a % b;
                case '&':
                    return a & b;
                case '^':
                    return a ^ b;
                case '|':
                    return a | b;
                    
                case '>':
                   return Convert.ToInt64(bw.Rsh(a.ToString(), b.ToString()));
                case '<':
                   return Convert.ToInt64(bw.Lsh(a.ToString(), b.ToString()));

            }
        }
        return 0;
    }

}

public class Number
    {
    public List<string> FunctionList = new List<string>()
    {
        "IsPrime", "IsPerfect", "IsArmstrong", "IsStrong" ,
        "Factorial", "Factors", "SumFactors", "CountDigit"
    };

    /* typing /// visual studio automatically create <summary>  */
    
    /// <summary>
    ///  IsPrime: To Check whether Number is Prime or Not
    /// </summary>
    /// <param name="iNum"></param>
    public bool IsPrime(string sNum)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);
            long iHalf = lNum / 2;       // Divisor range of any number [ 1 , number/2 ]

            // Checking if there is any divisble of that number. if there is we return false 
            for (int i = 2; i <= iHalf; i++)
            {
                if ((lNum % i) == 0)
                    return false;
            }
            return true;
        }

    }
    
    /// <summary>
    /// IsPrefect: To check whether Number is Prefect or Not
    /// </summary>
    /// <param name="iNum"></param>
    public bool IsPerfect(string sNum)
    {
       checked
        {
            long lNum = Convert.ToInt64(sNum);
            long iRet = 0;
            iRet = Convert.ToInt64(SumFactors(lNum.ToString()));

            if (iRet != lNum)
            {
                return false;
            }
            return true;
        }
    }


    /// <summary>
    /// IsArmstrong: Sum of digit raise to power of 371 eg 3**3 + 7**3 + 1**3 = 371
    /// </summary>
    /// <param name="iNum"></param>
    /// <returns></returns>
    public bool IsArmstrong(string sNum)
    {
       checked
        {
            long lNum = Convert.ToInt64(sNum);
            long iValue = lNum;
            long iSum = 0;
            while (iValue != 0)
            {
                iSum += Convert.ToInt64(Math.Pow((iValue % 10), 3));
                iValue /= 10;
            }

            if (iSum != lNum)
                return false;
            return true;
        }    
    }


    /// <summary>
    /// IsStrong: Sum of factorial of digit 145 eg 1! + 4! + 5! = 145
    /// </summary>
    /// <param name="iNum"></param>
    /// <returns></returns>
    public bool IsStrong( string sNum)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);
            long iValue = lNum;
            long iSum = 0;
            int iDigit = 0;
            long iMult = 1;
            while (iValue != 0)
            {
                iDigit = (int)iValue % 10;
                iMult = Convert.ToInt64(Factorial(iDigit.ToString()));
                iSum += iMult;
                iValue /= 10;
            }

            if (iSum != lNum)
                return false;
            return true;
        }
    }



    /// <summary>
    /// Factorial: To perform Factorial of given input( n! )
    /// </summary>
    /// <param name="iNum"></param>
    /// <returns></returns>
    public string Factorial( string sNum)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);
            long lResult = 1;
            while (lNum != 0)
            {
                lResult *= lNum;
                lNum--;
            }
            return lResult.ToString();
        }
    }

   
    /// <summary>
    /// Factors: To Find Factors of Given Number
    /// </summary>
    /// <param name="iNum"></param>
    /// <returns>A string contain all the factors</returns>
    public string Factors(string sNum )
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);
            string str = "{ ";
            for (int iCnt = 1; iCnt <= lNum / 2; iCnt++)
            {
                if ((lNum % iCnt) == 0)
                {
                    str += $" {iCnt},";
                }
            }
            str += " }";
            return str;
        }
    }

    /// <summary>
    /// SumFactor: Sum of all factors of number
    /// </summary>
    /// <param name="iNum"></param>
    /// <returns></returns>
    public string SumFactors(string sNum)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);
            long lSum = 0;
            for (int iCnt = 1; iCnt <= lNum / 2; iCnt++)
            {
                if ((lNum % iCnt) == 0)
                {
                    lSum += iCnt;
                }
            }

            return lSum.ToString();
        }
    }


    /// <summary>
    /// Count Number of digit present in given Number
    /// </summary>
    /// <param name="iNum"></param>
    /// <returns></returns>
    public string CountDigit(string sNum)
    {
       checked
        {
            long lNum = Convert.ToInt64(sNum);
            int iCnt = 0;
            while (lNum != 0)
            {
                iCnt++;
                lNum /= 10;
            }
            return iCnt.ToString();
        }
    }
  

}


public class Bitwise
{
   
   //not use
    public int CountOnBit( int iNum)
    {
        int iCnt = 0;
        int temp = iNum;

        while (temp != 0)
        {
            if ((temp % 2) == 1)
                iCnt++;
            temp /= 2;
        }
        return iCnt;
    }

    //not use
    public bool CheckBit(int iNum, int pos)
    {
        int mark = 0;
        mark = Convert.ToInt32(Math.Pow(2, pos));

        if ((iNum & mark) == 0)
            return false;
        return true;
    }


    public string OnBit(string sNum, int iPos)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);

            long mark = 0;
            mark = Convert.ToInt64(Math.Pow(2, iPos));

            // I have make that bit 1
            lNum = lNum | mark;
            return lNum.ToString();
        }
    }

    public string OffBit(string sNum, int iPos)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);

            long mark = 0;
            mark = Convert.ToInt64(Math.Pow(2, iPos));

            // I have make that bit 1
            lNum = lNum | mark;
            // Then I XOR that bit to make it 0
            lNum = lNum ^ mark;

            return lNum.ToString();
        }
    }

    public string ToggleBit(string sNum, int iPos)
    {
        checked
        {
            long lNum = Convert.ToInt64(sNum);

            long mark = 0;
            mark = Convert.ToInt64(Math.Pow(2, iPos));
            lNum = lNum ^ mark;

            return lNum.ToString();
        }
    }

    
    public string ToBinary(string sNum)
    {
        checked
        {
            return Convert.ToString(Convert.ToInt64(sNum), 2);
        }
    }

    public string And(string sNum1, string sNum2)
    {

        checked
        {
            string sNum3 = "";
            sNum1 = ToBinary(sNum1);
            sNum2 = ToBinary(sNum2);

            int k = 0;
            for (int i = sNum1.Length - 1, j = sNum2.Length - 1; i >= 0 && j >= 0; i--, j--, k++)
            {
                if (sNum1[i] == '1' && sNum2[j] == '1')
                {
                    sNum3 += '1';
                }
                else
                    sNum3 += '0';
            }
            string rev = "";
            for (int i = sNum3.Length - 1; i >= 0; i--)
            {
                rev += sNum3[i];
            }
            return Convert.ToInt64(rev, 2).ToString();
        }
    }

    public string Or(string sNum1, string sNum2)
    {

        checked
        {
            string sNum3 = "";
            sNum1 = ToBinary(sNum1);
            sNum2 = ToBinary(sNum2);

            int k = 0, i, j;
            for (i = sNum1.Length - 1, j = sNum2.Length - 1; i >= 0 && j >= 0; i--, j--, k++)
            {
                if (sNum1[i] == '1' || sNum2[j] == '1')
                {
                    sNum3 += '1';
                }
                else
                    sNum3 += '0';
            }
            while (i >= 0)
            {
                sNum3 += sNum1[i];
                i--;
            }

            while (j >= 0)
            {
                sNum3 += sNum2[j];
                j--;
            }

            string rev = "";
            for (i = sNum3.Length - 1; i >= 0; i--)
            {
                rev += sNum3[i];
            }

            return Convert.ToInt64(rev, 2).ToString();
        }
    }

    public string Xor(string sNum1, string sNum2)
    {

        checked
        {
            string sNum3 = "";
            sNum1 = ToBinary(sNum1);
            sNum2 = ToBinary(sNum2);

            int k = 0, i, j;
            for (i = sNum1.Length - 1, j = sNum2.Length - 1; i >= 0 && j >= 0; i--, j--, k++)
            {
                if (sNum1[i] == '1' && sNum2[j] == '0')
                {
                    sNum3 += '1';
                }
                else if (sNum1[i] == '0' && sNum2[j] == '1')
                {
                    sNum3 += '1';
                }
                else
                    sNum3 += '0';
            }

            while (i >= 0)
            {
                sNum3 += sNum1[i];
                i--;
            }

            while (j >= 0)
            {
                sNum3 += sNum2[j];
                j--;
            }

            string rev = "";
            for (i = sNum3.Length - 1; i >= 0; i--)
            {
                rev += sNum3[i];
            }

            return Convert.ToInt64(rev, 2).ToString();
        }
    }

    public string Not(string sNum1)
    {
        checked
        {
            string sNum2 = "";
            sNum1 = ToBinary(sNum1);

            int i;
            for (i = sNum1.Length - 1; i >= 0; i--)
            {
                if (sNum1[i] == '1')
                {
                    sNum2 += '0';
                }
                else
                    sNum2 += '1';
            }
            i = 63 - sNum1.Length;
            while (i >= 0)
            {
                sNum2 += '1';
                i--;
            }

            string rev = "";
            for (i = sNum2.Length - 1; i >= 0; i--)
            {
                rev += sNum2[i];
            }

            return Convert.ToInt64(rev, 2).ToString();
        }
    }

    public string Rsh(string sNum1, string sNo)
    {
        checked
        {
            string sNum2;
            int no = Convert.ToInt32(sNo);
            sNum1 = ToBinary(sNum1);
            int len = sNum1.Length - no;

            sNum2 = sNum1.Substring(0, len);

            return Convert.ToInt64(sNum2, 2).ToString();
        }
    }

    public string Lsh(string sNum1, string sNo)
    {
        checked
        {
            sNum1 = ToBinary(sNum1);
            int no = Convert.ToInt32(sNo);
            for (int i = 0; i < no; i++)
            {
                sNum1 += '0';
            }

            if (sNum1.Length >= 32)
            {
                sNum1 = sNum1.Substring(no - 1);
            }

            return Convert.ToInt64(sNum1, 2).ToString();
        }
    }
}
