using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApps01
{
   public delegate string ResultFormatter(int op1, string opr, int op2, int result);
    
    public class ResultFormatters
    { 
        public static string Infix(int op1, string opr, int op2, int result)
        {
            return String.Format("{0} {1} {2} = {3}", op1, opr, op2, result);
        }
        public static string MethodStyle(int op1, string opr, int op2, int result)
        {
            return String.Format("{1}( {0}, {2}) => {3}", op1, opr, op2, result);
        }
    }
}
