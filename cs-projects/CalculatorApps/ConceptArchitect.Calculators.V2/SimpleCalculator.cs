using System;

namespace CalculatorApps01
{
    public  class SimpleCalculator
    {
        public ResultFormatter Formatter { get; set; }
        public OutputPresenter Presenter { get; set; }
     
        public void Execute(int op1, BinaryOperator opr, int op2)
        {
            //STEP 1: calculate
            int result = opr(op1, op2);
            //Step 2: format
            string output = Formatter(op1, opr.Method.Name, op2, result);

            //Step 3: calculate
            Presenter(output);
        }

        
 
    }
}