using System;

namespace CalculatorApps01
{
    public  class SimpleCalculator
    {
        public IResultFormatter Formatter { get; set; }
        public IOutputPresenter Presenter { get; set; }
        public void Execute(int op1, string opr, int op2)
        {
            //STEP 1: calculate
            int result = Calculate(op1, opr, op2);
            //Step 2: format
            string output = Formatter.FormatResult(op1, opr, op2, result);

            //Step 3: calculate
            Presenter.Present(output);
        }

        public void Execute(int op1, IOperator opr, int op2)
        {
            //STEP 1: calculate
            //int result = Calculate(op1, opr, op2);
            int result = opr.Calculate(op1, op2);
            //Step 2: format
            string output = Formatter.FormatResult(op1, opr.GetType().Name, op2, result);

            //Step 3: calculate
            Presenter.Present(output);
        }

        private static int Calculate(int op1, string opr, int op2)
        {
            int result = 0;
            switch (opr)
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

            return result;
        }

        

 
    }
}