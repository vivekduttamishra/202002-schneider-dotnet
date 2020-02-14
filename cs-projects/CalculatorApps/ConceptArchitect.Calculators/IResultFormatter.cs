using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApps01
{
    public interface IResultFormatter
    {
        String FormatResult(int op1, string opr, int op2, int result);
    }

    public class InfixResultFormatter : IResultFormatter
    {
        public string FormatResult(int op1, string opr, int op2, int result)
        {
            return String.Format("{0} {1} {2} = {3}", op1, opr, op2, result);
        }
    }

    public class MethodStyleResultFormatter : IResultFormatter
    {
        public string FormatResult(int op1, string opr, int op2, int result)
        {
            return String.Format("{1}( {0}, {2}) => {3}", op1, opr, op2, result);
        }
    }
}
