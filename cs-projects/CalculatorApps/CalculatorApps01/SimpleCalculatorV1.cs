using System;

namespace CalculatorApps01
{
    internal class SimpleCalculatorV1
    {
        
        internal void Execute(int op1, string opr, int op2)
        {
            //STEP 1: calculate
            int result = 0;
            switch(opr)
            {
                case "plus":
                    result = op1 + op2;
                    break;
                case "minus":
                    result = op1 - op2;
                    break;
                case "multiply":
                    result = op1 * op2;
                    break;
                case "divide":
                    result = op1 / op2;
                    break;
                default:
                    break;
            }
            //Step 2: format
            var output = String.Format("{0} {1} {2} = {3}", op1, opr, op2, result);

            //Step 3: calculate
            Console.WriteLine(output);
        }
    }
}