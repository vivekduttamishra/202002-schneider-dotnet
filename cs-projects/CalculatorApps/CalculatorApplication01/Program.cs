using System;

namespace CalculatorApps01
{
    class Program
    {
        /// <summary>
        /// Assignment
        /// 1. Execute should provide the output in format
        /// 2 plus 10 = 12
        /// 2 minus 1 = 1
        /// 
        /// Note:
        /// a. Execute returns nothing
        /// b. Second parameter can be any datatype of your choice
        /// c. should display calculated output
        /// d. should support atleast 4 basic operations + , - , * , /
        /// e. in future may support more operation like power, mod etc
        /// f. in future we may display the output on UI 
        /// g. in future we may print output differently like
        /// 
        /// plus(2,10) => 12
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var calc = new SimpleCalculator();
            calc.Formatter = new InfixResultFormatter();
            calc.Presenter = new SimpleConsolePresenter();


            TestCalculator(calc);

            calc.Formatter = new MethodStyleResultFormatter();
            TestCalculator(calc);

            calc.Presenter = new ColoredConsolePresenter(ConsoleColor.Yellow);
            TestCalculator(calc);
        }

        static  void TestCalculator(SimpleCalculator calc)
        {
            calc.Execute(40, new Plus(), 20);
            calc.Execute(40, new Minus(), 20);
            calc.Execute(40, new Multiply(), 20);
            calc.Execute(40, new Divide(), 20);
            calc.Execute(10, new MyCustomOperator(), 5);
        }


        class MyCustomOperator : IOperator
        {
            public int Calculate(int op1, int op2)
            {
                return (op1 + op2) / (op1 - op2);
            }
        }



        //private static void TestCalculator(SimpleCalculator calc)
        //{
        //    calc.Execute(2, "plus", 10);
        //    calc.Execute(2, "minus", 1);
        //    calc.Execute(20, "multiply", 40);
        //    calc.Execute(200, "divide", 40);
        //    Console.WriteLine();
        //}
    }
}
